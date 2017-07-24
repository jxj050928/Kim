using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dal;
using System.IO;

namespace LETTER
{
    public partial class Uc_Backup : UserControl
    {
        public Uc_Backup()
        {
            InitializeComponent();
        }

        private void Fill()
        {
            DataTable dt = new Backup().Fill("");
            jm_dgv.Rows.Clear();
            if (dt.Rows.Count != 0)
            {
                jm_dgv.Rows.Add(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jm_dgv.Rows[i].Cells["ColID"].Value = dt.Rows[i]["ID"].ToString();
                    jm_dgv.Rows[i].Cells["ColDate"].Value = dt.Rows[i]["BackDate"].ToString();
                    jm_dgv.Rows[i].Cells["ColBackFile"].Value = dt.Rows[i]["BackFile"].ToString();
                }
            }
        }

        private void Uc_Sale_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string sFile = Application.StartupPath + "\\Letter.mdb";
                string dFile = folderBrowserDialog1.SelectedPath + "\\Letter" + DateTime.Now.ToString("yyyyMMddHHmmss");
                File.Copy(sFile, dFile);
                int dbresult = new Backup().Insert(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), dFile);
                if (dbresult > 0)
                {
                    MessageBox.Show("备份成功");
                    Fill();
                }
            }
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            if (jm_dgv.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            string sFile = jm_dgv.SelectedRows[0].Cells["ColBackFile"].Value.ToString();
            string dFile = Application.StartupPath + "\\Letter.mdb";
            File.Copy(sFile, dFile, true);
            MessageBox.Show("还原成功");
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
                string file = jm_dgv.SelectedRows[0].Cells["ColBackFile"].Value.ToString();
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                int ID = Convert.ToInt32(jm_dgv.SelectedRows[0].Cells["ColID"].Value);
                new Backup().Delete(ID);
                Fill();
            }
        }

        private void toolUpUser_Click(object sender, EventArgs e)
        {
            FrmUpUserPwd frm = new FrmUpUserPwd();
            frm.ShowDialog();
        }
    }
}
