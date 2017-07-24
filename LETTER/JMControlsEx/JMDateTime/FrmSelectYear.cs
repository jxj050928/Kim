using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmSelectYear : Form
    {
        public event JMDelegate.ClickItemHandel JMClick;
        
        public FrmSelectYear()
        {
            InitializeComponent();
        }

        public void Fun_SetDate(string _date)
        {
            //panel1.Focus();
            //panel1.Select();
            Label lb = panel1.Controls.Find("lb" + _date, true)[0] as Label;
            lb.Focus();
            lb.Select();
        }

        /// <summary>
        /// 填充下拉日期
        /// </summary>
        /// <param name="_JMMinYear">最小年度</param>
        /// <param name="_JMYearCount">年度数量</param>
        public void Fun_FillYear(int _JMMinYear, int _JMYearCount)
        {
            panel1.Controls.Clear();
            Size lbsz = new Size(90, 20);
            if (_JMYearCount > 9)
            {
                lbsz = new Size(73, 20);
            }
            Point lbpoint = new Point(0, 0);
            for (int i = 0; i < _JMYearCount; i++)
            {
                Label lb = new Label();
                lb.Name = "lb" + (_JMMinYear + i).ToString();
                lb.AutoSize = false;
                lb.Size = lbsz;
                lb.Text = (_JMMinYear + i).ToString();
                lb.Location = new Point(0, lbpoint.Y + (i * 25));
                lb.MouseEnter += new EventHandler(lb_MouseEnter);
                lb.MouseLeave += new EventHandler(lb_MouseLeave);
                lb.Click += new EventHandler(lb_Click);
                lb.TextAlign = ContentAlignment.MiddleCenter;
                panel1.Controls.Add(lb);
            }
        }

        #region 单击事件
        private void lb_Click(object sender, EventArgs e)
        {
            if (JMClick != null)
            {
                Label lb = sender as Label;
                JMClick(lb.Text);
                this.Hide();
            }
        }
        #endregion

        #region 鼠标进入
        private void lb_MouseEnter(object sender, EventArgs e)
        {
            Label jmlb = sender as Label;
            jmlb.BackColor = Color.FromArgb(154, 159, 236);
            jmlb.ForeColor = Color.White;
        }
        #endregion

        #region 鼠标离开
        private void lb_MouseLeave(object sender, EventArgs e)
        {
            Label jmlb = sender as Label;
            jmlb.BackColor = Color.White;
            jmlb.ForeColor = Color.Black;
        }
        #endregion

        #region 窗体加载
        private void FrmTypeSelect_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 窗体停用事件
        private void FrmTypeSelect_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion
    }
}