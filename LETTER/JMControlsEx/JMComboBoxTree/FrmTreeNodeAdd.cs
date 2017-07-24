using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmTreeNodeAdd : Form
    {
        /// <summary>
        /// 窗体 x坐标
        /// </summary>
        int XZhou = 0;
        /// <summary>
        /// 窗体 y坐标
        /// </summary>
        int YZhou = 0;

        /// <summary>
        /// 添加 修改 确定事件
        /// </summary>
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

        /// <summary>
        /// 操作类别  "ADD" "UPDATE"
        /// </summary>
        private string _typeCtl;

        [Description("操作类别")]
        public string TypeCtl
        {
            get { return _typeCtl; }
            set { _typeCtl = value; }
        }

        #endregion

        #region 构造函数
        public FrmTreeNodeAdd()
        {
            InitializeComponent();
        }

        public FrmTreeNodeAdd(int _X, int _Y)
        {
            InitializeComponent();
            XZhou = _X;
            YZhou = _Y;
        }
        #endregion

        #region 加载
        private void FrmTypeAdd_Load(object sender, EventArgs e)
        {
            this.Location = new Point(XZhou, YZhou);
        }
        #endregion

        #region 确定
        private void jm_btn_OK_Click(object sender, EventArgs e)
        {
            if (JMAddAndUpdateClick != null)
            {
                JEventargs ee = new JEventargs();
                ee.Tag = this.Tag == null ? "" : this.Tag.ToString();//编号
                ee.Text = txtName.ZText.Trim();//名称
                ee.Type = _typeCtl;
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
        #endregion

        #region 取消
        private void jm_btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
