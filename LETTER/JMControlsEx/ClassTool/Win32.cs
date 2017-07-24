using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace JMControlsEx
{
	/// <summary>
	/// Win32 API
	/// </summary>
	public class Win32
    {
        #region gdi32

        /// <summary>
        /// 将指定坐标处的像素设为指定的颜色
        /// </summary>
        /// <param name="hdc">句柄</param>
        /// <param name="X">像素x坐标</param>
        /// <param name="Y">像素y坐标</param>
        /// <param name="crColor">颜色</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern uint SetPixel(IntPtr hdc, int X, int Y, int crColor);
        #endregion

        #region user32
        /// <summary>
        /// 操作鼠标
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="cButtons"></param>
        /// <param name="dwExtraInfo"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        /// <summary>
        /// 获得有关指定窗口的信息
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        /// <summary>
        /// 改变指定窗口的属性
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32")]
        public static extern bool ReleaseCapture();

        [DllImport("user32")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);

        [DllImport("user32.dll")]
        public static extern int ShowScrollBar(IntPtr hWnd, int iBar, int bShow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        //释放句柄
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        #endregion

        #region winmm
        [DllImport("winmm.dll")]
        public static extern long sndPlaySound(string lpszSoundName, long uFlags);
        #endregion
    }
}
