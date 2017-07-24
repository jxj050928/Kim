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
    public partial class FrmCharge : Form
    {
        private string ID = "";

        public FrmCharge()
        {
            InitializeComponent();
            jmTextBoxEx1.Focus();
        }

        private void jmTextBoxEx1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Fill();
                e.Handled = true;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            if (string.IsNullOrEmpty(jmTextBoxEx1.Text.Trim()))
            {
                ID = "";
                label_Peoname.Text = "";
                label_PeoBalance.Text = "0.00";
                MessageBox.Show("请输入手机号码");
                return;
            }
            People dalpro = new People();
            if (!dalpro.IsExists("and PeoPhone='" + jmTextBoxEx1.Text.Trim() + "'"))
            {
                ID = "";
                label_Peoname.Text = "";
                label_PeoBalance.Text = "0.00";
                MessageBox.Show("未找到会员");
                return;
            }
            ID = dalpro.getScalar("ID", "and PeoPhone='" + jmTextBoxEx1.Text.Trim() + "'");
            label_Peoname.Text = dalpro.getScalar("PeoName", "and PeoPhone='" + jmTextBoxEx1.Text.Trim() + "'");
            label_PeoBalance.Text = dalpro.getScalar("PeoBalance", "and PeoPhone='" + jmTextBoxEx1.Text.Trim() + "'");
        }

        private void jmTextBoxEx1_TextChanged(object sender, EventArgs e)
        {
            ID = "";
            label_Peoname.Text = "";
            label_PeoBalance.Text = "0.00";
        }

        private void jm_btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(jmTextBoxEx1.Text.Trim()))
            {
                MessageBox.Show("请输入手机号");
                return;
            }
            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("还未锁定会员");
                return;
            }
            if (string.IsNullOrEmpty(jmTextBoxEx2.Text.Trim()) || decimal.Parse(jmTextBoxEx2.Text.Trim()) <= 0)
            {
                MessageBox.Show("请输入充值金额");
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确认要给会员 【" + label_Peoname.Text + "】充入【" + jmTextBoxEx2.Text + "】吗", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int result = 0;
                result = new People().UpdateCharge(ID, decimal.Parse(jmTextBoxEx2.Text.Trim()));
                if (result > 0)
                {
                    label_PeoBalance.Text = (decimal.Parse(label_PeoBalance.Text) + decimal.Parse(jmTextBoxEx2.Text.Trim())).ToString();
                    jmTextBoxEx2.Text = "0.00";
                    MessageBox.Show("充值成功");
                    DialogResult = DialogResult.Yes;
                }
            }
        }

        private void jmButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnReadCard_Click(object sender, EventArgs e)
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
                jmTextBoxEx1.Text = readdata.Substring(0, 11);
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
