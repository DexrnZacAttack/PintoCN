using PintoNS.Forms.Notification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PintoNS.Networking
{
    public class ConnectionException : Exception
    {
        public ConnectionException(string message) : base(message) { }
    }

    public class NetworkClient
    {
        private bool ignoreDisconnectReason;
        public bool IsConnected { get; private set; }
        private TcpClient tcpClient;
        private NetworkStream tcpStream;
        private Thread readThread;
        private Thread sendThread;
        public Action<string> Disconnected = delegate (string reason) { };
        public Action<IPacket> ReceivedPacket = delegate (IPacket packet) { };
        private object sendQueueLock = new object();
        private object sendQueueLock2 = new object();
        private LinkedList<IPacket> packetSendQueue = new LinkedList<IPacket>();
        private LinkedList<IPacket> packetSendQueue2 = new LinkedList<IPacket>();
        private bool flushingSendQueue;

        public async Task<(bool, Exception)> Connect(string ip, int port)
        {
            try
            {
                if (IsConnected) Disconnect("重新连接");
                ignoreDisconnectReason = false;

                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(ip, port);
                IsConnected = true;

                tcpStream = tcpClient.GetStream();
                readThread = new Thread(new ThreadStart(ReadThread_Func));
                readThread.Start();
                sendThread = new Thread(new ThreadStart(SendThread_Func));
                sendThread.Start();

                return (true, null);
            }
            catch (Exception ex)
            {
                Disconnect(null);
                return (false, ex);
            }
        }

        public void Disconnect(string reason)
        {
            bool ignoreDisconnectReasonValue = ignoreDisconnectReason;
            ignoreDisconnectReason = true;
            if (tcpStream != null) tcpStream.Dispose();
            if (tcpClient != null) tcpClient.Close();

            tcpClient = null;
            tcpStream = null;
            readThread = null;
            sendThread = null;

            if (IsConnected && !ignoreDisconnectReasonValue)
            {
                Disconnected.Invoke(reason);
            }
            IsConnected = false;
        }

        public void AddToSendQueue(IPacket packet)
        {
            if (!IsConnected) return;
            Program.Console.WriteMessage($"[Networking] 添加的数据包 {packet.GetType().Name.ToUpper()}" +
                $" ({packet.GetID()}) 到发送队列中");

            if (flushingSendQueue)
                lock (sendQueueLock2)
                    packetSendQueue2.AddLast(packet);
            else
                lock (sendQueueLock)
                    packetSendQueue.AddLast(packet);
        }

        public void ClearSendQueue()
        {
            lock (sendQueueLock)
                packetSendQueue.Clear();
            lock (sendQueueLock2)
                packetSendQueue2.Clear();
        }

        public void FlushSendQueue()
        {
            if (!IsConnected) return;
            flushingSendQueue = true;

            lock (sendQueueLock)
            {
                BinaryWriter writer = new BinaryWriter(tcpStream, Encoding.UTF8, true);
                foreach (IPacket packet in packetSendQueue.ToArray())
                {
                    try
                    {
                        if (!IsConnected) return;
                        if (packet == null) continue;
                        writer.Write((byte)packet.GetID());
                        packet.Write(writer);
                    }
                    catch (Exception ex)
                    {
                        Disconnect($"Internal error -> {ex.Message}");
                        Program.Console.WriteMessage($"[Networking]" +
                            $" 无法写入数据包 {packet.GetID()}: {ex}");
                        MsgBox.ShowNotification(null,
                        "发生了一个内部错误! 欲了解更多信息、" +
                        " 检查控制台（帮助>切换控制台）。",
                        "内部错误",
                            MsgBoxIconType.ERROR);
                    }
                }

                try
                {
                    writer.Flush();
                }
                catch (Exception ex)
                {
                    Disconnect($"Internal error -> {ex.Message}");
                    Program.Console.WriteMessage($"[Networking]" +
                        $" 无法发送数据包: {ex}");
                    MsgBox.ShowNotification(null,
                        "发生了一个内部错误! 欲了解更多信息、" +
                        " 检查控制台（帮助>切换控制台）。",
                        "内部错误",
                        MsgBoxIconType.ERROR);
                }
                packetSendQueue.Clear();
            }
            lock (sendQueueLock2)
                MergeSecondSendQueue();

            flushingSendQueue = false;
        }

        private void MergeSecondSendQueue()
        {
            lock (sendQueueLock2)
            {
                lock (sendQueueLock)
                {
                    foreach (IPacket packet in packetSendQueue2.ToArray())
                    {
                        packetSendQueue.AddLast(packet);
                    }
                }
                packetSendQueue2.Clear();
            }
        }

        private void ReadThread_Func()
        {
            while (IsConnected)
            {
                try
                {
                    int packetID = tcpStream.ReadByte();
                    IPacket packet = Packets.GetPacketByID(packetID);

                    if (packetID != -1)
                    {
                        if (packet != null)
                        {
                            BinaryReader reader = new BinaryReader(tcpStream, Encoding.UTF8, true);
                            packet.Read(reader);
                            reader.Dispose();
                            ReceivedPacket.Invoke(packet);
                        }
                        else
                        {
                            throw new ConnectionException("收到了无效的数据包 -> " + packetID);
                        }
                    }
                    else
                    {
                        throw new ConnectionException("服务器断开连接");
                    }

                    Thread.Sleep(1);
                }
                catch (Exception ex)
                {
                    if (!(ex is IOException || ex is ConnectionException))
                    {
                        Disconnect($"Internal error -> {ex.Message}");
                        Program.Console.WriteMessage($"Internal error: {ex}");
                        MsgBox.ShowNotification(null,
                        "发生了一个内部错误! 欲了解更多信息、" +
                        " 检查控制台（帮助>切换控制台）。",
                        "内部错误",
                            MsgBoxIconType.ERROR);
                    }
                    else
                    {
                        Disconnect(ex.Message);
                    }
                    return;
                }
            }
        }

        private void SendThread_Func()
        {
            while (IsConnected)
            {
                FlushSendQueue();
                Thread.Sleep(100);
            }
        }
    }
}
