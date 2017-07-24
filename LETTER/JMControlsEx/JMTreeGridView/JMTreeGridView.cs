//---------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
//using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Data;
using System.Collections.Generic;

namespace JMControlsEx
{
	/// <summary>
	/// 树形列表控件
    /// </summary>
    [System.ComponentModel.DesignerCategory("code"),
    Designer(typeof(System.Windows.Forms.Design.ControlDesigner)),
	ComplexBindingProperties(),
    Docking(DockingBehavior.Ask)]
    public class JMTreeGridView : DataGridView
	{		
		//private int _indentWidth;
        private JMTreeGridNode _root;
		private TreeGridColumn _expandableColumn;
		//private bool _disposing = false;
		internal ImageList _imageList;
		private bool _inExpandCollapse = false;
        internal bool _inExpandCollapseMouseCapture = false;
		private Control hideScrollBarControl;
        private bool _showLines = true;
        private bool _virtualNodes = false;

		//internal VisualStyleRenderer rOpen = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
		//internal VisualStyleRenderer rClosed = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);

        #region Constructor
        public JMTreeGridView()
		{
			// Control when edit occurs because edit mode shouldn't start when expanding/collapsing
			this.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.RowTemplate = new JMTreeGridNode() as DataGridViewRow;
			// This sample does not support adding or deleting rows by the user.
			this.AllowUserToAddRows = false;
			this.AllowUserToDeleteRows = false;
            this._root = new JMTreeGridNode(this);
			this._root.IsRoot = true;

			// Ensures that all rows are added unshared by listening to the CollectionChanged event.
			base.Rows.CollectionChanged += delegate(object sender, System.ComponentModel.CollectionChangeEventArgs e){};

            _ColumnHeaderColor1 = Color.White;
            _ColumnHeaderColor2 = ColorClass.GetBColor();
            _SelectedRowColor1 = Color.White;
            _SelectedRowColor2 = Color.FromArgb(171, 217, 254);
        }
        #endregion

        #region Keyboard F2 to begin edit support
        protected override void OnKeyDown(KeyEventArgs e)
		{
			// Cause edit mode to begin since edit mode is disabled to support 
			// expanding/collapsing 
			base.OnKeyDown(e);
			if (!e.Handled)
			{
				if (e.KeyCode == Keys.F2 && this.CurrentCellAddress.X > -1 && this.CurrentCellAddress.Y >-1)
				{
					if (!this.CurrentCell.Displayed)
					{
						this.FirstDisplayedScrollingRowIndex = this.CurrentCellAddress.Y;
					}
					else
					{
						//calculate if the cell is partially offscreen and if so scroll into view
					}
					this.SelectionMode = DataGridViewSelectionMode.CellSelect;
					this.BeginEdit(true);
				}
				else if (e.KeyCode == Keys.Enter && !this.IsCurrentCellInEditMode)
				{
					this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
					this.CurrentCell.OwningRow.Selected = true;
				}
			}
        }
        #endregion

        #region Shadow and hide DGV properties

        // This sample does not support databinding
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
		public new object DataSource
		{
			get { return null; }
			set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
		}

