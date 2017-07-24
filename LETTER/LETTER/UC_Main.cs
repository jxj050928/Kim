using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dal;
using JMControlsEx;

namespace LETTER
{
    public partial class UC_Main : UserControl
    {
        public UC_Main()
        {
            InitializeComponent();
        }

        private void FillCombobox()
        {
            ColSale.ValueMember = "ID";
            ColSale.DisplayMember = "ZkName";
            ColSale.DataSource = new Sale().Fill("");
        }

        private void UC_Main_Load(object sender, EventArgs e)
        {
            if (this.GetService(typeof(System.ComponentModel.Design.IDesignerHost)) != null || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                //设计模式
            }
            else
            {
                //运行模式
                FillCombobox();
                if (URF_R330.icdev > 0)
                {
                    jmButton1.Enabled = false;
                    jmButton2.Enabled = true;
                }
            }
        }

        private void Fill()
        {
            if (string.IsNullOrEmpty(jmTextBoxEx1.Text.Trim()))
            {
                label_Peoname.Tag = "";
                label_Peoname.Text = "";
                label_PeoBalance.Text = "0.00";
                MessageBox.Show("请输入手机号码");
                return;
            }
            People dalpro = new People();
            if (!dalpro.IsExists("and PeoPhone='" + jmTextBoxEx1.Text.Trim() + "'"))
            {
                label_Peoname.Tag = "";
                label_Peoname.Text = "";
                label_PeoBalance.Text = "0.00";
                MessageBox.Show("未找到会员");
                return;
            }
            label_Peoname.Tag = dalpro.getScalar("ID", "and PeoPhone='" + jmTextBoxEx1.Text.Trim() + "'");
            label_Peoname.Text = dalpro.getScalar("PeoName", "and PeoPhone='" + jmTextBoxEx1.Text.Trim() + "'");
            label_PeoBalance.Text = dalpro.getScalar("PeoBalance", "and PeoPhone='" + jmTextBoxEx1.Text.Trim() + "'");
        }

        private void jmTextBoxEx1_TextChanged(object sender, EventArgs e)
        {
            label_Peoname.Tag = "";
            label_Peoname.Text = "";
            label_PeoBalance.Text = "0.00";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Fill();
        }

