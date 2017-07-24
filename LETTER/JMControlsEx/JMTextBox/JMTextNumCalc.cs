using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class JMTextNumCalc : UserControl
    {
        public delegate void ClikeEventHandle(object sender, WizardClickEventArgs e);
        public event ClikeEventHandle BeforCalcClick;

        [Browsable(true)]
        public new event EventHandler TextChanged;

        public event JMDelegate.ClickHandel jmbeforclick;

        public event JMDelegate.ClickHandel jmendclick;

        /// <summary>
        /// 存放下拉框的窗体
        /// </summary>
        private Form frmCalc;
        /// <summary>
        /// 计算器
        /// </summary>
        private JMCalc jmcalc;

        public JMTextNumCalc()
        {
            InitializeComponent();

            this.frmCalc = new Form();
            this.frmCalc.FormBorderStyle = FormBorderStyle.None;
            this.frmCalc.BringToFront();
            this.frmCalc.StartPosition = FormStartPosition.Manual;
            this.frmCalc.ShowInTaskbar = false;
            this.frmCalc.BackColor = SystemColors.Control;
            this.frmCalc.Size = new Size(180, 240);
            this.frmCalc.Deactivate += new EventHandler(frmCalc_Deactivate);

            this.jmcalc = new JMCalc();
            this.jmcalc.Location = new Point(0, 0);
            this.jmcalc.EqualClike += new JMCalc.EventH(jmcalc_EqualClike);

            this.frmCalc.Controls.Add(jmcalc);
        }

        public bool ReadOnly
        {
            get { return jmTextBox1.ReadOnly; }
            set { jmTextBox1.ReadOnly = value; }
        }

        [Category("Appearance"),
        Description("启用负数"),
        DefaultValue(false)]
        public bool ZNegative
        {
            get { return jmTextBox1.ZNegative; }
            set { jmTextBox1.ZNegative = value; }
        }

        [Category("Appearance"),
        Description("小数位数"),
        DefaultValue(typeof(int), "0")]
        public int ZMedian
        {
            get { return jmTextBox1.ZMedian; }
            set
            {
                jmTextBox1.ZMedian = value;
            }
        }

        public Color ZBorderColor
        {
            get { return jmTextBox1.ZBorderColor; }
            set { jmTextBox1.ZBorderColor = value; }
        }

        [Category("Appearance"),
        Description("获取值"),
        DefaultValue(typeof(int), "0")]
        public override string Text
        {
            get { return jmTextBox1.Text; }
            set
            {
                jmTextBox1.Text = value;
            }
        }

        public bool IsXYK
        {
            get { return jmTextBox1.IsXYK; }
            set { jmTextBox1.IsXYK = value; }
        }

        private void jmcalc_EqualClike(string value)
        {
            if (!ZNegative)
            {
                if (Convert.ToDecimal(value) < 0)
                {
                    jmTextBox1.Text = decimal.Round(-Convert.ToDecimal(value) * 1.000000M, ZMedian).ToString();
                    this.frmCalc.Hide();
                    return;
                }
            }
            this.frmCalc.Hide();
            jmTextBox1.Text = decimal.Round(Convert.ToDecimal(value) * 1.000000M, ZMedian).ToString();
        }

        private void frmCalc_Deactivate(object sender, EventArgs e)
        {
            if (jmendclick != null)
            {
                jmendclick();
            }
            this.frmCalc.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!ReadOnly)
            {
                if (BeforCalcClick != null)
                {
                    WizardClickEventArgs we = new WizardClickEventArgs();
                    BeforCalcClick(sender, we);
                    if (we.Cancel == true)
                        return;
                }
                if (jmbeforclick != null)
                {
                    jmbeforclick();
                }
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                this.frmCalc.Location = new Point(CBRect.X, CBRect.Y + 21);
                if (Convert.ToDecimal(jmTextBox1.Text) != 0)
                    jmcalc.LabValue = jmTextBox1.Text;
                this.frmCalc.Show();
                this.frmCalc.BringToFront();
            }
        }

        private void JMTextNumCalc_Resize(object sender, EventArgs e)
        {
            this.Height = 21;
            jmTextBox1.Width = this.Width - 21;
            pictureBox1.Location = new Point(jmTextBox1.Width, 0);
        }

        private void jmTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(sender, e);
        }
    }
}
