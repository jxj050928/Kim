using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmAdd : Form
    {
        int XZhou = 0;
        int YZhou = 0;

        #region 属性
        /// <summary>
        /// 编号
        /// </summary>
        private string _BianHao;

        [Description("编号")]
        public string BianHao
        {
            get { return _BianHao; }
            set { _BianHao = value; this.Tag = value; }
        }

        /// <summary>
        /// 图片
        /// </summary>
        private Image _Img;

        [Description("图片")]
        public Image Img
        {
            get { return _Img; }
            set { _Img = value; pictureBox1.Image = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        private string _Names;

        [Description("名称")]
        public string Names
        {
            get { return _Names; }
            set { _Names = value; txtName.ZText = value; }
        }
        #endregion

        #region 事件
        [Description("单击事件")]
        public event JMDelegate.IEventHandle JMBtnClick;
        #endregion

        public FrmAdd()
        {
            InitializeComponent();
        }

        public FrmAdd(int _X, int _Y)
        {
            InitializeComponent();
            XZhou = _X;
            YZhou = _Y;
        }

        

        #region 窗体加载
        private void FrmAdd_Load(object sender, EventArgs e)
        {
            this.Location = new Point(XZhou, YZhou);
        }
        #endregion

        #region 浏览
        private void jm_btn_LiuLan_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter="*.jpg|*.jpg|*.bmp|*.bmp|*.png|*.png|*.gif|*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName.ToString());
                txtPath.ZText = ofd.FileName.ToString();
                txtName.ZText = ofd.SafeFileName.Split('.')[0];
            }
        }
        #endregion

        #region 确定
        private void jm_btn_OK_Click(object sender, EventArgs e)
        {
            if (JMBtnClick != null)
            {
                JEventargs ee = new JEventargs();
                ee.Img = pictureBox1.Image;
                ee.Tag = this.Tag == null ? "" : this.Tag.ToString();
                ee.Text = txtName.ZText.Trim();
                JMBtnClick(this, ee);
                if (ee.Cancel)
                {
                    this.Close();
                }
            }
        }
        #endregion

        #region 取消
        private void jm_btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}