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
        #region ���캯��
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

        #region ����
        //����ͼƬX����
        public const int CaptionSpacing = 6;
        //�Ҷ���ʱ�̶�ֵ
        public const int RightImagePositionX = 21;
        //����ͼƬY����
        public const int ImagePaddingTop = 5;
        //����߶�
        private const int m_iCaptionHeight = 25;
        #endregion

        #region ˽�б���

        #region panelCaption

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

        //�߿���ɫ
        private Color m_borderColor = Color.DarkBlue;
        //�߿���ɫ
        private bool m_canTd = false;

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
            //set {
            //    this.m_iCaptionHeight = value;
            //    this.Invalidate(this.CaptionRectangle);
            //    }
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
        /// �϶��ռ�ʱ���⽥�� ��ʼ��ɫ
        /// </summary>
        [Description("�϶��ռ�ʱ���⽥�� ��ʼ��ɫ")]
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
        /// �϶��ռ�ʱ���⽥�� ������ɫ
        /// </summary>
        [Description("�϶��ռ�ʱ���⽥�� ������ɫ")]
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

        /// <summary>
        /// panel�Ƿ�����϶�
        /// </summary>
        [Description("panel�Ƿ�����϶�")]
        [DefaultValue(false)]
        [Category("Collections")]
        public bool CanTd
        {
            get { return m_canTd; }
            set { m_canTd = value; }
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

        private bool mouse = false;//��ǰ�������Ƿ���
        private int lx = 0;//�ƶ�֮ǰx ����
        private int ly = 0;//�ƶ�֮ǰy ����

        /// <summary>
        /// �ƶ����
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
        /// �ƿ����
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            mouse = false;
            this.Invalidate(CaptionRectangle);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// �������
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
        /// �ͷ����
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
        /// �����ⲿ��
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
        #endregion
    }

    #region �ؼ����Ͻ����Ա༭��
    internal class PanelDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {
        #region ���캯��
        public PanelDesigner()
        {
        }
        #endregion

        #region ��д��������
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
        }

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // ��ʼ�����Լ���
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                // ������Լ���
                actionLists.Add(new PanelDesignerActionList(this.Component));

                // �������Լ���
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

    #region ���Լ�����
    public class PanelDesignerActionList : DesignerActionList
    {
        #region ��������

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

        #region ���캯��
        public PanelDesignerActionList(System.ComponentModel.IComponent component)
            : base(component)
        {
            // Automatically display smart tag panel when
            // design-time component is dropped onto the
            // Windows Forms Designer
            base.AutoShow = true;
        }
        #endregion

        #region ����
        /// <summary>
        /// ���Լ���
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
                "ShowTransparentBackground",//��������
                "�Ƿ���ʾ����",//ע��
                GetCategory(this.Panel, "ShowPanelBackground")));

            actionItems.Add(new DesignerActionPropertyItem("ShowXPanderPanelProfessionalStyle","�Ƿ���ʾ��ͷ",GetCategory(this.Panel, "ShowPanelCaption")));

            actionItems.Add(new DesignerActionPropertyItem("CaptionImage", "����ͼƬ", GetCategory(this.Panel, "CaptionImage")));

            return actionItems;
        }

        //��dock���Ը���Ӧֵ
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

        #region ����

        //��ȡDock��������˵��
        private string GetDockStyleText()
        {
            if (this.Panel.Dock == DockStyle.Fill)
            {
                return "ȡ���ڸ�������ͣ��";
            }
            else
            {
                return "�ڸ�������ͣ��";
            }
        }

        private JMPanelHead Panel
        {
            get { return (JMPanelHead)this.Component; }
        }

        // ��ȡ���Բ���ֵ
        private void SetProperty(string propertyName, object value)
        {
            // ��ȡ����
            System.ComponentModel.PropertyDescriptor property
                = System.ComponentModel.TypeDescriptor.GetProperties(this.Panel)[propertyName];
            // �����Ը�ֵ
            property.SetValue(this.Panel, value);
        }

        // ��ȡ�������
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
