using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dal;
using JMControlsEx;

namespace LETTER
{
    public delegate void MyDelegate(JMDataGridView Item1, string zk, string sl);//委托实质上是一个类

    public partial class FrmProductList : Form
    {
        public MyDelegate myDelegate;//声明一个委托的对象

        public FrmProductList()
        {
            InitializeComponent();
        }

        private void Fill()
        {
            DataTable dt = new Product().Fill("");
            jm_dgv.Rows.Clear();
            if (dt.Rows.Count != 0)
            {
                jm_dgv.Rows.Add(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jm_dgv.Rows[i].Cells["ColID"].Value = dt.Rows[i]["ID"].ToString();
                    jm_dgv.Rows[i].Cells["ColName"].Value = dt.Rows[i]["ProName"].ToString();
                    jm_dgv.Rows[i].Cells["ColProPrice"].Value = dt.Rows[i]["ProPrice"].ToString();
                }
            }
        }

        private void FillCombobox()
        {
            jmComboBox1.ValueMember = "ID";
            jmComboBox1.DisplayMember = "ZkName";
            jmComboBox1.DataSource = new Sale().Fill("");
            jmComboBox1.SelectedIndex = -1;
        }

        private void jm_btn_Login_Click(object sender, EventArgs e)
        {
            if (myDelegate != null)
            {
                myDelegate(jm_dgv, jmComboBox1.SelectedValue == null ? "" : jmComboBox1.SelectedValue.ToString(), jmTextBoxEx2.Text);
            }
            DialogResult = DialogResult.Yes;
        }

        private void jmButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            Fill();
            FillCombobox();
        }

        private void jm_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (jm_dgv.Rows[e.RowIndex].Cells["ColCheck"].Value == null || !Convert.ToBoolean(jm_dgv.Rows[e.RowIndex].Cells["ColCheck"].Value))
            {
                jm_dgv.Rows[e.RowIndex].Cells["ColCheck"].Value = true;
            }
            else
            {
                jm_dgv.Rows[e.RowIndex].Cells["ColCheck"].Value = false;
            }

        }
    }
}
