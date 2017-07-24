using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmMainSelectPanel : Form
    {
        public event JMDelegate.ClickHandel JMTYHide;

        /// <summary>
        /// 是否启用自动隐藏
        /// </summary>
        private bool _JMDeactivate;

        [Description("是否启用自动隐藏"), DefaultValue(typeof(bool), "true")]
        public bool JMDeactivate
        {
            get { return _JMDeactivate; }
            set { _JMDeactivate = value; }
        }

        private bool _JMTransparent;

        [Description("是否透明"), DefaultValue(typeof(bool), "False")]
        public bool JMTransparent
        {
            get { return _JMTransparent; }
            set
            {
                _JMTransparent = value;
                if (value)
                {
                    this.TransparencyKey = System.Drawing.SystemColors.Control;
                }
                Invalidate();
            }
        }

        public UserControl JMLoadUc
        {
            set { Fun_LoadUC(value); }
        }

        public FrmMainSelectPanel()
        {
            InitializeComponent();
            _JMDeactivate = true;
            _JMTransparent = false;
        }

        private void Fun_LoadUC(UserControl _JMLoadUc)
        {
            Controls.Clear();
            _JMLoadUc.Dock = DockStyle.Fill;
            Controls.Add(_JMLoadUc);
        }

        #region 窗体加载
        private void FrmTypeSelect_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 窗体停用事件
        private void FrmTypeSelect_Deactivate(object sender, EventArgs e)
        {
            if (_JMDeactivate)
            {
                this.Hide();
            }
            if (JMTYHide != null)
            {
                JMTYHide();
            }
        }
        #endregion

        #region Esc取消当前窗体
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Hide();
            }
        }
        #endregion
    }
}