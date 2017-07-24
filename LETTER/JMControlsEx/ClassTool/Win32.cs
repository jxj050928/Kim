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
        /// ��ָ�����괦��������Ϊָ������ɫ
        /// </summary>
        /// <param name="hdc">���</param>
        /// <param name="X">����x����</param>
        /// <param name="Y">����y����</param>
        /// <param name="crColor">��ɫ</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern uint SetPixel(IntPtr hdc, int X, int Y, int crColor);
        #endregion

        #region user32
        /// <summary>
        /// �������
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
        /// ����й�ָ�����ڵ���Ϣ
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

        /// <summary>
        /// �ı�ָ�����ڵ�����
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

        //�ͷž��
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        #endregion

        #region winmm
        [DllImport("winmm.dll")]
        public static extern long sndPlaySound(string lpszSoundName, long uFlags);
        #endregion
    }
}
