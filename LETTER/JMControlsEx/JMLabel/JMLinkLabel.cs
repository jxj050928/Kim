using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public class JMLinkLabel:LinkLabel
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (!string.IsNullOrEmpty(_url))
            {
                try
                {
                    System.Diagnostics.Process.Start(_url);
                }
                catch
                { }
            }
        }
    }
}
