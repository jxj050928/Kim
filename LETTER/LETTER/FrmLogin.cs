using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dal;

namespace LETTER
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        #region 窗体拖动
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            Win32_API.ReleaseCapture();
            Win32_API.SendMessage(this.Handle, 0x0112, 0Xf010 + 0x0002, 0);
        }
        #endregion

        private void jm_btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(jm_txt_Name.JMText.Trim()))
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            if (string.IsNullOrEmpty(jm_txt_Pwd.JMText.Trim()))
            {
                MessageBox.Show("请输入密码");
                return;
            }
            ProUsers puser = new ProUsers();
            string pwd = puser.getScalar("Userpwd", "and Username='" + jm_txt_Name.JMText.Trim() + "'");
            if (!string.IsNullOrEmpty(pwd) && jm_txt_Pwd.JMText.Trim() == pwd)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
                return;
            }
        }

        private void pnl_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void pnl_Close_MouseEnter(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.close1;
        }

        private void pnl_Close_MouseLeave(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.close;
        }
    }
}
