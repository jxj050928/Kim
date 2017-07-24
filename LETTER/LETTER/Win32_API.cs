using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LETTER
{
    public class Win32_API
    {
        //释放内存 
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        [DllImport("kernel32.dll")]
        public static extern int GetLastError();

        [DllImport("advapi32.dll")]
        public static extern int DeleteService(IntPtr SVHANDLE);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern IntPtr OpenService(IntPtr SCHANDLE, string lpSvcName, int dwNumServiceArgs);


        [DllImport("advapi32.dll")]
        public static extern int StartService(IntPtr SVHANDLE, int dwNumServiceArgs, string lpServiceArgVectors);

        [DllImport("advapi32.dll")]
        public static extern void CloseServiceHandle(IntPtr SCHANDLE);

        [DllImport("Advapi32.dll")]
        public static extern IntPtr CreateService(IntPtr SC_HANDLE, string lpSvcName, string lpDisplayName,
         int dwDesiredAccess, int dwServiceType, int dwStartType, int dwErrorControl, string lpPathName,
         string lpLoadOrderGroup, int lpdwTagId, string lpDependencies, string lpServiceStartName, string lpPassword);


        [DllImport("advapi32.dll")]
        public static extern IntPtr OpenSCManager(string lpMachineName, string lpSCDB, int scParameter);


        [DllImport("user32")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// 窗体弹出方式
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="stime"></param>
        /// <param name="style"></param>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void AnimateWindow(IntPtr hwnd, int stime, int style);

        /// <summary>
        /// 判断是否有网
        /// </summary>
        /// <param name="dwFlag"></param>
        /// <param name="dwReserved"></param>
        /// <returns></returns>
        [DllImport("winInet.dll")]
        public static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);

        /// <summary>
        /// 该函数改变一个子窗口，弹出式窗口式顶层窗口的尺寸，位置和Z序。
        /// 子窗口，弹出式窗口，及顶层窗口根据它们在屏幕上出现的顺序排序、
        /// 顶层窗口设置的级别最高，并且被设置为Z序的第一个窗口
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="x">坐标</param>
        /// <param name="y">坐标</param>
        /// <param name="cx">宽</param>
        /// <param name="cy">高</param>
        /// <param name="wFlags"></param>
        /// <returns>0失败 非0成功</returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        /// <summary>
        /// 激活窗体
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        /// <summary>
        /// 显示隐藏窗体
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="nCmdShow">显示隐藏(0,1)</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 查找窗体
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName">窗口名称</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}
