using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmSelectComboBox : Form
    {
        Label jmlb;

        /// <summary>
        /// 是否隐藏当前窗体
        /// </summary>
        bool SFVisble = true;

        string Names = "";

        string BH = "";

        #region 属性
        /// <summary>
        /// 显示值
        /// </summary>
        private DataTable _JMDT;

        [Description("显示值")]
        public DataTable JMDT
        {
            get { return _JMDT; }
            set { _JMDT = value; Fill(); }
        }

        /// <summary>
        /// 编号列
        /// </summary>
        private string _JMBHLie;

        [Description("编号列")]
        public string JMBHLie
        {
            get { return _JMBHLie; }
            set { _JMBHLie = value; }
        }

        /// <summary>
        /// 名称列
        /// </summary>
        private string _JMNameLie;

        [Description("名称列")]
        public string JMNameLie
        {
            get { return _JMNameLie; }
            set { _JMNameLie = value; }
        }

        /// <summary>
        /// 是否显示右键菜单
        /// </summary>
        private bool _JMVisibleYJ;

        [Description("是否显示右键菜单")]
        public bool JMVisibleYJ
        {
            get { return _JMVisibleYJ; }
            set { _JMVisibleYJ = value; }
        }

        /// <summary>
        /// 是否显示增加按钮
        /// </summary>
        private bool _JMVisibleAdd;

        [Description("是否显示增加按钮")]
        public bool JMVisibleAdd
        {
            get { return _JMVisibleAdd; }
            set { _JMVisibleAdd = value; jm_btn_Add.Visible = value; }
        }
        #endregion

        #region 事件
        public event JMDelegate.IEventHandle JMAddAndUpdateClick;

        public event JMDelegate.ClickDeleteHandel JMSelectClick;

        public event JMDelegate.IEventHandle JMDelClick;
        #endregion

        /// <summary>
        /// 填充
        /// </summary>
        private void Fill()
        {
            panel2.Controls.Clear();
            if (_JMDT == null)
            {
                return;
            }
            for (int i = 0; i < _JMDT.Rows.Count; i++)
            {
                //定义控件
                jmlb = new Label();
                jmlb.Name = "Label" + (i + 1).ToString();
                jmlb.AutoSize = true;
                jmlb.Tag = _JMDT.Rows[i][_JMBHLie].ToString();
                jmlb.Cursor = Cursors.Hand;
                jmlb.Text = _JMDT.Rows[i][_JMNameLie].ToString();
                jmlb.Margin = new Padding(15, 15, 0, 0);
                //事件
                jmlb.MouseEnter += new EventHandler(jmlb_MouseEnter);
                jmlb.MouseLeave += new EventHandler(jmlb_MouseLeave);
                jmlb.MouseClick += new MouseEventHandler(jmlb_MouseClick);
                //添加控件
                panel2.Controls.Add(jmlb);
            }
        }

        /// <summary>
        /// 调用添加窗体
        /// </summary>
        private void ADDFrom()
        {
            Screen cre = Screen.PrimaryScreen;
            Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
            FrmTypeAdd frm = new FrmTypeAdd(CBRect.X + (CBRect.Width - 318) / 2, CBRect.Y + (CBRect.Height - 125) / 2);
            frm.JMAddAndUpdateClick += new JMDelegate.IEventHandle(frm_JMADDAndUpdate);
            SFVisble = false;
            frm.Focus();
            frm.ShowDialog();
            SFVisble = true;
        }

        private void UpdateFrom()
        {
            Screen cre = Screen.PrimaryScreen;
            Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
            FrmTypeAdd frm = new FrmTypeAdd(CBRect.X + (CBRect.Width - 318) / 2, CBRect.Y + (CBRect.Height - 125) / 2);
            frm.BianHao = BH;
            frm.Names = Names;
            frm.JMAddAndUpdateClick += new JMDelegate.IEventHandle(frm_JMADDAndUpdate);
            SFVisble = false;
            frm.Focus();
            frm.ShowDialog();
            SFVisble = true;
        }

        public FrmSelectComboBox()
        {
            InitializeComponent();
            _JMVisibleAdd = true;
            _JMVisibleYJ = true;
        }

        #region 窗体加载
        private void FrmTypeSelect_Load(object sender, EventArgs e)
        {
            panel2.MouseWheel += new MouseEventHandler(panel2_MouseWheel);
            timer1.Enabled = true;
            textBox1.Focus();
            textBox1.Select();
        }
        #endregion

        #region 新增按钮
        private void jm_btn_Add_Click(object sender, EventArgs e)
        {
            ADDFrom();
        }
        #endregion

        #region 取消按钮
        private void jm_btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        #region 右键菜单
        #region 新增
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADDFrom();
        }
        #endregion

        #region 修改
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFrom();
        }
        #endregion

        #region 删除
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (JMDelClick != null)
            {
                JEventargs ee = new JEventargs();
                ee.Tag = BH;
                ee.Text = Names;
                JMDelClick(this, ee);
            }
        }
        #endregion
        #endregion

        #region 添加/修改事件
        private void frm_JMADDAndUpdate(object sender, JEventargs e)
        {
            if (JMAddAndUpdateClick != null)
            {
                JMAddAndUpdateClick(sender, e);
                if (e.Cancel)
                {
                    panel2.VerticalScroll.Value = 1;
                }
            }
        }
        #endregion

        #region 鼠标单击事件
        private void jmlb_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (JMSelectClick != null)
                {
                    JMSelectClick((sender as Label).Tag.ToString(), (sender as Label).Text.Trim());
                    this.Hide();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_JMVisibleYJ)
                {
                    jContextMenuStrip1.Show((sender as Label), new Point(0, (sender as Label).Height - 1));
                    BH = (sender as Label).Tag.ToString();
                    Names = (sender as Label).Text.Trim();
                }
            }
        }
        #endregion

        #region 鼠标进入和离开事件
        private void jmlb_MouseEnter(object sender, EventArgs e)
        {
            foreach (var kj in panel2.Controls)
            {
                if (kj.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    (kj as Label).BackColor = Color.Transparent;
                }
            }
            (sender as Label).BackColor = Color.LightGray;
        }

        private void jmlb_MouseLeave(object sender, EventArgs e)
        {
            foreach (var kj in panel2.Controls)
            {
                if (kj.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    (kj as Label).BackColor = Color.Transparent;
                }
            }
        }
        #endregion

        #region 窗体停用事件
        private void FrmTypeSelect_Deactivate(object sender, EventArgs e)
        {
            if (SFVisble)
            {
                jContextMenuStrip1.Hide();
                this.Hide();
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timer1.Enabled = false;
                this.jScrollbar1.Minimum = 0;
                this.jScrollbar1.Maximum = this.panel2.VerticalScroll.Maximum - panel2.Height + 1;
                this.jScrollbar1.LargeChange = this.panel2.VerticalScroll.LargeChange;
                if (this.panel2.VerticalScroll.Maximum > panel2.Height + 1)
                {
                    jScrollbar1.Visible = true;
                }
                else
                {
                    jScrollbar1.Visible = false;
                }
            }
        }

        private void jScrollbar1_Scroll(object sender, EventArgs e)
        {
            panel2.VerticalScroll.Value = jScrollbar1.Value;
        }

        #region 滚动框事件
        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
            jScrollbar1.Value = panel2.VerticalScroll.Value;
        }
        #endregion

        #region 鼠标滚动
        private void panel2_MouseWheel(object sender, MouseEventArgs e)
        {
            jScrollbar1.Value = panel2.VerticalScroll.Value;
        }
        #endregion

        #region 鼠标进入事件
        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.Focus();
        }
        #endregion

        #region Esc取消当前窗体
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Hide();
            }
        }
        #endregion
    }
}