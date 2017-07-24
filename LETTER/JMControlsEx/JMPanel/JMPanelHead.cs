using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace JMControlsEx
{
    [Designer(typeof(PanelDesigner)),DesignTimeVisibleAttribute(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
    public class JMPanelHead : ScrollableControl
    {
        #region 构造函数
        public JMPanelHead()
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
            m_canTd = false;
        }
        #endregion

        #region 常量
        //标题图片X坐标
        public const int CaptionSpacing = 6;
        //右对齐时固定值
        public const int RightImagePositionX = 21;
        //标题图片Y坐标
        public const int ImagePaddingTop = 5;
        //标题高度
        private const int m_iCaptionHeight = 25;
        #endregion

        #region 私有变量

        #region panelCaption

        //标题 字体样式
        private Font m_captionFont;
        //标题 范围
        private Rectangle m_imageRectangle;
        //标题 字体颜色
        private Color m_captionForeColor;
        //是否显示边框
        private bool m_bShowBorder;
        //标题图片大小
        private Size m_imageSize;
        //标题图片
        private Image m_image;

        //标题渐变 开始颜色
        private Color m_colorCaptionGradientBegin = ProfessionalColors.OverflowButtonGradientBegin;
        //标题渐变 结束颜色
        private Color m_colorCaptionGradientEnd = ProfessionalColors.OverflowButtonGradientEnd;

        //鼠标经过 标题渐变 开始颜色
        private Color m_movecolorCaptionGradientBegin = ProfessionalColors.OverflowButtonGradientBegin;
        //鼠标经过 标题渐变 结束颜色
        private Color m_movecolorCaptionGradientEnd = ProfessionalColors.OverflowButtonGradientEnd;

        //边框颜色
        private Color m_borderColor = Color.DarkBlue;
        //边框颜色
        private bool m_canTd = false;

        #endregion

        #region panel
        //panel背景渐变 开始 颜色
        Color m_colorContentPanelGradientBegin = ProfessionalColors.ToolStripContentPanelGradientBegin;
        //panel背景渐变 结束 颜色
        Color m_colorContentPanelGradientEnd = ProfessionalColors.ToolStripContentPanelGradientEnd;
        //panel背景线性渐变方向
        private LinearGradientMode m_linearGradientMode;
        //是否显示panel背景
        private bool m_bShowTransparentBackground;
        //是否显示panel标题
        private bool m_bShowXPanderPanelProfessionalStyle;
        #endregion

        #endregion

        #region 公共属性
        #region panelCaption
        /// <summary>
        /// 设置或获取标题图片
        /// </summary>
        [Description("设置或获取标题图片")]
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
        /// 标题高度 
        /// </summary>
        [Description("标题高度"),
        DefaultValue(25),
        Category("Appearance")]
        public int CaptionHeight
        {
            get { return m_iCaptionHeight; }
            //set {
            //    this.m_iCaptionHeight = value;
            //    this.Invalidate(this.CaptionRectangle);
            //    }
        }
        /// <summary>
        /// 标题字体样式
        /// </summary>
        [Description("标题字体样式")]
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
        /// 标题字体颜色
        /// </summary>
        [Description("标题字体颜色")]
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
        /// 标题渐变 开始颜色
        /// </summary>
        [Description("标题渐变 开始颜色")]
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
        /// 标题渐变 结束颜色
        /// </summary>
        [Description("标题渐变 结束颜色")]
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
        /// 拖动空间时标题渐变 开始颜色
        /// </summary>
        [Description("拖动空间时标题渐变 开始颜色")]
        [Category("Appearance")]
        public Color CaptionMoveColorBegin
        {
            get { return this.m_movecolorCaptionGradientBegin; }
            set
            {
                if (value != this.m_colorCaptionGradientBegin)
                {
                    this.m_movecolorCaptionGradientBegin = value;
                }
            }
        }
        /// <summary>
        /// 拖动空间时标题渐变 结束颜色
        /// </summary>
        [Description("拖动空间时标题渐变 结束颜色")]
        [Category("Appearance")]
        public Color CaptionMoveColorEnd
        {
            get { return this.m_movecolorCaptionGradientEnd; }
            set
            {
                if (value != this.m_movecolorCaptionGradientEnd)
                {
                    this.m_movecolorCaptionGradientEnd = value;
                }
            }
        }
        
        /// <summary>
        /// 是否显示边框
        /// </summary>
        [Description("是否显示边框")]
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
        /// 边框颜色
        /// </summary>
        [Description("边框颜色")]
        [Category("Appearance")]
        public Color BorderColor
        {
            get { return m_borderColor; }
            set { m_borderColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// panel是否可以拖动
        /// </summary>
        [Description("panel是否可以拖动")]
        [DefaultValue(false)]
        [Category("Collections")]
        public bool CanTd
        {
            get { return m_canTd; }
            set { m_canTd = value; }
        }
        #endregion

        /// <summary>
        /// 获取标题区域
        /// </summary>
        internal Rectangle CaptionRectangle
        {
            get { return new Rectangle(0, 0, this.ClientRectangle.Width, this.CaptionHeight); }
        }

        /// <summary>
        /// 获取图片大小
        /// </summary>
        internal Size ImageSize
        {
            get { return this.m_imageSize; }
        }

        /// <summary>
        /// 获取图片区域
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
        /// 获取或设置panel背景渐变 开始 颜色
        /// </summary>
        [Description("panel背景渐变 开始 颜色")]//System.ComponentModel
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
        /// panel背景渐变 结束 颜色
        /// </summary>
        [Description("panel背景渐变 结束 颜色")]
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
        /// panel背景线性渐变方向
        /// </summary>
        [Description("panel背景线性渐变方向"),
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
        /// 是否显示panel背景
        /// </summary>
        [Description("是否显示panel背景")]
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
                    if (m_bShowTransparentBackground)
                    {
                        this.Height = 200;
                    }
                    else
                    {
                        this.Height = CaptionHeight;
                    }
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 是否显示panel标题
        /// </summary>
        [Description("是否显示panel标题")]
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

        #region 重载方法

        /// <summary>
        /// 画背景
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
        /// 改变text内容
        /// </summary>
        /// <param name="e">改变text内容</param>
        protected override void OnTextChanged(EventArgs e)
        {
            this.Invalidate(this.CaptionRectangle);
            base.OnTextChanged(e);
        }

        private bool mouse = false;//当前鼠标左键是否按下
        private int lx = 0;//移动之前x 坐标
        private int ly = 0;//移动之前y 坐标

        /// <summary>
        /// 移动鼠标
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (CanTd)
            {
                if (e.Y <= CaptionHeight)
                {
                    this.Cursor = Cursors.Hand;
                    if (e.Button == MouseButtons.Left)
                    {
                        this.Cursor = Cursors.SizeAll;
                        this.Location = new Point(this.Location.X + (e.X - lx), this.Location.Y + (e.Y - ly));
                    }

                }
                else
                {
                    mouse = false;
                    this.Invalidate(CaptionRectangle);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// 移开鼠标
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            mouse = false;
            this.Invalidate(CaptionRectangle);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 按下鼠标
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Y <= CaptionHeight)
            {
                if (CanTd)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        this.Cursor = Cursors.SizeAll;
                        lx = e.X;
                        ly = e.Y;
                        mouse = true;
                        this.Invalidate(CaptionRectangle);
                    }
                    else
                    {
                        this.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 释放鼠标
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (CanTd)
            {
                mouse = false;
                this.Invalidate(CaptionRectangle);
            }
        }
        
        /// <summary>
        /// 画标题部分
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            base.OnPaint(e);
            Rectangle rectangle = this.CaptionRectangle;

            Color colorGradientBegin = this.CaptionColorBegin;
            Color colorGradientEnd = this.CaptionColorEnd;

            if (mouse)
            {
                colorGradientBegin = this.m_movecolorCaptionGradientBegin;
                colorGradientEnd = this.m_movecolorCaptionGradientEnd;
            }

            #region 标题区域
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

            //存放画标题内容开始位置  (如果有图片先画图片 然后画内容)
            int iTextPositionX = CaptionSpacing;//初始化图片开始位置
            if (this.CaptionImage != null)
            {
                Rectangle imageRectangle = this.ImageRectangle;
                //从左之右
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

        #region 方法
        /// <summary>
        /// 画panel背景
        /// </summary>
        /// <param name="graphics">画布</param>
        /// <param name="bounds">范围</param>
        /// <param name="beginColor">渐变开始颜色</param>
        /// <param name="endColor">渐变结束颜色</param>
        /// <param name="linearGradientMode">渐变方向</param>
        protected static void RenderBackgroundGradient(Graphics graphics, Rectangle bounds, Color beginColor, Color endColor, LinearGradientMode linearGradientMode)
        {
            if (graphics == null)
            {
                throw new Exception();
            }
            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                return;
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
        /// 画标题内容
        /// </summary>
        /// <param name="graphics">画布</param>
        /// <param name="layoutRectangle">标题区域</param>
        /// <param name="font">标题内容字体</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="strText">字体内容</param>
        /// <param name="rightToLeft">对齐方式</param>
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
        /// 画图片
        /// </summary>
        /// <param name="graphics">画布</param>
        /// <param name="image">图片</param>
        /// <param name="imageRectangle">区域</param>
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
        /// 检查矩形范围是否为0
        /// </summary>
        /// <param name="rectangle">矩形对象</param>
        /// <returns></returns>
        private static bool IsZeroWidthOrHeight(Rectangle rectangle)
        {
            if (rectangle.Width != 0)
            {
                return (rectangle.Height == 0);
            }
            return true;
        }
        #endregion
    }

    #region 控件右上角属性编辑器
    internal class PanelDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {
        #region 构造函数
        public PanelDesigner()
        {
        }
        #endregion

        #region 重写方法属性
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
        }

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // 初始化属性集合
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                // 添加属性集合
                actionLists.Add(new PanelDesignerActionList(this.Component));

                // 返回属性集合
                return actionLists;
            }
        }
        
        protected override void OnPaintAdornments(PaintEventArgs e)
        {
            base.OnPaintAdornments(e);
        }

        #endregion
    }

    #endregion

    #region 属性集合类
    public class PanelDesignerActionList : DesignerActionList
    {
        #region 公共属性

        public bool ShowTransparentBackground
        {
            get { return this.Panel.ShowPanelBackground; }
            set { SetProperty("ShowPanelBackground", value); }
        }
        public bool ShowXPanderPanelProfessionalStyle
        {
            get { return this.Panel.ShowPanelCaption; }
            set { SetProperty("ShowPanelCaption", value); }
        }
        public Image CaptionImage
        {
            get { return this.Panel.CaptionImage; }
            set { SetProperty("CaptionImage", value); }
        }
        #endregion

        #region 构造函数
        public PanelDesignerActionList(System.ComponentModel.IComponent component)
            : base(component)
        {
            // Automatically display smart tag panel when
            // design-time component is dropped onto the
            // Windows Forms Designer
            base.AutoShow = true;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 属性集合
        /// </summary>
        /// <returns></returns>
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
                "ShowTransparentBackground",//属性名称
                "是否显示背景",//注释
                GetCategory(this.Panel, "ShowPanelBackground")));

            actionItems.Add(new DesignerActionPropertyItem("ShowXPanderPanelProfessionalStyle","是否显示表头",GetCategory(this.Panel, "ShowPanelCaption")));

            actionItems.Add(new DesignerActionPropertyItem("CaptionImage", "标题图片", GetCategory(this.Panel, "CaptionImage")));

            return actionItems;
        }

        //给dock属性赋相应值
        public void ToggleDockStyle()
        {
            if (this.Panel.Dock != DockStyle.Fill)
            {
                SetProperty("Dock", DockStyle.Fill);
            }
            else
            {
                SetProperty("Dock", DockStyle.None);
            }
        }

        #endregion

        #region 方法

        //获取Dock属性文字说明
        private string GetDockStyleText()
        {
            if (this.Panel.Dock == DockStyle.Fill)
            {
                return "取消在父容器中停靠";
            }
            else
            {
                return "在父容器中停靠";
            }
        }

        private JMPanelHead Panel
        {
            get { return (JMPanelHead)this.Component; }
        }

        // 获取属性并赋值
        private void SetProperty(string propertyName, object value)
        {
            // 获取属性
            System.ComponentModel.PropertyDescriptor property
                = System.ComponentModel.TypeDescriptor.GetProperties(this.Panel)[propertyName];
            // 给属性赋值
            property.SetValue(this.Panel, value);
        }

        // 获取属性类别
        private static string GetCategory(object source, string propertyName)
        {
            System.Reflection.PropertyInfo property = source.GetType().GetProperty(propertyName);
            CategoryAttribute attribute = (CategoryAttribute)property.GetCustomAttributes(typeof(CategoryAttribute), false)[0];
            if (attribute == null) return null;
            return attribute.Category;
        }

        #endregion
    }
    #endregion
}
