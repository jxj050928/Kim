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
    public class JMButtonEx : Button
    {
        /// <summary>
        /// 是否显示鼠标进入效果
        /// </summary>
        private bool SFVisibleEffect = false;

        /// <summary>
        /// 是否显示鼠标按下效果
        /// </summary>
        private bool SFDownEffect = false;

        private bool bl = false;

        private bool bol = false;

        #region 私有变量
        /// <summary>
        /// 按钮颜色
        /// </summary>
        private Color _JMBaseColor;
        /// <summary>
        /// 按钮颜色
        /// </summary>
        private Color _JMBaseColorTwo;
        /// <summary>
        /// 按钮状态
        /// </summary>
        private ControlState _JMControlState;
        /// <summary>
        /// 按钮圆角弧度
        /// </summary>
        private int _JMRadius;
        /// <summary>
        /// 按钮圆角样式
        /// </summary>
        private RoundStyle _JMRoundStyle;
        /// <summary>
        /// 图像大小
        /// </summary>
        private Size _ImageSize;

        private bool _JMSFNew;
        #endregion

        #region 构造函数
        public JMButtonEx()
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

        #region 属性
        [Category("Appearance"), Description("按钮颜色"), DefaultValue(typeof(Color), "51, 161, 224")]
        public Color JMBaseColor
        {
            get { return _JMBaseColor; }
            set { _JMBaseColor = value; Invalidate(); }
        }

        [Category("Appearance"), Description("按钮颜色"), DefaultValue(typeof(Color), "51, 161, 224")]
        public Color JMBaseColorTwo
        {
            get { return _JMBaseColorTwo; }
            set { _JMBaseColorTwo = value; Invalidate(); }
        }

        [Category("Appearance"), Description("按钮圆角弧度"), DefaultValue(8)]
        public int JMRadius
        {
            get { return _JMRadius; }
            set { _JMRadius = value; }
        }

        [Category("Appearance"), Description("按钮圆角样式"), DefaultValue(typeof(RoundStyle), "All")]
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

        [Description("按钮状态")]
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

        [Category("Appearance"), Description("按钮圆角样式"), DefaultValue(typeof(Size), "20, 20")]
        public Size ImageSize
        {
            get { return _ImageSize; }
            set { _ImageSize = value; Invalidate(); }
        }

        [Description("按钮状态"), DefaultValue(typeof(bool), "false")]
        public bool JMSFNew
        {
            get { return _JMSFNew; }
            set { _JMSFNew = value; Invalidate(); }
        }
        #endregion

        #region Override 鼠标事件
        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            SFVisibleEffect = true;
            Invalidate();
        }

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SFVisibleEffect = false;
            Invalidate();
        }

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //bl = true;
            SFDownEffect = true;
            SFVisibleEffect = false;
            Invalidate();
        }

        /// <summary>
        /// 鼠标松开事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            SFDownEffect = false;
            SFVisibleEffect = false;
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
            //bl = false;
            SFDownEffect = false;
            SFVisibleEffect = false;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);

            Rectangle rectangle;//图片范围
            Rectangle rectangle2;//字体范围
            this.CalculateRect(out rectangle, out rectangle2);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (base.Enabled)
            {
                //填充按钮颜色效果
                GraphicsPath aa = GetGraphicPath.CreatePath(base.ClientRectangle, _JMRadius, RoundStyle.All, true);
                aa.CloseFigure();

                //加载鼠标进入效果
                if (SFVisibleEffect)
                {
                    Color col1 = ColorClass.GetColor(_JMBaseColorTwo, 0, -20, -20, -20);
                    Color col2 = ColorClass.GetColor(_JMBaseColor, 0, -20, -20, -20);
                    GraphicsPath bb = GetGraphicPath.CreatePath(base.ClientRectangle, _JMRadius, RoundStyle.All, true);
                    bb.CloseFigure();
                    g.FillPath(new LinearGradientBrush(base.ClientRectangle, col1, col2, LinearGradientMode.Vertical), bb);
                    g.DrawPath(new Pen(new SolidBrush(Color.DarkGray)), aa);
                }
                else if (SFDownEffect)//加载鼠标按下效果 || Focused
                {
                    Color col1 = ColorClass.GetColor(_JMBaseColorTwo, 0, -35, -35, -35);
                    Color col2 = ColorClass.GetColor(_JMBaseColor, 0, -35, -35, -35);
                    GraphicsPath cc = GetGraphicPath.CreatePath(base.ClientRectangle, _JMRadius, RoundStyle.All, true);
                    cc.CloseFigure();
                    g.FillPath(new LinearGradientBrush(base.ClientRectangle, col1, col2, LinearGradientMode.Vertical), cc);
                    g.DrawPath(new Pen(new SolidBrush(Color.DarkGray)), aa);
                }
                else
                {
                    g.FillPath(new LinearGradientBrush(base.ClientRectangle, _JMBaseColorTwo, _JMBaseColor, LinearGradientMode.Vertical), aa);
                    g.DrawPath(new Pen(new SolidBrush(Color.DarkGray)), aa);
                }
                //加载图片
                if (base.Image != null)
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    g.DrawImage(base.Image, rectangle);
                }
            }
            else//不可用为“灰色”
            {
                //填充按钮颜色效果
                GraphicsPath aa = GetGraphicPath.CreatePath(base.ClientRectangle, _JMRadius, RoundStyle.All, true);
                aa.CloseFigure();
                g.FillPath(new LinearGradientBrush(base.ClientRectangle, SystemColors.ControlDark, SystemColors.ControlDark, LinearGradientMode.Vertical), aa);
                g.DrawPath(new Pen(new SolidBrush(Color.DarkGray)), aa);
            }

            //加载文字
            TextRenderer.DrawText(g, this.Text, this.Font, rectangle2, this.ForeColor, TextFormat.GetTextFormatFlags(this.TextAlign, this.RightToLeft == RightToLeft.Yes));

            if (_JMSFNew)
            {
                e.Graphics.DrawImage(Properties.Resources._new, new Rectangle(Width - 12, Height / 2 - 5, 10, 10));
            }
        }

        #region 私有方法
        /// <summary>
        /// 获取按钮范围
        /// </summary>
        /// <param name="imageRect">图片范围</param>
        /// <param name="textRect">字体范围</param>
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
