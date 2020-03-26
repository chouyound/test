using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Baymax;
using MyDm;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace MyContent
{
    [Description("王城争霸超V版脚本1.0")]
    public partial class Program : IContent
    {
        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
        }

        private delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);

        //用来遍历所有窗口 
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, int lParam);

        //获取窗口Text 
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        //获取窗口类名 
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        public WindowInfo[] GetAllDesktopWindows()
        {
            //用来保存窗口对象 列表
            List<WindowInfo> wndList = new List<WindowInfo>();

            WNDENUMPROC pro = delegate(IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);

                //get hwnd 
                wnd.hWnd = hWnd;

                //get window name  
                GetWindowTextW(hWnd, sb, sb.Capacity);
                wnd.szWindowName = sb.ToString();

                //get window class 
                GetClassNameW(hWnd, sb, sb.Capacity);
                wnd.szClassName = sb.ToString();

                //add it into list 
                wndList.Add(wnd);
                return true;
            };

            //enum all desktop windows 
            EnumWindows(pro, 0);

            return wndList.ToArray();
        }

        public void Main(string[] args)
        {
            var list = GetAllDesktopWindows();
            foreach (var item in list)
            {
                Controller.ViewPrintLine("标题为{0},句柄为{1}",item.szWindowName,item.hWnd);
            }
        }

    }


}

