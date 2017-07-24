using System;
using System.Collections.Generic;
using System.Text;

namespace JMControlsEx
{
    public class JMTextBoxEx : JMControlsEx.JMTextBox
    {
        private const int WM_GETTEXT = 0x000d;
        private const int WM_COPY = 0x0301;
        private const int WM_PASTE = 0x0302;
        private const int WM_CONTEXTMENU = 0x007B;
        private const int WM_RBUTTONDOWN = 0x0204;

        public JMTextBoxEx()
        {
        }

        //protected override void WndProc(ref System.Windows.Forms.Message m)
        //{
        //    if (m.Msg == WM_RBUTTONDOWN /*|| m.Msg == WM_GETTEXT*/ || m.Msg == WM_COPY || m.Msg == WM_PASTE)
        //        return;//WM_RBUTTONDOWN是为了不让出现鼠标菜单 
        //    base.WndProc(ref m);
        //}
    }
}
