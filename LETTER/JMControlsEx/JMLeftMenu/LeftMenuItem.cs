using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace JMControlsEx
{
    public class LeftMenuItem
    {
        private LeftMenu owner;

        public LeftMenu Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        #region 构造函数
        public LeftMenuItem(LeftMenu c)
        {
            owner = c;
        }

        public LeftMenuItem()
        {

        }
        #endregion

        //图片(标题图片)
        private Image ButtonImage;
        //账户名(标题)
        private string sText = "";
        //数量(简介)
        private string sTextContent = "";

        private bool bHovering = false;
        private bool bMouseDown = false;
        private bool bDisabled = false;
        private bool bChecked = false;
        private Object Tag = null;

        public string Text
        {
            get
            {
                return this.sText;
            }
            set
            {
                this.sText = value;
                if (owner != null) owner.Invalidate();
            }
        }
        public string Description
        {
            get
            {
                return this.sTextContent;
            }
            set
            {
                this.sTextContent = value;
                if (owner != null) owner.Invalidate();
            }
        }


        public Image Image
        {
            get
            {
                return this.ButtonImage;
            }
            set
            {

                this.ButtonImage = value;
                if (owner != null) owner.Invalidate();
            }
        }

        public bool Hovering
        {
            get
            {
                return bHovering;
            }
            set
            {
                this.bHovering = value;
            }
        }

        public bool MouseDown
        {
            get
            {
                return bMouseDown;
            }
            set
            {
                this.bMouseDown = value;
            }
        }

        public bool Disabled
        {
            get
            {
                return bDisabled;
            }
            set
            {
                this.bDisabled = value;
            }
        }

        public Object ItemTag
        {
            get
            {
                return this.Tag;
            }
            set
            {
                this.Tag = value;
            }
        }

        public bool Checked
        {
            get
            {
                return bChecked;
            }
            set
            {
                this.bChecked = value;
            }
        }
    }
}
