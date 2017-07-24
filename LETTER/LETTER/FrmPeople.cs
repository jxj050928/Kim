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
    public partial class FrmPeople : Form
    {
        private string ID = "";
        private string Phone = "";

        public FrmPeople(string id)
        {
            InitializeComponent();
            ID = id;
            if (!string.IsNullOrEmpty(ID))
            {
                People dalpro = new People();
                jmTextBoxEx1.Text = dalpro.getScalar("PeoName", "and ID='" + ID + "'");
                jmTextBoxEx2.Text = dalpro.getScalar("PeoPhone", "and ID='" + ID + "'");
                Phone = jmTextBoxEx2.Text;
                jmTextBoxEx3.Text = dalpro.getScalar("PeoAddress", "and ID='" + ID + "'");
                jmTextBoxEx4.Text = dalpro.getScalar("PeoIDCard", "and ID='" + ID + "'");
                jmDateTime1.Text = dalpro.getScalar("PeoBirthday", "and ID='" + ID + "'");
                string PeoSex = dalpro.getScalar("PeoSex", "and ID='" + ID + "'");
                if (!string.IsNullOrEmpty(PeoSex))
                {
                    if (PeoSex == "男")
                    {
                        jmRadioButton1.Checked = true;
                    }
                    else
                    {
                        jmRadioButton2.Checked = true;
                    }
                }
            }
            jmTextBoxEx1.Focus();
        }

        private void jm_btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(jmTextBoxEx1.Text.Trim()))
            {
                MessageBox.Show("请输入会员姓名");
                return;
            }
            if (string.IsNullOrEmpty(jmTextBoxEx2.Text.Trim()))
            {
                MessageBox.Show("请输入手机号码");
                return;
            }
            if (jmTextBoxEx2.Text.Trim().Length!=11)
            {
                MessageBox.Show("手机号码必须为11位");
                return;
            }
            int result = 0;

            string PeoName = jmTextBoxEx1.Text.Trim();
            string PeoPhone = jmTextBoxEx2.Text.Trim();
            string PeoSex = "";
            if (jmRadioButton1.Checked)
            {
                PeoSex = "男";
            }
            if (jmRadioButton2.Checked)
            {
                PeoSex = "女";
            }
            string PeoBirthday = jmDateTime1.Text;
            string PeoAddress = jmTextBoxEx3.Text.Trim();
            string PeoIDCard = jmTextBoxEx4.Text.Trim();

            People dalpro = new People();
            if (string.IsNullOrEmpty(ID))
            {                
                if (dalpro.IsExists("and PeoPhone='" + PeoPhone + "'"))
                {
                    MessageBox.Show("该手机号码已存在");
                    return;
                }
                ID = dalpro.AutoID();
                string PeoICard = "";
                string PeoICardDate = "";
                string PeoBalance = "0";
                result = dalpro.Insert(ID, PeoName, PeoPhone, PeoSex, PeoBirthday, PeoAddress, PeoIDCard, PeoICard, PeoICardDate, PeoBalance);
            }
            else
            {
                if (dalpro.IsExists("and PeoPhone='" + PeoPhone + "' and PeoPhone<>'" + Phone + "'")) 
                {
                    MessageBox.Show("该手机号码已存在");
                    return;
                }
                result = dalpro.Update(ID, PeoName, PeoPhone, PeoSex, PeoBirthday, PeoAddress, PeoIDCard);
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
