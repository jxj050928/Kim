using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data;

namespace JMControlsEx
{
    /// <summary>
    /// ComboBoxAdd
    /// </summary>
    [DefaultEvent("ClikeBootomButton")]
    public partial class JMComboBoxAdd : UserControl
    {
        private IContainer components;

        public delegate void ClikeEventHandle(string _text, WizardClickEventArgs e, object sender);
        /// <summary>
        /// 单击添加
        /// </summary>
        public event ClikeEventHandle ClikeBootomButton;

        /// <summary>
        /// treeview单击事件
        /// </summary>
        public event JMDelegate.ClickItemHandel JMClickXZ;

        #region Private 属性
        private Panel pnlBack;
        private Panel pnlTree;
        /// <summary>
        /// 文本框
        /// </summary>
        private JMTextBox tbSelectedValue;
        /// <summary>
        /// 下拉按钮
        /// </summary>
        private ButtonEx btnSelect;
        /// <summary>
        /// 下拉框里的容器
        /// </summary>
        private ListBox tvTreeView;
        /// <summary>
        /// 用于改变下拉框大小
        /// </summary>
        private LabelEx lblSizingGrip;
        /// <summary>
        /// 存放下拉框的窗体
        /// </summary>
        private Form frmTreeView;
        /// <summary>
        /// 下拉框大小
        /// </summary>
        private Size zExSize;
        /// <summary>
        /// 添加
        /// </summary>
        private Label picbtn;
        /// <summary>
        /// 查找
        /// </summary>
        private Label picsel;
        /// <summary>
        /// 添加查找文本框
        /// </summary>
        private JMTextBox jmtxt;

        private Point DragOffset;
        private ToolTip toolTip1;

        /// <summary>
        /// 下拉按钮中小山角颜色
        /// </summary>
        private Color _acolor;

        private string _tipText;

        public string TipText
        {
            get { return _tipText; }
            set { _tipText = value; this.toolTip1.SetToolTip(tbSelectedValue, value); }
        }

        public string ZEmptyTextTip
        {
            get { return tbSelectedValue.ZEmptyTextTip; }
            set { tbSelectedValue.ZEmptyTextTip = value; Invalidate(); }
        }
        #endregion

        #region 构造函数
        public JMComboBoxAdd()
        {
            this.InitializeComponent();
            _acolor = Color.FromArgb(19, 88, 128);
            zExSize = new Size(200, 300);

            this.pnlBack = new Panel();
            this.pnlBack.BorderStyle = BorderStyle.None;
            this.pnlBack.BackColor = Color.White;
            this.pnlBack.AutoScroll = false;
            this.pnlBack.Dock = DockStyle.Fill;

            this.tbSelectedValue = new JMTextBox();
            this.tbSelectedValue.BorderStyle = BorderStyle.FixedSingle;
            this.tbSelectedValue.ZEmptyTextTip = "";
            this.tbSelectedValue.ReadOnlyChanged += new EventHandler(tbSelectedValue_ReadOnlyChanged);


            this.btnSelect = new ButtonEx(_acolor, ZBorderColor);
            this.btnSelect.Click += new EventHandler(ToggleTreeView);
            this.btnSelect.FlatStyle = FlatStyle.Flat;

            this.lblSizingGrip = new LabelEx();
            this.lblSizingGrip.Size = new Size(9, 9);
            this.lblSizingGrip.BackColor = Color.Transparent;
            this.lblSizingGrip.Cursor = Cursors.SizeNWSE;
            this.lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
            this.lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

            this.tvTreeView = new ListBox();
            this.tvTreeView.BorderStyle = BorderStyle.None;
            this.tvTreeView.SelectedIndexChanged += new EventHandler(tvTreeView_SelectedIndexChanged);
            this.tvTreeView.MouseDoubleClick += new MouseEventHandler(TreeViewNodeSelect);
            this.tvTreeView.Location = new Point(0, 0);
            //this.tvTreeView.Scrollable = false;            

            this.frmTreeView = new Form();
            this.frmTreeView.FormBorderStyle = FormBorderStyle.None;
            this.frmTreeView.BringToFront();
            this.frmTreeView.StartPosition = FormStartPosition.Manual;
            this.frmTreeView.ShowInTaskbar = false;
            this.frmTreeView.BackColor = SystemColors.Control;
            this.frmTreeView.Size = new Size(200, 300);
            this.frmTreeView.Deactivate += new EventHandler(frmTreeView_Deactivate);

            this.pnlTree = new Panel();
            this.pnlTree.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTree.BackColor = Color.White;
            this.pnlTree.Dock = DockStyle.Fill;
            this.pnlTree.Size = new Size(200, 300);

            this.picbtn = new Label();
            this.picbtn.Cursor = Cursors.Hand;
            this.picbtn.Size = new Size(30, 12);
            this.picbtn.AutoSize = false;
            this.picbtn.Location = new Point(120, 275);
            this.picbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.picbtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.picbtn.Text = "添加";
            this.picbtn.Click += new EventHandler(picbtn_Click);

            this.picsel = new Label();
            this.picsel.Cursor = Cursors.Hand;
            this.picsel.Size = new Size(30, 12);
            this.picsel.AutoSize = false;
            this.picsel.Location = new Point(155, 275);
            this.picsel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.picsel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.picsel.Text = "查找";
            this.picsel.Click += new EventHandler(picsel_Click);

            this.jmtxt = new JMTextBox();
            this.jmtxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jmtxt.Size = new Size(110, 21);
            this.jmtxt.Location = new Point(5, 270);
            this.jmtxt.ZEmptyTextTip = "-录入值-";

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Adding Controls to UserControl
            this.pnlTree.Controls.Add(this.lblSizingGrip);
            this.pnlTree.Controls.Add(this.tvTreeView);
            this.pnlTree.Controls.Add(this.jmtxt);
            this.pnlTree.Controls.Add(this.picbtn);
            this.pnlTree.Controls.Add(this.picsel);
            this.frmTreeView.Controls.Add(this.pnlTree);
            this.pnlBack.Controls.AddRange(new Control[] { btnSelect, tbSelectedValue });
            this.Controls.Add(this.pnlBack);

        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // JMComboBoxAdd
            // 
            this.MaximumSize = new System.Drawing.Size(500, 21);
            this.MinimumSize = new System.Drawing.Size(100, 21);
            this.Name = "JMComboBoxAdd";
            this.Size = new System.Drawing.Size(100, 21);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ComboBoxTree_Layout);
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        #region Public 属性
        [DefaultValue(typeof(Color), "19, 88, 128")]
        public Color ZArrowColor
        {
            get { return _acolor; }
            set
            {
                if (_acolor != value)
                {
                    _acolor = value;
                    btnSelect.ArrowColor = value;
                    Invalidate();
                }
            }
        }

