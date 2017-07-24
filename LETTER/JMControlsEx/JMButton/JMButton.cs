using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JMButton : Button
    {
        /// <summary>
        /// �Ƿ���ʾ������Ч��
        /// </summary>
        private bool SFVisibleEffect = false;

        /// <summary>
        /// �Ƿ���ʾ��갴��Ч��
        /// </summary>
        private bool SFDownEffect = false;

        #region ˽�б���
        /// <summary>
        /// ��ť��ɫ
        /// </summary>
        private Color _JMBaseColor;
        /// <summary>
        /// ��ť��ɫ
        /// </summary>
        private Color _JMBaseColorTwo;
        /// <summary>
        /// ��ť״̬
        /// </summary>
        private ControlState _JMControlState;
        /// <summary>
        /// ��ťԲ�ǻ���
        /// </summary>
        private int _JMRadius;
        /// <summary>
        /// ��ťԲ����ʽ
        /// </summary>
        private RoundStyle _JMRoundStyle;
        /// <summary>
        /// ͼ���С
        /// </summary>
        private Size _ImageSize;

        private bool _JMSFNew;
        #endregion

        #region ���캯��
        public JMButton()
        {
            _JMBaseColorTwo = Color.White;
            this._JMBaseColor = Color.Gainsboro;
            this._JMRoundStyle = RoundStyle.All;
            this._JMSFNew = false;
            this._JMRadius = 8;
            this._ImageSize = new Size(20, 20);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint, true);
        }
        #endregion

        #region ����
        [Category("Appearance"), Description("��ť��ɫ"), DefaultValue(typeof(Color), "51, 161, 224")]
        public Color JMBaseColor
        {
            get { return _JMBaseColor; }
            set { _JMBaseColor = value; Invalidate(); }
        }

        [Category("Appearance"), Description("��ť��ɫ"), DefaultValue(typeof(Color), "51, 161, 224")]
        public Color JMBaseColorTwo
        {
            get { return _JMBaseColorTwo; }
            set { _JMBaseColorTwo = value; Invalidate(); }
        }
        //[Category("Appearance"),
        //Description("ͼƬ���"), 
        //DefaultValue(0x12)]
        //public int _ImageSize.Width
        //{
        //    get
        //    {
        //        return this.__ImageSize.Width;
        //    }
        //    set
        //    {
        //        this.__ImageSize.Width = value;
        //        //if (value != this.__ImageSize.Width)
        //        //{
        //        //    this.__ImageSize.Width = (value < 12) ? 12 : value;
        //        //    base.Invalidate();
        //        //}
        //        base.Invalidate();
        //    }
        //}

        [Category("Appearance"), Description("��ťԲ�ǻ���"), DefaultValue(8)]
        public int JMRadius
        {
            get { return _JMRadius; }
            set { _JMRadius = value; }
        }

        [Category("Appearance"), Description("��ťԲ����ʽ"), DefaultValue(typeof(RoundStyle), "All")]
        public RoundStyle JMRoundStyle
        {
            get { return _JMRoundStyle; }
            set
            {
                if (_JMRoundStyle != value)
                {
                    _JMRoundStyle = value;
                    Invalidate();
                }
            }
        }

        [Description("��ť״̬")]
        internal ControlState JMControlState
        {
            get
            {
                return this._JMControlState;
            }
            set
            {
                if (this._JMControlState != value)
                {
                    this._JMControlState = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Appearance"), Description("��ťԲ����ʽ"), DefaultValue(typeof(Size), "20, 20")]
        public Size ImageSize
        {
            get { return _ImageSize; }
            set { _ImageSize = value; Invalidate(); }
        }

        [Description("��ť״̬"), DefaultValue(typeof(bool), "false")]
        public bool JMSFNew
        {
            get { return _JMSFNew; }
            set { _JMSFNew = value; Invalidate(); }
        }
        #endregion

        #region Override ����¼�
        /// <summary>
        /// �������¼�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            SFVisibleEffect = true;
            Invalidate();
        }

        /// <summary>
        /// ����뿪�¼�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SFVisibleEffect = false;
            Invalidate();
        }

        /// <summary>
        /// ��갴���¼�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            SFDownEffect = true;
            SFVisibleEffect = false;
            Invalidate();
        }

        /// <summary>
        /// ����ɿ��¼�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            SFDownEffect = false;
            SFVisibleEffect = true;
            Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            SFVisibleEffect = true;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            SFVisibleEffect = false;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }
        #endregion

        /// <summary>
        /// ��ɫ����Ч��
        /// </summary>
        /// <param name="rec">����ʹ�С</param>
        /// <param name="_JBColorOne">��ʼ������ɫ</param>
        /// <param name="_JBColorTwo">�м佥����ɫ</param>
        /// <param name="_JBColorThree">����������ɫ</param>
        /// <param name="lgm">���䷽��</param>
        /// <returns></returns>
        private LinearGradientBrush ColorGradient(Rectangle rec, Color _JBColorOne, Color _JBColorTwo, Color _JBColorThree, LinearGradientMode lgm)
        {
            LinearGradientBrush lb = new LinearGradientBrush(rec, _JBColorOne, _JBColorTwo, lgm);

            Color[] colors = new Color[3];
            colors[0] = _JBColorOne;
            colors[1] = _JBColorTwo;
            colors[2] = _JBColorThree;

            ColorBlend blend = new ColorBlend();
            blend.Positions = new float[] { 0.0f, 0.5f, 1.0f };
            blend.Colors = colors;
            lb.InterpolationColors = blend;
            return lb;
        }

        #region �ػ�
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);

            Rectangle rectangle;//ͼƬ��Χ
            Rectangle rectangle2;//���巶Χ
            this.CalculateRect(out rectangle, out rectangle2);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rec = new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1);

            if (base.Enabled)
            {
                //��䰴ť��ɫЧ��
                GraphicsPath aa = GetGraphicPath.CreatePath(rec, _JMRadius, _JMRoundStyle, true);
                aa.CloseFigure();
                g.FillPath(new LinearGradientBrush(rec, _JMBaseColorTwo, _JMBaseColor, LinearGradientMode.Vertical), aa);
                g.DrawPath(new Pen(new SolidBrush(Color.DarkGray)), aa);

                //����������Ч��
                if (SFVisibleEffect)
                {
                    Color col1 = ColorClass.GetColor(_JMBaseColorTwo, 0, -10, -10, -10);
                    Color col2 = ColorClass.GetColor(_JMBaseColor, 0, 30, 30, 30);
                    GraphicsPath bb = GetGraphicPath.CreatePath(base.ClientRectangle, _JMRadius, _JMRoundStyle, true);
                    bb.CloseFigure();
                    g.FillPath(new LinearGradientBrush(base.ClientRectangle, col1, col2, LinearGradientMode.Vertical), bb);
                    g.DrawPath(new Pen(new SolidBrush(Color.DarkGray)), aa);
                }
                else if (SFDownEffect)//������갴��Ч��
                {
                    Color col1 = ColorClass.GetColor(_JMBaseColorTwo, 0, -15, -15, -15);
                    Color col2 = ColorClass.GetColor(_JMBaseColor, 0, 65, 65, 65);
                    GraphicsPath cc = GetGraphicPath.CreatePath(base.ClientRectangle, _JMRadius, _JMRoundStyle, true);
                    cc.CloseFigure();
                    g.FillPath(new LinearGradientBrush(base.ClientRectangle, col1, col2, LinearGradientMode.Vertical), cc);
                    g.DrawPath(new Pen(new SolidBrush(Color.DarkGray)), aa);
                }

                //����ͼƬ
                if (base.Image != null)
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    g.DrawImage(base.Image, rectangle);
                }
            }
            else//������Ϊ����ɫ��
            {
                //��䰴ť��ɫЧ��
                GraphicsPath aa = GetGraphicPath.CreatePath(base.ClientRectangle, _JMRadius, _JMRoundStyle, true);
                aa.CloseFigure();
                g.FillPath(new LinearGradientBrush(base.ClientRectangle, SystemColors.ControlDark, SystemColors.ControlDark, LinearGradientMode.Vertical), aa);
                g.DrawPath(new Pen(new SolidBrush(Color.DarkGray)), aa);
            }

            //��������
            TextRenderer.DrawText(g, this.Text, this.Font, rectangle2, this.ForeColor, TextFormat.GetTextFormatFlags(this.TextAlign, this.RightToLeft == RightToLeft.Yes));

            if (_JMSFNew)
            {
                e.Graphics.DrawImage(Properties.Resources._new, new Rectangle(Width - 12, Height / 2 - 5, 10, 10));
            }
        }
        #endregion

        #region ˽�з���
        /// <summary>
        /// ��ȡ��ť��Χ
        /// </summary>
        /// <param name="imageRect">ͼƬ��Χ</param>
        /// <param name="textRect">���巶Χ</param>
        private void CalculateRect(out Rectangle imageRect, out Rectangle textRect)
        {
            int x1 = Padding.Left;
            int y1 = Padding.Top;
            int wid = Width - Padding.Left - Padding.Right;
            int hei = Height - Padding.Top - Padding.Bottom;

            imageRect = Rectangle.Empty;
            textRect = Rectangle.Empty;
            if (base.Image == null)
            {
                textRect = new Rectangle(x1, y1, wid, hei);
            }
            else
            {
                switch (base.TextImageRelation)
                {
                    case TextImageRelation.Overlay:
                        imageRect = new Rectangle(x1, (hei - this._ImageSize.Width) / 2, this._ImageSize.Width, this._ImageSize.Width);
                        textRect = new Rectangle(x1, y1, wid, hei);
                        break;

                    case TextImageRelation.ImageAboveText:
                        imageRect = new Rectangle((wid - this._ImageSize.Width) / 2, y1, this._ImageSize.Width, this._ImageSize.Width);
                        textRect = new Rectangle(x1, imageRect.Bottom, wid, (hei - imageRect.Bottom));
                        break;

                    case TextImageRelation.TextAboveImage:
                        imageRect = new Rectangle((wid - this._ImageSize.Width) / 2, (hei - this._ImageSize.Width), this._ImageSize.Width, this._ImageSize.Width);
                        textRect = new Rectangle(x1, y1, wid, (hei - imageRect.Y));
                        break;

                    case TextImageRelation.ImageBeforeText:
                        imageRect = new Rectangle(x1, (hei - this._ImageSize.Width) / 2, this._ImageSize.Width, this._ImageSize.Width);
                        textRect = new Rectangle(imageRect.Right, y1, (wid - imageRect.Right), hei);
                        break;

                    case TextImageRelation.TextBeforeImage:
                        imageRect = new Rectangle((wid - this._ImageSize.Width), (hei - this._ImageSize.Width) / 2, this._ImageSize.Width, this._ImageSize.Width);
                        textRect = new Rectangle(x1, y1, imageRect.X, hei);
                        break;
                }
                if (this.RightToLeft == RightToLeft.Yes)
                {
                    imageRect.X = wid - imageRect.Right;
                    textRect.X = wid - textRect.Right;
                }
            }
        }
        #endregion
    }
}