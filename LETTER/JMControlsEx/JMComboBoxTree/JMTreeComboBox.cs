using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    /// <summary>
    /// TreeViewComboBox 的摘要说明。
    /// </summary>
    public partial class JMTreeComboBox : UserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private Container components = null;

        public delegate void ClikeEventHandle(object sender, WizardClickEventArgs e);

        public event ClikeEventHandle BeforExplan;

        public event ClikeEventHandle BeforTextChange;

        public event TreeViewCancelEventHandler TreeBeforExplan;

        public delegate void EventHandle(TreeNode n);
        public event EventHandle AfterSelectedNode;
        public event EventHandle AfterSelectedNodeClike;
        private bool _allowSelectParentNode = false;

        public JMTreeComboBox()
        {
            this.InitializeComponent();
            _acolor = Color.FromArgb(19, 88, 128);
            // Initializing Controls
            this.pnlBack = new Panel();
            this.pnlBack.BorderStyle = BorderStyle.None;
            this.pnlBack.BackColor = Color.White;
            this.pnlBack.AutoScroll = false;
            this.pnlBack.Dock = DockStyle.Fill;

            this.tbSelectedValue = new JMTextBox();
            this.tbSelectedValue.BorderStyle = BorderStyle.FixedSingle;
            this.tbSelectedValue.ZEmptyTextTip = "";
            this.tbSelectedValue.Click += new EventHandler(tbSelectedValue_Click);
            this.tbSelectedValue.ReadOnlyChanged += new EventHandler(tbSelectedValue_ReadOnlyChanged);
            this.tbSelectedValue.KeyPress += new KeyPressEventHandler(tbSelectedValue_KeyPress);

            this.btnSelect = new ButtonEx(_acolor, ZBorderColor);
            this.btnSelect.Click += new EventHandler(ToggleTreeView);
            this.btnSelect.FlatStyle = FlatStyle.Flat;

            this.lblSizingGrip = new LabelEx();
            this.lblSizingGrip.Size = new Size(9, 9);
            this.lblSizingGrip.BackColor = Color.Transparent;
            this.lblSizingGrip.Cursor = Cursors.SizeNWSE;
            this.lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
            this.lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

            this.tvTreeView = new TreeView();
            this.tvTreeView.BorderStyle = BorderStyle.None;
            this.tvTreeView.DoubleClick += new EventHandler(TreeViewNodeSelect);
            this.tvTreeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(tvTreeView_NodeMouseClick);
            this.tvTreeView.BeforeExpand += new TreeViewCancelEventHandler(tvTreeView_BeforeExpand);
            this.tvTreeView.Location = new Point(0, 0);
            this.tvTreeView.LostFocus += new EventHandler(TreeViewLostFocus);
            //this.tvTreeView.Scrollable = false;

            this.frmTreeView = new Form();
            this.frmTreeView.FormBorderStyle = FormBorderStyle.None;
            this.frmTreeView.BringToFront();
            this.frmTreeView.StartPosition = FormStartPosition.Manual;
            this.frmTreeView.ShowInTaskbar = false;
            this.frmTreeView.BackColor = SystemColors.Control;

            this.pnlTree = new Panel();
            this.pnlTree.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTree.BackColor = Color.White;

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Adding Controls to UserControl
            this.pnlTree.Controls.Add(this.lblSizingGrip);
            this.pnlTree.Controls.Add(this.tvTreeView);
            this.frmTreeView.Controls.Add(this.pnlTree);
            this.pnlBack.Controls.AddRange(new Control[] { btnSelect, tbSelectedValue });
            this.Controls.Add(this.pnlBack);
            zExSize = new Size(200, 300);
        }
        /// <summary>
        /// 树节点展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void tvTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
           
            if (TreeBeforExplan!=null)
            {
                TreeBeforExplan(sender, e);
            }
        }

        private void tbSelectedValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (BeforTextChange != null)
            {
                WizardClickEventArgs ea = new WizardClickEventArgs();
                BeforTextChange(sender, ea);
                if (ea.Cancel)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (_textReadOnly)
            {
                if (e.KeyChar == 8)
                {
                    this.Text = "";
                    this.Tag = null;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void tbSelectedValue_Click(object sender, EventArgs e)
        {
            //if (_textReadOnly)
            //{
            //    ToggleTreeView(sender, e);
            //}
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
            this.SuspendLayout();
            // 
            // JMTreeComboBox
            // 
            this.MaximumSize = new System.Drawing.Size(500, 21);
            this.MinimumSize = new System.Drawing.Size(100, 21);
            this.Name = "JMTreeComboBox";
            this.Size = new System.Drawing.Size(100, 21);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ComboBoxTree_Layout);
            this.ResumeLayout(false);

        }
        #endregion

        #region Private 属性
        private Panel pnlBack;
        private Panel pnlTree;
        private JMTextBox tbSelectedValue;
        private ButtonEx btnSelect;
        private TreeView tvTreeView;
        private LabelEx lblSizingGrip;
        private Form frmTreeView;
        private Size zExSize;
        //  private string _branchSeparator;
        //  private bool _absoluteChildrenSelectableOnly;
        private Point DragOffset;

        private Color _acolor;
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

        /// <summary>
        /// 是否允许选择非叶子节点
        /// </summary>
        public bool AllowSelectParentNode
        {
            set
            {
                _allowSelectParentNode = value;
            }
            get
            {
                return _allowSelectParentNode;
            }
        }

        public Color TextForeColor
        {
            set { this.tbSelectedValue.ForeColor = value; }
        }

        public Color TextBackColor
        {
            set { this.tbSelectedValue.BackColor = value; }
        }

        private bool _textReadOnly;

        /// <summary>
        /// 文本只读属性
        /// </summary>
        public bool TextReadOnly
        {
            set { _textReadOnly = value; }
            get { return _textReadOnly; }
        }

        /// <summary>
        /// 树节点集合
        /// </summary>
        public TreeNodeCollection Nodes
        {
            get
            {
                return this.tvTreeView.Nodes;
            }
        }

        /// <summary>
        /// 选中的节点
        /// </summary>
        public TreeNode SelectedNode
        {
            set
            {
                this.tvTreeView.SelectedNode = value;
            }
            get
            {
                return this.tvTreeView.SelectedNode;
            }
        }

        /// <summary>
        /// ImageList
        /// </summary>
        public ImageList Imagelist
        {
            get { return this.tvTreeView.ImageList; }
            set { this.tvTreeView.ImageList = value; }
        }

        /// <summary>
        /// 显示选中的值
        /// </summary>
        public override string Text
        {
            get { return this.tbSelectedValue.Text; }
            set { this.tbSelectedValue.Text = value; }
        }

        /// <summary>
        /// 下拉框展开大小
        /// </summary>
        public Size ZExSize
        {
            get { return zExSize; }
            set { zExSize = value; }
        }
        //  /// <summary>
        //  /// 显示完整树节点路径时，路经的分隔符（1位字符）
        //  /// </summary>
        //  public string BranchSeparator
        //  {
        //   get {return this._branchSeparator;}
        //   set
        //   {
        //    if(value.Length > 0)
        //     this._branchSeparator = value.Substring(0,1);
        //   }
        //  }
        //
        //  /// <summary>
        //  /// 是否是叶子节点
        //  /// </summary>
        //  public bool AbsoluteChildrenSelectableOnly
        //  {
        //   get {return this._absoluteChildrenSelectableOnly;}
        //   set {this._absoluteChildrenSelectableOnly = value;}
        //  }
        #endregion

        /// <summary>
        /// 拖动树背景，改变背景大小
        /// </summary>
        private void RelocateGrip()
        {
            this.lblSizingGrip.Top = this.frmTreeView.Height - lblSizingGrip.Height - 1;
            this.lblSizingGrip.Left = this.frmTreeView.Width - lblSizingGrip.Width - 1;
        }

        /// <summary>
        /// 点击三角按钮，显示树Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleTreeView(object sender, EventArgs e)
        {
            if (BeforExplan != null)
            {
                WizardClickEventArgs ea = new WizardClickEventArgs();
                BeforExplan(sender, ea);
                if (ea.Cancel)
                {
                    return;
                }
            }
            if (!this.frmTreeView.Visible)
            {
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                this.frmTreeView.Location = new Point(CBRect.X, CBRect.Y + this.pnlBack.Height);
                if (tvTreeView.Nodes.Count > 0)
                    this.tvTreeView.Nodes[0].Expand();
                this.frmTreeView.Show();
                this.frmTreeView.BringToFront();

                this.RelocateGrip();
                //this.tbSelectedValue.Text = "";
            }
            else
            {
                this.frmTreeView.Hide();
            }
        }

        #region 事件
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
                this.pnlTree.Size = this.frmTreeView.Size;
                this.tvTreeView.Size = new Size(this.frmTreeView.Size.Width - this.lblSizingGrip.Width, this.frmTreeView.Size.Height - this.lblSizingGrip.Width); ;
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
        /// 树型控件失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewLostFocus(object sender, EventArgs e)
        {
            if (!this.btnSelect.RectangleToScreen(this.btnSelect.ClientRectangle).Contains(Cursor.Position))
                this.frmTreeView.Hide();
        }

        private void tvTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (AfterSelectedNodeClike != null)
            {
                if (e.Node.Nodes.Count < 1 || this._allowSelectParentNode)
                    AfterSelectedNodeClike(this.tvTreeView.SelectedNode);
            }
        }

        /// <summary>
        /// 选中树型空间节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewNodeSelect(object sender, EventArgs e)
        {
            if (this._allowSelectParentNode)
            {
                this.tbSelectedValue.Text = this.tvTreeView.SelectedNode.Text;

                this.ToggleTreeView(sender, null);
                if (AfterSelectedNode != null)
                    AfterSelectedNode(this.tvTreeView.SelectedNode);
            }
            else
            {
                if (this.tvTreeView.SelectedNode.Nodes.Count == 0)
                {
                    this.tbSelectedValue.Text = this.tvTreeView.SelectedNode.Text;

                    this.ToggleTreeView(sender, null);
                    if (AfterSelectedNode != null)
                        AfterSelectedNode(this.tvTreeView.SelectedNode);
                }
                else
                {
                    //this.tbSelectedValue.Text = this.tvTreeView.SelectedNode.Text;

                    //this.ToggleTreeView(sender, null);

                    //AfterSelectedNode(this.tvTreeView.SelectedNode);
                }
            }
        }

        private void ComboBoxTree_Layout(object sender, LayoutEventArgs e)
        {
            //this.Height = this.tbSelectedValue.Height;
            this.pnlBack.Size = this.Size;


            this.btnSelect.Location = new Point(this.Width - 15, 2);

            this.tbSelectedValue.Location = new Point(0, 0);
            this.tbSelectedValue.Width = this.Width;
            this.frmTreeView.Size = zExSize;
            this.pnlTree.Size = this.frmTreeView.Size;
            this.tvTreeView.Width = this.frmTreeView.Width - this.lblSizingGrip.Width;
            this.tvTreeView.Height = this.frmTreeView.Height - this.lblSizingGrip.Width;
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

        #region 树型背景Label
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

