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
    public partial class Uc_Charge : UserControl
    {
        public Uc_Charge()
        {
            InitializeComponent();
        }

        private int Fill()
        {
            string QueryCondition = "";
            if (!string.IsNullOrEmpty(toolStripTextBox1.Text.Trim()))
            {
                QueryCondition = "and PeoPhone like '%" + toolStripTextBox1.Text.Trim() + "%'";
            }
            PageData pagedata = new PageData();
            pagedata.TableName = "View_Charge";
            pagedata.PrimaryKey = "ChargeDate";
            pagedata.OrderStr = "ChargeDate desc";
            pagedata.PageIndex = pager1.PageCurrent;
            pagedata.PageSize = pager1.PageSize;
            pagedata.QueryFieldName = "*";
            pagedata.QueryCondition = QueryCondition;
            pager1.bindingSource.DataSource = pagedata.QueryDataTable();
            pager1.bindingNavigator.BindingSource = pager1.bindingSource;

            DataTable dt = pager1.bindingSource.DataSource as DataTable;
            jm_dgv.Rows.Clear();
            if (dt.Rows.Count != 0)
            {
                jm_dgv.Rows.Add(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jm_dgv.Rows[i].Cells["ColID"].Value = dt.Rows[i]["PeoID"].ToString();
                    jm_dgv.Rows[i].Cells["ColChargeID"].Value = dt.Rows[i]["ID"].ToString();
                    jm_dgv.Rows[i].Cells["ColName"].Value = dt.Rows[i]["PeoName"].ToString();
                    jm_dgv.Rows[i].Cells["ColPhone"].Value = dt.Rows[i]["PeoPhone"].ToString();

                    jm_dgv.Rows[i].Cells["ColChargeDate"].Value = dt.Rows[i]["ChargeDate"].ToString();
                    jm_dgv.Rows[i].Cells["ColCharteMoney"].Value = dt.Rows[i]["CharteMoney"].ToString();

                }
            }

            return pagedata.TotalCount;
        }

        private void Uc_Sale_Load(object sender, EventArgs e)
        {
            pager1.PageCurrent = 1;
            pager1.Bind();
        }

        private int pager1_EventPaging(EventPagingArg e)
        {
            return Fill();
        }

        private void toolSearch_Click(object sender, EventArgs e)
        {
            pager1.Bind();
        }

        #region 充值
        private void toolCharge_Click(object sender, EventArgs e)
        {
            FrmCharge frm = new FrmCharge();
            frm.ShowDialog();
            pager1.Bind();
        }
        #endregion
    }
}
