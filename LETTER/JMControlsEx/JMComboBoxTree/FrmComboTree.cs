using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmComboTree : Form
    {
        /// <summary>
        /// 编码方案每级长度
        /// </summary>
        private const int leve = 3;

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

        [Description("绑定数据集")]
        public DataTable JMDT
        {
            get { return _JMDT; }
            set { _JMDT = value; flowLayoutPanel1.Controls.Clear(); Fill(""); }
        }

        /// <summary>
        /// 编号列
        /// </summary>
        private string _JMBHLie = "Hao";

        [Description("编号列(数据库字段)")]
        public string JMBHLie
        {
            get { return _JMBHLie; }
            set { _JMBHLie = value; }
        }

        /// <summary>
        /// 名称列
        /// </summary>
        private string _JMNameLie = "ming";

        [Description("名称列(数据库字段)")]
        public string JMNameLie
        {
            get { return _JMNameLie; }
            set { _JMNameLie = value; }
        }

        /// <summary>
        /// 是否显示增加按钮、右键菜单
        /// </summary>
        private bool _JMVisibleADDandYJ;

        [Description("是否显示增加按钮、右键菜单")]
        public bool JMVisibleADDandYJ
        {
            get { return _JMVisibleADDandYJ; }
            set
            {
                _JMVisibleADDandYJ = value;
            }
        }

        private bool _shwoAddCancel = true;

        public bool ShwoAddCancel
        {
            get { return _shwoAddCancel; }
            set
            {
                _shwoAddCancel = value;
            }
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
        private void Fill(string id)
        {
            panel2.Controls.Clear();
            if (_JMDT == null)
            {
                return;
            }
            int len = id.Length + leve;
            for (int i = 0; i < _JMDT.Rows.Count; i++)
            {
                if (_JMDT.Rows[i][_JMBHLie].ToString().Length != len)
                {
                    continue;
                }
                if (_JMDT.Rows[i][_JMBHLie].ToString().StartsWith(id))
                {
                    //定义控件
                    ComboTreeNode jmlb = new ComboTreeNode();
                    jmlb.ForeColor = Color.FromArgb(0, 133, 0);
                    jmlb.Name = "Label" + (i + 1).ToString();
                    jmlb.ZID = _JMDT.Rows[i][_JMBHLie];
                    jmlb.ZText = _JMDT.Rows[i][_JMNameLie].ToString();
                    jmlb.IsExpland = _JMDT.Select(JMBHLie + " like '" + jmlb.ZID + "%' and len(" + JMBHLie + ")=" + (len + leve) + "").Length < 1;
                    jmlb.Margin = new Padding(15, 15, 0, 0);
                    //事件
                    jmlb.TextSelected += new MouseEventHandler(jmlb_TextSelected);
                    jmlb.Explaned += new MouseEventHandler(jmlb_Explaned);
                    jmlb.MouseClick += new MouseEventHandler(jmlb_MouseClick);
                    jmlb.MouseDownMinut += new EventHandler(jmlb_MouseDownMinut);
                    //添加控件
                    panel2.Controls.Add(jmlb);
                }
            }
        }

        /// <summary>
        /// 调用窗体
        /// </summary>
        /// <param name="_Type"></param>
        private void ShowFrom(string _Type)
        {
            Screen cre = Screen.PrimaryScreen;
            Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
            FrmTreeNodeAdd frm = new FrmTreeNodeAdd(CBRect.X + (CBRect.Width - 318) / 2, CBRect.Y + (CBRect.Height - 125) / 2);
            frm.BianHao = BH;
            if (_Type.Length == 4)
            {
                frm.BianHao += "001";
            }
            frm.Names = Names;
            frm.TypeCtl = _Type.Trim();
            frm.JMAddAndUpdateClick += new JMDelegate.IEventHandle(frm_JMADDAndUpdate);
            SFVisble = false;
            frm.Focus();
            frm.ShowDialog();
            SFVisble = true;
        }

        public FrmComboTree()
        {
            InitializeComponent();
            _JMVisibleADDandYJ = true;
        }

        #region 窗体加载
        private void FrmTypeSelect_Load(object sender, EventArgs e)
        {
            panel2.MouseWheel += new MouseEventHandler(panel2_MouseWheel);
            timer1.Enabled = true;
        }
        #endregion

        #region 新增按钮
        private void jm_btn_Add_Click(object sender, EventArgs e)
        {
            ShowFrom("ADD");
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
            ShowFrom("ADD");
        }


        private void MenuItemAddC_Click(object sender, EventArgs e)
        {
            ShowFrom("ADD ");
        }
        #endregion

        #region 修改
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFrom("UPDATE");
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

        /// <summary>
        /// 单击内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jmlb_TextSelected(object sender, MouseEventArgs e)
        {
            if (JMSelectClick != null)
            {
                JMSelectClick((sender as ComboTreeNode).ZID.ToString(), (sender as ComboTreeNode).ZText.Trim());
                this.Hide();
            }
        }

        private void jmlb_MouseDownMinut(object sender, EventArgs e)
        {
            if (_JMVisibleADDandYJ)
            {
                jContextMenuStrip1.Show((sender as ComboTreeNode), new Point((sender as ComboTreeNode).Width, 0));
                BH = (sender as ComboTreeNode).ZID.ToString();
                Names = (sender as ComboTreeNode).ZText.Trim();
            }
        }

        /// <summary>
        /// 单击内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jmlb_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_JMVisibleADDandYJ)
                {
                    jContextMenuStrip1.Show((sender as ComboTreeNode), new Point((sender as ComboTreeNode).Width, 0));
                    BH = (sender as ComboTreeNode).ZID.ToString();
                    Names = (sender as ComboTreeNode).ZText.Trim();
                }
            }
        }

        /// <summary>
        /// 单击展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jmlb_Explaned(object sender, MouseEventArgs e)
        {
            ComboTreeNode cbtnoed = sender as ComboTreeNode;
            Label lab = new Label();
            lab.AutoSize = true;
            lab.Margin = new Padding(3, 10, 0, 0);
            lab.Text = cbtnoed.ZText.ToString() + ">";
            lab.Tag = cbtnoed.ZID;
            lab.Cursor = Cursors.Hand;
            lab.ForeColor = Color.FromArgb(0, 133, 0);
            lab.Click += new EventHandler(lab_Click);
            flowLayoutPanel1.Controls.Add(lab);
            Fill(cbtnoed.ZID.ToString());
        }

        private void lab_Click(object sender, EventArgs e)
        {
            Label lab = sender as Label;
            for (int i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                Label labitm = flowLayoutPanel1.Controls[i] as Label;
                if (labitm.TabIndex >= lab.TabIndex)
                    flowLayoutPanel1.Controls.Remove(labitm);
            }
            Fill(lab.Tag.ToString().Substring(0, lab.Tag.ToString().Length - leve));
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

    }
}