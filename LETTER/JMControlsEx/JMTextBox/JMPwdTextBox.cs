using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public partial class JMPwdTextBox : UserControl
    {
        public event JMDelegate.KeyPressEventHandler JMKeyPress;

        public event JMDelegate.ClickHandel JMPwdFindClick;

        bool bl = false;

        #region 属性
        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color _JMFrameLineColor;

        [Description("边框颜色"), DefaultValue(typeof(Color), "201,201,201")]
        public Color JMFrameLineColor
        {
            get { return _JMFrameLineColor; }
            set { _JMFrameLineColor = value; Invalidate(); }
        }

        private Color _JMEnterLineColor;

        [Description("编辑状态时边框颜色"), DefaultValue(typeof(Color), "79, 193, 233")]
        public Color JMEnterLineColor
        {
            get { return _JMEnterLineColor; }
            set { _JMEnterLineColor = value; }
        }

        private Image _JMEnterImage;

        [Description("编辑状态时显示图像"), DefaultValue(typeof(Image), "null")]
        public Image JMEnterImage
        {
            get { return _JMEnterImage; }
            set { _JMEnterImage = value; }
        }

        /// <summary>
        /// 显示图像
        /// </summary>
        private Image _JMImage;

        [Description("显示图像")]
        public Image JMImage
        {
            get { return _JMImage; }
            set { _JMImage = value; Invalidate(); }
        }

        /// <summary>
        /// 显示图像大小
        /// </summary>
        private Size _JMImgaeSize;

        [Description("显示图像大小")]
        public Size JMImgaeSize
        {
            get { return _JMImgaeSize; }
            set { _JMImgaeSize = value; Invalidate(); }
        }

        /// <summary>
        /// 显示图像坐标
        /// </summary>
        private Point _JMImageLocation;

        [Description("显示图像坐标")]
        public Point JMImageLocation
        {
            get { return _JMImageLocation; }
            set { _JMImageLocation = value; Invalidate(); }
        }

        [Description("显示值")]
        public string JMText
        {
            get { return jm_txt_Text.Text; }
            set { jm_txt_Text.Text = value; }
        }

        /// <summary>
        /// 显示值坐标
        /// </summary>
        private Point _JMTextBoxLocation;

        [Description("显示值坐标")]
        public Point JMTextBoxLocation
        {
            get { return _JMTextBoxLocation; }
            set { _JMTextBoxLocation = value; jm_txt_Text.Location = value; }
        }

        [Description("水印值")]
        public string JMTextTip
        {
            get { return jm_txt_Text.ZEmptyTextTip; }
            set { jm_txt_Text.ZEmptyTextTip = value; }
        }

        [Description("文本录入最大字符")]
        public int JMMaxLenght
        {
            get { return jm_txt_Text.MaxLen; }
            set { jm_txt_Text.MaxLen = value; }
        }

        [Description("密码显示方式")]
        public char JMPasswordChar
        {
            get { return jm_txt_Text.PasswordChar; }
            set { jm_txt_Text.PasswordChar = value; }
        }

        [Description("右侧按钮显示文本")]
        public string JMTextBoxLable
        {
            get { return jm_lb_PwdFind.Text; }
            set { jm_lb_PwdFind.Text = value; }
        }

        [Description("右侧按钮是否显示")]
        public bool JMTBLableVisible
        {
            get { return jm_lb_PwdFind.Visible; }
            set { jm_lb_PwdFind.Visible = value; }
        }

        [Description("右侧按钮显示颜色")]
        public Color JMTBLableColor
        {
            get { return jm_lb_PwdFind.ForeColor; }
            set { jm_lb_PwdFind.ForeColor = value; }
        }

        [Description("右侧按钮背影颜色")]
        public Color JMTBLableBlackColor
        {
            get { return jm_lb_PwdFind.BackColor; }
            set { jm_lb_PwdFind.BackColor = value; }
        }

        [Description("右侧按钮文本控件字体")]
        public Font JMTBLableFont
        {
            get { return jm_lb_PwdFind.Font; }
            set { jm_lb_PwdFind.Font = value; }
        }
        #endregion

        public JMPwdTextBox()
        {
            InitializeComponent();

            this.Size = new Size(158, 27);
            _JMFrameLineColor = Color.FromArgb(201, 201, 201);
            _JMEnterLineColor = Color.FromArgb(79, 193, 233);
            this.MinimumSize = new Size(212, 27);
            _JMImageLocation = new Point(10, 1);
            _JMTextBoxLocation = new Point(40, 5);
            _JMImgaeSize = new Size(20, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Image img = _JMImage;
            Color col = _JMFrameLineColor;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            GraphicsPath FW = GetGraphicPath.CreatePath(rect, 6, RoundStyle.None, true);

            //g.FillPath(new SolidBrush(Color.White), FW);
            if (bl)
            {
                img = _JMEnterImage;
                col = _JMEnterLineColor;
            }

            g.DrawPath(new Pen(col), FW);

            if (img != null)
            {
                Rectangle rec = new Rectangle(_JMImageLocation, _JMImgaeSize);
                g.DrawImage(img, rec);
            }
        }

        private void jm_txt_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (JMKeyPress != null)
            {
                JMKeyPress(sender, e);
            }
        }

        private void jm_lb_PwdFind_Click(object sender, EventArgs e)
        {
            if (JMPwdFindClick != null)
            {
                JMPwdFindClick();
            }
        }

        private void jm_txt_Text_Enter(object sender, EventArgs e)
        {
            bl = true;
            Invalidate();
        }

        private void jm_txt_Text_Leave(object sender, EventArgs e)
        {
            bl = false;
            Invalidate();
        }
    }
}