        [Category("Appearance"),
        Description("边框颜色"),
        DefaultValue(typeof(Color), "51, 161, 224")]
        public Color ZBorderColor
        {
            get
            {
                return tbSelectedValue.ZBorderColor;
            }
            set
            {
                tbSelectedValue.ZBorderColor = value;
                btnSelect.BaseColor = value;
                Invalidate();
            }
        }

        public int SelectedIndex
        {
            get { return tvTreeView.SelectedIndex; }
            set
            {
                tvTreeView.SelectedIndex = value;
                if (value < 0)
                {
                    this.Text = "";
                }
                else
                {
                    this.Text = tvTreeView.Text;
                }
            }
        }

        public object SelectedValue
        {
            get { return tvTreeView.SelectedValue; }
            set
            {
                tvTreeView.SelectedValue = value;
                if (value == null)
                {
                    this.Text = "";
                }
                else
                {
                    this.Text = tvTreeView.Text;
                }
            }
        }

        public object DataSource
        {
            get { return tvTreeView.DataSource; }
            set { tvTreeView.DataSource = value; }
        }

        public string DisplayMember
        {
            get { return tvTreeView.DisplayMember; }
            set { tvTreeView.DisplayMember = value; }
        }

        public string ValueMember
        {
            get { return tvTreeView.ValueMember; }
            set { tvTreeView.ValueMember = value; }
        }

        public Color TextForeColor
        {
            set { this.tbSelectedValue.ForeColor = value; }
        }

        public Color TextBackColor
        {
            set { this.tbSelectedValue.BackColor = value; }
        }

        /// <summary>
        /// 文本只读属性
        /// </summary>
        public bool TextReadOnly
        {
            set { this.tbSelectedValue.ReadOnly = value; }
        }

        /// <summary>
        /// 显示选中的值
        /// </summary>
        public override string Text
        {
            get { return this.tbSelectedValue.Text; }
            set
            {
                this.tbSelectedValue.Text = value;
                this.tvTreeView.Text = value;
            }
        }

        /// <summary>
        /// 下拉框展开大小
        /// </summary>
        public Size ZExSize
        {
            get { return zExSize; }
            set { zExSize = value; frmTreeView.Size = value; }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 拖动树背景，改变背景大小
        /// </summary>
        private void RelocateGrip()
        {
            this.lblSizingGrip.Top = this.frmTreeView.Height - lblSizingGrip.Height - 1;
            this.lblSizingGrip.Left = this.frmTreeView.Width - lblSizingGrip.Width - 1;
        }
        #endregion

        #region 事件

        #region 查找
        private void picsel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tvTreeView.Items.Count; i++)
            {
                DataRowView drv = tvTreeView.Items[i] as DataRowView;

                if (drv[DisplayMember].ToString().IndexOf(jmtxt.Text.Trim()) >= 0)
                {
                    tvTreeView.SelectedIndex = i;
                    return;
                }
            }
        }
        #endregion

