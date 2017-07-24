using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing.Design;

namespace JMControlsEx
{
    public class JMImageGrid : ScrollableControl
    {
        public event EventHandler ItemClike;

        Color _buttonBaseColor = Color.FromArgb(166, 222, 255);

        public Color ZBaseColor
        {
            get { return _buttonBaseColor; }
            set { _buttonBaseColor = value; Invalidate(); }
        }
        Color _buttonBorderColor = Color.FromArgb(23, 169, 254);

        public Color ZBorderColor
        {
            get { return _buttonBorderColor; }
            set { _buttonBorderColor = value; Invalidate(); }
        }
        Color _buttonArrowColor = Color.FromArgb(0, 95, 152);

        public Color ZArrowColor
        {
            get { return _buttonArrowColor; }
            set { _buttonArrowColor = value; Invalidate(); }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color _ZBorderStyle = Color.LightGray;

        public Color ZBorderStyle
        {
            get { return _ZBorderStyle; }
            set { _ZBorderStyle = value; Invalidate(); }
        }

        private int itemheight;

        private int m_pagecount;

        public int Pagecount
        {
            get { return m_pagecount; }
            set
            {
                m_pagecount = value;
                itemheight = (Height - 16) / m_pagecount;
                OnChangeIndex(_pageindex);
            }
        }

        private JMImageItemCollection m_items;

        private int _pageindex;

        public int Pageindex
        {
            get { return _pageindex; }
            set
            {
                _pageindex = value;
                OnChangeIndex(value);
            }
        }

        protected void OnChangeIndex(int index)
        {
            if (index * m_pagecount < Items.Count)
            {
                this.Controls.Clear();
                for (int i = index * m_pagecount; i < Items.Count; i++)
                {
                    if (i == index * m_pagecount + m_pagecount)
                        return;
                    if (index * m_pagecount + m_pagecount < Items.Count)
                    {
                        this.Controls.Add(Items[index * m_pagecount + index * m_pagecount + m_pagecount - i - 1]);
                    }
                    else
                    {
                        this.Controls.Add(Items[index * m_pagecount + Items.Count - i - 1]);
                    }
                }
            }
        }

        public JMImageGrid()
            : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            this.DockPadding.Top = 20;
            m_items = new JMImageItemCollection(this);
            m_pagecount = 10;
            itemheight = (Height - 16) / m_pagecount;
            Pageindex = 0;
        }

