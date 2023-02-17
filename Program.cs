#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  Program.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ManagementStudio;
using System.Threading;
using Microsoft.Win32;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ManagementStudio
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CustomExceptionHandler eh = new CustomExceptionHandler();
            Application.ThreadException += new ThreadExceptionEventHandler(eh.OnThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                if (e.ExceptionObject != null && e.ExceptionObject is Exception)
                {
                    Exception ex = (Exception)e.ExceptionObject;
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    MessageBox.Show("Unhandled Exception Detected");
                }
            }
            catch
            {
            }
        }
    }

    public struct MENUINFO
    {
        public int cbSize;
        public uint fMask;
        public int dwStyle;
        public int cyMax;
        public int hbrBack;
        public int dwContextHelpID;
        public int dwMenuData;
    }

    public static class Win32
    {
        [DllImport("user32.dll")]
        public static extern int AppendMenu(IntPtr hMenu, int Flagsw, int IDNewItem, string lpNewItem);

        [DllImport("user32")]
        public static extern IntPtr GetSystemMenu(int hwnd, int bRevert);

        [DllImport("user32")]
        public static extern IntPtr GetMenu(int hwnd);

        [DllImport("user32")]
        public static extern int SetMenuInfo(IntPtr hMenu, ref MENUINFO mi);

        [DllImport("gdi32")]
        public static extern int CreatePatternBrush(int hBitmap);

        [DllImport("gdi32.dll")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, Boolean bRedraw);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);


    }

    public class ChangeSystemMenuColor
    {
        public static void SystemMenuColor(IntPtr Hwnd, Color color1, Color color2, int direct)
        {
            MENUINFO MENUINFO = new MENUINFO();
            MENUINFO.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(MENUINFO);
            MENUINFO.fMask = 2;

            Bitmap bmp = new Bitmap(200, 135);
            Brush b;
            Rectangle rrect = new Rectangle(20, 0, 140, 135);
            Graphics g = Graphics.FromImage(bmp);

            b = new System.Drawing.Drawing2D.LinearGradientBrush(rrect, color2, color1, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
            g.FillRectangle(b, rrect);
            b = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(20, 0, 10, 5), color1, color1, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
            g.FillRectangle(b, new Rectangle(20, 132, 3, 5));
            Pen lightPen = new Pen(Color.Red);
            g.FillRectangle(b, new Rectangle(0, 0, 20, 135));
            g.DrawLine(lightPen, new Point(20, 3), new Point(20, 131));
            g.DrawLine(lightPen, new Point(23, 132), new Point(23, 135));
            b.Dispose();
            lightPen.Dispose();
            g.Dispose();
            if (bmp == null)
                MENUINFO.hbrBack = 0;
            else
                MENUINFO.hbrBack = Win32.CreatePatternBrush((bmp.GetHbitmap()).ToInt32());
            try
            {
                Win32.SetMenuInfo(Win32.GetSystemMenu(Hwnd.ToInt32(), 0), ref MENUINFO);
            }
            catch
            {
            }

        }

    }

    public class Shared
    {
        //string SystemDatabase = System.Configuration.ConfigurationManager.ConnectionStrings["SystemDatabase"].ConnectionString;
        public static string SystemDatabase = "data source=(LOCAL);initial catalog=dbEmpSys;integrated security=SSPI;persist security info=False;packet size=4096";

        public static int CommandTimeout = 86400;
        public static int ReindexFillFactor = 0;

        //检测.NET是否安装


        public static bool CheckIfDotNetFrameworkInstalled(DotNetFrameworkVersion version)
        {
            return CheckIfDotNetFrameworkInstalled(version.ToString(), 0);
        }

        public static bool CheckIfDotNetFrameworkInstalled(string version)
        {
            return CheckIfDotNetFrameworkInstalled(version, 0);
        }

        public static bool CheckIfDotNetFrameworkInstalled(string version, int servicePack)
        {
            bool isInstalled = false;

            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(string.Format("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v{0}", version));
            if (registryKey != null)
            {
                if (Convert.ToInt32(registryKey.GetValue("Install", 0)) == 1)
                {
                    if (servicePack > 0)
                    {
                        if (Convert.ToInt32(registryKey.GetValue("SP", 0)) == servicePack)
                        {
                            isInstalled = true;
                        }
                    }
                    else
                    {
                        isInstalled = true;
                    }
                }
            }

            return isInstalled;
        }


        //设置程序开机自动运行
        public static void SetRegistryIsStart(bool IsStart)
        {
            if (IsStart)
            {
                try
                {
                    string strAssName = Application.StartupPath + @"\" + Application.ProductName + @".exe";
                    string ShortFileName = Application.ProductName;

                    RegistryKey rgkRun = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    if (rgkRun == null)
                    {
                        rgkRun = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                        rgkRun.SetValue(ShortFileName, strAssName);
                    }
                    else
                    {
                        rgkRun.SetValue(ShortFileName, strAssName);
                    }
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true).DeleteValue(Application.ProductName, false);
                }
                catch
                {

                }
            }
        }

    }
     
     public enum DotNetFrameworkVersion
     {
         Version10 = 0,
         Version11 = 1,
         Version20 = 2,
         Version30 = 3,
         Version35 = 4,
         Version40 = 5,
     }
    

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class FunctionCode : Attribute
    {
        private string _value;

        public string Value
        {
            get
            {
                return _value;
            }
        }

        public FunctionCode(string value)
        {
            _value = value;
        }
    }
}
