using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class JMPanelComboBox : UserControl
    {
        public event JMDelegate.ClickHandel JMTZClick;

        public event JMDelegate.ClickHandel JMTitleClick;

        FrmSelectPanel frm = new FrmSelectPanel();

        public void Set_JMLoadUc(UserControl value)
        {
            frm.JMLoadUc = value;
        }

        #region 属性
        [Description("弹出下拉菜单时是否覆盖标题"), DefaultValue(typeof(bool), "true")]
        private bool _JMVisibleToDown;

        public bool JMVisibleToDown
        {
            get { return _JMVisibleToDown; }
            set { _JMVisibleToDown = value; }
        }

        [Description("是否启用自动隐藏"), DefaultValue(typeof(bool), "true")]
        public bool JMDeactivate
        {
            get { return frm.JMDeactivate; }
            set { frm.JMDeactivate = value; }
        }
        /// <summary>
        /// 下拉框是否左对齐
        /// </summary>
        private bool _JMDropDownLeft;

        [Description("下拉框是否左对齐"), DefaultValue(typeof(bool), "true")]
        public bool JMDropDownLeft
        {
            get { return _JMDropDownLeft; }
            set { _JMDropDownLeft = value; }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("边框颜色"), DefaultValue(typeof(Color), "Black")]
        public Color JMBorderLineColor
        {
            get { return jmPanel1.JMBorderLineColor; }
            set { jmPanel1.JMBorderLineColor = value; }
        }

        /// <summary>
        /// 是否显示边框
        /// </summary>
        [Description("是否显示边框"), DefaultValue(typeof(bool), "false")]
        public bool JMBorderStyle
        {
            get { return jmPanel1.JMBorderStyle; }
            set { jmPanel1.JMBorderStyle = value; }
        }

        /// <summary>
        /// 按钮圆角样式
        /// </summary>
        [Category("Appearance"), Description("按钮圆角样式"), DefaultValue(typeof(RoundStyle), "None")]
        public RoundStyle JMRoundStyle
        {
            get { return jmPanel1.JMRoundStyle; }
            set
            {
                if (jmPanel1.JMRoundStyle != value)
                {
                    jmPanel1.JMRoundStyle = value;
                }
            }
        }

        /// <summary>
        /// 按钮圆角弧度
        /// </summary>
        [Category("Appearance"), Description("按钮圆角弧度"), DefaultValue(8)]
        public int JMRadius
        {
            get { return jmPanel1.JMRadius; }
            set { jmPanel1.JMRadius = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        [Description("标题"), DefaultValue(typeof(string), "")]
        public string JMTitle
        {
            get { return jmPanel1.JMTitle; }
            set { jmPanel1.JMTitle = value; }
        }

        /// <summary>
        /// 标题颜色
        /// </summary>
        [Description("标题颜色"), DefaultValue(typeof(Color), "Black")]
        public Color JMTitleColor
        {
            get { return jmPanel1.JMTitleColor; }
            set { jmPanel1.JMTitleColor = value; }
        }

        /// <summary>
        /// 是否显示标题
        /// </summary>
        [Description("是否显示标题"), DefaultValue(typeof(bool), "false")]
        public bool JMTitleVisible
        {
            get { return jmPanel1.JMTitleVisible; }
            set { jmPanel1.JMTitleVisible = value; }
        }

        /// <summary>
        /// 标题坐标
        /// </summary>
        [Description("标题坐标"), DefaultValue(typeof(Point), "40,3")]
        public Point JMTitleLocation
        {
            get { return jmPanel1.JMTitleLocation; }
            set { jmPanel1.JMTitleLocation = value; }
        }

        /// <summary>
        /// 标题图像
        /// </summary>
        [Description("标题图像"), DefaultValue(typeof(Image), "null")]
        public Image JMTitleImage
        {
            get { return jmPanel1.JMTitleImage; }
            set { jmPanel1.JMTitleImage = value; }
        }

        /// <summary>
        /// 是否显示标题图像
        /// </summary>
        [Description("是否显示标题图像"), DefaultValue(typeof(bool), "false")]
        public bool JMTitleImageVisible
        {
            get { return jmPanel1.JMTitleImageVisible; }
            set { jmPanel1.JMTitleImageVisible = value; }
        }

        /// <summary>
        /// 标题图像坐标
        /// </summary>
        [Description("标题图像坐标"), DefaultValue(typeof(Point), "2,3")]
        public Point JMTiTleImageLocation
        {
            get { return jmPanel1.JMTiTleImageLocation; }
            set { jmPanel1.JMTiTleImageLocation = value; }
        }

        /// <summary>
        /// 标题图像大小
        /// </summary>
        [Description("标题图像大小"), DefaultValue(typeof(Size), "22,22")]
        public Size JMTitleImageSize
        {
            get { return jmPanel1.JMTitleImageSize; }
            set { jmPanel1.JMTitleImageSize = value; }
        }

        /// <summary>
        /// 标题跳转
        /// </summary>
        [Description("标题跳转"), DefaultValue(typeof(Image), "null")]
        public Image JMTitleTiaoZhuan
        {
            get { return jmPanel1.JMTitleTiaoZhuan; }
            set { jmPanel1.JMTitleTiaoZhuan = value; }
        }

        /// <summary>
        /// 是否显示标题跳转
        /// </summary>
        [Description("是否显示标题跳转"), DefaultValue(typeof(bool), "false")]
        public bool JMTitleTZVisible
        {
            get { return jmPanel1.JMTitleTZVisible; }
            set { jmPanel1.JMTitleTZVisible = value; }
        }

        /// <summary>
        /// 标题跳转大小
        /// </summary>
        [Description("标题跳转大小"), DefaultValue(typeof(Size), "22,22")]
        public Size JMTitleTZSize
        {
            get { return jmPanel1.JMTitleTZSize; }
            set { jmPanel1.JMTitleTZSize = value; }
        }

        /// <summary>
        /// 标题跳转坐标
        /// </summary>
        [Description("标题跳转坐标"), DefaultValue(typeof(Point), "100,3")]
        public Point JMTitleTZLocation
        {
            get { return jmPanel1.JMTitleTZLocation; }
            set { jmPanel1.JMTitleTZLocation = value; }
        }

        /// <summary>
        /// 控件内部间距离
        /// </summary>
        [Description("控件内部间距离"), DefaultValue(typeof(Point), "100,3")]
        public Padding JMPadding
        {
            get { return jmPanel1.Padding; }
            set { jmPanel1.Padding = value; }
        }
        #endregion

        public JMPanelComboBox()
        {
            InitializeComponent();
            _JMDropDownLeft = true;
            _JMVisibleToDown = true;
        }

        public void Fun_Load()
        {
            if (frm.Visible)
            {
                frm.Hide();
            }
            else
            {
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                Screen cre = Screen.PrimaryScreen;
                frm.Show();
                frm.Focus();
                int jheight = 0;
                if (!_JMVisibleToDown)
                {
                    jheight = this.Height;
                }
                if (_JMDropDownLeft)
                {
                    if (CBRect.X + frm.Width > cre.WorkingArea.Width)
                    {
                        frm.Location = new Point(CBRect.X - frm.Width + this.Width, CBRect.Y + jheight);
                    }
                    else
                    {
                        frm.Location = new Point(CBRect.X, CBRect.Y + jheight);
                    }
                }
                else
                {
                    frm.Location = new Point(CBRect.X + this.Width - frm.Width, CBRect.Y + jheight);
                }
            }
        }

        private void jmPanel1_JMTitleClick()
        {
            if (JMTitleClick != null)
            {
                JMTitleClick();
            }
        }

        private void jmPanel1_JMTZClick()
        {
            if (JMTZClick != null)
            {
                JMTZClick();
            }
        }
    }
}
