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
    public partial class FrmProduct : Form
    {
        private string ID = "";

        public FrmProduct(string id)
        {
            InitializeComponent();
            ID = id;
            if (!string.IsNullOrEmpty(ID))
            {
                Product dalpro = new Product();
                jmTextBoxEx1.Text = dalpro.getScalar("ProName", "and ID='" + ID + "'");
                jmTextBoxEx2.Text = dalpro.getScalar("ProPrice", "and ID='" + ID + "'");
                jmTextBoxEx3.Text = dalpro.getScalar("ProRemake", "and ID='" + ID + "'");
            }
            jmTextBoxEx1.Focus();
        }

        private void jm_btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(jmTextBoxEx1.Text.Trim()))
            {
                MessageBox.Show("请输入产品名称");
                return;
            }
            if (string.IsNullOrEmpty(jmTextBoxEx2.Text.Trim()) || decimal.Parse(jmTextBoxEx2.Text.Trim()) <= 0)
            {
                MessageBox.Show("请输入产品单价");
                return;
            }
            int result = 0;
            if (string.IsNullOrEmpty(ID))
            {
                Product dalpro = new Product();
                ID = dalpro.AutoID();
                result = dalpro.Insert(ID, jmTextBoxEx1.Text.Trim(), jmTextBoxEx2.Text.Trim(), jmTextBoxEx3.Text.Trim());
            }
            else
            {
                result = new Product().Update(ID, jmTextBoxEx1.Text.Trim(), jmTextBoxEx2.Text.Trim(), jmTextBoxEx3.Text.Trim());
            }
            if (result > 0)
            {
                DialogResult = DialogResult.Yes;
            }
        }

        private void jmButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