		[Browsable(false),
	    DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
		public new object DataMember
		{
			get { return null; }
			set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
		}

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRowCollection Rows
        {
            get { return base.Rows; }
        }

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new bool VirtualMode
        {
            get { return false; }
            set { throw new NotSupportedException("The TreeGridView does not support virtual mode"); }
        }

        // none of the rows/nodes created use the row template, so it is hidden.
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRow RowTemplate
        {
            get { return base.RowTemplate; }
            set { base.RowTemplate = value; }
        }

        #endregion

        #region Public methods
        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public JMTreeGridNode GetNodeForRow(DataGridViewRow row)
        {
            return row as JMTreeGridNode;
        }

        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public JMTreeGridNode GetNodeForRow(int index)
        {
            return GetNodeForRow(base.Rows[index]);
        }
        #endregion

        #region Public properties
        [Category("Data"),
		Description("The collection of root nodes in the treelist."),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public JMTreeGridNodeCollection Nodes
		{
			get
			{
				return this._root.Nodes;
			}
		}

        public new JMTreeGridNode CurrentRow
		{
			get
			{
                return base.CurrentRow as JMTreeGridNode;
			}
		}

        [DefaultValue(false),
        Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")]
        public bool VirtualNodes
        {
            get { return _virtualNodes; }
            set { _virtualNodes = value; }
        }

        public JMTreeGridNode CurrentNode
		{
			get
			{
				return this.CurrentRow;
			}
		}

        [DefaultValue(true)]
        public bool ShowLines
        {
            get { return this._showLines; }
            set { 
                if (value != this._showLines) {
                    this._showLines = value;
                    this.Invalidate();
                } 
            }
        }
	
		public ImageList ImageList
		{
			get { return this._imageList; }
			set { 
				this._imageList = value; 
				// should we invalidate cell styles when setting the image list?
			
			}
		}

        public new int RowCount
        {
            get { return this.Nodes.Count; }
            set
            {
                for (int i = 0; i < value; i++)
                    this.Nodes.Add(new JMTreeGridNode());

            }
        }
        #endregion

        #region Site nodes and collapse/expand support
        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            // Notify the row when it is added to the base grid 
            int count = e.RowCount - 1;
            JMTreeGridNode row;
            while (count >= 0)
            {
                row = base.Rows[e.RowIndex + count] as JMTreeGridNode;
                if (row != null)
                {
                    row.Sited();
                }
                count--;
            }
        }

		internal protected void UnSiteAll()
		{
			this.UnSiteNode(this._root);
		}

        internal protected virtual void UnSiteNode(JMTreeGridNode node)
		{
            if (node.IsSited || node.IsRoot)
			{
				// remove child rows first
                foreach (JMTreeGridNode childNode in node.Nodes)
				{
					this.UnSiteNode(childNode);
				}

				// now remove this row except for the root
				if (!node.IsRoot)
				{
					base.Rows.Remove(node);
					// Row isn't sited in the grid anymore after remove. Note that we cannot
					// Use the RowRemoved event since we cannot map from the row index to
					// the index of the expandable row/node.
					node.UnSited();
				}
			}
		}

        internal protected virtual bool CollapseNode(JMTreeGridNode node)
		{
			if (node.IsExpanded)
			{
				CollapsingEventArgs exp = new CollapsingEventArgs(node);
				this.OnNodeCollapsing(exp);

				if (!exp.Cancel)
				{
					this.LockVerticalScrollBarUpdate(true);
                    this.SuspendLayout();
                    _inExpandCollapse = true;
                    node.IsExpanded = false;

                    foreach (JMTreeGridNode childNode in node.Nodes)
					{
						Debug.Assert(childNode.RowIndex != -1, "Row is NOT in the grid.");
						this.UnSiteNode(childNode);
					}

					CollapsedEventArgs exped = new CollapsedEventArgs(node);
					this.OnNodeCollapsed(exped);
					// Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    this.LockVerticalScrollBarUpdate(false);
                    this.ResumeLayout(true);
                    this.InvalidateCell(node.Cells[0]);

				}

				return !exp.Cancel;
			}
			else
			{
				// row isn't expanded, so we didn't do anything.				
				return false;
			}
		}

        internal protected virtual void SiteNode(JMTreeGridNode node)
		{
			// Raise exception if parent node is not the root or is not sited.
			int rowIndex = -1;
            JMTreeGridNode currentRow;
			node._grid = this;

			if (node.Parent != null && node.Parent.IsRoot == false)
			{
				// row is a child
				Debug.Assert(node.Parent != null && node.Parent.IsExpanded == true);

				if (node.Index > 0)
				{
					currentRow = node.Parent.Nodes[node.Index - 1];
				}
				else
				{
					currentRow = node.Parent;
				}
			}
			else
			{
				// row is being added to the root
				if (node.Index > 0)
				{
					currentRow = node.Parent.Nodes[node.Index - 1];
				}
				else
				{
					currentRow = null;
				}

			}

			if (currentRow != null)
			{
				while (currentRow.Level >= node.Level)
				{
					if (currentRow.RowIndex < base.Rows.Count - 1)
					{
                        currentRow = base.Rows[currentRow.RowIndex + 1] as JMTreeGridNode;
						Debug.Assert(currentRow != null);
					}
					else
						// no more rows, site this node at the end.
						break;

				}
				if (currentRow == node.Parent)
					rowIndex = currentRow.RowIndex + 1;
				else if (currentRow.Level < node.Level)
					rowIndex = currentRow.RowIndex;
				else
					rowIndex = currentRow.RowIndex + 1;
			}
			else
				rowIndex = 0;


			Debug.Assert(rowIndex != -1);
			this.SiteNode(node, rowIndex);

			Debug.Assert(node.IsSited);
			if (node.IsExpanded)
			{
				// add all child rows to display
                foreach (JMTreeGridNode childNode in node.Nodes)
				{
					// could use the more efficient SiteRow with index.
					this.SiteNode(childNode);
				}
			}
		}

        internal protected virtual void SiteNode(JMTreeGridNode node, int index)
		{
			if (index < base.Rows.Count)
			{
				base.Rows.Insert(index, node);
			}
			else
			{
				// for the last item.
				base.Rows.Add(node);
			}
		}

        internal protected virtual bool ExpandNode(JMTreeGridNode node)
		{
            if (!node.IsExpanded || this._virtualNodes)
			{
				ExpandingEventArgs exp = new ExpandingEventArgs(node);
				this.OnNodeExpanding(exp);

				if (!exp.Cancel)
				{
					this.LockVerticalScrollBarUpdate(true);
                    this.SuspendLayout();
                    _inExpandCollapse = true;
                    node.IsExpanded = true;

					
                    foreach (JMTreeGridNode childNode in node.Nodes)
					{
						Debug.Assert(childNode.RowIndex == -1, "Row is already in the grid.");

						this.SiteNode(childNode);
						//this.BaseRows.Insert(rowIndex + 1, childRow);
						//childNode.Cells[0].Value = "child";
					}

					ExpandedEventArgs exped = new ExpandedEventArgs(node);
					this.OnNodeExpanded(exped);
					// Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    this.LockVerticalScrollBarUpdate(false);
                    this.ResumeLayout(true);
                    this.InvalidateCell(node.Cells[0]);
				}

				return !exp.Cancel;
			}
			else
			{
				// row is already expanded, so we didn't do anything.
				return false;
			}
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // used to keep extra mouse moves from selecting more rows when collapsing
            base.OnMouseUp(e);
            this._inExpandCollapseMouseCapture = false;
            if (e.Y <= this.ColumnHeadersHeight)
            {
                if (!string.IsNullOrEmpty(_zxmlname))
                {
                    string path = Application.StartupPath + "\\" + _zxmlname;
                    foreach (DataGridViewColumn column in this.Columns)
                    {
                        XmlHelperEx.Update(path, "DataGridViewColumns/Column[@cname='" + column.Name + "']/DisplayIndex", "", column.DisplayIndex.ToString());
                    }
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // while we are expanding and collapsing a node mouse moves are
            // supressed to keep selections from being messed up.
            if (!this._inExpandCollapseMouseCapture)
                base.OnMouseMove(e);

        }
        #endregion

        #region Collapse/Expand events
        public event ExpandingEventHandler NodeExpanding;
        public event ExpandedEventHandler NodeExpanded;
        public event CollapsingEventHandler NodeCollapsing;
        public event CollapsedEventHandler NodeCollapsed;

        protected virtual void OnNodeExpanding(ExpandingEventArgs e)
        {
            if (this.NodeExpanding != null)
            {
                NodeExpanding(this, e);
            }
        }
        protected virtual void OnNodeExpanded(ExpandedEventArgs e)
        {
            if (this.NodeExpanded != null)
            {
                NodeExpanded(this, e);
            }
        }
        protected virtual void OnNodeCollapsing(CollapsingEventArgs e)
        {
            if (this.NodeCollapsing != null)
            {
                NodeCollapsing(this, e);
            }

        }
        protected virtual void OnNodeCollapsed(CollapsedEventArgs e)
        {
            if (this.NodeCollapsed != null)
            {
                NodeCollapsed(this, e);
            }
        }
        #endregion

        #region Helper methods
        protected override void Dispose(bool disposing)
        {
            //this._disposing = true;
            base.Dispose(Disposing);
            this.UnSiteAll();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // this control is used to temporarly hide the vertical scroll bar
            hideScrollBarControl = new Control();
            hideScrollBarControl.Visible = false;
            hideScrollBarControl.Enabled = false;
            hideScrollBarControl.TabStop = false;
            // control is disposed automatically when the grid is disposed
            this.Controls.Add(hideScrollBarControl);
        }

        protected override void OnRowEnter(DataGridViewCellEventArgs e)
        {
            // ensure full row select
            base.OnRowEnter(e);
            if (this.SelectionMode == DataGridViewSelectionMode.CellSelect ||
                (this.SelectionMode == DataGridViewSelectionMode.FullRowSelect &&
                base.Rows[e.RowIndex].Selected == false))
            {
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                base.Rows[e.RowIndex].Selected = true;
            }
        }
        
		private void LockVerticalScrollBarUpdate(bool lockUpdate/*, bool delayed*/)
		{
            // Temporarly hide/show the vertical scroll bar by changing its parent
            if (!this._inExpandCollapse)
            {
                if (lockUpdate)
                {
                    this.VerticalScrollBar.Parent = hideScrollBarControl;
                }
                else
                {
                    this.VerticalScrollBar.Parent = this;
                }
            }
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            if (typeof(TreeGridColumn).IsAssignableFrom(e.Column.GetType()))
            {
                if (_expandableColumn == null)
                {
                    // identify the expanding column.			
                    _expandableColumn = (TreeGridColumn)e.Column;
                }
                else
                {
                   // this.Columns.Remove(e.Column);
                    //throw new InvalidOperationException("Only one TreeGridColumn per TreeGridView is supported.");
                }
            }

            // Expandable Grid doesn't support sorting. This is just a limitation of the sample.
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;

            base.OnColumnAdded(e);
        }

        private static class Win32Helper
        {
            public const int WM_SYSKEYDOWN = 0x0104,
                             WM_KEYDOWN = 0x0100,
                             WM_SETREDRAW = 0x000B;

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, int wParam, int lParam);

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern bool PostMessage(System.Runtime.InteropServices.HandleRef hwnd, int msg, IntPtr wparam, IntPtr lparam);

        }
        #endregion

        private Color _ColumnHeaderColor1;
        private Color _ColumnHeaderColor2;
        private Color _SelectedRowColor1;
        private Color _SelectedRowColor2;

        [Description("表头起始颜色")]
        public Color ColumnHeaderColorBegin //表头起始颜色
        {
            get { return _ColumnHeaderColor1; }
            set
            {
                _ColumnHeaderColor1 = value;
                this.Invalidate();
            }
        }

        [Description("表头终止颜色")]
        public Color ColumnHeaderColorEnd //表头终止颜色
        {
            get { return _ColumnHeaderColor2; }
            set
            {
                _ColumnHeaderColor2 = value;
                this.Invalidate();
            }
        }

        [Description("选中行起始颜色")]
        public Color SelectedRowColor1 //选中行起始颜色
        {
            get { return _SelectedRowColor1; }

            set { _SelectedRowColor1 = value; }
        }

        [Description("选中行终止颜色")]
        public Color SelectedRowColor2 //选中行终止颜色
        {
            get { return _SelectedRowColor2; }

            set { _SelectedRowColor2 = value; }
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            try
            {
                if (e.RowIndex == -1)
                {
                    if (!(_ColumnHeaderColor1 == Color.Transparent) && !(_ColumnHeaderColor2 == Color.Transparent) &&
                        !_ColumnHeaderColor1.IsEmpty && !_ColumnHeaderColor2.IsEmpty)
                    {
                        DrawLinearGradient(e.CellBounds, e.Graphics, _ColumnHeaderColor1, _ColumnHeaderColor2);
                        DrawLine(e.CellBounds, e.Graphics, Color.Silver);
                        e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background));
                        e.Handled = true;
                    }
                }
                else
                {
                    if (this.CurrentCell.RowIndex == e.RowIndex)
                    {
                        DrawLinearGradient(e.CellBounds, e.Graphics, _SelectedRowColor1, _SelectedRowColor2);

                        e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background));
                        e.Handled = true;
                    }
                }
            }
            catch { }
        }