        private void jmTextBoxEx1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Fill();
                e.Handled = true;
            }
        }

        private void toolDeleteRow_Click(object sender, EventArgs e)
        {
            if (jm_dgv.SelectedRows.Count<=0)
            {
                MessageBox.Show("请选择要删除的产品");
                return;
            }
            jm_dgv.Rows.Remove(jm_dgv.SelectedRows[0]);
            rePayMoney();
        }

        private void toolAddRow_Click(object sender, EventArgs e)
        {
            FrmProductList frm = new FrmProductList();
            frm.myDelegate += new MyDelegate(AddPro);
            frm.ShowDialog();
        }

        private void AddPro(JMDataGridView Item1, string zk, string sl)
        {
            foreach (DataGridViewRow item in Item1.Rows)
            {
                if (item.Cells["ColCheck"].EditedFormattedValue.ToString() == "True")
                {
                    jm_dgv.Rows.Add(1);
                    jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColID"].Value = item.Cells["ColID"].Value;
                    jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColName"].Value = item.Cells["ColName"].Value;
                    jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColPrice"].Value = item.Cells["ColProPrice"].Value;
                    if (!string.IsNullOrEmpty(zk))
                    {
                        jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColSale"].Value = int.Parse(zk);
                    }
                    jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColCount"].Value = sl;
                    if (sl == "0")
                    {
                        jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColMoney"].Value = "0.00";
                        jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColMoney2"].Value = "0.00";
                    }
                    else
                    {
                        decimal price = Convert.ToDecimal(item.Cells["ColProPrice"].Value) * 1.00M;
                        int prosl = int.Parse(sl);
                        if (string.IsNullOrEmpty(zk))
                        {
                            jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColMoney"].Value = decimal.Round(price * prosl, 2).ToString();
                        }
                        else
                        {
                            decimal prozk = Convert.ToDecimal(new Sale().getScalar("ZkName", "and ID=" + zk)) / 100.00M;
                            jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColMoney"].Value = decimal.Round(price * prozk * prosl, 2).ToString();
                        }
                        jm_dgv.Rows[jm_dgv.Rows.Count - 1].Cells["ColMoney2"].Value = decimal.Round(price * prosl, 2).ToString();
                    }
                }
            }
            rePayMoney();
        }

        /// <summary>
        /// 重新计算金额
        /// </summary>
        private void rePayMoney()
        {
            decimal summoney = 0.00M;
            decimal summoney2 = 0.00M;
            foreach (DataGridViewRow item in jm_dgv.Rows)
            {
                summoney += Convert.ToDecimal(item.Cells["ColMoney"].Value);
                summoney2 += Convert.ToDecimal(item.Cells["ColMoney2"].Value);
            }
            label2.Text = decimal.Round(summoney, 2).ToString();
            label5.Text = decimal.Round(summoney2, 2).ToString();
        }

        private void btn_buy_Click(object sender, EventArgs e)
        {
            if (label_Peoname.Tag == null || label_Peoname.Tag.ToString() == "")
            {
                MessageBox.Show("未找到会员信息，无法结算");
                return;
            }
            if (jm_dgv.Rows.Count <= 0)
            {
                MessageBox.Show("无待结算产品");
                return;
            }
            if (label2.Text == "0.00")
            {
                MessageBox.Show("应收总金额为0.00元，无法结算");
                return;
            }
            if (Convert.ToDecimal(label_PeoBalance.Text) < Convert.ToDecimal(label2.Text))
            {
                MessageBox.Show("余额不足，无法结算，请充值");
                return;
            }

            List<string> tsqls = new List<string>();

            decimal PeoBalance = decimal.Round(Convert.ToDecimal(label_PeoBalance.Text) - Convert.ToDecimal(label2.Text), 2);
            string tsql1 = "update People set PeoBalance='" + PeoBalance + "' where ID='" + label_Peoname.Tag.ToString() + "'";
            tsqls.Add(tsql1);

            string sellID = new Sell().AutoID(DateTime.Now.ToString("yyyyMMdd"));
            string tsql2 = "insert into Sell(ID,PeoID,SellDate,SellSumMoney) values('" + sellID + "','" + label_Peoname.Tag.ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + label2.Text + "')";
            tsqls.Add(tsql2);

            int mxid = 1;
            foreach (DataGridViewRow item in jm_dgv.Rows)
            {
                string ProID = item.Cells["ColID"].Value.ToString();
                string ProPrice = item.Cells["ColPrice"].Value.ToString();

                string SaleNum = "100";
                if (item.Cells["ColSale"].Value != null)
                {
                    string zk = item.Cells["ColSale"].Value.ToString();
                    SaleNum = new Sale().getScalar("ZkName", "and ID=" + zk);
                }

                string SellCount = item.Cells["ColCount"].Value.ToString();
                string SellMoney = item.Cells["ColMoney"].Value.ToString();
                string SellMoney2 = item.Cells["ColMoney2"].Value.ToString();
                string tsql3 = "insert into SellProduct(ID,SellID,ProID,ProPrice,SaleNum,SellCount,SellMoney,SellMoney2) values('" + (sellID + mxid.ToString("00")) + "','" + sellID + "','" + ProID + "','" + ProPrice + "','" + SaleNum + "','" + SellCount + "','" + SellMoney + "','" + SellMoney2 + "')";
                mxid++;
                tsqls.Add(tsql3);
            }

            if (new SellProduct().SellAdd(tsqls))
            {
                jm_dgv.Rows.Clear();
                label_PeoBalance.Text = PeoBalance.ToString();
                label2.Text = "0.00";
                MessageBox.Show("结算成功");
            }
            else
            {
                MessageBox.Show("结算失败");
            }
        }

        private void jm_dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //列的索引根据自己的网格来
            if (jm_dgv.CurrentCell.RowIndex >= 0)
            {
                if (jm_dgv.CurrentCell.ColumnIndex == 2)
                {
                    //还原控件并绑定事件
                    ((ComboBox)e.Control).SelectedIndexChanged += new EventHandler(UC_Main_SelectedIndexChanged);
                }
                else if (jm_dgv.CurrentCell.ColumnIndex == 3)
                {
                    //还原控件并绑定事件
                    ((TextBox)e.Control).TextChanged += new EventHandler(UC_Main_TextChanged);
                    ((TextBox)e.Control).KeyPress += new KeyPressEventHandler(UC_Main_KeyPress);
                }
            }
        }

        void UC_Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        void UC_Main_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                jm_dgv.SelectedRows[0].Cells["ColMoney"].Value = "0.00";
                jm_dgv.SelectedRows[0].Cells["ColMoney2"].Value = "0.00";
                rePayMoney();
                return;
            }
            decimal prozk = 1.00M;
            if (jm_dgv.SelectedRows[0].Cells["ColSale"].Value != null)
            {
                string zk = jm_dgv.SelectedRows[0].Cells["ColSale"].Value.ToString();
                prozk = Convert.ToDecimal(new Sale().getScalar("ZkName", "and ID=" + zk)) / 100.00M;
            }
            decimal price = Convert.ToDecimal(jm_dgv.SelectedRows[0].Cells["ColPrice"].Value) * 1.00M;
            decimal prosl = Convert.ToDecimal(((TextBox)sender).Text);
            jm_dgv.SelectedRows[0].Cells["ColMoney"].Value = decimal.Round(price * prozk * prosl, 2).ToString();
            jm_dgv.SelectedRows[0].Cells["ColMoney2"].Value = decimal.Round(price * prosl, 2).ToString();
            rePayMoney();
        }

        void UC_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0)
            {
                string zk = ((ComboBox)sender).Text.ToString();
                if (zk == "System.Data.DataRowView")
                {
                    return;
                }
                //decimal prozk = Convert.ToDecimal(new Sale().getScalar("ZkName", "and ID=" + zk)) / 100.00M;
                decimal prozk = Convert.ToDecimal(zk) / 100.00M;
                decimal price = Convert.ToDecimal(jm_dgv.SelectedRows[0].Cells["ColPrice"].Value) * 1.00M;
                decimal prosl = Convert.ToDecimal(jm_dgv.SelectedRows[0].Cells["ColCount"].Value);
                jm_dgv.SelectedRows[0].Cells["ColMoney"].Value = decimal.Round(price * prozk * prosl, 2).ToString();
                jm_dgv.SelectedRows[0].Cells["ColMoney2"].Value = decimal.Round(price * prosl, 2).ToString();
                rePayMoney();
            }
        }

        

        private void jmButton1_Click(object sender, EventArgs e)
        {
            URF_R330.icdev = common.rf_init(0, 115200);
            if (URF_R330.icdev > 0)
            {
                jmButton1.Enabled = false;
                jmButton2.Enabled = true;
                common.rf_beep(URF_R330.icdev, 10);
            }
            else
            {
                MessageBox.Show("连接设备失败！");
            }
        }

        private void jmButton2_Click(object sender, EventArgs e)
        {
            Int16 st = common.rf_exit(URF_R330.icdev);
            if (st == 0)
            {
                MessageBox.Show("断开连接成功！");
                URF_R330.icdev = 0;
                jmButton1.Enabled = true;
                jmButton2.Enabled = false;
            }
            else
            {
                MessageBox.Show("断开连接失败！");
                jmButton1.Enabled = false;
                jmButton2.Enabled = true;
            }
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
                jmTextBoxEx1.Text = readdata.Substring(0,11);
            }
            else
            {
                jmTextBoxEx1.Text = readdata;
            }
            common.rf_beep(URF_R330.icdev, 10);
            Fill();  
        }

    }
}
