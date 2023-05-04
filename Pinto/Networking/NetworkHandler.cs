using PintoNS.Forms;
using PintoNS.Forms.Notification;
using PintoNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
using PintoNS.General;
using System.Media;
using System.Net;
using Newtonsoft.Json.Linq;

namespace PintoNS.Networking
{
    public class NetworkHandler
    {
        private MainForm mainForm;
        private NetworkClient networkClient;
        public bool LoggedIn;

        public NetworkHandler(MainForm mainForm, NetworkClient networkClient)
        {
            this.mainForm = mainForm;
            this.networkClient = networkClient;
        }

        public void HandlePacket(IPacket packet) 
        {
            if (packet.GetID() != 255)
                Program.Console.WriteMessage($"[联网] 收到的数据包 {packet.GetType().Name.ToUpper()}" +
                    $" ({packet.GetID()})");
            packet.Handle(this);
        }
        
        public void HandleLoginPacket(PacketLogin packet) 
        {
            LoggedIn = true;
            mainForm.Invoke(new Action(() => 
            {
                mainForm.OnLogin();
            }));
        }

        public void HandleLogoutPacket(PacketLogout packet)
        {
            mainForm.NetManager.IsActive = false;
            Program.Console.WriteMessage($"[联网] 被服务器踢了： {packet.Reason}");
            mainForm.NetManager.NetClient.Disconnect($"被服务器踢了 -> {packet.Reason}");
            mainForm.Invoke(new Action(() =>
            {
                MsgBox.ShowNotification(mainForm, packet.Reason, "被服务器踢了", 
                    MsgBoxIconType.WARNING, true);
            }));
        }

        public void HandleMessagePacket(PacketMessage packet) 
        {
            mainForm.Invoke(new Action(() =>
            {
                MessageForm messageForm = mainForm.GetMessageFormFromReceiverName(packet.ContactName);
                if (messageForm == null) 
                {
                    Program.Console.WriteMessage($"[联网]" +
                        $" 无法得到一个信息表格，用于 {packet.ContactName}!");
                    return;
                }

                if (packet.Sender.Trim().Length > 0)
                    messageForm.WriteMessage($"{packet.Sender}: ", Color.Black, false);
                if (packet.Message.StartsWith(@"{\rtf"))
                    messageForm.WriteRTF(packet.Message);
                else
                    messageForm.WriteMessage(packet.Message, Color.Black);

                if (Form.ActiveForm != messageForm && !messageForm.HasBeenInactive)
                {
                    messageForm.HasBeenInactive = true;
                    mainForm.PopupController.CreatePopup($"收到一个新消息，来自 {packet.ContactName}!",
                        "新消息");
                    new SoundPlayer() { Stream = Sounds.IM }.Play();
                }
            }));
        }

        public void HandleInWindowPopupPacket(PacketInWindowPopup packet)
        {
            mainForm.Invoke(new Action(() =>
            {
                mainForm.InWindowPopupController.CreatePopup(packet.Message);
            }));
        }

        public void HandleAddContactPacket(PacketAddContact packet)
        {
            Program.Console.WriteMessage($"[联系人] 添加 {packet.ContactName} 到联系人列表中...");
            mainForm.Invoke(new Action(() =>
            {
                mainForm.ContactsMgr.AddContact(new Contact() { Name = packet.ContactName, Status = packet.Status });
            }));
        }

        public void HandleRemoveContactPacket(PacketRemoveContact packet)
        {
            Program.Console.WriteMessage($"[联系人] 移除 {packet.ContactName} 从联系人列表中...");
            mainForm.Invoke(new Action(() =>
            {
                mainForm.ContactsMgr.RemoveContact(mainForm.ContactsMgr.GetContact(packet.ContactName));
            }));
        }

        public void HandleStatusPacket(PacketStatus packet)
        {
            Program.Console.WriteMessage(
                $"[一般] 状态改变： " +
                $"{(string.IsNullOrWhiteSpace(packet.ContactName) ? "SELF" : packet.ContactName)} -> {packet.Status}");
            
            mainForm.Invoke(new Action(() =>
            {
                if (string.IsNullOrWhiteSpace(packet.ContactName))
                    mainForm.OnStatusChange(packet.Status);
                else
                {
                    Contact contact = mainForm.ContactsMgr.GetContact(packet.ContactName);

                    if (contact == null) 
                    {
                        Program.Console.WriteMessage($"[一般] 收到无效的状态变化" +
                            $", \"{packet.ContactName}\" 不是一个有效的联系人!");
                        return;
                    }

                    if (packet.Status == UserStatus.OFFLINE && contact.Status != UserStatus.OFFLINE)
                    {
                        mainForm.PopupController.CreatePopup($"{packet.ContactName} 现已下线",
                            "状态变化");
                        new SoundPlayer() { Stream = Sounds.OFFLINE }.Play();
                    }
                    else if (packet.Status != UserStatus.OFFLINE && contact.Status == UserStatus.OFFLINE)
                    {
                        mainForm.PopupController.CreatePopup($"{packet.ContactName} 现已上线",
                            "状态变化");
                        new SoundPlayer() { Stream = Sounds.ONLINE }.Play();
                    }

                    mainForm.ContactsMgr.UpdateContact(new Contact() { Name = packet.ContactName, Status = packet.Status });
                }
            }));
        }

        public void HandleContactRequestPacket(PacketContactRequest packet)
        {
            Program.Console.WriteMessage($"[联网] 收到了以下的联系请求 {packet.ContactName}");
            mainForm.Invoke(new Action(() =>
            {
                MsgBox.ShowPromptNotification(mainForm,
                    $"{packet.ContactName} 想把你加入他们的联系名单。继续？", "联系请求",
                    MsgBoxIconType.QUESTION, true,
                    (MsgBoxButtonType button) =>
                    {
                        SendContactRequestPacket(packet.ContactName, button == MsgBoxButtonType.YES);
                    });
            }));
        }

        public void HandleClearContactsPacket()
        {
            Program.Console.WriteMessage($"[联系人] 清除联系人名单...");
            mainForm.Invoke(new Action(() =>
            {
                mainForm.dgvContacts.Rows.Clear();
                mainForm.ContactsMgr = new ContactsManager(mainForm);
            }));
        }

        public void SendLoginPacket(byte protocolVersion, string clientVersion, 
            string name, string sessionID) 
        {
            networkClient.AddToSendQueue(new PacketLogin(protocolVersion, clientVersion, name, sessionID));
        }

        public void SendRegisterPacket(byte protocolVersion, string clientVersion, 
            string name, string sessionID)
        {
            networkClient.AddToSendQueue(new PacketRegister(protocolVersion, clientVersion, name, sessionID));
        }

        public void SendMessagePacket(string contactName, string message)
        {
            networkClient.AddToSendQueue(new PacketMessage(contactName, message));
        }

        public void SendStatusPacket(UserStatus status)
        {
            networkClient.AddToSendQueue(new PacketStatus("", status));
        }

        public void SendContactRequestPacket(string name, bool approved)
        {
            networkClient.AddToSendQueue(new PacketContactRequest($"{name}:{(approved ? "是的" : "不是")}"));
        }

        public void SendAddContactPacket(string name)
        {
            networkClient.AddToSendQueue(new PacketAddContact(name, UserStatus.OFFLINE));
        }

        public void SendRemoveContactPacket(string name)
        {
            networkClient.AddToSendQueue(new PacketRemoveContact(name));
        }
    }
}
