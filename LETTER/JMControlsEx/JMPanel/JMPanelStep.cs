using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Design;
using System.ComponentModel.Design;

namespace JMControlsEx
{
    public partial class JMPanelStep : Control
    {
        public delegate void WizardClickEventHandler(JMPanelStep sender, WizardClickEventArgs args);

        public delegate void IndexChangedEventHandler(JMPanelStep sender, int index);

        #region 事件
        [Description("索引改变结束后")]
        public event IndexChangedEventHandler IndexChanged;

        [Description("单击上一步")]
        public event WizardClickEventHandler BackButtonClick;

        [Description("单击完成按钮")]
        public event EventHandler FinishButtonClick;

        [Description("单击退出按钮")]
        public event EventHandler ExitButtonClick;

        [Description("单击下一步按钮")]
        public event WizardClickEventHandler NextButtonClick;
        #endregion

        private Color baseBtnClolr;

        public Color ZBaseBtnClolr
        {
            get { return baseBtnClolr; }
            set { baseBtnClolr = value;
            //jmbtnback.ZBaseColor = value;
            //jmbtnnext.ZBaseColor = value;
            //jmbtnexit.ZBaseColor = value;
            }
        }

        /// <summary>
        /// 集合
        /// </summary>
        private PanelStepCollection m_xpanderPanels;

        /// <summary>
        /// 当前索引
        /// </summary>
        private int _selectindex;

        #region 构造函数
        public JMPanelStep()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
            this.m_xpanderPanels = new PanelStepCollection(this);
            _selectindex = 0;
            baseBtnClolr = Color.FromArgb(51, 161, 224);
        }

        private JMButton jmbtnback = new JMButton();
        private JMButton jmbtnnext = new JMButton();
        private JMButton jmbtnexit = new JMButton();

        private void InitializeComponent()
        {
            SuspendLayout();
            //
            //上一页
            //
            jmbtnback.Location = new Point(40, 170);
            jmbtnback.Size = new Size(70, 23);
            jmbtnback.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            jmbtnback.Text = "上一页";
            jmbtnback.Name = "jmbtnback";
            jmbtnback.Click += new EventHandler(jmbtnback_Click);
            //
            //下一页
            //
            jmbtnnext.Location = new Point(120, 170);
            jmbtnnext.Size = new Size(70, 23);
            jmbtnnext.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            jmbtnnext.Text = "下一页";
            jmbtnnext.Name = "jmbtnnext";
            jmbtnnext.Click+=new EventHandler(jmbtnnext_Click);
            //
            //退出
            //
            jmbtnexit.Location = new Point(200, 170);
            jmbtnexit.Size = new Size(70, 23);
            jmbtnexit.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            jmbtnexit.Text = "退出";
            jmbtnexit.Name = "jmbtnexit";
            jmbtnexit.Click += new EventHandler(jmbtnexit_Click);
            //
            //this
            //
            Size = new Size(300, 200);
            base.Controls.Add(jmbtnback);
            base.Controls.Add(jmbtnnext);
            base.Controls.Add(jmbtnexit);
            ResumeLayout();
        }

        void jmbtnexit_Click(object sender, EventArgs e)
        {
            if (ExitButtonClick != null)
                ExitButtonClick(sender, e);
        }
        #endregion

        public int Selectindex
        {
            get { return _selectindex; }
            set
            {
                if (value == 0)
                    jmbtnback.Visible = false;
                if (Items.Count < 1)
                    return;
                OnChangeSelectedIndex(value);
            }
        }

        /// <summary>
        /// 导航栏项
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint),
        Category("Collections"),
        Browsable(true),
        Description("导航栏项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(PanelStepItemCollectionEditor), typeof(UITypeEditor))]
        public PanelStepCollection Items
        {
            get { return this.m_xpanderPanels; }
        }

        #region 重写
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rectangle = new Rectangle(0, Height-37, Width, 2);
            ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Etched, Border3DSide.Top);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            Panel xpanderPanel = e.Control as Panel;
            if (xpanderPanel != null)
            {
                xpanderPanel.Parent = this;
                xpanderPanel.Location = new Point(0, 0);
                xpanderPanel.Size = new Size(this.Size.Width, this.Size.Height - 38);
                xpanderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            jmbtnback.Location = new Point(Width - 260, Height - 30);
            jmbtnnext.Location = new Point(Width - 180, Height - 30);
            jmbtnexit.Location = new Point(Width - 100, Height - 30);
            foreach (Control item in this.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    item.Size = new Size(this.Size.Width, this.Size.Height - 38);
                    break;
                }
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 上一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void jmbtnback_Click(object sender, EventArgs e)
        {
            //当前第一页
            if (Selectindex == 0)
            {
                return;
            }
            //设计模式
            if (DesignMode)
            {
                Selectindex--;
                return;
            }
            //没注册上一页事件
            if (BackButtonClick == null)
            {
                Selectindex--;
                return;
            }
            else
            {
                WizardClickEventArgs args = new WizardClickEventArgs();
                BackButtonClick(this, args);
                if (args.Cancel)
                {
                    return;
                }
                Selectindex--;
                return;
            }
        }

        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void jmbtnnext_Click(object sender, EventArgs e)
        {
            //当前最后一页
            if (_selectindex == this.Items.Count - 1)
            {
                if (FinishButtonClick != null)
                    FinishButtonClick(this, EventArgs.Empty);
                return;
            }
            //设计模式
            if (DesignMode)
            {
                Selectindex++;
                return;
            }
            //没注册上一页事件
            if (NextButtonClick == null)
            {
                Selectindex++;
                return;
            }
            else
            {
                WizardClickEventArgs args = new WizardClickEventArgs();
                NextButtonClick(this, args);
                if (args.Cancel)
                {
                    return;
                }
                Selectindex++;
                return;
            }
        }

        /// <summary>
        /// 选中索引
        /// </summary>
        /// <param name="newIndex"></param>
        /// <param name="force"></param>
        protected internal virtual void OnChangeSelectedIndex(int newIndex)
        {
            if (newIndex < 0 || newIndex >= Items.Count)
            {
                throw new ArgumentOutOfRangeException("newIndex", "The new index must be a valid index of the WizardSteps collection property.");
            }
            if (_selectindex != newIndex)
            {
                ChangePanel(newIndex);
            }
        }

        /// <summary>
        /// 改变索引加载相应 控件
        /// </summary>
        /// <param name="newIndex"></param>
        private void ChangePanel(int newIndex)
        {
            SuspendLayout();
            _selectindex = newIndex;
            foreach (Control item in this.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    Controls.Remove(item);
                    break;
                }
            }
            this.Controls.Add(Items[newIndex]);
            if (_selectindex != 0)
            {
                jmbtnback.Visible = true;
            }
            else
            {
                jmbtnback.Visible = false;
            }
            if (_selectindex != (Items.Count - 1))
            {
                jmbtnnext.Text = "下一步";
            }
            else
            {
                jmbtnnext.Text = "完成";
            }
            ResumeLayout();
            if (IndexChanged != null)
                IndexChanged(this, _selectindex);
        }
        #endregion
    }

    #region PanelStep Panel项添加 删除

    public class PanelStepCollection : IList//, ICollection, IEnumerable
    {
        #region 私有变量

        private JMPanelStep m_xpanderPanelList;
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

        internal PanelStepCollection(JMPanelStep xpanderPanelList)
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

    internal class PanelStepItemCollectionEditor : CollectionEditor
    {
        #region FieldsPrivate

        private CollectionForm m_collectionForm;

        #endregion

        #region MethodsPublic

        public PanelStepItemCollectionEditor(Type type)
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
