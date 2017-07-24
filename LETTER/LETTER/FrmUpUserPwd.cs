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
    public partial class FrmUpUserPwd : Form
    {

        public FrmUpUserPwd()
        {
            InitializeComponent();
            jmTextBoxEx1.Focus();
        }

        private void jm_btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(jmTextBoxEx1.Text.Trim()))
            {
                MessageBox.Show("请输入原用户名");
                return;
            }
            if (string.IsNullOrEmpty(jmTextBoxEx2.Text.Trim()))
            {
                MessageBox.Show("请输入原密码");
                return;
            }
            if (string.IsNullOrEmpty(jmTextBoxEx3.Text.Trim()))
            {
                MessageBox.Show("请输入新用户名");
                return;
            }
            if (string.IsNullOrEmpty(jmTextBoxEx4.Text.Trim()))
            {
                MessageBox.Show("请输入新密码");
                return;
            }
            if (jmTextBoxEx4.Text.Trim() != jmTextBoxEx5.Text.Trim())
            {
                MessageBox.Show("新密码与确认密码不同");
                return;
            }
            ProUsers daluser=new ProUsers();
            bool check = daluser.IsExists("and Username='" + jmTextBoxEx1.Text.Trim() + "' and Userpwd='" + jmTextBoxEx2.Text.Trim() + "'");
            if (!check)
            {
                MessageBox.Show("原用户名或原密码错误，请重新输入");
                return;
            }

            string ID = daluser.getScalar("ID", "and Username='" + jmTextBoxEx1.Text.Trim() + "' and Userpwd='" + jmTextBoxEx2.Text.Trim() + "'");

            int result = daluser.Update(ID,jmTextBoxEx3.Text.Trim(),jmTextBoxEx4.Text.Trim());

            if (result > 0)
            {
                MessageBox.Show("修改成功");
                DialogResult = DialogResult.Yes;
            }
        }

        private void jmButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
