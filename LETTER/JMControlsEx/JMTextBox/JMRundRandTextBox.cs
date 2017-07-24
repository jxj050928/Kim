using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JMRundRandTextBox : Panel
    {
        public event KeyPressEventHandler JKeyPress;

        public event JMDelegate.ClickHandel JMClickEnter;

        JMTextBox jmtb;

        /// <summary>
        /// TextBox的X轴坐标
        /// </summary>
        int XZhou = 8;

        /// <summary>
        /// TextBox的Y轴坐标
        /// </summary>
        int YZhou = 5;

        #region 属性

        public char PassWordChar
        {
            get { return jmtb.PasswordChar; }
            set { jmtb.PasswordChar = value; }
        }

        [Description("文本是否能跨越多行"), DefaultValue(typeof(bool), "false")]
        public bool AMultiline
        {
            get { return jmtb.Multiline; }
            set
            {
                jmtb.Multiline = value;
                if (!jmtb.Multiline)
                {
                    this.Height = this.MinimumSize.Height;
                }
            }
        }

        [Description("显示方式"), DefaultValue(typeof(JMDataType), "NONE")]
        public JMDataType ZType
        {
            get { return jmtb.ZDtype; }
            set { jmtb.ZDtype = value; }
        }

        [Description("水印显示文字"), DefaultValue("--请输入--")]
        public string ZEmptyTextTip
        {
            get { return jmtb.ZEmptyTextTip; }
            set { jmtb.ZEmptyTextTip = value; }
        }

        [Description("水印显示文字颜色"), DefaultValue(typeof(Color), "DarkGray")]
        public Color ZEmptyTextTipColor
        {
            get { return jmtb.ZEmptyTextTipColor; }
            set { jmtb.ZEmptyTextTipColor = value; }
        }

        [Description("日期格式"), DefaultValue(typeof(bool), "yyyy-MM-dd")]
        public string ZFormat
        {
            get { return jmtb.ZFormat; }
            set { jmtb.ZFormat = value; }
        }

        [Description("小数位数"), DefaultValue(typeof(int), "0")]
        public int ZMedian
        {
            get { return jmtb.ZMedian; }
            set { jmtb.ZMedian = value; }
        }

        [Description("启用负数"), DefaultValue(typeof(bool), "false")]
        public bool ZNegative
        {
            get { return jmtb.ZNegative; }
            set { jmtb.ZNegative = value; }
        }

        [Description("文本框类型"), DefaultValue(typeof(TextStyle), "Rec")]
        public TextStyle ZShowStyle
        {
            get { return jmtb.ZShowStyle; }
            set { jmtb.ZShowStyle = value; }
        }

        [Description("显示文字"), DefaultValue(typeof(TextStyle), "")]
        public string ZText
        {
            get { return jmtb.Text; }
            set { jmtb.Text = value; }
        }

        [Description("编辑时最大字符"), DefaultValue(typeof(int), "30")]
        public int ZMaxLen
        {
            get { return jmtb.MaxLen; }
            set { jmtb.MaxLen = value; }
        }

        [Description("编辑时最大字符"), DefaultValue(typeof(int), "32767")]
        public int ZMaxLength
        {
            get { return jmtb.MaxLength; }
            set { jmtb.MaxLength = value; }
        }

        [Description("显示文字")]
        public Font ZFont
        {
            get { return jmtb.Font; }
            set { jmtb.Font = value; }
        }

        /// <summary>
        /// 圆角弧度
        /// </summary>
        private int _ZRadian;

        [Description("圆角弧度"), DefaultValue(typeof(int), "23")]
        public int ZRadian
        {
            get { return _ZRadian; }
            set { _ZRadian = value; Invalidate(); }
        }

        private Color _borderColor;

        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        [Description("是否可编辑"), DefaultValue(typeof(bool), "false")]
        public bool ZReadOnly
        {
            get { return jmtb.ReadOnly; }
            set { jmtb.ReadOnly = value; }
        }

        [Description("是否可编辑"), DefaultValue(typeof(Color), "236, 233, 216")]
        public Color ZBlackColor
        {
            get { return jmtb.ZBlackColor; }
            set { jmtb.ZBlackColor = value; }
        }
        #endregion

        public JMRundRandTextBox()
        {
            jmtb = new JMTextBox();
            jmtb.Name = "jmTextBox1";
            jmtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            jmtb.BorderStyle = BorderStyle.None;
            jmtb.Location = new Point(XZhou, YZhou);
            jmtb.ZBorderColor = Color.White;
            jmtb.KeyPress += new KeyPressEventHandler(jmtb_KeyPress);
            jmtb.SizeChanged += new EventHandler(jmtb_SizeChanged);
            this.Controls.Add(jmtb);

            jmtb.Width = this.Width - 16;

            this.Size = new Size(110, 23);
            this.MinimumSize = new Size(110, 23);
            this.BackColor = Color.Transparent;
            _ZRadian = 23;
            _borderColor = Color.FromArgb(170, 170, 170);
        }

        /// <summary>
        /// TextBox大小更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jmtb_SizeChanged(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(this.MinimumSize.Width, jmtb.Height + 5 + 4);
            this.Size = new Size(this.Size.Width, jmtb.Height + 5 + 4);
            jmtb.Location = new Point(XZhou, YZhou);
            jmtb.Width = this.Width - 16;
            Invalidate();
        }

        /// <summary>
        /// 按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jmtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (JKeyPress != null)
            {
                JKeyPress(sender, e);
            }
            if (e.KeyChar == 13)
            {
                if (JMClickEnter!=null)
                {
                    JMClickEnter();
                }
                
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            GraphicsPath aa = GetGraphicPath.CreatePath(rect, _ZRadian, RoundStyle.All, false);
            //aa.CloseFigure();
            g.FillPath(new SolidBrush(Color.White), aa);
            g.DrawPath(new Pen(_borderColor), aa);

            rect.Offset(0, 1);
            aa = GetGraphicPath.CreatePathTOP(rect, _ZRadian, false, 45);
            g.DrawPath(new Pen(ColorClass.GetColor(_borderColor, 0, -20, -20, -20)), aa);
        }

        /// <summary>
        /// 窗体大小更改事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!AMultiline)
            {
                this.Height = this.MinimumSize.Height;
            }
            Invalidate();
        }
    }
}