using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dal;

namespace LETTER
{
    public partial class Uc_Sale : UserControl
    {
        public Uc_Sale()
        {
            InitializeComponent();
        }

        private void FillSale()
        {
            DataTable dt = new Sale().Fill("");
            jm_dgv.Rows.Clear();
            if (dt.Rows.Count != 0)
            {
                jm_dgv.Rows.Add(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jm_dgv.Rows[i].Cells["ColSaleID"].Value = dt.Rows[i]["ID"].ToString();
                    jm_dgv.Rows[i].Cells["ColSaleZkName"].Value = dt.Rows[i]["ZkName"].ToString() + "%";
                }
            }
        }

        private void Uc_Sale_Load(object sender, EventArgs e)
        {
            FillSale();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmSale frm = new FrmSale(0);
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                FillSale();
            }
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            if (jm_dgv.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            int ID = Convert.ToInt32(jm_dgv.SelectedRows[0].Cells["ColSaleID"].Value);
            FrmSale frm = new FrmSale(ID);
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                FillSale();
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (jm_dgv.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确认要删除吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int ID = Convert.ToInt32(jm_dgv.SelectedRows[0].Cells["ColSaleID"].Value);
                new Sale().Delete(ID);
                FillSale();
            }
        }
    }
}
