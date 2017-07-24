using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmSelectEmail : Form
    {
        public event JMDelegate.ClickDeleteHandel JMSelectClick;

        public FrmSelectEmail()
        {
            InitializeComponent();
        }

        #region Label单击事件
        private void label1_Click(object sender, EventArgs e)
        {
            if (JMSelectClick != null)
            {
                JMSelectClick((sender as Label).Text.Trim(), "");
                this.Hide();
            }
        }
        #endregion

        #region 鼠标进入事件
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Label LB = sender as Label;
            LB.ForeColor = Color.White;
            LB.BackColor = Color.FromArgb(49, 106, 197);
        }
        #endregion

        #region 鼠标离开事件
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label LB = sender as Label;
            LB.ForeColor = Color.Black;
            LB.BackColor = Color.FromArgb(234, 234, 234);
        }
        #endregion

        #region 窗体停用事件
        private void FrmSelectEmail_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion
    }
}
