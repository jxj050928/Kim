using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JMCheckBox:CheckBox
    {
        #region 私有变量
        private Color _BorderColor;
        private Color _HotColor;
        private ControlState isFouc;

        private static readonly ContentAlignment RightAlignment =
            ContentAlignment.TopRight |
            ContentAlignment.BottomRight |
            ContentAlignment.MiddleRight;
        private static readonly ContentAlignment LeftAligbment =
            ContentAlignment.TopLeft |
            ContentAlignment.BottomLeft |
            ContentAlignment.MiddleLeft;
        #endregion
        
        #region 构造函数
        public JMCheckBox(): base()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);

            _BorderColor = ColorClass.GetBColor();
            _HotColor = ColorClass.GetColor(_BorderColor, _BorderColor.A, 50, 50, 50);
            isFouc = ControlState.Normal;
        }
        #endregion

        #region 属性
        [Category("Appearance"),
        Description("边框颜色"),
        DefaultValue(typeof(Color), "51, 161, 224")]
        public Color ZBorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                this._BorderColor = value;
                _HotColor = ColorClass.GetColor(_BorderColor, _BorderColor.A, 50, 50, 50);
                this.Invalidate();
            }
        }

        protected virtual int DefaultCheckButtonWidth
        {
            get { return 12; }
        }
        #endregion

        #region 重写
        protected override void OnMouseEnter(EventArgs e)
        {
            isFouc = ControlState.Hover;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isFouc = ControlState.Normal;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            isFouc = ControlState.Hover;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            isFouc = ControlState.Normal;
        }
        #endregion

        #region 重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);

            Rectangle checkButtonRect;//复选框区域
            Rectangle textRect;//文本区域
            CalculateRect(out checkButtonRect, out textRect);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color backColor = ControlPaint.Light(_BorderColor);
            Color borderColor;
            Color innerBorderColor;
            Color checkColor;
            bool hover = false;

            if (Enabled)
            {
                switch (isFouc)
                {
                    case ControlState.Hover:
                        borderColor = _BorderColor;
                        innerBorderColor = _BorderColor;
                        checkColor = ColorClass.GetColor(_BorderColor, 0, 35, 24, 9);
                        hover = true;
                        break;
                    case ControlState.Pressed:
                        borderColor = _BorderColor;
                        innerBorderColor = ColorClass.GetColor(_BorderColor, 0, -13, -8, -3);
                        checkColor = ColorClass.GetColor(_BorderColor, 0, -35, -24, -9);
                        hover = true;
                        break;
                    default:
                        borderColor = _BorderColor;
                        innerBorderColor = Color.Empty;
                        checkColor = _BorderColor;
                        break;
                }
            }
            else
            {
                borderColor = SystemColors.ControlDark;
                innerBorderColor = SystemColors.ControlDark;
                checkColor = SystemColors.ControlDark;
            }

            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillRectangle(brush, checkButtonRect);
            }

            if (hover)
            {
                using (Pen pen = new Pen(innerBorderColor, 2F))
                {
                    g.DrawRectangle(pen, checkButtonRect);
                }
            }

            switch (CheckState)
            {
                case CheckState.Checked:
                    DrawCheckedFlag(
                        g,
                        checkButtonRect,
                        checkColor);
                    break;
                case CheckState.Indeterminate:
                    checkButtonRect.Inflate(-1, -1);
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddEllipse(checkButtonRect);
                        using (PathGradientBrush brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = checkColor;
                            brush.SurroundColors = new Color[] { Color.White };
                            Blend blend = new Blend();
                            blend.Positions = new float[] { 0f, 0.4f, 1f };
                            blend.Factors = new float[] { 0f, 0.3f, 1f };
                            brush.Blend = blend;
                            g.FillEllipse(brush, checkButtonRect);
                        }
                    }
                    checkButtonRect.Inflate(1, 1);
                    break;
            }

            using (Pen pen = new Pen(borderColor))
            {
                g.DrawRectangle(pen, checkButtonRect);
            }

            Color textColor = Enabled ? ForeColor : SystemColors.GrayText;
            TextRenderer.DrawText(
                g,
                Text,
                Font,
                textRect,
                textColor,
                TextFormat.GetTextFormatFlags(TextAlign, RightToLeft == RightToLeft.Yes));
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取复选框与内容区域
        /// </summary>
        /// <param name="checkButtonRect">复选框区域</param>
        /// <param name="textRect">内容区域</param>
        private void CalculateRect(out Rectangle checkButtonRect, out Rectangle textRect)
        {
            checkButtonRect = new Rectangle(
                0, 0, DefaultCheckButtonWidth, DefaultCheckButtonWidth);
            textRect = Rectangle.Empty;
            bool bCheckAlignLeft = (int)(LeftAligbment & CheckAlign) != 0;
            bool bCheckAlignRight = (int)(RightAlignment & CheckAlign) != 0;
            bool bRightToLeft = RightToLeft == RightToLeft.Yes;

            if ((bCheckAlignLeft && !bRightToLeft) ||
                (bCheckAlignRight && bRightToLeft))
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopRight:
                    case ContentAlignment.TopLeft:
                        checkButtonRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.MiddleLeft:
                        checkButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                        break;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.BottomLeft:
                        checkButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                        break;
                }

                checkButtonRect.X = 1;

                textRect = new Rectangle(
                    checkButtonRect.Right + 2,
                    0,
                    Width - checkButtonRect.Right - 4,
                    Height);
            }
            else if ((bCheckAlignRight && !bRightToLeft)
                || (bCheckAlignLeft && bRightToLeft))
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopRight:
                        checkButtonRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleRight:
                        checkButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomRight:
                        checkButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                        break;
                }

                checkButtonRect.X = Width - DefaultCheckButtonWidth - 1;

                textRect = new Rectangle(
                    2, 0, Width - DefaultCheckButtonWidth - 6, Height);
            }
            else
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopCenter:
                        checkButtonRect.Y = 2;
                        textRect.Y = checkButtonRect.Bottom + 2;
                        textRect.Height = Height - DefaultCheckButtonWidth - 6;
                        break;
                    case ContentAlignment.MiddleCenter:
                        checkButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                        textRect.Y = 0;
                        textRect.Height = Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        checkButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                        textRect.Y = 0;
                        textRect.Height = Height - DefaultCheckButtonWidth - 6;
                        break;
                }

                checkButtonRect.X = (Width - DefaultCheckButtonWidth) / 2;

                textRect.X = 2;
                textRect.Width = Width - 4;
            }
        }

        /// <summary>
        /// 画"V"号复选框被选中状态
        /// </summary>
        /// <param name="graphics">画布</param>
        /// <param name="rect">复选框区域</param>
        /// <param name="color">颜色</param>
        private void DrawCheckedFlag(Graphics graphics, Rectangle rect, Color color)
        {
            PointF[] points = new PointF[3];
            points[0] = new PointF(
                rect.X + rect.Width / 4.5f,
                rect.Y + rect.Height / 2.5f);
            points[1] = new PointF(
                rect.X + rect.Width / 2.5f,
                rect.Bottom - rect.Height / 3f);
            points[2] = new PointF(
                rect.Right - rect.Width / 4.0f,
                rect.Y + rect.Height / 4.5f);
            using (Pen pen = new Pen(color, 2F))
            {
                graphics.DrawLines(pen, points);
            }
        }
        #endregion
    }
}
