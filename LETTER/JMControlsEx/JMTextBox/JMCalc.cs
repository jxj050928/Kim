using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class JMCalc : UserControl
    {
        public delegate void EventH(string value);
        public event EventH EqualClike;

        private string BeforNumber = "0";

        public JMCalc()
        {
            InitializeComponent();
            
        }

        public string LabValue
        {
            set { label1.Text = value; }
        }

        #region 数字
        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 14)
            {
                if (textBox1.Text != "0")
                    textBox1.Text += ((JMButton)(sender)).Text;
                else if (((JMButton)(sender)).Text != "00")
                    textBox1.Text = ((JMButton)(sender)).Text;
            }
        }
        #endregion

        #region 清空
        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            textBox1.Text = "0";
        }
        #endregion

        #region 檫除
        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0" && textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "0";
            }
        }
        #endregion

        #region 等于
        private void button24_Click(object sender, EventArgs e)
        {
            if ((int)label1.Text[label1.Text.Length - 1] >= 48 && (int)label1.Text[label1.Text.Length - 1] <= 57)
            {

                if (EqualClike != null)
                {
                    if (label1.Text == "0" && textBox1.Text != "0")
                    {
                        EqualClike(textBox1.Text);
                        textBox1.Text = "0";
                    }
                    else
                    { 
                        EqualClike(label1.Text);
                    }
                }
            }
            else
            {
                double a = Convert.ToDouble(label1.Text.TrimStart('-').TrimEnd(label1.Text[label1.Text.Length - 1]));
                BeforNumber = a.ToString();
                double b = Convert.ToDouble(textBox1.Text.TrimEnd('.'));
                JiSuan(a, b, label1.Text[label1.Text.Length - 1], "");
                if (label1.Text.StartsWith("非数字"))
                {
                    label1.Text = "0";
                }
                if (label1.Text.IndexOf('E') >= 0)
                {
                    label1.Text = "0";
                }
                if (label1.Text.TrimStart('-').TrimEnd('+').TrimEnd('-').TrimEnd('*').TrimEnd('/').TrimEnd('%').Split('.')[0].Length > 14)
                {
                    label1.Text = "0";
                }
                if (EqualClike != null)
                    EqualClike(label1.Text);
            }
        }
        #endregion

        #region 小数点
        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf('.') < 0)
            {
                textBox1.Text += ".";
            }
        }
        #endregion

        #region 符号
        private void button1_Click(object sender, EventArgs e)
        {
            if ((int)label1.Text[label1.Text.Length - 1] >= 48 && (int)label1.Text[label1.Text.Length - 1]<=57)
            {
                if (label1.Text == "0")
                {
                    label1.Text = textBox1.Text.TrimEnd('.') + ((JMButton)(sender)).Text;
                    textBox1.Text = "0";
                }
                else
                {
                    label1.Text += ((JMButton)(sender)).Text;
                }
            }
            else
            {
                double a = Convert.ToDouble(label1.Text.TrimEnd(label1.Text[label1.Text.Length - 1]));
                BeforNumber = a.ToString();
                double b = Convert.ToDouble(textBox1.Text.TrimEnd('.'));
                JiSuan(a, b, label1.Text[label1.Text.Length - 1], ((JMButton)(sender)).Text);
            }
        }
        #endregion

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="Symbol"></param>
        private void JiSuan(double a, double b, char Symbol,string fuhao)
        {
            try
            {
                switch (Symbol)
                {
                    case '+':
                        label1.Text = (a + b).ToString() + fuhao;
                        break;
                    case '-':
                        label1.Text = (a - b).ToString() + fuhao;
                        break;
                    case '*':
                        label1.Text = (a * b).ToString() + fuhao;
                        break;
                    case '/':
                        label1.Text = (a / b).ToString() + fuhao;
                        break;
                    case '%':
                        label1.Text = (a % b).ToString() + fuhao;
                        break;
                }
                Convert.ToDouble(label1.Text.TrimEnd('+').TrimEnd('-').TrimEnd('*').TrimEnd('/').TrimEnd('%'));
                if (label1.Text.StartsWith("非数字"))
                {
                    label1.Text = "0" + fuhao;
                }
                if (label1.Text.IndexOf('E') >= 0)
                {
                    label1.Text = "0" + fuhao;
                }
                if (label1.Text.TrimStart('-').TrimEnd('+').TrimEnd('-').TrimEnd('*').TrimEnd('/').TrimEnd('%').Split('.')[0].Length > 14)
                {
                    label1.Text = "0" + fuhao;
                }
            }
            catch
            {
                label1.Text = "0" + fuhao;
            }
            textBox1.Text = "0";
        }

        #region 返回
        private void jmButton1_Click(object sender, EventArgs e)
        {
            label1.Text = BeforNumber;
        }
        #endregion

        private void ParentForm_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Add)// +
            {
                button1_Click(button5, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Subtract)// -
            {
                button1_Click(button4, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Multiply)// *
            {
                button1_Click(button3, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Divide)// /
            {
                button1_Click(button2, EventArgs.Empty);
            }
            else if (e.Shift&(int)e.KeyCode == 53)// %
            {
                button1_Click(button1, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Back)// back
            {
                button11_Click(button2, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Decimal)// .
            {
                button22_Click(button2, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Enter)//enter
            {
                button24_Click(button24, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad0 || (int)e.KeyCode == 48)// 0~9
            {
                button20_Click(btn0, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad1 || (int)e.KeyCode == 49)
            {
                button20_Click(btn1, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad2 || (int)e.KeyCode == 50)
            {
                button20_Click(btn2, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad3 || (int)e.KeyCode == 51)
            {
                button20_Click(btn3, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad4 || (int)e.KeyCode == 52)
            {
                button20_Click(btn4, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad5 || (int)e.KeyCode == 53)
            {
                button20_Click(btn5, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad6 || (int)e.KeyCode == 54)
            {
                button20_Click(btn6, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad7 || (int)e.KeyCode == 55)
            {
                button20_Click(btn7, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad8 || (int)e.KeyCode == 56)
            {
                button20_Click(btn8, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.NumPad9 || (int)e.KeyCode == 57)
            {
                button20_Click(btn9, EventArgs.Empty);
            }
        }

        private void JMCalc_Load(object sender, EventArgs e)
        {
            ParentForm.KeyDown += new KeyEventHandler(ParentForm_KeyDown);
            ParentForm.KeyPreview = true;
        }
    }
}