        private static void DrawLinearGradient(Rectangle Rec, Graphics Grp, Color Color1, Color Color2)
        {
            if (Color1 == Color2)
            {
                Brush backbrush = new SolidBrush(Color1);
                Grp.FillRectangle(backbrush, Rec);
            }
            else
            {
                using (Brush backbrush =
                    new LinearGradientBrush(Rec, Color1, Color2,
                                            LinearGradientMode.
                                                Vertical))
                {
                    Grp.FillRectangle(backbrush, Rec);
                }
            }
        }

        private static void DrawLine(Rectangle Rec, Graphics Grp, Color Color1)
        {
            Grp.DrawLine(new Pen(new SolidBrush(Color1)), new Point(Rec.X + Rec.Width - 1, Rec.Y + 2), new Point(Rec.X + Rec.Width - 1, Rec.Y + Rec.Height - 2));
        }

        #region 单击表头弹出菜单
        //protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        //{
        //    //base.OnColumnHeaderMouseClick(e);
        //    //MessageBoxJ.Show(e.X.ToString() + "," + e.Y.ToString());
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        if (e.X < this.Columns[e.ColumnIndex].Width && e.X > this.Columns[e.ColumnIndex].Width - 20)
        //        {
        //            List<columninfo> strlist = new List<columninfo>();
        //            foreach (DataGridViewColumn var in this.Columns)
        //            {
        //                if (var.GetType().ToString() == "JMControlsEx.TreeGridColumn")
        //                    continue;
        //                columninfo cin = new columninfo();
        //                cin.Cvisble = var.Visible;
        //                cin.Cname = var.Name;
        //                cin.Ctext = var.HeaderText;
        //                strlist.Add(cin);
        //            }
        //            DataTable colvalue = new DataTable();
        //            string cname = this.Columns[e.ColumnIndex].Name;
        //            colvalue.Columns.Add("vs", typeof(bool));
        //            colvalue.Columns.Add(cname, typeof(string));
        //            foreach (DataGridViewRow var in this.Rows)
        //            {
        //                DataRow dr = colvalue.NewRow();
        //                dr["vs"] = var.Visible;
        //                dr[cname] = var.Cells[cname].Value;
        //                colvalue.Rows.Add(dr);
        //            }
        //            JMDGVMENU ContextMenu = new JMDGVMENU(strlist, cname, GetDistinctTable(colvalue, cname));
        //            ContextMenu.Stype = JMControlsEx.ShowType.Top;//从左到右
        //            ContextMenu.ColumnVisbleChange += new JMDGVMENU.ColumnVisbleHandel(ContextMenu_ColumnVisbleChange);
        //            ContextMenu.ColumnOrderChange += new JMDGVMENU.ColumnOrderHandel(ContextMenu_ColumnOrderChange);
        //            ContextMenu.ColumnValueChange += new JMDGVMENU.ColumnValueHandel(ContextMenu_ColumnValueChange);
        //            Screen cre = Screen.PrimaryScreen;//当前屏幕
        //            //是否超出屏幕
        //            if (ContextMenu.Height + MousePosition.Y > cre.WorkingArea.Height)
        //                ContextMenu.Location = new Point(MousePosition.X + 5, cre.WorkingArea.Height - ContextMenu.Height);
        //            else
        //                ContextMenu.Location = new Point(MousePosition.X + 5, MousePosition.Y);
        //            ContextMenu.Show();
        //        }
        //        else
        //            base.OnColumnHeaderMouseClick(e);
        //    }
        //    else
        //        base.OnColumnHeaderMouseClick(e);
        //}

