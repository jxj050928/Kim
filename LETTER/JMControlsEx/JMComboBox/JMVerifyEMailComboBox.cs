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
    public partial class JMVerifyEMailComboBox : UserControl
    {
        FrmSelectEmail frm = new FrmSelectEmail();

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

        [Description("TextBox值")]
        public string JMText
        {
            get { return jm_txt_Text.Text; }
            set { jm_txt_Text.Text = value; }
        }

        [Description("水印值")]
        public string JMTextTip
        {
            get { return jm_txt_Text.ZEmptyTextTip; }
            set { jm_txt_Text.ZEmptyTextTip = value; }
        }

        [Description("文本内容是否可编辑")]
        public bool JMReadOnly
        {
            get { return jm_txt_Text.ReadOnly; }
            set { jm_txt_Text.ReadOnly = value; }
        }

        private bool _JMFoucs;

        [Description("当前控件是否有焦点")]
        public bool JMFoucs
        {
            get { return _JMFoucs; }
            set
            {
                _JMFoucs = value;
                if (!value)
                {
                    bl = false;
                    Invalidate();
                }
            }
        }
        #endregion

        public JMVerifyEMailComboBox()
        {
            InitializeComponent();
            _JMFrameLineColor = Color.FromArgb(201, 201, 201);
            _JMEnterLineColor = Color.FromArgb(79, 193, 233);

            frm.Deactivate += new EventHandler(frm_Deactivate);//窗体停用
            frm.JMSelectClick += new JMDelegate.ClickDeleteHandel(frm_JMSelectClick);
        }

        #region 选择事件
        private void frm_JMSelectClick(string _str, string _str1)
        {
            jm_txt_Text.Text = _str;
        }
        #endregion

        #region 下拉框失去焦点
        private void frm_Deactivate(object sender, EventArgs e)
        {

        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Color col = _JMFrameLineColor;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            GraphicsPath FW = GetGraphicPath.CreatePath(rect, 6, RoundStyle.None, true);

            if (bl)
            {
                col = _JMEnterLineColor;
            }

            g.DrawPath(new Pen(col), FW);
        }

        private void jPictureBox1_Click(object sender, EventArgs e)
        {
            jm_txt_Text.Focus();
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
                frm.Width = Width;
                if (CBRect.X + frm.Width > cre.WorkingArea.Width)
                {
                    frm.Location = new Point(CBRect.X - frm.Width + this.Width, CBRect.Y + this.Height);
                }
                else
                {
                    frm.Location = new Point(CBRect.X, CBRect.Y + this.Height);
                }
            }
        }

        private void jm_txt_Text_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(jm_txt_Text.Text.Trim()))
            //{
            //    jm_txt_Text.Location = new Point(_JMTextBoxLocation.X, _JMTextBoxLocation.Y);
            //}
            //else
            //{
            //    jm_txt_Text.Location = new Point(_JMTextBoxLocation.X, _JMTextBoxLocation.Y + 2);
            //}
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