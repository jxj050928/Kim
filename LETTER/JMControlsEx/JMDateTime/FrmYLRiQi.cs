using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmYLRiQi : Form
    {
        public event JMDelegate.DelItemEventHandle JMYLHaoClick;

        string[] strHao = new string[] {
            "初一","初二","初三","初四","初五","初六","初七","初八","初九","初十",
            "十一","十二","十三","十四","十五","十六","十七","十八","十九","二十",
            "廿一","廿二","廿三","廿四","廿五","廿六","廿七","廿八","廿九","三十"};

        public FrmYLRiQi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 填充天数
        /// </summary>
        public void Fun_FillHao(int _count)
        {
            panel1.Controls.Clear();
            int lbwidth = 79;
            if (_count > 12)
            {
                lbwidth = 61;
            }
            int Yzhou = 4;
            for (int i = 0; i < _count; i++)
            {
                Label LB = new Label();
                LB.BackColor = System.Drawing.Color.White;
                LB.Location = new System.Drawing.Point(0, Yzhou);
                LB.Name = "label" + (i + 1).ToString();
                LB.Cursor = Cursors.Hand;
                LB.Size = new System.Drawing.Size(lbwidth, 20);
                LB.Tag = (i + 1).ToString("00");
                LB.TabIndex = i;
                LB.Text = strHao[i];
                LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                LB.MouseEnter += new EventHandler(LB_MouseEnter);
                LB.MouseLeave += new EventHandler(LB_MouseLeave);
                LB.Click += new EventHandler(LB_Click);
                panel1.Controls.Add(LB);
                Yzhou += 22;
            }
            this.Size = new Size(81, 272);
        }

        #region 鼠标进入事件
        private void LB_MouseEnter(object sender, EventArgs e)
        {
            panel1.Select();
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
            if (JMYLHaoClick != null)
            {
                CancelEventArgs ee = new CancelEventArgs();
                JMYLHaoClick(sender as Label, ee);
                this.Hide();
            }
        }
        #endregion

        #region 窗体停用事件
        private void FrmYLRiQi_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        private void FrmYLRiQi_Load(object sender, EventArgs e)
        {
            this.Size = new Size(81, 272);
        }
    }
}