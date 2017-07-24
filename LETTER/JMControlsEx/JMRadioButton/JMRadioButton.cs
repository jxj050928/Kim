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
    public class JMRadioButton : RadioButton
    {
        private Color _BorderColor;
        private Color _HotColor;
        private ControlState _controlState;

        private static readonly ContentAlignment RightAlignment =
            ContentAlignment.TopRight |
            ContentAlignment.BottomRight |
            ContentAlignment.MiddleRight;
        private static readonly ContentAlignment LeftAligbment =
            ContentAlignment.TopLeft |
            ContentAlignment.BottomLeft |
            ContentAlignment.MiddleLeft;

        public JMRadioButton()
            : base()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            _BorderColor = ColorClass.GetBColor();
            _HotColor = ColorClass.GetColor(_BorderColor, _BorderColor.A, 50, 50, 50);
        }

        [Category("Appearance"),
        Description("±ß¿òÑÕÉ«"),
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

        internal ControlState ControlState
        {
            get { return _controlState; }
            set
            {
                if (_controlState != value)
                {
                    _controlState = value;
                    base.Invalidate();
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            ControlState = ControlState.Hover;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ControlState = ControlState.Normal;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            ControlState = ControlState.Hover;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            ControlState = ControlState.Normal;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                ControlState = ControlState.Pressed;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (ClientRectangle.Contains(e.Location))
                {
                    ControlState = ControlState.Hover;
                }
                else
                {
                    ControlState = ControlState.Normal;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;
            Rectangle radioButtonrect;
            Rectangle textRect;

            CalculateRect(out radioButtonrect, out textRect);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color borderColor;
            Color innerBorderColor;
            Color checkColor;
            bool hover = false;

            if (Enabled)
            {
                switch (ControlState)
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
                g.FillEllipse(brush, radioButtonrect);
            }

            if (hover)
            {
                using (Pen pen = new Pen(innerBorderColor, 2F))
                {
                    g.DrawEllipse(pen, radioButtonrect);
                }
            }

            if (Checked)
            {
                radioButtonrect.Inflate(-2, -2);
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(radioButtonrect);
                    using (PathGradientBrush brush = new PathGradientBrush(path))
                    {
                        brush.CenterColor = checkColor;
                        brush.SurroundColors = new Color[] { Color.White };
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, 0.4f, 1f };
                        blend.Factors = new float[] { 0f, 0.4f, 1f };
                        brush.Blend = blend;
                        g.FillEllipse(brush, radioButtonrect);
                    }
                }
                radioButtonrect.Inflate(2, 2);
            }

            using (Pen pen = new Pen(borderColor))
            {
                g.DrawEllipse(pen, radioButtonrect);
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


        private void CalculateRect(
            out Rectangle radioButtonRect, out Rectangle textRect)
        {
            radioButtonRect = new Rectangle(
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
                        radioButtonRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.MiddleLeft:
                        radioButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                        break;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.BottomLeft:
                        radioButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                        break;
                }

                radioButtonRect.X = 1;

                textRect = new Rectangle(
                    radioButtonRect.Right + 2,
                    0,
                    Width - radioButtonRect.Right - 4,
                    Height);
            }
            else if ((bCheckAlignRight && !bRightToLeft)
                || (bCheckAlignLeft && bRightToLeft))
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopRight:
                        radioButtonRect.Y = 2;
                        break;
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleRight:
                        radioButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomRight:
                        radioButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                        break;
                }

                radioButtonRect.X = Width - DefaultCheckButtonWidth - 1;

                textRect = new Rectangle(
                    2, 0, Width - DefaultCheckButtonWidth - 6, Height);
            }
            else
            {
                switch (CheckAlign)
                {
                    case ContentAlignment.TopCenter:
                        radioButtonRect.Y = 2;
                        textRect.Y = radioButtonRect.Bottom + 2;
                        textRect.Height = Height - DefaultCheckButtonWidth - 6;
                        break;
                    case ContentAlignment.MiddleCenter:
                        radioButtonRect.Y = (Height - DefaultCheckButtonWidth) / 2;
                        textRect.Y = 0;
                        textRect.Height = Height;
                        break;
                    case ContentAlignment.BottomCenter:
                        radioButtonRect.Y = Height - DefaultCheckButtonWidth - 2;
                        textRect.Y = 0;
                        textRect.Height = Height - DefaultCheckButtonWidth - 6;
                        break;
                }

                radioButtonRect.X = (Width - DefaultCheckButtonWidth) / 2;

                textRect.X = 2;
                textRect.Width = Width - 4;
            }
        }


    }

}