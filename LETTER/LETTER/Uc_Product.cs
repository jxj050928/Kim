﻿using System;
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
    public partial class Uc_Product : UserControl
    {
        public Uc_Product()
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
                    jm_dgv.Rows[i].Cells["ColPrice"].Value = dt.Rows[i]["ProPrice"].ToString();
                    jm_dgv.Rows[i].Cells["ColRemake"].Value = dt.Rows[i]["ProRemake"].ToString();                    
                }
            }
        }

        private void Uc_Sale_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct("");
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                Fill();
            }
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            if (jm_dgv.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            string ID = jm_dgv.SelectedRows[0].Cells["ColID"].Value.ToString();
            FrmProduct frm = new FrmProduct(ID);
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                Fill();
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
                string ID = jm_dgv.SelectedRows[0].Cells["ColID"].Value.ToString();
                new Product().Delete(ID);
                Fill();
            }
        }
    }
}
