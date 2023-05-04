using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PintoNS.General
{
    public class User
    {
        public string Name;
        public UserStatus Status;

        public static Bitmap StatusToBitmap(UserStatus status) 
        {
            switch (status) 
            {
                case UserStatus.ONLINE:
                    return Statuses.ONLINE;
                case UserStatus.AWAY:
                    return Statuses.AWAY;
                case UserStatus.BUSY: 
                    return Statuses.BUSY;
                case UserStatus.INVISIBLE: 
                    return Statuses.INVISIBLE;
                default:
                    return Statuses.OFFLINE;
            }
        }

        public static Icon StatusToIcon(UserStatus status)
        {
            switch (status)
            {
                case UserStatus.ONLINE:
                    return Statuses.ONLINE1;
                case UserStatus.AWAY:
                    return Statuses.AWAY1;
                case UserStatus.BUSY:
                    return Statuses.BUSY1;
                case UserStatus.INVISIBLE:
                    return Statuses.INVISIBLE1;
                default:
                    return Statuses.OFFLINE1;
            }
        }

        public static string StatusToText(UserStatus status)
        {
            switch (status)
            {
                case UserStatus.ONLINE:
                    return "在线的";
                case UserStatus.AWAY:
                    return "离开";
                case UserStatus.BUSY:
                    return "忙碌的";
                case UserStatus.INVISIBLE:
                    return "无形的";
                default:
                    return "在线的";
            }
        }
    }
}