        #region 添加
        private void picbtn_Click(object sender, EventArgs e)
        {
            //if (jmtxt.Text != "")
            //{
            //MessageBoxJ.Show("内容不允许为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //return;

            if (ClikeBootomButton != null)
            {
                WizardClickEventArgs arg = new WizardClickEventArgs();
                ClikeBootomButton(jmtxt.Text, arg, this);
                if (arg.Cancel)
                {
                    return;
                }
                for (int i = 0; i < tvTreeView.Items.Count; i++)
                {
                    DataRowView drv = tvTreeView.Items[i] as DataRowView;

                    if (drv[DisplayMember].ToString() == jmtxt.Text.Trim())
                    {
                        tvTreeView.SelectedIndex = i;
                        return;
                    }
                }
            }
            //}
        }
        #endregion

        #region 下拉框失去焦点
        private void frmTreeView_Deactivate(object sender, EventArgs e)
        {
            this.frmTreeView.Hide();
        }
        #endregion

        /// <summary>
        /// 点击三角按钮，显示树Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleTreeView(object sender, EventArgs e)
        {
            if (!this.frmTreeView.Visible)
            {
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                this.frmTreeView.Location = new Point(CBRect.X, CBRect.Y + this.pnlBack.Height);
                this.frmTreeView.Show();
                this.frmTreeView.BringToFront();
                this.RelocateGrip();
            }
            else
            {
                this.frmTreeView.Hide();
            }
        }

        /// <summary>
        /// 改变背景大小，在鼠标移动时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizingGripMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int TvWidth, TvHeight;
                TvWidth = Cursor.Position.X - this.frmTreeView.Location.X;
                TvWidth = TvWidth + this.DragOffset.X;
                TvHeight = Cursor.Position.Y - this.frmTreeView.Location.Y;
                TvHeight = TvHeight + this.DragOffset.Y;

