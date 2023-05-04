using PintoNS.Forms.Notification;
using PintoNS.General;
using PintoNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace PintoNS.Forms
{
    public partial class MessageForm : Form
    {
        private MainForm mainForm;
        public Contact Receiver;
        private bool isTypingLastStatus;
        public bool HasBeenInactive;
        public InWindowPopupController InWindowPopupController;

        public MessageForm(MainForm mainForm, Contact receiver)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            InWindowPopupController = new InWindowPopupController(this, 25);
            Receiver = receiver;
            Text = $"Pinto! - 即时通讯 - 你正在与人聊天 {Receiver.Name}";
            UpdateColorPicker();
            LoadChat();
        }

        private void LoadChat()
        {
            Program.Console.WriteMessage("[General] 正在加载聊天...");
            try
            {
                string filePath = Path.Combine(mainForm.DataFolder, "chats",  $"{Receiver.Name}.txt");
                if (!File.Exists(filePath)) return;
                rtxtMessages.Rtf = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Program.Console.WriteMessage($"[General]" +
                    $" 无法加载聊天记录： {ex}");
                MsgBox.ShowNotification(this,
                    "无法加载聊天记录!",
                    "误差", MsgBoxIconType.ERROR);
            }
        }

        private void SaveChat()
        {
            Program.Console.WriteMessage("[General] 保存聊天记录...");
            try
            {
                string filePath = Path.Combine(mainForm.DataFolder, "chats", $"{Receiver.Name}.txt");
                File.WriteAllText(filePath, rtxtMessages.Rtf);
            }
            catch (Exception ex)
            {
                Program.Console.WriteMessage($"[General]" +
                    $" 无法保存聊天记录： {ex}");
                MsgBox.ShowNotification(this,
                    "无法保存聊天记录",
                    "误差", MsgBoxIconType.ERROR);
            }
        }

        private void DeleteChat() 
        {
            Program.Console.WriteMessage("[General] 删除聊天...");
            try
            {
                string filePath = Path.Combine(mainForm.DataFolder, "chats", $"{Receiver.Name}.txt");
                if (!File.Exists(filePath)) return;
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                Program.Console.WriteMessage($"[General]" +
                    $" 无法删除聊天记录： {ex}");
                MsgBox.ShowNotification(this,
                    "无法删除聊天记录",
                    "误差", MsgBoxIconType.ERROR);
            }
        }

        public void WriteMessage(string msg, Color color, bool newLine = true)
        {
            Invoke(new Action(() =>
            {
                rtxtMessages.SelectionStart = rtxtMessages.TextLength;
                rtxtMessages.SelectionLength = 0;
                rtxtMessages.SelectionColor = color;
                rtxtMessages.AppendText(msg + (newLine ? Environment.NewLine : ""));
                rtxtMessages.SelectionColor = rtxtMessages.ForeColor;
                SaveChat();
            }));
        }

        public void WriteRTF(string msg) 
        {
            Invoke(new Action(() => 
            {
                rtxtMessages.SelectionStart = rtxtMessages.TextLength;
                rtxtMessages.SelectionLength = 0;
                rtxtMessages.SelectionColor = Color.Black;
                try
                {
                    rtxtMessages.SelectedRtf = msg;
                }
                catch 
                { 
                    WriteMessage("** 格式不当的信息 **", Color.Red); 
                }
                SaveChat();
            }));
        }

        public void UpdateColorPicker() 
        {
            Bitmap b = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(new SolidBrush(rtxtInput.SelectionColor), 0, 0, 16, 16);
            btnColor.Image = b;
        }

        private void rtxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Keyboard.Modifiers.HasFlag(System.Windows
                .Input.ModifierKeys.Control) && e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void rtxtMessages_TextChanged(object sender, EventArgs e)
        {
            rtxtMessages.SelectionStart = rtxtMessages.Text.Length;
            rtxtMessages.ScrollToCaret();
        }

        private void rtxtInput_TextChanged(object sender, EventArgs e)
        {
            if (mainForm.NetManager == null) return;
            string text = rtxtInput.Text;

            if (!string.IsNullOrWhiteSpace(text) && !isTypingLastStatus)
            {
                isTypingLastStatus = true;
                //mainForm.NetManager.NetHandler.SendTypingPacket(Receiver.Name, true);
            }
            else if (string.IsNullOrWhiteSpace(text) && isTypingLastStatus)
            {
                isTypingLastStatus = false;
                //mainForm.NetManager.NetHandler.SendTypingPacket(Receiver.Name, false);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = rtxtInput.Rtf;
            string inputStripped = rtxtInput.Text;

            if (string.IsNullOrWhiteSpace(inputStripped))
            {
                MsgBox.ShowNotification(this, "指定的信息是无效的!", "误差", 
                    MsgBoxIconType.ERROR);
                return;
            }

            rtxtInput.Clear();
            if (mainForm.NetManager != null) 
            {
                mainForm.NetManager.NetHandler.SendMessagePacket(Receiver.Name, input);
            }
        }

        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainForm.MessageForms != null)
                mainForm.MessageForms.Remove(this);
        }

        private void tsmiMenuBarHelpAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog(this);
        }

        private void MessageForm_Activated(object sender, EventArgs e)
        {
            HasBeenInactive = false;
        }

        private void rtxtMessages_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void btnTalk_Click(object sender, EventArgs e)
        {
            MsgBox.ShowNotification(this,
                "这个功能在这个版本中是不可用的!",
                "尚未实施",
                MsgBoxIconType.WARNING);
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            MsgBox.ShowNotification(this,
                "这个功能在这个版本中是不可用的!",
                "尚未实施",
                MsgBoxIconType.WARNING);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            cdPicker.ShowDialog();
            rtxtInput.SelectionColor = cdPicker.Color;
            UpdateColorPicker();
        }

        private void rtxtInput_SelectionChanged(object sender, EventArgs e)
        {
            UpdateColorPicker();
        }

        private void tsmiMenuBarFileClearSavedData_Click(object sender, EventArgs e)
        {
            rtxtMessages.Rtf = null;
            DeleteChat();
        }
    }
}
