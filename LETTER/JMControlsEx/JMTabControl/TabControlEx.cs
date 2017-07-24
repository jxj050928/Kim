using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace JMControlsEx
{
    public class TabControlEx : Panel
    {
        /// <summary>
        /// 集合
        /// </summary>
        private PanelCollection m_xpanderPanels;

        /// <summary>
        /// 当前索引
        /// </summary>
        private int _selectindex;

        public int Selectindex
        {
            get { return _selectindex; }
            set
            {
                if (_selectindex != value)
                {
                    _selectindex = value;
                    if (_selectindex >= 0)
                    {
                        ChangePanel(value);
                        Invalidate();
                    }
                }
            }
        }

        private int _captionHeight;

        public int CaptionHeight
        {
            get { return _captionHeight; }
            set
            {
                _captionHeight = value;
                this.Padding = new Padding(0, _captionHeight, 0, 0);
            }
        }

        private Color bordercolor;

        public Color Bordercolor
        {
            get { return bordercolor; }
            set { bordercolor = value; Invalidate(); }
        }

        private List<Rectangle> RectList;

        #region 构造函数
        public TabControlEx()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            this.m_xpanderPanels = new PanelCollection(this);
            _captionHeight = 45;
            this.Padding = new Padding(0, _captionHeight, 0, 0);
            bordercolor=Color.FromArgb(200, 200, 200);
            _selectindex = -1;
        }
        #endregion

        /// <summary>
        /// 导航栏项
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint),
        Category("Collections"),
        Browsable(true),
        Description("导航栏项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(PanelItemCollectionEditor), typeof(UITypeEditor))]
        public PanelCollection Items
        {
            get { return this.m_xpanderPanels; }
        }

        #region 重写
        protected override void OnPaint(PaintEventArgs e)
        {
            RectList = new List<Rectangle>();

            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawLine(new Pen(bordercolor), new Point(0, _captionHeight - 1), new Point(Width, _captionHeight - 1));

            //Color selectColor = Color.Red;

            if (Items != null)
            {
                int count = Items.Count;
                if (count > 0)
                {
                    int aWidth = Width / count;

                    for (int i = 0; i < Items.Count; i++)
                    {
                        Rectangle rectone = new Rectangle(i * aWidth, 0, aWidth, _captionHeight);
                        RectList.Add(rectone);

                        if (i == _selectindex)
                        {
                            g.DrawLine(new Pen(this.BackColor), new Point(rectone.X, _captionHeight - 1), new Point(rectone.X + rectone.Width, _captionHeight - 1));

                            //g.FillRectangle(new SolidBrush(selectColor), rectone);
                        }
                        if (i != 0)
                        {
                            g.DrawLine(new Pen(bordercolor), new Point(rectone.X, 0), new Point(rectone.X, _captionHeight - 1));
                        }
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Trimming = StringTrimming.EllipsisCharacter;
                        g.DrawString((Items[i] as Panel).Name, Font, new SolidBrush(ForeColor), rectone, sf);
                    }
                }
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            Panel xpanderPanel = e.Control as Panel;
            if (xpanderPanel != null)
            {
                xpanderPanel.Parent = this;
                xpanderPanel.Dock = DockStyle.Fill;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (RectList == null)
            {
                return;
            }
            if (RectList.Count < 2)
            {
                return;
            }
            if (e.Location.Y < _captionHeight)
            {
                for (int i = 0; i < RectList.Count; i++)
                {
                    if (RectList[i].Contains(e.Location))
                    {
                        Selectindex = i;
                        break;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// 改变索引加载相应 控件
        /// </summary>
        /// <param name="newIndex"></param>
        private void ChangePanel(int newIndex)
        {
            SuspendLayout();
            foreach (Control item in this.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    Controls.Remove(item);
                    break;
                }
            }
            this.Controls.Add(Items[newIndex]);
            ResumeLayout();
        }
    }

    #region PanelStep Panel项添加 删除

    public class PanelCollection : IList//, ICollection, IEnumerable
    {
        #region 私有变量

        private TabControlEx m_xpanderPanelList;
        private List<Panel> m_controlCollection;

        #endregion

        #region Events

        public event EventHandler PanelAdded;

        public event EventHandler PanelRemoved;

        #endregion

        protected virtual void OnPanelAdded()
        {
            if (PanelAdded != null)
                PanelAdded(this, EventArgs.Empty);
        }

        protected virtual void OnPanelRemoved()
        {
            if (PanelRemoved != null)
                PanelRemoved(this, EventArgs.Empty);
        }

        #region 构造函数

        internal PanelCollection(TabControlEx xpanderPanelList)
        {
            this.m_xpanderPanelList = xpanderPanelList;
            this.m_controlCollection = new List<Panel>();
        }

        #endregion

        #region 属性
        /// <summary>
        /// Gets or sets a XPanderPanel in the collection. 
        /// </summary>
        /// <param name="iIndex">The zero-based index of the XPanderPanel to get or set.</param>
        /// <returns>The xPanderPanel at the specified index.</returns>
        public Panel this[int index]
        {
            get { return m_controlCollection[index]; }
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
            return this.m_controlCollection.Contains(xpanderPanel as Panel);
        }
        /// <summary>
        /// Adds a XPanderPanel to the collection.  
        /// </summary>
        /// <param name="xpanderPanel">The XPanderPanel to add.</param>
        public void Add(Panel xpanderPanel)
        {
            this.m_controlCollection.Add(xpanderPanel);

        }
        /// <summary>
        /// Removes the first occurrence of a specific XPanderPanel from the XPanderPanelCollection
        /// </summary>
        /// <param name="value">The XPanderPanel to remove from the XPanderPanelCollection</param>
        public void Remove(Panel xpanderPanel)
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
                if (item.GetType().ToString() == "System.Windows.Forms.Panel")
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
        public int IndexOf(Panel xpanderPanel)
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
        public void Insert(int index, Panel xpanderPanel)
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
        public void CopyTo(Panel[] xpanderPanels, int index)
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
            Panel xpanderPanel = value as Panel;
            if (xpanderPanel == null)
            {
                throw new ArgumentException();
            }
            this.Add(xpanderPanel);
            return this.IndexOf(xpanderPanel);
        }

        bool IList.Contains(object value)
        {
            return this.Contains(value as Panel);
        }

        int IList.IndexOf(object value)
        {
            return this.IndexOf(value as Panel);
        }

        void IList.Insert(int index, object value)
        {
            if ((value is Panel) == false)
            {
                throw new ArgumentException();
            }
        }

        void IList.Remove(object value)
        {
            this.Remove(value as Panel);
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

    #endregion

    #region PanelHeadList PanelHeadListItem属性  对话框

    internal class PanelItemCollectionEditor : CollectionEditor
    {
        #region FieldsPrivate

        private CollectionForm m_collectionForm;

        #endregion

        #region MethodsPublic

        public PanelItemCollectionEditor(Type type)
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
            Panel xpanderPanel = (Panel)base.CreateInstance(ItemType);
            //if (this.Context.Instance != null)
            //{
            //    xpanderPanel.Expand = true;
            //}
            return xpanderPanel;
        }

        #endregion
    }

    #endregion
}
