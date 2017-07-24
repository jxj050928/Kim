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
    public partial class Uc_People : UserControl
    {
        public Uc_People()
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
            pagedata.TableName = "People";
            pagedata.PrimaryKey = "ID";
            pagedata.OrderStr = "ID desc";
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
                    jm_dgv.Rows[i].Cells["ColID"].Value = dt.Rows[i]["ID"].ToString();
                    jm_dgv.Rows[i].Cells["ColName"].Value = dt.Rows[i]["PeoName"].ToString();
                    jm_dgv.Rows[i].Cells["ColPhone"].Value = dt.Rows[i]["PeoPhone"].ToString();
                    jm_dgv.Rows[i].Cells["ColBalance"].Value = Convert.ToDecimal(dt.Rows[i]["PeoBalance"]).ToString("N2");
                    jm_dgv.Rows[i].Cells["ColICard"].Value = dt.Rows[i]["PeoICard"].ToString();
                    jm_dgv.Rows[i].Cells["ColICardDate"].Value = dt.Rows[i]["PeoICardDate"].ToString();
                    jm_dgv.Rows[i].Cells["ColSex"].Value = dt.Rows[i]["PeoSex"].ToString();
                    jm_dgv.Rows[i].Cells["ColBirthday"].Value = dt.Rows[i]["PeoBirthday"].ToString();
                    jm_dgv.Rows[i].Cells["ColIDCard"].Value = dt.Rows[i]["PeoIDCard"].ToString();
                    jm_dgv.Rows[i].Cells["ColAddress"].Value = dt.Rows[i]["PeoAddress"].ToString();
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

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmPeople frm = new FrmPeople("");
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                pager1.Bind();
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
            FrmPeople frm = new FrmPeople(ID);
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                pager1.Bind();
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (jm_dgv.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            if (Convert.ToDecimal(jm_dgv.SelectedRows[0].Cells["ColBalance"].Value) > 0)
            {
                MessageBox.Show("该会员还有可用余额，无法删除");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确认要删除吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string ID = jm_dgv.SelectedRows[0].Cells["ColID"].Value.ToString();
                new People().Delete(ID);
                pager1.Bind();
            }
        }

        #region 充值
        private void toolCharge_Click(object sender, EventArgs e)
        {
            FrmCharge frm = new FrmCharge();
            frm.ShowDialog();
            pager1.Bind();
        }
        #endregion

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (URF_R330.icdev==0)
            {
                MessageBox.Show("请先连接设备");
                return;
            }
            if (jm_dgv.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            if (jm_dgv.SelectedRows[0].Cells["ColICard"].Value != null && !string.IsNullOrEmpty(jm_dgv.SelectedRows[0].Cells["ColICard"].Value.ToString()))
            {
                MessageBox.Show("该会员已绑定IC卡");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确认要发卡吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                UInt16 tagtype = 0;
                byte size = 0;
                uint snr = 0;

                //射频读写模块复位
                //mifareone.rf_reset(URF_R330.icdev, 3);

                //寻卡请求
                Int16 st = mifareone.rf_request(URF_R330.icdev, 1, out tagtype);
                if (st != 0)
                {
                    MessageBox.Show("未找到卡片!");
                    return;
                }

                //卡防冲突，返回卡的序列号
                st = mifareone.rf_anticoll(URF_R330.icdev, 0, out snr);
                if (st != 0)
                {
                    MessageBox.Show("读取卡片序列号失败!");
                    return;
                }
                string snrstr = snr.ToString("X");

                //从多个卡中选取一个给定序列号的卡
                st = mifareone.rf_select(URF_R330.icdev, snr, out size);
                if (st != 0)
                {
                    MessageBox.Show("选取卡片失败!");
                    return;
                }

                People peo = new People();
                if (peo.IsExists("and PeoICard='" + snrstr + "'"))
                {
                    MessageBox.Show("当前IC卡已绑定其他会员!");
                    return;
                }

                byte[] key1 = new byte[17];
                byte[] key2 = new byte[7];

                key1 = Encoding.ASCII.GetBytes(URF_R330.skey);
                common.a_hex(key1, key2, 12);
                st = common.rf_load_key(URF_R330.icdev, 0, URF_R330.sec, key2);
                if (st != 0)
                {
                    MessageBox.Show("装载密码失败！");
                    return;
                }
                st = mifareone.rf_authentication(URF_R330.icdev, 0, URF_R330.sec);
                if (st != 0)
                {
                    MessageBox.Show("认证失败！");
                    return;
                }

                string Phone = jm_dgv.SelectedRows[0].Cells["ColPhone"].Value.ToString();

                byte[] databuff = new byte[16];
                byte[] buff = new byte[32];

                string data = Phone+"fffffffffffffffffffff";

                buff = Encoding.ASCII.GetBytes(data);
                common.a_hex(buff, databuff, 32);
                st = mifareone.rf_write(URF_R330.icdev, URF_R330.sec * 4 + 1, databuff);
                if (st != 0)
                {
                    MessageBox.Show("发卡失败！");
                    return;
                }
                else
                {
                    string ID = jm_dgv.SelectedRows[0].Cells["ColID"].Value.ToString();
                    peo.UpdateICard(ID, snrstr, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    MessageBox.Show("发卡成功！");
                    pager1.Bind();
                }
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (jm_dgv.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确认要挂失吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string ID = jm_dgv.SelectedRows[0].Cells["ColID"].Value.ToString();
                new People().DeleteCard(ID);
                pager1.Bind();
            }
        }
    }
}
