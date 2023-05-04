using PintoNS.Forms;
using PintoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using PintoNS.Forms.Notification;

namespace PintoNS
{
    public static class Program
    {
        [DllImport("ntdll.dll", EntryPoint = "wine_get_version")]
        private static extern string GetWineVersion();
        public static ConsoleForm Console;
        public const string VERSION = "a1.3";
        public const int PROTOCOL_VERSION = 13;

        [STAThread]
        static void Main()
        {
            // Enable visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Unhandled exception handler
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Setup console
            Console = new ConsoleForm();
            Console.Show();

            // Detect what runtime we are being ran under
            bool underWine = false;
            try
            {
                string wineVer = GetWineVersion();
                Console.WriteMessage($"[General] 在Wine下运行 ({wineVer})");
                underWine = true;
            }
            catch (Exception ex)
            {
                Console.WriteMessage($"[General] 不能在Wine下运行： {ex}");
            }

            if (Type.GetType("Mono.Runtime") != null) 
            {
                Console.WriteMessage("[General] 在Mono下运行");

                if (!underWine) 
                {
                    MsgBox.ShowNotification(Console,
                        $"Pinto！检测到当前正在 Mono 下运行" +
                        $" 而不是在 Wine 下运行！{Environment.NewLine}" +
                        $"该运行环境不受支持！",
                        "不支持的运行环境",
                        MsgBoxIconType.ERROR);
                    return;
                }
            }

            // Start Pinto!
            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            UnhandledExceptionHandler(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            UnhandledExceptionHandler(e.ExceptionObject);
        }

        private static void UnhandledExceptionHandler(object ex) 
        {
            FatalErrorForm fatalErrorForm = new FatalErrorForm();
            fatalErrorForm.rtxtLog.Text = $"{ex}";
            fatalErrorForm.ShowDialog();
            Environment.Exit(0);
        }
    }
}
