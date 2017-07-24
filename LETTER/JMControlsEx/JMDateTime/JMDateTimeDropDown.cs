using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class JMDateTimeDropDown : UserControl
    {
        public event JMDelegate.ClickHandel JMYearClick;

        FrmSelectYear frm = new FrmSelectYear();

        /// <summary>
        /// 显示值
        /// </summary>        
        [Description("显示值"), DefaultValue(typeof(string), "")]
        public string JMText
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        /// <summary>
        /// 实际值
        /// </summary>   
        [Description("实际值"), DefaultValue(typeof(string), "")]
        public string JMTag
        {
            get
            {
                if (label1.Tag != null && label1.Tag != DBNull.Value)
                {
                    return label1.Tag.ToString();
                }
                else
                {
                    return "";
                }
            }
            set { label1.Tag = value; }
        }

        /// <summary>
        /// 图像
        /// </summary>
        [Description("图像"), DefaultValue(typeof(bool), "true")]
        public Image JMImage
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        [Description("图像坐标"), DefaultValue(typeof(Point), "0,0")]
        public Point JMImageLocation
        {
            get { return pictureBox1.Location; }
            set { pictureBox1.Location = value; }
        }

        [Description("图像大小"), DefaultValue(typeof(Size), "24,24")]
        public Size JMImageSize
        {
            get { return pictureBox1.Size; }
            set { pictureBox1.Size = value; }
        }

        /// <summary>
        /// 年度显示行数
        /// </summary>
        private int _JMYearCount;

        [Description("年度显示行数"), DefaultValue(typeof(int), "50")]
        public int JMYearCount
        {
            get { return _JMYearCount; }
            set { _JMYearCount = value; }
        }

        /// <summary>
        /// 最小年度
        /// </summary>
        private int _JMMinYear;

        [Description("最小年度"), DefaultValue(typeof(int), "1900")]
        public int JMMinYear
        {
            get { return _JMMinYear; }
            set
            {
                if (value.ToString().Length != 4)
                {
                    _JMMinYear = 1900;
                    return;
                }
                _JMMinYear = value;
            }
        }

        public JMDateTimeDropDown()
        {
            InitializeComponent();
            _JMYearCount = 50;
            _JMMinYear = 1900;
            frm.JMClick += new JMDelegate.ClickItemHandel(frm_JMClick);
        }

        public void Fun_Fill_Year()
        {
            frm.Fun_FillYear(_JMMinYear, _JMYearCount);
        }

        private void frm_JMClick(string _str)
        {
            label1.Text = _str + "年";
            label1.Tag = _str;
            if (JMYearClick != null)
            {
                JMYearClick();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (frm.Visible)
            {
                frm.Hide();
            }
            else
            {
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                Screen cre = Screen.PrimaryScreen;
                if (CBRect.X + frm.Width > cre.WorkingArea.Width)
                {
                    frm.Location = new Point(CBRect.X - frm.Width + this.Width, CBRect.Y + this.Height);
                }
                else
                {
                    frm.Location = new Point(CBRect.X, CBRect.Y + this.Height);
                }
                frm.Show();
                frm.Fun_SetDate(label1.Tag.ToString());
            }
        }
    }
}