        //void ContextMenu_ColumnValueChange(List<string> values, string _cname)
        //{
        //    foreach (DataGridViewRow var in this.Rows)
        //    {
        //        string va = "";
        //        if (var.Cells[_cname].Value != null)
        //            va = var.Cells[_cname].Value.ToString();
        //        bool bl = true;
        //        foreach (string str in values)
        //        {
        //            if (va == str)
        //            {
        //                bl = false;
        //                break;
        //            }
        //        }

        //        if (this.DataSource != null)
        //        {
        //            CurrencyManager cm = (CurrencyManager)BindingContext[this.DataSource];
        //            cm.SuspendBinding(); //挂起数据绑定
        //            var.Visible = bl;
        //            cm.ResumeBinding(); //恢复数据绑定
        //        }
        //        else
        //        {
        //            var.Visible = bl;
        //        }
        //    }
        //}

        //void ContextMenu_ColumnOrderChange(ListSortDirection cstate, string _cname)
        //{
        //    this.Sort(this.Columns[_cname], cstate);
        //}

        //void ContextMenu_ColumnVisbleChange(bool cstate, string _cname)
        //{
        //    this.Columns[_cname].Visible = cstate;
        //    if (!string.IsNullOrEmpty(_zxmlname))
        //    {
        //        string path = Application.StartupPath + "\\" + _zxmlname;
        //        XmlHelper.Update(path, "DataGridViewColumns/Column[@cname='" + _cname + "']/Visble", "", cstate.ToString());
        //    }
        //}

