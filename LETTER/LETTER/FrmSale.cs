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
    public partial class FrmSale : Form
    {
        private int ID = 0;

        public FrmSale(int id)
        {
            InitializeComponent();
            ID = id;
            if (ID > 0)
            {
                jmTextBoxEx1.Text = new Sale().getScalar("ZkName", "and ID=" + ID);
            }
            jmTextBoxEx1.Focus();
        }

        private void jm_btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(jmTextBoxEx1.Text.Trim()))
            {
                MessageBox.Show("请输入折扣数");
                return;
            }
            int result = 0;
            if (ID == 0)
            {
                result = new Sale().Insert(jmTextBoxEx1.Text.Trim());
            }
            else
            {
                result = new Sale().Update(jmTextBoxEx1.Text.Trim(), ID);
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
