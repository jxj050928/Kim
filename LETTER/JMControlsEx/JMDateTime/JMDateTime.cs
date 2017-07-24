using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class JMDateTime : UserControl
    {
        /// <summary>
        /// 存放下拉框的窗体
        /// </summary>
        private Form frmCalen;

        /// <summary>
        /// 修改高度
        /// </summary>
        private bool XGGD = false;

        /// <summary>
        /// 默认值
        /// </summary>
        private Color _BorderColor = Color.FromArgb(255, 51, 161, 224);//边框颜色

        /// <summary>
        /// 属性
        /// </summary>
        public Color BorderColor
        {
            get { return _BorderColor; }
            set { this.txtDatetime.ZBorderColor = value; _BorderColor = value; }
        }

        private Color _MonthBorderColor = Color.FromArgb(255, 0, 84, 227);

        public Color MonthBorderColor
        {
            get { return _MonthBorderColor; }
            set
            {
                monthCalendar1.TitleBackColor = value;
                _MonthBorderColor = value;
            }
        }

        /// <summary>
        /// 显示选中的值
        /// </summary>
        public override string Text
        {
            get { return this.txtDatetime.Text; }
            set { this.txtDatetime.Text = value; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public JMDateTime()
        {
            InitializeComponent();
            this.frmCalen = new Form();
            this.frmCalen.FormBorderStyle = FormBorderStyle.None;
            this.frmCalen.BringToFront();
            this.frmCalen.StartPosition = FormStartPosition.Manual;
            this.frmCalen.ShowInTaskbar = false;
            this.frmCalen.BackColor = SystemColors.Control;
            this.frmCalen.Deactivate += new EventHandler(frmCalen_Deactivate);
        }

        #region 当窗体丢去焦点
        private void frmCalen_Deactivate(object sender, EventArgs e)
        {
            this.frmCalen.Hide();
        }
        #endregion

        #region 加载
        private void JMDateTime_Load(object sender, EventArgs e)
        {
            txtDatetime.ShortcutsEnabled = false;
        }
        #endregion

        #region 日期单击
        private void jm_pb_Date_Click(object sender, EventArgs e)
        {
            XGGD = true;
            this.frmCalen.Controls.Add(monthCalendar1);
            Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
            this.frmCalen.Location = new Point(CBRect.X, CBRect.Y + 21);
            this.frmCalen.Size = monthCalendar1.Size;
            this.frmCalen.Show();
            this.frmCalen.BringToFront();
        }
        #endregion

        #region Text控制
        private void txtDatetime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                txtDatetime.Text = "";
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        private void JMDateTime_SizeChanged(object sender, EventArgs e)
        {
            if (XGGD)
            {
                this.Size = new Size(this.frmCalen.Width, txtDatetime.Height + frmCalen.Height);
            }
            else
            {
                txtDatetime.Size = new Size(this.Size.Width - 21, 21);
                jm_pb_Date.Location = new Point(txtDatetime.Location.X + txtDatetime.Width, 0);
                this.Size = new Size(txtDatetime.Width + 21, 21);
            }
        }

        #region 日期选择
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtDatetime.Text = e.Start.ToString("yyyy-MM-dd");
            this.frmCalen.Hide();
        }
        #endregion

        private void txtDatetime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtDatetime.Text = "";
                e.Handled = true;
            }
        }
    }
}
