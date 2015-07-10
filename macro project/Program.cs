using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

/**
 * Stole some keylogging code from http://null-byte.wonderhowto.com/how-to/create-simple-hidden-console-keylogger-c-sharp-0132757/
 **/
namespace macro_project {

    static class Program {

        //private const int WH_KEYBOARD_LL = 13;
        //private const int WM_KEYDOWN = 0x0100;
        //private static LowLevelKeyboardProc _proc = HookCallback;
        //private static IntPtr _hookID = IntPtr.Zero;

        ////These Dll's will handle the hooks. Yaaar mateys!

        //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern IntPtr SetWindowsHookEx(int idHook,
        //    LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        //    IntPtr wParam, IntPtr lParam);

        //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern IntPtr GetModuleHandle(string lpModuleName);

        //// The two dll imports below will handle the window hiding.

        ////[DllImport("kernel32.dll")]
        ////static extern IntPtr GetConsoleWindow();

        ////[DllImport("user32.dll")]
        ////static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        ////const int SW_HIDE = 0;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //Form1 view = new Form1();
            //view.ShowDialog();

            Form1 view = new Form1();
            //view.ShowDialog();

            ////-------Keylogging stuff------------

            ////var handle = GetConsoleWindow();

            ////// Hide
            ////ShowWindow(handle, SW_HIDE);

            ////These lines are neccesary for the printing of keys pressed to the console
            //_hookID = SetHook(_proc);
            //Application.Run(view);
            //UnhookWindowsHookEx(_hookID);

            ////-------End Keylogging stuff------------
        }

        //private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        //private static IntPtr HookCallback(
        //    int nCode, IntPtr wParam, IntPtr lParam) {
        //    if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN) {
        //        int vkCode = Marshal.ReadInt32(lParam);
        //        Console.WriteLine((Keys) vkCode);
                
        //        //StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
        //        //sw.Write((Keys) vkCode);
        //        //sw.Close();

        //    }
        //    return CallNextHookEx(_hookID, nCode, wParam, lParam);
        //}

        //private static IntPtr SetHook(LowLevelKeyboardProc proc) {
        //    using (Process curProcess = Process.GetCurrentProcess())
        //    using (ProcessModule curModule = curProcess.MainModule) {
        //        return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
        //        GetModuleHandle(curModule.ModuleName), 0);
        //    }
        //}
    }
}
