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
    public partial class JMLoginComboBox : UserControl
    {
        FrmSelectComboBox frm = new FrmSelectComboBox();

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

        [Description("TextBox值")]
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

        /// <summary>
        /// 编号
        /// </summary>
        private string _JMTypeID;

        [Description("编号")]
        public string JMTypeID
        {
            get { return _JMTypeID; }
            set { _JMTypeID = value; }
        }

        [Description("下拉显示值")]
        public DataTable JMDT
        {
            get { return frm.JMDT; }
            set { frm.JMDT = value; }
        }

        [Description("编号列号")]
        public string JMBHLie
        {
            get { return frm.JMBHLie; }
            set { frm.JMBHLie = value; }
        }

        [Description("名称列名")]
        public string JMNameLie
        {
            get { return frm.JMNameLie; }
            set { frm.JMNameLie = value; }
        }

        [Description("是否显示增加按钮")]
        public bool JMVisibleAdd
        {
            get { return frm.JMVisibleAdd; }
            set { frm.JMVisibleAdd = value; }
        }

        [Description("是否显示右键菜单")]
        public bool JMVisibleYJ
        {
            get { return frm.JMVisibleYJ; }
            set { frm.JMVisibleYJ = value; }
        }

        [Description("文本内容是否可编辑")]
        public bool JMReadOnly
        {
            get { return jm_txt_Text.ReadOnly; }
            set { jm_txt_Text.ReadOnly = value; }
        }
        #endregion

        #region 事件
        [Description("单击添加、修改事件")]
        public event JMDelegate.IEventHandle JMAddAndUpdateClick;

        [Description("单击删除事件")]
        public event JMDelegate.IEventHandle JMDelClick;

        [Description("单击选择事件")]
        public event JMDelegate.ClickDeleteHandel AfterSelect;
        #endregion

        public JMLoginComboBox()
        {
            InitializeComponent();
            this.Size = new Size(178, 28);
            _JMFrameLineColor = Color.FromArgb(201, 201, 201);
            _JMEnterLineColor = Color.FromArgb(79, 193, 233);
            _JMImageLocation = new Point(10, 1);
            _JMTextBoxLocation = new Point(40, 5);
            _JMImgaeSize = new Size(20, 20);

            frm.Deactivate += new EventHandler(frm_Deactivate);//窗体停用
            frm.JMSelectClick += new JMDelegate.ClickDeleteHandel(frm_JMSelectClick);
            frm.JMDelClick += new JMDelegate.IEventHandle(frm_JMDelClick);
            frm.JMAddAndUpdateClick += new JMDelegate.IEventHandle(frm_JMAddClick);
        }

        #region 单击添加、修改
        private void frm_JMAddClick(object sender, JEventargs e)
        {
            if (JMAddAndUpdateClick != null)
            {
                JMAddAndUpdateClick(sender, e);
                if (e.Cancel)
                {
                    if (!string.IsNullOrEmpty(e.Tag))
                    {
                        _JMTypeID = e.Tag.ToString();
                    }
                }
            }
        }
        #endregion

        #region 删除
        private void frm_JMDelClick(object sender, JEventargs e)
        {
            if (JMDelClick != null)
            {
                JMDelClick(sender, e);
                if (e.Cancel)
                {
                    if (_JMTypeID == e.Tag.ToString())
                    {
                        _JMTypeID = "";
                        jm_txt_Text.Text = "";
                    }
                }
            }
        }
        #endregion

        #region 选择事件
        private void frm_JMSelectClick(string _str, string _str1)
        {
            _JMTypeID = _str;
            jm_txt_Text.Text = _str1;
            if (AfterSelect != null)
            {
                AfterSelect(_str, _str1);
            }
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

            Image img = _JMImage;
            Color col = _JMFrameLineColor;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            GraphicsPath FW = GetGraphicPath.CreatePath(rect, 6, RoundStyle.None, true);

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

        private void jPictureBox1_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(jm_txt_Text.Text.Trim()))
            {
                jm_txt_Text.Location = new Point(_JMTextBoxLocation.X, _JMTextBoxLocation.Y);
            }
            else
            {
                jm_txt_Text.Location = new Point(_JMTextBoxLocation.X, _JMTextBoxLocation.Y + 2);
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