        /// <summary>
        /// 获取对固定列不重复的新DataTable
        /// </summary>
        /// <param name="dt">含有重复数据的DataTable</param>
        /// <param name="colName">需要验证重复的列名</param>
        /// <returns>新的DataTable，colName列不重复，表格式保持不变</returns>
        private DataTable GetDistinctTable(DataTable dt, string colName)
        {
            DataView dv = dt.DefaultView;
            DataTable dtCardNo = dv.ToTable(true, colName);
            DataTable Pointdt = new DataTable();
            Pointdt = dv.ToTable();
            Pointdt.Clear();
            for (int i = 0; i < dtCardNo.Rows.Count; i++)
            {
                string value = "";
                if (dtCardNo.Rows[i][0] != null)
                    value = dtCardNo.Rows[i][0].ToString();
                if (dt.Select(colName + "='" + value + "'").Length > 0)
                {
                    DataRow dr = dt.Select(colName + "='" + value + "'")[0];
                    Pointdt.Rows.Add(dr.ItemArray);
                }
            }
            return Pointdt;
        }
        #endregion

        private string _zxmlname;

        public string Zxmlname
        {
            get { return _zxmlname; }
            set { _zxmlname = value; }
        }

        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            if (!string.IsNullOrEmpty(_zxmlname))
            {
                string path = Application.StartupPath + "\\" + _zxmlname;
                XmlHelperEx.Update(path, "DataGridViewColumns/Column[@cname='" + e.Column.Name + "']", "Width", e.Column.Width.ToString());
            }
        }
    }
}
