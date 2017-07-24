using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmYLMonth : Form
    {
        public event JMDelegate.DelItemEventHandle JMYLMonthClick;

        string[] strMonth = { "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "腊月" };

        public FrmYLMonth()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 填充阴历月份
        /// </summary>
        private void Fun_FillMonth()
        {
            panel1.Controls.Clear();
            int Yzhou = 4;
            for (int i = 0; i < strMonth.Length; i++)
            {
                Label LB = new Label();
                LB.BackColor = System.Drawing.Color.White;
                LB.Location = new System.Drawing.Point(0, Yzhou);
                LB.Name = "label" + (i + 1).ToString();
                LB.Cursor = Cursors.Hand;
                LB.Size = new System.Drawing.Size(61, 20);
                LB.Tag = (i + 1).ToString("00");
                LB.TabIndex = i;
                LB.Text = strMonth[i];
                LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                LB.MouseEnter += new EventHandler(LB_MouseEnter);
                LB.MouseLeave += new EventHandler(LB_MouseLeave);
                LB.Click += new EventHandler(LB_Click);
                panel1.Controls.Add(LB);
                Yzhou += 22;
            }
            this.Size = new Size(63, 272);
        }

        #region 鼠标进入事件
        private void LB_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(185, 231, 255);
        }
        #endregion

        #region 鼠标离开事件
        private void LB_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.White;
        }
        #endregion

        #region 单击选择事件
        private void LB_Click(object sender, EventArgs e)
        {
            if (JMYLMonthClick != null)
            {
                CancelEventArgs ee = new CancelEventArgs();
                JMYLMonthClick(sender as Label, ee);
                this.Hide();
            }
        }
        #endregion

        #region 窗体加载
        private void FrmYLMonth_Load(object sender, EventArgs e)
        {
            Fun_FillMonth();
        }
        #endregion

        #region 窗体停用事件
        private void FrmYLMonth_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion
    }
}