                if (TvWidth < 50)
                    TvWidth = 50;
                if (TvHeight < 50)
                    TvHeight = 50;
                this.frmTreeView.Size = new Size(TvWidth, TvHeight);
                this.tvTreeView.Size = new Size(this.frmTreeView.Size.Width, this.frmTreeView.Size.Height - this.lblSizingGrip.Height - 20);
                RelocateGrip();
            }
        }

        /// <summary>
        /// 改变背景大小，在按下鼠标时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizingGripMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int OffsetX = Math.Abs(Cursor.Position.X - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Right);
                int OffsetY = Math.Abs(Cursor.Position.Y - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Bottom);

                this.DragOffset = new Point(OffsetX, OffsetY);
            }
        }

        /// <summary>
        /// 选中树型空间节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewNodeSelect(object sender, EventArgs e)
        {
            this.tbSelectedValue.Text = this.tvTreeView.Text;
            if (this.tvTreeView.Text != "")
            {
                this.frmTreeView.Hide();
                if (JMClickXZ != null)
                {
                    JMClickXZ(this.SelectedValue.ToString());
                }
            }
        }



        void tvTreeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbSelectedValue.Text = this.tvTreeView.Text;
            if (this.tvTreeView.Text != "")
            {
                if (JMClickXZ != null)
                {
                    JMClickXZ(this.SelectedValue.ToString());
                }
            }
        }

        /// <summary>
        /// 改变大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxTree_Layout(object sender, LayoutEventArgs e)
        {
            this.pnlBack.Size = this.Size;
            this.btnSelect.Location = new Point(this.Width - 15, 2);
            this.tbSelectedValue.Location = new Point(0, 0);
            this.tbSelectedValue.Width = this.Width;
            this.frmTreeView.Size = zExSize;
            this.pnlTree.Size = this.frmTreeView.Size;
            this.tvTreeView.Width = this.frmTreeView.Width;
            this.tvTreeView.Height = this.frmTreeView.Height - this.lblSizingGrip.Height - 20;
            this.RelocateGrip();
        }

        /// <summary>
        /// 文本只读事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSelectedValue_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (this.tbSelectedValue.ReadOnly)
            {
                this.tbSelectedValue.BackColor = Color.White;
            }
        }
        #endregion

        #region 背景Label
        private class LabelEx : Label
        {
            /// <summary>
            /// 
            /// </summary>
            public LabelEx()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                ControlPaint.DrawSizeGrip(e.Graphics, Color.Black, 1, 0, this.Size.Width, this.Size.Height);
            }
        }
        #endregion

        #region 三角形按钮
        private class ButtonEx : Button
        {
            private Color _arrowColor;

            public Color ArrowColor
            {
                get { return _arrowColor; }
                set { _arrowColor = value; Invalidate(); }
            }
            private Color _baseColor;

            public Color BaseColor
            {
                get { return _baseColor; }
                set { _baseColor = value; Invalidate(); }
            }

            ControlState constate = ControlState.Normal;

            /// <summary>
            /// 
            /// </summary>
            public ButtonEx(Color a, Color b)
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.Size = new Size(13, 17);
                _arrowColor = a;
                _baseColor = b;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                constate = ControlState.Pressed;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseUp(MouseEventArgs e)
            {
                base.OnMouseUp(e);
                constate = ControlState.Hover;
            }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                constate = ControlState.Hover;
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                constate = ControlState.Normal;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Rectangle rec = new Rectangle(0, 0, 13, 17);
                //ControlPaint.DrawComboButton(e.Graphics, 0, 0, this.Width, this.Height, state);
                RenderConboBoxDropDownButton(e.Graphics, rec, constate);
            }

            private void RenderConboBoxDropDownButton(
            Graphics g,
            Rectangle buttonRect,
            ControlState state)
            {
                Color baseColor;
                Color backColor = Color.FromArgb(160, 250, 250, 250);
                Color borderColor = base.Enabled ?
                    _baseColor : SystemColors.ControlDarkDark;
                Color arrowColor = base.Enabled ?
                    _arrowColor : SystemColors.ControlDarkDark;
                Rectangle rect = buttonRect;

                if (base.Enabled)
                {
                    switch (state)
                    {
                        case ControlState.Hover:
                            baseColor = ColorClass.GetColor(
                                _baseColor, 0, -33, -22, -13);
                            break;
                        case ControlState.Pressed:
                            baseColor = ColorClass.GetColor(
                                _baseColor, 0, -65, -47, -25);
                            break;
                        default:
                            baseColor = _baseColor;
                            break;
                    }
                }
                else
                {
                    baseColor = SystemColors.ControlDark;
                }

                RenderScrollBarArrowInternal(
                    g,
                    rect,
                    baseColor,
                    borderColor,
                    backColor,
                    arrowColor,
                    RoundStyle.None,
                    true,
                    false,
                    ArrowDirection.Down,
                    LinearGradientMode.Vertical);
            }

            internal void RenderScrollBarArrowInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           Color arrowColor,
           RoundStyle roundStyle,
           bool drawBorder,
           bool drawGlass,
           ArrowDirection arrowDirection,
           LinearGradientMode mode)
            {
                ControlPaintClass.RenderBackgroundInternal(
                   g,
                   rect,
                   baseColor,
                   borderColor,
                   innerBorderColor,
                   roundStyle,
                   0,
                   .45F,
                   drawBorder,
                   drawGlass,
                   mode);

                using (SolidBrush brush = new SolidBrush(arrowColor))
                {
                    RenderArrowInternal(
                        g,
                        rect,
                        arrowDirection,
                        brush);
                }
            }

            internal void RenderArrowInternal(
                Graphics g,
                Rectangle dropDownRect,
                ArrowDirection direction,
                Brush brush)
            {
                Point point = new Point(
                    dropDownRect.Left + (dropDownRect.Width / 2),
                    dropDownRect.Top + (dropDownRect.Height / 2));
                Point[] points = null;
                switch (direction)
                {
                    case ArrowDirection.Left:
                        points = new Point[] { 
                        new Point(point.X + 2, point.Y - 3), 
                        new Point(point.X + 2, point.Y + 3), 
                        new Point(point.X - 1, point.Y) };
                        break;

                    case ArrowDirection.Up:
                        points = new Point[] { 
                        new Point(point.X - 3, point.Y + 2), 
                        new Point(point.X + 3, point.Y + 2), 
                        new Point(point.X, point.Y - 2) };
                        break;

                    case ArrowDirection.Right:
                        points = new Point[] {
                        new Point(point.X - 2, point.Y - 3), 
                        new Point(point.X - 2, point.Y + 3), 
                        new Point(point.X + 1, point.Y) };
                        break;

                    default:
                        points = new Point[] {
                        new Point(point.X - 2, point.Y - 1), 
                        new Point(point.X + 3, point.Y - 1), 
                        new Point(point.X, point.Y + 2) };
                        break;
                }
                g.FillPolygon(brush, points);
            }
        }
        #endregion

    }

}

