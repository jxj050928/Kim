using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace JMControlsEx
{
    #region JMPanelHeadList
    [Designer(typeof(XPanderPanelListDesigner)), DesignTimeVisibleAttribute(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
    public class JMPanelHeadList : ScrollableControl
    {
        public delegate void EventHandle(PanelHeadListItem sender);

        public event EventHandle AfterSelectedItem;

        #region ˽�б���
        //�Ƿ���ʾ���䱳��
        private bool m_bShowGradientBackground;
        private LinearGradientMode m_linearGradientMode;
        private Color m_colorGradientBackground;
        private PanelHeadListItemCollection m_xpanderPanels;
        private bool m_bShowBorder;

        //���⽥�� ��ʼ��ɫ
        private Color m_colorCaptionGradientBegin = ProfessionalColors.OverflowButtonGradientBegin;
        //���⽥�� ������ɫ
        private Color m_colorCaptionGradientEnd = ProfessionalColors.OverflowButtonGradientEnd;

        //��꾭�� ���⽥�� ��ʼ��ɫ
        private Color m_movecolorCaptionGradientBegin = ProfessionalColors.OverflowButtonGradientBegin;
        //��꾭�� ���⽥�� ������ɫ
        private Color m_movecolorCaptionGradientEnd = ProfessionalColors.OverflowButtonGradientEnd;

        //����� ���⽥�� ��ʼ��ɫ
        private Color m_downcolorCaptionGradientBegin = ProfessionalColors.OverflowButtonGradientBegin;
        //����� ���⽥�� ������ɫ
        private Color m_downcolorCaptionGradientEnd = ProfessionalColors.OverflowButtonGradientEnd;

        #endregion

        #region ��������
        /// <summary>
        /// �Ƿ���ʾ���䱳��
        /// </summary>
        [Description("�Ƿ���ʾ���䱳��"),
        DefaultValue(false),
        Category("Appearance")]
        public bool ShowGradientBackground
        {
            get { return this.m_bShowGradientBackground; }
            set
            {
                if (value != this.m_bShowGradientBackground)
                {
                    this.m_bShowGradientBackground = value;
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// �Ƿ���ʾ�߿�
        /// </summary>
        [Description("�Ƿ���ʾ�߿�"),
        DefaultValue(true),
        Category("Appearance")]
        public bool ShowBorder
        {
            get { return this.m_bShowBorder; }
            set
            {
                if (value != this.m_bShowBorder)
                {
                    this.m_bShowBorder = value;
                    foreach (PanelHeadListItem xpanderPanel in this.Items)
                    {
                        xpanderPanel.ShowBorder = this.m_bShowBorder;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// ���⽥�� ��ʼ��ɫ
        /// </summary>
        [Description("���⽥�� ��ʼ��ɫ")]
        [Category("Appearance")]
        public Color CaptionColorBegin
        {
            get { return this.m_colorCaptionGradientBegin; }
            set
            {
                if (value != this.m_colorCaptionGradientBegin)
                {
                    this.m_colorCaptionGradientBegin = value;
                    foreach (PanelHeadListItem xpanderPanel in this.Items)
                    {
                        xpanderPanel.CaptionColorBegin = this.m_colorCaptionGradientBegin;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// ���⽥�� ������ɫ
        /// </summary>
        [Description("���⽥�� ������ɫ")]
        [Category("Appearance")]
        public Color CaptionColorEnd
        {
            get { return this.m_colorCaptionGradientEnd; }
            set
            {
                if (value != this.m_colorCaptionGradientEnd)
                {
                    this.m_colorCaptionGradientEnd = value;
                    foreach (PanelHeadListItem xpanderPanel in this.Items)
                    {
                        xpanderPanel.CaptionColorEnd = this.m_colorCaptionGradientEnd;
                    }
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// ��꾭�����⽥�� ��ʼ��ɫ
        /// </summary>
        [Description("��꾭�����⽥�� ��ʼ��ɫ")]
        [Category("Appearance")]
        public Color CaptionMoveColorBegin
        {
            get { return this.m_movecolorCaptionGradientBegin; }
            set
            {
                if (value != this.m_colorCaptionGradientBegin)
                {
                    this.m_movecolorCaptionGradientBegin = value;
                    foreach (PanelHeadListItem xpanderPanel in this.Items)
                    {
                        xpanderPanel.CaptionMoveColorBegin = this.m_movecolorCaptionGradientBegin;
                    }
                }
            }
        }
        /// <summary>
        /// ��꾭�����⽥�� ������ɫ
        /// </summary>
        [Description("��꾭�����⽥�� ������ɫ")]
        [Category("Appearance")]
        public Color CaptionMoveColorEnd
        {
            get { return this.m_movecolorCaptionGradientEnd; }
            set
            {
                if (value != this.m_movecolorCaptionGradientEnd)
                {
                    this.m_movecolorCaptionGradientEnd = value;
                    foreach (PanelHeadListItem xpanderPanel in this.Items)
                    {
                        xpanderPanel.CaptionMoveColorEnd = this.m_movecolorCaptionGradientEnd;
                    }
                }
            }
        }
        /// <summary>
        /// ��꾭�����⽥�� ��ʼ��ɫ
        /// </summary>
        [Description("��������⽥�� ��ʼ��ɫ")]
        [Category("Appearance")]
        public Color CaptionDownColorBegin
        {
            get { return this.m_downcolorCaptionGradientBegin; }
            set
            {
                if (value != this.m_downcolorCaptionGradientBegin)
                {
                    this.m_downcolorCaptionGradientBegin = value;
                    foreach (PanelHeadListItem xpanderPanel in this.Items)
                    {
                        xpanderPanel.CaptionDownColorBegin = this.m_downcolorCaptionGradientBegin;
                    }
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// ��꾭�����⽥�� ������ɫ
        /// </summary>
        [Description("��������⽥�� ������ɫ")]
        [Category("Appearance")]
        public Color CaptionDownColorEnd
        {
            get { return this.m_downcolorCaptionGradientEnd; }
            set
            {
                if (value != this.m_downcolorCaptionGradientEnd)
                {
                    this.m_downcolorCaptionGradientEnd = value;
                    foreach (PanelHeadListItem xpanderPanel in this.Items)
                    {
                        xpanderPanel.CaptionDownColorEnd = this.m_downcolorCaptionGradientEnd;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// ���䷽��
        /// </summary>
        [Description("���䷽��"),
        DefaultValue(LinearGradientMode.Vertical),
        Category("Appearance")]
        public LinearGradientMode LinearGradientMode
        {
            get { return this.m_linearGradientMode; }
            set
            {
                if (value != this.m_linearGradientMode)
                {
                    this.m_linearGradientMode = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// ���䱳��
        /// </summary>
        [Description("���䱳��"),
        DefaultValue(false),
        Category("Appearance")]
        public System.Drawing.Color GradientBackground
        {
            get { return this.m_colorGradientBackground; }
            set
            {
                if (value != this.m_colorGradientBackground)
                {
                    this.m_colorGradientBackground = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint),
        Category("Collections"),
        Browsable(true),
        Description("��������")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Editor(typeof(PanelHeadListItemCollectionEditor), typeof(UITypeEditor))]
        public PanelHeadListItemCollection Items
        {
            get { return this.m_xpanderPanels; }
        }
        #endregion

        #region ���캯��
        public JMPanelHeadList()
		{
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.ResizeRedraw, false);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.m_xpanderPanels = new PanelHeadListItemCollection(this);
            
            this.ShowBorder = true;
            this.LinearGradientMode = LinearGradientMode.Vertical;
        }
        #endregion

        #region ��д����
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="pevent">A PaintEventArgs that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            if (this.m_bShowGradientBackground == true)
            {
                Rectangle rectangle = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
                using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
                    rectangle,
                    this.BackColor,
                    this.GradientBackground,
                    this.LinearGradientMode))
                {
                    pevent.Graphics.FillRectangle(linearGradientBrush, rectangle);
                }
            }
        }

        /// <summary>
        /// ��ӵ�����
        /// </summary>
        /// <param name="e">A ControlEventArgs that contains the event data.</param>
        protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
        {
            base.OnControlAdded(e);
            PanelHeadListItem xpanderPanel = e.Control as PanelHeadListItem;
            if (xpanderPanel != null)
            {
                if (xpanderPanel.Expand == true)
                {
                    foreach (PanelHeadListItem tmpXPanderPanel in this.Items)
                    {
                        if (tmpXPanderPanel != xpanderPanel)
                        {
                            tmpXPanderPanel.Expand = false;
                            tmpXPanderPanel.Height = xpanderPanel.CaptionHeight;
                        }
                    }
                }
                xpanderPanel.Parent = this;
                xpanderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                xpanderPanel.Left = this.Padding.Left;
                xpanderPanel.Width = this.ClientRectangle.Width
                    - this.Padding.Left
                    - this.Padding.Right;
                xpanderPanel.ShowBorder = this.ShowBorder;
                xpanderPanel.Top = this.GetTopPosition();
                xpanderPanel.CaptionClick += new EventHandler<XPanderPanelClickEventArgs>(this.XPanderPanelCaptionClick);
            }
            else
            {
                throw new InvalidOperationException("ֻ�����PanelHeadListItem����");
            }
        }

        /// <summary>
        /// ɾ��������
        /// </summary>
        /// <param name="e">A ControlEventArgs that contains the event data.</param>
        protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            PanelHeadListItem xpanderPanel = e.Control as PanelHeadListItem;

            if (xpanderPanel != null)
            {
                xpanderPanel.CaptionClick -= new EventHandler<XPanderPanelClickEventArgs>(this.XPanderPanelCaptionClick);
            }
        }

        /// <summary>
        /// �ı��С
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            int iXPanderPanelCaptionHeight = 0;

            if (this.m_xpanderPanels != null)
            {
                foreach (PanelHeadListItem xpanderPanel in this.m_xpanderPanels)
                {
                    xpanderPanel.Width = this.ClientRectangle.Width
                        - this.Padding.Left
                        - this.Padding.Right;
                    if (xpanderPanel.Visible == false)
                    {
                        iXPanderPanelCaptionHeight -= xpanderPanel.CaptionHeight;
                    }
                    iXPanderPanelCaptionHeight += xpanderPanel.CaptionHeight;
                }

                foreach (PanelHeadListItem xpanderPanel in this.m_xpanderPanels)
                {
                    if (xpanderPanel.Expand == true)
                    {
                        xpanderPanel.Height =
                            this.Height
                            - iXPanderPanelCaptionHeight
                            - this.Padding.Top
                            - this.Padding.Bottom
                            + xpanderPanel.CaptionHeight;
                        return;
                    }
                }
            }
        }
        #endregion

        #region ����

        /// <summary>
        /// ������ͷ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XPanderPanelCaptionClick(object sender, XPanderPanelClickEventArgs e)
        {
            base.OnClick(e);
            PanelHeadListItem xpanderPanel = sender as PanelHeadListItem;
            if (xpanderPanel != null)
            {
                this.Expand(xpanderPanel);
            }
            if(AfterSelectedItem!=null)
            AfterSelectedItem(sender as PanelHeadListItem);
        }

        /// <summary>
        /// չ��
        /// </summary>
        /// <param name="xpanderPanel">Ҫչ����PanelHeadListItem</param>
        public void Expand(PanelHeadListItem xpanderPanel)
        {
            if (xpanderPanel == null)
            {
                throw new ArgumentException();
            }
            else
            {
                foreach (PanelHeadListItem tmpXPanderPanel in this.m_xpanderPanels)
                {
                    if (tmpXPanderPanel.Equals(xpanderPanel) == false)
                    {
                        tmpXPanderPanel.Expand = false;
                    }
                }
                xpanderPanel.Expand = true;
            }
        }

        private int GetTopPosition()
        {
            int iTopPosition = this.Padding.Top;
            int iNextTopPosition = 0;

            //The next top position is the highest top value + that controls height, with a
            //little vertical spacing thrown in for good measure
            IEnumerator enumerator = this.Items.GetEnumerator();
            while (enumerator.MoveNext())
            {
                PanelHeadListItem xpanderPanel = (PanelHeadListItem)enumerator.Current;

                if (xpanderPanel.Visible == true)
                {
                    if (iNextTopPosition == this.Padding.Top)
                    {
                        iTopPosition = this.Padding.Top;
                    }
                    else
                    {
                        iTopPosition = iNextTopPosition;
                    }
                    iNextTopPosition = iTopPosition + xpanderPanel.Height;
                }
            }
            return iTopPosition;
        }

        #endregion
    }
    #endregion

    #region Class XPanderPanelListDesigner

    internal class XPanderPanelListDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {
        #region FieldsPrivate

        private Pen m_borderPen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark));
        private JMPanelHeadList m_xpanderPanelList;

        #endregion

        #region MethodsPublic

        public XPanderPanelListDesigner()
        {
            this.m_borderPen.DashStyle = DashStyle.Dash;
        }
        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The IComponent to associate with the designer.</param>
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.m_xpanderPanelList = (JMPanelHeadList)this.Control;
            //Disable the autoscroll feature for the control during design time.  The control
            //itself sets this property to true when it initializes at run time.  Trying to position
            //controls in this control with the autoscroll property set to True is problematic.
            this.m_xpanderPanelList.AutoScroll = false;
        }
        /// <summary>
        /// This member overrides ParentControlDesigner.ActionLists
        /// </summary>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // Create action list collection
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                // Add custom action list
                actionLists.Add(new XPanderPanelListDesignerActionList(this.Component));

                // Return to the designer action service
                return actionLists;
            }
        }

        #endregion

        #region MethodsProtected

        protected override void OnPaintAdornments(PaintEventArgs e)
        {
            base.OnPaintAdornments(e);
            e.Graphics.DrawRectangle(this.m_borderPen, 0, 0, this.m_xpanderPanelList.Width - 2, this.m_xpanderPanelList.Height - 2);
        }

        #endregion
    }

    #endregion

    #region Class XPanderPanelListDesignerActionList

    public class XPanderPanelListDesignerActionList : DesignerActionList
    {
        #region Properties

        [Editor(typeof(PanelHeadListItemCollectionEditor), typeof(UITypeEditor))]
        public PanelHeadListItemCollection XPanderPanels
        {
            get { return this.PanelHeadList.Items; }
        }
        public bool ShowBorder
        {
            get { return this.PanelHeadList.ShowBorder; }
            set { SetProperty("ShowBorder", value); }
        }
        public Color CaptionColorBegin
        {
            get { return this.PanelHeadList.CaptionColorBegin; }
            set { SetProperty("CaptionColorBegin", value); }
        }
        public Color CaptionColorEnd
        {
            get { return this.PanelHeadList.CaptionColorEnd; }
            set { SetProperty("CaptionColorEnd", value); }
        }
        public Color CaptionDownColorBegin
        {
            get { return this.PanelHeadList.CaptionDownColorBegin; }
            set { SetProperty("CaptionDownColorBegin", value); }
        }
        public Color CaptionDownColorEnd
        {
            get { return this.PanelHeadList.CaptionDownColorEnd; }
            set { SetProperty("CaptionDownColorEnd", value); }
        }
        public Color CaptionMoveColorBegin
        {
            get { return this.PanelHeadList.CaptionMoveColorBegin; }
            set { SetProperty("CaptionMoveColorBegin", value); }
        }
        public Color CaptionMoveColorEnd
        {
            get { return this.PanelHeadList.CaptionMoveColorEnd; }
            set { SetProperty("CaptionMoveColorEnd", value); }
        }
        #endregion

        #region MethodsPublic

        public XPanderPanelListDesignerActionList(System.ComponentModel.IComponent component)
            : base(component)
        {
            // Automatically display smart tag panel when
            // design-time component is dropped onto the
            // Windows Forms Designer
            base.AutoShow = true;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            // Create list to store designer action items
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();

            actionItems.Add(
              new DesignerActionMethodItem(
                this,
                "ToggleDockStyle",
                GetDockStyleText(),
                "Design",
                "Dock or undock this control in it's parent container.",
                true));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "ShowBorder",
                "��ʾ�߿�",
                GetCategory(this.PanelHeadList, "ShowBorder")));

            actionItems.Add(new DesignerActionPropertyItem("CaptionColorBegin", "Ĭ�ϱ��⽥����ɫ", GetCategory(this.PanelHeadList, "CaptionColorBegin")));
            actionItems.Add(new DesignerActionPropertyItem("CaptionColorEnd", "Ĭ�ϱ��⽥����ɫ", GetCategory(this.PanelHeadList, "CaptionColorEnd")));
            actionItems.Add(new DesignerActionPropertyItem("CaptionDownColorBegin", "ѡ�б��⽥����ɫ", GetCategory(this.PanelHeadList, "CaptionDownColorBegin")));
            actionItems.Add(new DesignerActionPropertyItem("CaptionDownColorEnd", "ѡ�б��⽥����ɫ", GetCategory(this.PanelHeadList, "CaptionDownColorEnd")));
            actionItems.Add(new DesignerActionPropertyItem("CaptionMoveColorBegin", "�����ͣ���⽥����ɫ", GetCategory(this.PanelHeadList, "CaptionMoveColorBegin")));
            actionItems.Add(new DesignerActionPropertyItem("CaptionMoveColorEnd", "�����ͣ���⽥����ɫ", GetCategory(this.PanelHeadList, "CaptionMoveColorEnd")));

            actionItems.Add(
              new DesignerActionPropertyItem(
                "XPanderPanels",
                "Items",
                GetCategory(this.PanelHeadList, "Items")));

            return actionItems;
        }

        // Dock/Undock designer action method implementation
        //[CategoryAttribute("Design")]
        //[DescriptionAttribute("Dock/Undock in parent container.")]
        //[DisplayNameAttribute("Dock/Undock in parent container")]
        public void ToggleDockStyle()
        {
            // Toggle ClockControl's Dock property
            if (this.PanelHeadList.Dock != DockStyle.Fill)
            {
                SetProperty("Dock", DockStyle.Fill);
            }
            else
            {
                SetProperty("Dock", DockStyle.None);
            }
        }

        #endregion

        #region MethodsPrivate
        /// <summary>
        /// Helper method that returns an appropriate display name for the Dock/Undock property,
        /// based on the ClockControl's current Dock property value
        /// </summary>
        /// <returns>the string to display</returns>
        private string GetDockStyleText()
        {
            if (this.PanelHeadList.Dock == DockStyle.Fill)
            {
                return "ȡ���ڸ�������ͣ��";
            }
            else
            {
                return "�ڸ�������ͣ��";
            }
        }

        private JMPanelHeadList PanelHeadList
        {
            get { return (JMPanelHeadList)this.Component; }
        }

        // Helper method to safely set a component�s property
        private void SetProperty(string propertyName, object value)
        {
            // Get property
            System.ComponentModel.PropertyDescriptor property
                = System.ComponentModel.TypeDescriptor.GetProperties(this.PanelHeadList)[propertyName];
            // Set property value
            property.SetValue(this.PanelHeadList, value);
        }
        // Helper method to return the Category string from a
        // CategoryAttribute assigned to a property exposed by 
        //the specified object
        private static string GetCategory(object source, string propertyName)
        {
            System.Reflection.PropertyInfo property = source.GetType().GetProperty(propertyName);
            CategoryAttribute attribute = (CategoryAttribute)property.GetCustomAttributes(typeof(CategoryAttribute), false)[0];
            if (attribute == null)
            {
                return null;
            }
            else
            {
                return attribute.Category;
            }
        }

        #endregion
    }

    #endregion

    #region PanelHeadList PanelHeadListItem����� ɾ��

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface")]
    public sealed class PanelHeadListItemCollection : IList, ICollection, IEnumerable
    {

        #region FieldsPrivate

        private JMPanelHeadList m_xpanderPanelList;
        private Control.ControlCollection m_controlCollection;

        #endregion

        #region Constructor

        internal PanelHeadListItemCollection(JMPanelHeadList xpanderPanelList)
        {
            this.m_xpanderPanelList = xpanderPanelList;
            this.m_controlCollection = this.m_xpanderPanelList.Controls;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a XPanderPanel in the collection. 
        /// </summary>
        /// <param name="iIndex">The zero-based index of the XPanderPanel to get or set.</param>
        /// <returns>The xPanderPanel at the specified index.</returns>
        public PanelHeadListItem this[int index]
        {
            get { return (PanelHeadListItem)this.m_controlCollection[index] as PanelHeadListItem; }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Determines whether the XPanderPanelCollection contains a specific XPanderPanel
        /// </summary>
        /// <param name="value">The XPanderPanel to locate in the XPanderPanelCollection</param>
        /// <returns>true if the XPanderPanelCollection contains the specified value; otherwise, false.</returns>
        public bool Contains(PanelHeadListItem xpanderPanel)
        {
            return this.m_controlCollection.Contains(xpanderPanel);
        }
        /// <summary>
        /// Adds a XPanderPanel to the collection.  
        /// </summary>
        /// <param name="xpanderPanel">The XPanderPanel to add.</param>
        public void Add(PanelHeadListItem xpanderPanel)
        {
            this.m_controlCollection.Add(xpanderPanel);
            this.m_xpanderPanelList.Invalidate();

        }
        /// <summary>
        /// Removes the first occurrence of a specific XPanderPanel from the XPanderPanelCollection
        /// </summary>
        /// <param name="value">The XPanderPanel to remove from the XPanderPanelCollection</param>
        public void Remove(PanelHeadListItem xpanderPanel)
        {
            this.m_controlCollection.Remove(xpanderPanel);
        }
        /// <summary>
        /// Removes all the XPanderPanels from the collection. 
        /// </summary>
        public void Clear()
        {
            this.m_controlCollection.Clear();
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
            get { return this.m_controlCollection.IsReadOnly; }
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
        public int IndexOf(PanelHeadListItem xpanderPanel)
        {
            return this.m_controlCollection.IndexOf(xpanderPanel);
        }
        /// <summary>
        /// Removes the XPanderPanel at the specified index from the collection. 
        /// </summary>
        /// <param name="iIndex">The zero-based index of the xpanderPanel to remove from the ControlCollection instance.</param>
        public void RemoveAt(int index)
        {
            this.m_controlCollection.RemoveAt(index);
        }
        /// <summary>
        /// Inserts an XPanderPanel to the collection at the specified index. 
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted. </param>
        /// <param name="xpanderPanel">The XPanderPanel to insert into the Collection.</param>
        public void Insert(int index, PanelHeadListItem xpanderPanel)
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
        public void CopyTo(PanelHeadListItem[] xpanderPanels, int index)
        {
            this.m_controlCollection.CopyTo(xpanderPanels, index);
        }

        #endregion

        #region Interface ICollection

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

        #region Interface IList

        object IList.this[int index]
        {
            get { return this.m_controlCollection[index]; }
            set { }
        }

        int IList.Add(object value)
        {
            PanelHeadListItem xpanderPanel = value as PanelHeadListItem;
            if (xpanderPanel == null)
            {
                throw new ArgumentException();
            }
            this.Add(xpanderPanel);
            return this.IndexOf(xpanderPanel);
        }

        bool IList.Contains(object value)
        {
            return this.Contains(value as PanelHeadListItem);
        }

        int IList.IndexOf(object value)
        {
            return this.IndexOf(value as PanelHeadListItem);
        }

        void IList.Insert(int index, object value)
        {
            if ((value is PanelHeadListItem) == false)
            {
                throw new ArgumentException();
            }
        }

        void IList.Remove(object value)
        {
            this.Remove(value as PanelHeadListItem);
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

    #region PanelHeadList PanelHeadListItem����  �Ի���

    internal class PanelHeadListItemCollectionEditor : CollectionEditor
    {
        #region FieldsPrivate

        private CollectionForm m_collectionForm;

        #endregion

        #region MethodsPublic

        public PanelHeadListItemCollectionEditor(Type type)
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
            PanelHeadListItem xpanderPanel =(PanelHeadListItem)base.CreateInstance(ItemType);
            if (this.Context.Instance != null)
            {
                xpanderPanel.Expand = true;
            }
            return xpanderPanel;
        }

        #endregion
    }

    #endregion

    #region PanelHeadListItem
    [Designer(typeof(XPanderPanelDesigner))]
    [DesignTimeVisible(false)]
    public class PanelHeadListItem : ScrollableControl
    {

        #region ���ⵥ���¼�
        /// <summary>
        /// ���ⵥ���¼�
        /// </summary>
        [Description("���ⵥ���¼�")]
        public event EventHandler<XPanderPanelClickEventArgs> CaptionClick;
        #endregion

        #region ���캯��
        public PanelHeadListItem()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.ContainerControl, true);
            this.CaptionFont = new Font("Arial", SystemFonts.MenuFont.SizeInPoints + 1.5F, FontStyle.Bold);
            this.CaptionForeColor = SystemColors.ActiveCaptionText;
            this.BackColor = SystemColors.Window;
            this.ForeColor = SystemColors.ControlText;
            ShowPanelBackground = true;
            this.ShowPanelCaption = true;
            this.DockPadding.Top = this.CaptionHeight;
            this.GradientMode = LinearGradientMode.Vertical;
            this.m_imageSize = new Size(16, 16);
            this.m_imageRectangle = Rectangle.Empty;
            this.ShowBorder = true;
            m_bExpand = false;
        }
        #endregion

        #region ����
        //����ͼƬX����
        public const int CaptionSpacing = 6;
        //�Ҷ���ʱ�̶�ֵ
        public const int RightImagePositionX = 21;
        //����ͼƬY����
        public const int ImagePaddingTop = 5;
        //����߶�
        private const int m_iCaptionHeight = 26;
        #endregion

        #region ˽�б���

        #region panelCaption
        //չ��
        private bool m_bExpand;
        //���� ������ʽ
        private Font m_captionFont;
        //���� ��Χ
        private Rectangle m_imageRectangle;
        //���� ������ɫ
        private Color m_captionForeColor;
        //�Ƿ���ʾ�߿�
        private bool m_bShowBorder;
        //����ͼƬ��С
        private Size m_imageSize;
        //����ͼƬ
        private Image m_image;

        //���⽥�� ��ʼ��ɫ
        private Color m_colorCaptionGradientBegin = ProfessionalColors.OverflowButtonGradientBegin;
        //���⽥�� ������ɫ
        private Color m_colorCaptionGradientEnd = ProfessionalColors.OverflowButtonGradientEnd;

        //��꾭�� ���⽥�� ��ʼ��ɫ
        private Color m_movecolorCaptionGradientBegin = ProfessionalColors.OverflowButtonGradientBegin;
        //��꾭�� ���⽥�� ������ɫ
        private Color m_movecolorCaptionGradientEnd = ProfessionalColors.OverflowButtonGradientEnd;

        //����� ���⽥�� ��ʼ��ɫ
        private Color m_downcolorCaptionGradientBegin = ProfessionalColors.OverflowButtonGradientBegin;
        //����� ���⽥�� ������ɫ
        private Color m_downcolorCaptionGradientEnd = ProfessionalColors.OverflowButtonGradientEnd;
        //�߿���ɫ
        private Color m_borderColor = Color.DarkBlue;

        #endregion

        #region panel
        //panel�������� ��ʼ ��ɫ
        Color m_colorContentPanelGradientBegin = ProfessionalColors.ToolStripContentPanelGradientBegin;
        //panel�������� ���� ��ɫ
        Color m_colorContentPanelGradientEnd = ProfessionalColors.ToolStripContentPanelGradientEnd;
        //panel�������Խ��䷽��
        private LinearGradientMode m_linearGradientMode;
        //�Ƿ���ʾpanel����
        private bool m_bShowTransparentBackground;
        //�Ƿ���ʾpanel����
        private bool m_bShowXPanderPanelProfessionalStyle;
        #endregion

        #endregion

        #region ��������
        #region panelCaption
        /// <summary>
        /// ���û��ȡ����ͼƬ
        /// </summary>
        [Description("���û��ȡ����ͼƬ")]
        [Category("Appearance")]
        public Image CaptionImage
        {
            get { return this.m_image; }
            set
            {
                if (value != this.m_image)
                {
                    this.m_image = value;
                    this.Invalidate(this.CaptionRectangle);
                }
            }
        }
        /// <summary>
        /// ����߶� 
        /// </summary>
        [Description("����߶�"),
        DefaultValue(25),
        Category("Appearance")]
        public int CaptionHeight
        {
            get { return m_iCaptionHeight; }
            //set
            //{
            //    this.m_iCaptionHeight = value;
            //    this.Invalidate(this.CaptionRectangle);
            //}
        }
        /// <summary>
        /// ����������ʽ
        /// </summary>
        [Description("����������ʽ")]
        [DefaultValue(typeof(Font), "Microsoft Sans Serif; 8,25pt; style=Bold")]
        [Category("Appearance")]
        public Font CaptionFont
        {
            get { return this.m_captionFont; }
            set
            {
                if (value != null)
                {
                    if (value != this.m_captionFont)
                    {
                        this.m_captionFont = value;
                        this.Invalidate(this.CaptionRectangle);
                    }
                }
            }
        }
        /// <summary>
        /// ����������ɫ
        /// </summary>
        [Description("����������ɫ")]
        [DefaultValue(typeof(SystemColors), "System.Drawing.SystemColors.ActiveCaptionText")]
        [Category("Appearance")]
        public Color CaptionForeColor
        {
            get { return this.m_captionForeColor; }
            set
            {
                if (value != this.m_captionForeColor)
                {
                    this.m_captionForeColor = value;
                    this.Invalidate(this.CaptionRectangle);
                }
            }
        }
        /// <summary>
        /// ���⽥�� ��ʼ��ɫ
        /// </summary>
        [Description("���⽥�� ��ʼ��ɫ")]
        [Category("Appearance")]
        public Color CaptionColorBegin
        {
            get { return this.m_colorCaptionGradientBegin; }
            set
            {
                if (value != this.m_colorCaptionGradientBegin)
                {
                    this.m_colorCaptionGradientBegin = value;
                    this.Invalidate(this.CaptionRectangle);
                }
            }
        }
        /// <summary>
        /// ���⽥�� ������ɫ
        /// </summary>
        [Description("���⽥�� ������ɫ")]
        [Category("Appearance")]
        public Color CaptionColorEnd
        {
            get { return this.m_colorCaptionGradientEnd; }
            set
            {
                if (value != this.m_colorCaptionGradientEnd)
                {
                    this.m_colorCaptionGradientEnd = value;
                    this.Invalidate(this.CaptionRectangle);
                }
            }
        }
        /// <summary>
        /// ��꾭�����⽥�� ��ʼ��ɫ
        /// </summary>
        [Description("��꾭�����⽥�� ��ʼ��ɫ")]
        [Category("Appearance")]
        public Color CaptionMoveColorBegin
        {
            get { return this.m_movecolorCaptionGradientBegin; }
            set
            {
                if (value != this.m_colorCaptionGradientBegin)
                {
                    this.m_movecolorCaptionGradientBegin = value;
                    //this.Invalidate(this.CaptionRectangle);
                }
            }
        }
        /// <summary>
        /// ��꾭�����⽥�� ������ɫ
        /// </summary>
        [Description("��꾭�����⽥�� ������ɫ")]
        [Category("Appearance")]
        public Color CaptionMoveColorEnd
        {
            get { return this.m_movecolorCaptionGradientEnd; }
            set
            {
                if (value != this.m_movecolorCaptionGradientEnd)
                {
                    this.m_movecolorCaptionGradientEnd = value;
                    //this.Invalidate(this.CaptionRectangle);
                }
            }
        }
        /// <summary>
        /// ��꾭�����⽥�� ��ʼ��ɫ
        /// </summary>
        [Description("��������⽥�� ��ʼ��ɫ")]
        [Category("Appearance")]
        public Color CaptionDownColorBegin
        {
            get { return this.m_downcolorCaptionGradientBegin; }
            set
            {
                if (value != this.m_downcolorCaptionGradientBegin)
                {
                    this.m_downcolorCaptionGradientBegin = value;
                    //this.Invalidate(this.CaptionRectangle);
                }
            }
        }
        /// <summary>
        /// ��꾭�����⽥�� ������ɫ
        /// </summary>
        [Description("��������⽥�� ������ɫ")]
        [Category("Appearance")]
        public Color CaptionDownColorEnd
        {
            get { return this.m_downcolorCaptionGradientEnd; }
            set
            {
                if (value != this.m_downcolorCaptionGradientEnd)
                {
                    this.m_downcolorCaptionGradientEnd = value;
                    //this.Invalidate(this.CaptionRectangle);
                }
            }
        }
        /// <summary>
        /// �Ƿ���ʾ�߿�
        /// </summary>
        [Description("�Ƿ���ʾ�߿�")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(true)]
        [Browsable(true)]
        [Category("Appearance")]
        public bool ShowBorder
        {
            get { return this.m_bShowBorder; }
            set
            {
                if (value != this.m_bShowBorder)
                {
                    this.m_bShowBorder = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// �߿���ɫ
        /// </summary>
        [Description("�߿���ɫ")]
        [Category("Appearance")]
        public Color BorderColor
        {
            get { return m_borderColor; }
            set { m_borderColor = value; this.Invalidate(); }
        }
        #endregion

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        internal Rectangle CaptionRectangle
        {
            get { return new Rectangle(0, 0, this.ClientRectangle.Width, this.CaptionHeight); }
        }

        /// <summary>
        /// ��ȡͼƬ��С
        /// </summary>
        internal Size ImageSize
        {
            get { return this.m_imageSize; }
        }

        /// <summary>
        /// ��ȡͼƬ����
        /// </summary>
        internal Rectangle ImageRectangle
        {
            get
            {
                if (this.m_imageRectangle == Rectangle.Empty)
                {
                    this.m_imageRectangle = new Rectangle(
                        CaptionSpacing,
                        ImagePaddingTop,
                        this.m_imageSize.Width,
                        this.m_imageSize.Height);
                }
                return this.m_imageRectangle;
            }
        }

        #region panel
        /// <summary>
        /// չ��
        /// </summary>
        [Description("չ��")]
        [DefaultValue(false)]
        [Category("Appearance")]
        public bool Expand
        {
            get { return this.m_bExpand; }
            set
            {
                if (value != this.m_bExpand)
                {
                    this.m_bExpand = value;
                    if (this.DesignMode == true)
                    {
                        if (this.m_bExpand == true)
                        {
                            if (this.CaptionClick != null)
                            {
                                this.CaptionClick(this, new XPanderPanelClickEventArgs(this.m_bExpand));
                            }
                        }
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// ��ȡ������panel�������� ��ʼ ��ɫ
        /// </summary>
        [Description("panel�������� ��ʼ ��ɫ")]//System.ComponentModel
        [Category("Appearance")]
        public Color PanelColorBegin
        {
            get { return this.m_colorContentPanelGradientBegin; }
            set
            {
                if (value != this.m_colorContentPanelGradientBegin)
                {
                    this.m_colorContentPanelGradientBegin = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// panel�������� ���� ��ɫ
        /// </summary>
        [Description("panel�������� ���� ��ɫ")]
        [Category("Appearance")]
        public Color PanelColorEnd
        {
            get { return this.m_colorContentPanelGradientEnd; }
            set
            {
                if (value != this.m_colorContentPanelGradientEnd)
                {
                    this.m_colorContentPanelGradientEnd = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// panel�������Խ��䷽��
        /// </summary>
        [Description("panel�������Խ��䷽��"),
        DefaultValue(1),
        Category("Appearance")]
        public LinearGradientMode GradientMode
        {
            get { return this.m_linearGradientMode; }
            set
            {
                if (value != this.m_linearGradientMode)
                {
                    this.m_linearGradientMode = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// �Ƿ���ʾpanel����
        /// </summary>
        [Description("�Ƿ���ʾpanel����")]
        [DefaultValue(true)]
        [Category("Behavior")]
        public bool ShowPanelBackground
        {
            get { return this.m_bShowTransparentBackground; }
            set
            {
                if (value != this.m_bShowTransparentBackground)
                {
                    this.m_bShowTransparentBackground = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// �Ƿ���ʾpanel����
        /// </summary>
        [Description("�Ƿ���ʾpanel����")]
        [DefaultValue(true)]
        [Category("Behavior")]
        public bool ShowPanelCaption
        {
            get { return this.m_bShowXPanderPanelProfessionalStyle; }
            set
            {
                if (value != this.m_bShowXPanderPanelProfessionalStyle)
                {
                    this.m_bShowXPanderPanelProfessionalStyle = value;
                    this.Invalidate();
                }
            }
        }
        #endregion
        #endregion

        #region ���ط���

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (!ShowPanelBackground)
            {
                this.BackColor = Color.Transparent;
            }
            else
            {
                Color colorContentPanelGradientBegin = this.m_colorContentPanelGradientBegin;
                Color colorContentPanelGradientEnd = this.m_colorContentPanelGradientEnd;

                Rectangle rectangleBounds = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
                RenderBackgroundGradient(
                    e.Graphics,
                    rectangleBounds,
                    colorContentPanelGradientBegin,
                    colorContentPanelGradientEnd,
                    this.GradientMode);
            }
        }

        /// <summary>
        /// �ı�text����
        /// </summary>
        /// <param name="e">�ı�text����</param>
        protected override void OnTextChanged(EventArgs e)
        {
            this.Invalidate(this.CaptionRectangle);
            base.OnTextChanged(e);
        }

        public bool mouse = false;
        public bool mdown = false;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Y <= CaptionHeight)
            {
                mouse = true;
                this.Invalidate(CaptionRectangle);
                this.Cursor = Cursors.Hand;
            }
            else
            {
                mouse = false;
                this.Invalidate(CaptionRectangle);
                this.Cursor = Cursors.Default;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mouse = false;
            this.Invalidate(CaptionRectangle);
            this.Cursor = Cursors.Default;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Y <= CaptionHeight)
            {
                mdown = true;
                this.Invalidate(CaptionRectangle);
                this.Cursor = Cursors.Default;
                if (this.Parent == null)
                {
                    return;
                }
                if (this.m_bExpand == false)
                {
                    foreach (Control control in this.Parent.Controls)
                    {
                        PanelHeadListItem xpanderPanel = control as PanelHeadListItem;
                        if (xpanderPanel.Expand)
                        {
                            xpanderPanel.Expand = false;
                        }
                    }
                    this.m_bExpand = true;
                    if (this.CaptionClick != null)
                    {
                        this.CaptionClick(this, new XPanderPanelClickEventArgs(this.m_bExpand));
                    }
                }
            }
        }

        /// <summary>
        /// Visible���Ըı�ʱ
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.DesignMode == true)
            {
                return;
            }
            if (this.Visible == false)
            {
                if (this.Expand == true)
                {
                    this.Expand = false;
                    foreach (Control control in this.Parent.Controls)
                    {
                        PanelHeadListItem xpanderPanel = control as PanelHeadListItem;
                        if (xpanderPanel != null)
                        {
                            if (xpanderPanel.Visible == true)
                            {
                                xpanderPanel.Expand = true;
                                return;
                            }
                        }
                    }
                }
            }
#if DEBUG
            //System.Diagnostics.Trace.WriteLine("Visibility: " + this.Name + this.Visible);
#endif
            CalculatePanelHeights();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            base.OnPaint(e);
            Rectangle rectangle = this.CaptionRectangle;

            Color colorGradientBegin = this.CaptionColorBegin;
            Color colorGradientEnd = this.CaptionColorEnd;

            if (mouse && !this.Expand)
            {
                colorGradientBegin = this.m_movecolorCaptionGradientBegin;
                colorGradientEnd = this.m_movecolorCaptionGradientEnd;
            }
            else if (this.Expand)
            {
                colorGradientBegin = this.m_downcolorCaptionGradientBegin;
                colorGradientEnd = this.m_downcolorCaptionGradientEnd;
            }


            #region ��������
            if (ShowPanelCaption)
            {
                RenderBackgroundGradient(
                    e.Graphics,
                    rectangle,
                    colorGradientBegin,
                    colorGradientEnd,
                    LinearGradientMode.Vertical);
            }
            #endregion

            CalculatePanelHeights();

            if (this.ShowBorder == true)
            {
                using (SolidBrush borderBrush = new SolidBrush(this.BorderColor))
                {
                    using (Pen borderPen = new Pen(borderBrush, 1))
                    {
                        Pen borderPen1 = new Pen(borderBrush, 3);
                        e.Graphics.DrawLine(borderPen1, this.ClientRectangle.Left, this.ClientRectangle.Height, this.ClientRectangle.Width, this.ClientRectangle.Height);
                        e.Graphics.DrawLine(borderPen, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Left, this.ClientRectangle.Height);
                        e.Graphics.DrawLine(borderPen1, this.ClientRectangle.Width, this.ClientRectangle.Top, this.ClientRectangle.Width, this.ClientRectangle.Height);
                        e.Graphics.DrawLine(borderPen, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Width, this.ClientRectangle.Top);
                    }
                }
            }

            //��Ż��������ݿ�ʼλ��  (�����ͼƬ�Ȼ�ͼƬ Ȼ������)
            int iTextPositionX = CaptionSpacing;//��ʼ��ͼƬ��ʼλ��
            if (this.CaptionImage != null)
            {
                Rectangle imageRectangle = this.ImageRectangle;
                //����֮��
                if (this.RightToLeft == RightToLeft.No)
                {
                    DrawImage(e.Graphics, this.CaptionImage, imageRectangle);
                    iTextPositionX += this.ImageSize.Width + CaptionSpacing;
                }
                else
                {
                    imageRectangle.X = this.ClientRectangle.Right - RightImagePositionX;
                    DrawImage(e.Graphics, this.CaptionImage, imageRectangle);
                }
            }
            Rectangle textRectangle = rectangle;
            textRectangle.X = iTextPositionX;
            textRectangle.Width -= iTextPositionX + CaptionSpacing;
            if (this.RightToLeft == RightToLeft.Yes)
            {
                if (this.CaptionImage != null)
                {
                    textRectangle.Width -= RightImagePositionX;
                }
            }
            DrawString(e.Graphics, textRectangle, this.CaptionFont, this.CaptionForeColor, this.Text, this.RightToLeft);
        }
        #endregion

        #region ����
        /// <summary>
        /// ��panel����
        /// </summary>
        /// <param name="graphics">����</param>
        /// <param name="bounds">��Χ</param>
        /// <param name="beginColor">���俪ʼ��ɫ</param>
        /// <param name="endColor">���������ɫ</param>
        /// <param name="linearGradientMode">���䷽��</param>
        protected static void RenderBackgroundGradient(Graphics graphics, Rectangle bounds, Color beginColor, Color endColor, LinearGradientMode linearGradientMode)
        {
            if (graphics == null)
            {
                throw new Exception();
            }
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, beginColor, endColor, linearGradientMode))
            {
                if (IsZeroWidthOrHeight(bounds))
                {
                    return;
                }

                linearGradientBrush.TranslateTransform((float)(bounds.Location.X + bounds.Width), (float)(bounds.Y - bounds.Height));
                graphics.FillRectangle(linearGradientBrush, new Rectangle(Point.Empty, bounds.Size));
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="graphics">����</param>
        /// <param name="layoutRectangle">��������</param>
        /// <param name="font">������������</param>
        /// <param name="fontColor">������ɫ</param>
        /// <param name="strText">��������</param>
        /// <param name="rightToLeft">���뷽ʽ</param>
        protected static void DrawString(Graphics graphics, Rectangle layoutRectangle, Font font, Color fontColor, string strText, RightToLeft rightToLeft)
        {
            if (graphics == null)
            {
                throw new Exception();
            }
            using (SolidBrush stringBrush = new SolidBrush(fontColor))
            {
                using (StringFormat stringFormat = new StringFormat())
                {
                    if (rightToLeft == RightToLeft.Yes)
                    {
                        stringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft;
                    }
                    else
                    {
                        stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                    }
                    stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    graphics.DrawString(strText, font, stringBrush, layoutRectangle, stringFormat);
                }
            }
        }

        /// <summary>
        /// ��ͼƬ
        /// </summary>
        /// <param name="graphics">����</param>
        /// <param name="image">ͼƬ</param>
        /// <param name="imageRectangle">����</param>
        protected static void DrawImage(Graphics graphics, Image image, Rectangle imageRectangle)
        {
            if (graphics == null)
            {
                throw new Exception();
            }
            if (image != null)
            {
                graphics.DrawImage(image, imageRectangle);
            }
        }

        /// <summary>
        /// �����η�Χ�Ƿ�Ϊ0
        /// </summary>
        /// <param name="rectangle">���ζ���</param>
        /// <returns></returns>
        private static bool IsZeroWidthOrHeight(Rectangle rectangle)
        {
            if (rectangle.Width != 0)
            {
                return (rectangle.Height == 0);
            }
            return true;
        }

        #region �ڸ����������Լ�λ��
        private void CalculatePanelHeights()
        {
            if (this.Parent == null)
            {
                return;
            }
            int iPanelHeight = this.Parent.Padding.Top;

            foreach (Control control in this.Parent.Controls)
            {
                PanelHeadListItem xpanderPanel = control as PanelHeadListItem;
                xpanderPanel.Width = this.Parent.Width;
                if (xpanderPanel != null)
                {
                    if (xpanderPanel.Visible == true)
                    {
                        iPanelHeight += this.CaptionHeight;
                    }
                }
            }

            iPanelHeight += this.Parent.Padding.Bottom;

            foreach (Control control in this.Parent.Controls)
            {
                PanelHeadListItem xpanderPanel =
                    control as PanelHeadListItem;

                if (xpanderPanel != null)
                {
                    if (xpanderPanel.Expand == true)
                    {
                        xpanderPanel.Height = this.Parent.Height
                            + this.CaptionHeight
                            - iPanelHeight;
                    }
                    else
                    {
                        xpanderPanel.Height = this.CaptionHeight;
                    }
                }
            }

            int iTop = this.Parent.Padding.Top;
            foreach (Control control in this.Parent.Controls)
            {
                PanelHeadListItem xpanderPanel =
                    control as PanelHeadListItem;

                if (xpanderPanel != null)
                {
                    if (xpanderPanel.Visible == true)
                    {
                        xpanderPanel.Top = iTop;
                        iTop += xpanderPanel.Height;
                    }
                }
            }
        }
        #endregion

        #endregion
    }
    #endregion

    #region PanelHeadListItem�ؼ����ģʽ ȥ���������� ����������Ǹ���Ƶĸ�����

    internal class XPanderPanelDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
    {
        #region FieldsPrivate

        private Pen m_BorderPen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark));

        #endregion

        #region MethodsPublic
        /// <summary>
        /// 
        /// </summary>
        public XPanderPanelDesigner()
        {
            this.m_BorderPen.DashStyle = DashStyle.Dash;
        }
        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The IComponent to associate with the designer.</param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
        }
        /// <summary>
        /// Gets the selection rules that indicate the movement capabilities of a component.
        /// </summary>
        public override System.Windows.Forms.Design.SelectionRules SelectionRules
        {
            get
            {
                System.Windows.Forms.Design.SelectionRules selectionRules
                    = System.Windows.Forms.Design.SelectionRules.None;

                return selectionRules;
            }
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Receives a call when the control that the designer is managing has painted its surface so the designer can
        /// paint any additional adornments on top of the xpanderpanel.
        /// </summary>
        /// <param name="e">A PaintEventArgs the designer can use to draw on the xpanderpanel.</param>
        protected override void OnPaintAdornments(PaintEventArgs e)
        {
            base.OnPaintAdornments(e);
            e.Graphics.DrawRectangle(
                this.m_BorderPen,
                0,
                0,
                this.Control.Width - 2,
                this.Control.Height - 2);
        }
        /// <summary>
        /// Allows a designer to change or remove items from the set of properties that it exposes through a <see cref="TypeDescriptor">TypeDescriptor</see>. 
        /// </summary>
        /// <param name="properties">The properties for the class of the component.</param>
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("AccessibilityObject");
            properties.Remove("AccessibleDefaultActionDescription");
            properties.Remove("AccessibleDescription");
            properties.Remove("AccessibleName");
            properties.Remove("AccessibleRole");
            properties.Remove("AllowDrop");
            properties.Remove("Anchor");
            properties.Remove("AntiAliasing");
            properties.Remove("AutoScroll");
            properties.Remove("AutoScrollMargin");
            properties.Remove("AutoScrollMinSize");
            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("CausesValidation");
            properties.Remove("ContextMenuStrip");
            properties.Remove("Dock");
            properties.Remove("GenerateMember");
            properties.Remove("ImeMode");
            properties.Remove("Location");
            properties.Remove("MaximumSize");
            properties.Remove("MinimumSize");
            properties.Remove("Size");
        }

        #endregion
    }

    #endregion
}
