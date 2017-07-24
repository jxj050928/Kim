using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace JMControlsEx
{
    public class JMDelegate
    {
        public delegate void ClickHandel();
        public delegate void ClickItemHandel(string _str);
        //public delegate void ClickSmallItemHandel(JDiarySmallItem sitem, string _str);
        public delegate void ClickDeleteHandel(string _str, string _str1);
        public delegate void EventHandle(string Text, string _KongZhi1, string _KongZhi2, string _KongZhi3);
        //public delegate void UpdateNodeHandel(JTreeNode tnode, string _str, string _str1);
        //public delegate void NodeBtnHandel(JTreeNodePlug tnode, string _key);
        public delegate void ClickEventHandle(string _str, string _str1, CancelEventArgs e);
        public delegate void DelItemEventHandle(object sender, CancelEventArgs e);
        public delegate void ImgEventHandle(string _BH, Image _Value, string _Hover);
        public delegate void IEventHandle(object sender, JEventargs e);
        public delegate void KeyPressEventHandler(object sender, KeyPressEventArgs e);

        public delegate void JTreeViewEventHandler(object sender, JTreeViewEventArgs e);
    }

    public class JTreeViewEventArgs : TreeViewEventArgs
    {

        public JTreeViewEventArgs(TreeNode node)
            : base(node)
        {

        }

        public bool Cancel
        {
            get;
            set;
        }

        public string NewText
        {
            get;
            set;
        }

        public string NewID
        {
            get;
            set;
        }
    }

    public class JEventargs : CancelEventArgs
    {
        public string Type
        {
            get;
            set;
        }

        public string Tag
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public Image Img
        {
            get;
            set;
        }
    }
}