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
    public partial class Uc_Sell : UserControl
    {
        public Uc_Sell()
        {
            InitializeComponent();
        }

        private int Fill()
        {
            string QueryCondition = "";
            if (!string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                QueryCondition = "and PeoPhone like '%" + txtPhone.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(jmDateTime1.Text.Trim()))
            {
                QueryCondition += "and SellDate >= '" + jmDateTime1.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(jmDateTime2.Text.Trim()))
            {
                QueryCondition += "and SellDate <= '" + jmDateTime2.Text.Trim() + " 23:59:59" + "'";
            }
            PageData pagedata = new PageData();
            pagedata.TableName = "View_SellProduct";
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
                    jm_dgv.Rows[i].Cells["ColPeoName"].Value = dt.Rows[i]["PeoName"].ToString();
                    jm_dgv.Rows[i].Cells["ColPeoPhone"].Value = dt.Rows[i]["PeoPhone"].ToString();
                    jm_dgv.Rows[i].Cells["ColSellDate"].Value = dt.Rows[i]["SellDate"].ToString();
                    jm_dgv.Rows[i].Cells["ColProName"].Value = dt.Rows[i]["ProName"].ToString();
                    jm_dgv.Rows[i].Cells["ColProPrice"].Value = dt.Rows[i]["ProPrice"].ToString();
                    jm_dgv.Rows[i].Cells["ColSaleNum"].Value = dt.Rows[i]["SaleNum"].ToString() + "%";
                    jm_dgv.Rows[i].Cells["ColSellCount"].Value = dt.Rows[i]["SellCount"].ToString();
                    jm_dgv.Rows[i].Cells["ColSellMoney2"].Value = dt.Rows[i]["SellMoney2"].ToString();
                    jm_dgv.Rows[i].Cells["ColSellMoney"].Value = dt.Rows[i]["SellMoney"].ToString();
                    jm_dgv.Rows[i].Cells["ColID"].Value = dt.Rows[i]["ID"].ToString();
                    jm_dgv.Rows[i].Cells["ColSellID"].Value = dt.Rows[i]["SellID"].ToString();
                    jm_dgv.Rows[i].Cells["ColProID"].Value = dt.Rows[i]["ProID"].ToString();
                }
            }

            label_sum.Text = "合计： " + new SellProduct().getSum(QueryCondition);

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

        private void jmButton3_Click(object sender, EventArgs e)
        {
            if (URF_R330.icdev == 0)
            {
                MessageBox.Show("请先连接设备");
                return;
            }

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

            int i = 0;
            byte[] data = new byte[16];
            byte[] buff = new byte[32];

            for (i = 0; i < 16; i++)
                data[i] = 0;
            for (i = 0; i < 32; i++)
                buff[i] = 0;

            st = mifareone.rf_read(URF_R330.icdev, URF_R330.sec * 4 + 1, data);
            if (st != 0)
            {
                MessageBox.Show("读数据失败！");
                return;
            }

            common.hex_a(data, buff, 16);
            string readdata = System.Text.Encoding.ASCII.GetString(buff);
            if (readdata.Length > 11)
            {
                txtPhone.Text = readdata.Substring(0, 11);
            }
            else
            {
                txtPhone.Text = readdata;
            }
            common.rf_beep(URF_R330.icdev, 10);
        }

    }
}
