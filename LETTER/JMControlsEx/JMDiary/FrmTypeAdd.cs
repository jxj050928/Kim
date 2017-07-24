using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmTypeAdd : Form
    {
        int XZhou = 0;
        int YZhou = 0;

        public event JMDelegate.IEventHandle JMAddAndUpdateClick;

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

        public FrmTypeAdd()
        {
            InitializeComponent();
        }

        public FrmTypeAdd(int _X, int _Y)
        {
            InitializeComponent();
            XZhou = _X;
            YZhou = _Y;
        }

        private void FrmTypeAdd_Load(object sender, EventArgs e)
        {
            this.Location = new Point(XZhou, YZhou);
        }

        private void jm_btn_OK_Click(object sender, EventArgs e)
        {
            if (JMAddAndUpdateClick != null)
            {
                JEventargs ee = new JEventargs();
                ee.Tag = this.Tag == null ? "" : this.Tag.ToString();//编号
                ee.Text = txtName.ZText.Trim();//名称
                JMAddAndUpdateClick(this, ee);
                if (ee.Cancel)
                {
                    this.Close();
                }
                else
                {
                    txtName.Focus();
                }
            }
        }

        private void jm_btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