        /// <summary>
        /// 导航栏项
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint),
        Category("Collections"),
        Browsable(true),
        Description("导航栏项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(JMImageItemCollectionEditor), typeof(UITypeEditor))]
        public JMImageItemCollection Items
        {
            get { return this.m_items; }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            itemheight = (Height - 16) / m_pagecount;
            foreach (JMImageItem item in Items)
            {
                item.Height = itemheight;
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            JMImageItem xpanderPanel = e.Control as JMImageItem;
            if (xpanderPanel != null)
            {
                xpanderPanel.Parent = this;
                xpanderPanel.Dock = DockStyle.Top;
                xpanderPanel.Height = itemheight;
                xpanderPanel.Click += new EventHandler(xpanderPanel_Click);
            }
            else
            {
                throw new InvalidOperationException("只能添加JMImageItem对象");
            }
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            JMImageItem xpanderPanel = e.Control as JMImageItem;
            xpanderPanel.Click -= new EventHandler(xpanderPanel_Click);
        }

        void xpanderPanel_Click(object sender, EventArgs e)
        {
            if (ItemClike != null)
                ItemClike(sender, e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            Rectangle upButtonRect = new Rectangle(0, 0, Width - 1, 8);
            Rectangle downButtonRect = new Rectangle(0, 9, Width - 1, 8);

            Point pt = e.Location;
            if (upButtonRect.Contains(pt))
            {
                //向上翻页
                if (Pageindex > 0)
                    Pageindex--;
            }
            else if (downButtonRect.Contains(pt))
            {
                //向下方也
                if ((Pageindex + 1) * Pagecount < Items.Count)
                    Pageindex++;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Rectangle upButtonRect = new Rectangle(0, 0, Width - 1, 8);
            Rectangle downButtonRect = new Rectangle(0, 9, Width - 1, 8);

            Point pt = e.Location;
            if (upButtonRect.Contains(pt))
            {
                this.Cursor = Cursors.Hand;
            }
            else if (downButtonRect.Contains(pt))
            {
                this.Cursor = Cursors.Hand;
            }
            else
                this.Cursor = Cursors.Default;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Cursor = Cursors.Default;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawRectangle(new Pen(_ZBorderStyle), 0, 0, this.Width - 1, this.Height - 1);

            Rectangle upButtonRect = new Rectangle(0, 0, Width - 1, 8);
            //Rectangle downButtonRect = new Rectangle(0, Height - 9, Width - 1, 8);
            Rectangle downButtonRect = new Rectangle(0, 9, Width - 1, 8);

            Color upButtonBaseColor = _buttonBaseColor;
            Color upButtonBorderColor = _buttonBorderColor;
            Color upButtonArrowColor = _buttonArrowColor;

            Color downButtonBaseColor = _buttonBaseColor;
            Color downButtonBorderColor = _buttonBorderColor;
            Color downButtonArrowColor = _buttonArrowColor;

            RenderButton(
                g,
                upButtonRect,
                upButtonBaseColor,
                upButtonBorderColor,
                upButtonArrowColor,
                ArrowDirection.Up);

            RenderButton(
                g,
                downButtonRect,
                downButtonBaseColor,
                downButtonBorderColor,
                downButtonArrowColor,
                ArrowDirection.Down);

            //if (this.Items.Count > 0)
            //{
            //    foreach (JMImageItem item in this.Items)
            //    {
            //        this.Controls.Add(item);
            //    }

            //}
        }

        #region 画上下按钮
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
                        new Point(point.X - 3, point.Y + 1), 
                        new Point(point.X + 3, point.Y + 1), 
                        new Point(point.X, point.Y - 1) };
                    break;

                case ArrowDirection.Right:
                    points = new Point[] {
                        new Point(point.X - 2, point.Y - 3), 
                        new Point(point.X - 2, point.Y + 3), 
                        new Point(point.X + 1, point.Y) };
                    break;

                default:
                    points = new Point[] {
                        new Point(point.X - 3, point.Y - 1), 
                        new Point(point.X + 3, point.Y - 1), 
                        new Point(point.X, point.Y + 1) };
                    break;
            }
            g.FillPolygon(brush, points);
        }

        internal void RenderButton(
            Graphics g,
            Rectangle rect,
            Color baseColor,
            Color borderColor,
            Color arrowColor,
            ArrowDirection direction)
        {
            RenderBackgroundInternal(
                g,
                rect,
                baseColor,
                borderColor,
                0.45f,
                true,
                LinearGradientMode.Vertical);
            using (SolidBrush brush = new SolidBrush(arrowColor))
            {
                RenderArrowInternal(
                    g,
                    rect,
                    direction,
                    brush);
            }
        }

        internal void RenderBackgroundInternal(
          Graphics g,
          Rectangle rect,
          Color baseColor,
          Color borderColor,
          float basePosition,
          bool drawBorder,
          LinearGradientMode mode)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
               rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = ColorClass.GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = ColorClass.GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = ColorClass.GetColor(baseColor, 0, 68, 69, 54);

                ColorBlend blend = new ColorBlend();
                blend.Positions =
                    new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, rect);
            }
            if (baseColor.A > 80)
            {
                Rectangle rectTop = rect;
                if (mode == LinearGradientMode.Vertical)
                {
                    rectTop.Height = (int)(rectTop.Height * basePosition);
                }
                else
                {
                    rectTop.Width = (int)(rect.Width * basePosition);
                }
                using (SolidBrush brushAlpha =
                    new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                {
                    g.FillRectangle(brushAlpha, rectTop);
                }
            }

            if (drawBorder)
            {
                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }
        #endregion
    }

    public class JMImageItemCollection : IList//, ICollection, IEnumerable
    {
        #region 私有变量

        private JMImageGrid m_xpanderPanelList;
        private List<JMImageItem> m_controlCollection;

        #endregion

        #region 构造函数

        internal JMImageItemCollection(JMImageGrid xpanderPanelList)
        {
            this.m_xpanderPanelList = xpanderPanelList;
            this.m_controlCollection = new List<JMImageItem>();
        }

        #endregion

        #region 属性
        /// <summary>
        /// Gets or sets a XPanderPanel in the collection. 
        /// </summary>
        /// <param name="iIndex">The zero-based index of the XPanderPanel to get or set.</param>
        /// <returns>The xPanderPanel at the specified index.</returns>
        public JMImageItem this[int index]
        {
            get { return m_controlCollection[index] as JMImageItem; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// Determines whether the XPanderPanelCollection contains a specific XPanderPanel
        /// </summary>
        /// <param name="value">The XPanderPanel to locate in the XPanderPanelCollection</param>
        /// <returns>true if the XPanderPanelCollection contains the specified value; otherwise, false.</returns>
        public bool Contains(object xpanderPanel)
        {
            return this.m_controlCollection.Contains(xpanderPanel as JMImageItem);
        }
        /// <summary>
        /// Adds a XPanderPanel to the collection.  
        /// </summary>
        /// <param name="xpanderPanel">The XPanderPanel to add.</param>
        public void Add(JMImageItem xpanderPanel)
        {
            this.m_controlCollection.Add(xpanderPanel);
            m_xpanderPanelList.Invalidate();

        }
        /// <summary>
        /// Removes the first occurrence of a specific XPanderPanel from the XPanderPanelCollection
        /// </summary>
        /// <param name="value">The XPanderPanel to remove from the XPanderPanelCollection</param>
        public void Remove(JMImageItem xpanderPanel)
        {
            this.m_controlCollection.Remove(xpanderPanel);
        }

        /// <summary>
        /// Removes all the XPanderPanels from the collection. 
        /// </summary>
        public void Clear()
        {
            this.m_controlCollection.Clear();
            foreach (Control item in m_xpanderPanelList.Controls)
            {
                if (item.GetType().ToString() == "JMControls.JMImageItem")
                {
                    m_xpanderPanelList.Controls.Remove(item);
                }
            }
        }

        /// <summary>
        /// Gets the number of XPanderPanels in the collection. 
        /// </summary>
        public int Count
        {
            get { return this.m_controlCollection.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only. 
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }
        /// <summary>
        /// Returns an enumeration of all the XPanderPanels in the collection.  
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return this.m_controlCollection.GetEnumerator();
        }
        /// <summary>
        /// Returns the index of the specified XPanderPanel in the collection. 
        /// </summary>
        /// <param name="xpanderPanel">The xpanderPanel to find the index of.</param>
        /// <returns>The index of the xpanderPanel, or -1 if the xpanderPanel is not in the <see ref="ControlCollection">ControlCollection</see> instance.</returns>
        public int IndexOf(JMImageItem xpanderPanel)
        {
            return this.m_controlCollection.IndexOf(xpanderPanel);
        }
        /// <summary>
        /// Removes the XPanderPanel at the specified index from the collection. 
        /// </summary>
        /// <param name="iIndex">The zero-based index of the xpanderPanel to remove from the ControlCollection instance.</param>
        public void RemoveAt(int index)
        {
            //m_xpanderPanelList.Controls.Remove(m_controlCollection[index]);
            this.m_controlCollection.RemoveAt(index);
        }
        /// <summary>
        /// Inserts an XPanderPanel to the collection at the specified index. 
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted. </param>
        /// <param name="xpanderPanel">The XPanderPanel to insert into the Collection.</param>
        public void Insert(int index, JMImageItem xpanderPanel)
        {
            ((IList)this).Insert(index, (object)xpanderPanel);
        }
        /// <summary>
        /// Copies the elements of the collection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="xPanderPanels">The one-dimensional Array that is the destination of the elements copied from ICollection.
        /// The Array must have zero-based indexing.
        ///</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(JMImageItem[] xpanderPanels, int index)
        {
            this.m_controlCollection.CopyTo(xpanderPanels, index);
        }

        #endregion

        #region 接口实现

        int ICollection.Count
        {
            get { return this.Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return ((ICollection)this.m_controlCollection).IsSynchronized; }
        }

        object ICollection.SyncRoot
        {
            get { return ((ICollection)this.m_controlCollection).SyncRoot; }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)this.m_controlCollection).CopyTo(array, index);
        }

        #endregion

        #region 接口实现

        object IList.this[int index]
        {
            get { return this.m_controlCollection[index]; }
            set { }
        }

        int IList.Add(object value)
        {
            JMImageItem xpanderPanel = value as JMImageItem;
            if (xpanderPanel == null)
            {
                throw new ArgumentException();
            }
            this.Add(xpanderPanel);
            return this.IndexOf(xpanderPanel);
        }

        bool IList.Contains(object value)
        {
            return this.Contains(value as JMImageItem);
        }

        int IList.IndexOf(object value)
        {
            return this.IndexOf(value as JMImageItem);
        }

        void IList.Insert(int index, object value)
        {
            if ((value is JMImageItem) == false)
            {
                throw new ArgumentException();
            }
        }

        void IList.Remove(object value)
        {
            this.Remove(value as JMImageItem);
        }

        void IList.RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        bool IList.IsReadOnly
        {
            get { return this.IsReadOnly; }
        }

        bool IList.IsFixedSize
        {
            get { return ((IList)this.m_controlCollection).IsFixedSize; }
        }

        #endregion
    }

    internal class JMImageItemCollectionEditor : CollectionEditor
    {
        #region FieldsPrivate

        private CollectionForm m_collectionForm;

        #endregion

        #region MethodsPublic

        public JMImageItemCollectionEditor(Type type)
            : base(type)
        {
        }

        #endregion

        #region MethodsProtected

        protected override CollectionForm CreateCollectionForm()
        {
            this.m_collectionForm = base.CreateCollectionForm();
            return this.m_collectionForm;
        }

        protected override Object CreateInstance(Type ItemType)
        {
            JMImageItem xpanderPanel = (JMImageItem)base.CreateInstance(ItemType);
            return xpanderPanel;
        }

        #endregion
    }
}
