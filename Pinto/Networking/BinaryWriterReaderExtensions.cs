﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PintoNS.Networking
{
    public static class BinaryWriterReaderExtensions
    {
        public const int USERNAME_MAX = 16;

        public static void WriteBE(this BinaryWriter writer, short value) 
        {
            writer.Write(IPAddress.HostToNetworkOrder(value));
        }

        public static void WriteBE(this BinaryWriter writer, int value)
        {
            writer.Write(IPAddress.HostToNetworkOrder(value));
        }

        public static void WritePintoString(this BinaryWriter writer, string str, int maxLength)
        {
            if (str.Length > maxLength)
                str = str.Substring(0, maxLength);
            byte[] stringData = Encoding.BigEndianUnicode.GetBytes(str);
            
            writer.WriteBE(stringData.Length);
            if (stringData.Length < 1) return;

            writer.Write(stringData);
        }

        public static short ReadBEShort(this BinaryReader reader)
        {
            return IPAddress.NetworkToHostOrder(reader.ReadInt16());
        }

        public static int ReadBEInt(this BinaryReader reader)
        {
            return IPAddress.NetworkToHostOrder(reader.ReadInt32());
        }

        public static string ReadPintoString(this BinaryReader reader, int maxLength)
        {
            int length = reader.ReadBEInt();
            if (length < 0) 
                throw new InvalidDataException("奇怪的字符串，长度小于0!");
            if (length < 1) return "";

            byte[] buffer = new byte[length];
            reader.Read(buffer, 0, length);

            string str = Encoding.BigEndianUnicode.GetString(buffer);
            if (str.Length > maxLength)
                throw new ArgumentException($"收到的数据超过了允许的范围 ({str.Length} > {maxLength})");

            return str;
        }
    }
}
