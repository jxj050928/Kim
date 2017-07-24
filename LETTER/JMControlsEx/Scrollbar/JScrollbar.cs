using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace JMControlsEx
{
    [Designer(typeof(ScrollbarControlDesigner))]
    public class JScrollbar : Panel
    {
        public new event EventHandler Scroll;
        public event EventHandler ValueChanged;

        //滚动条旧区域
        Rectangle rectcrollHand;
        //滚动条新区域
        Rectangle renew;

        //鼠标进入
        private bool MouseOn = false;
        //鼠标按下
        private bool MouseD = false;
        //开始移动y坐标
        int startY = 0;

        //滚动条高度
        private int tumbHeight;

        private int round;
        private int roundtum;
        protected int moLargeChange = 10;
        protected int moSmallChange = 1;
        protected int moMinimum = 0;
        protected int moMaximum = 100;
        protected int moValue = 0;

        private Color _baseColor;

        public Color BaseColor
        {
            get { return _baseColor; }
            set { _baseColor = value; Invalidate(); }
        }
        private Color _selectColor;

        public Color SelectColor
        {
            get { return _selectColor; }
            set { _selectColor = value; Invalidate(); }
        }

        #region 属性    
    
        public int Roundtum
        {
            get { return roundtum; }
            set { roundtum = value; Invalidate(); }
        }

        public int TumbHeight
        {
            get { return tumbHeight; }
            set { tumbHeight = value; Invalidate(); }
        }

        public int Round
        {
            get { return round; }
            set { round = value; Invalidate(); }
        }

        [EditorBrowsable(EditorBrowsableState.Always),
        Browsable(true),
        DefaultValue(false),
        Category("Behavior"),
        Description("LargeChange")]
        public int LargeChange
        {
            get { return moLargeChange; }
            set
            {
                moLargeChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always),
        Browsable(true), DefaultValue(false),
        Category("Behavior"), Description("SmallChange")]
        public int SmallChange
        {
            get { return moSmallChange; }
            set
            {
                moSmallChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always),
        Browsable(true), DefaultValue(false),
        Category("Behavior"), Description("Minimum")]
        public int Minimum
        {
            get { return moMinimum; }
            set
            {
                moMinimum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always),
        Browsable(true), DefaultValue(false),
        Category("Behavior"), Description("Maximum")]
        public int Maximum
        {
            get { return moMaximum; }
            set
            {
                moMaximum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always),
        Browsable(true), DefaultValue(false),
        Category("Behavior"), Description("Value")]
        public int Value
        {
            get { return moValue; }
            set
            {
                moValue = value;
                if (renew == Rectangle.Empty)
                {
                    renew = rectcrollHand;
                }
                float canmoveH = Height - (Padding.Top + Padding.Bottom + tumbHeight + 4);
                float oneV = canmoveH / (Maximum - Minimum);
                float ry = moValue * oneV + 2 + Padding.Top;
                renew.Y = (int)ry;
                Invalidate();
            }
        }
        #endregion

        #region 构造函数
        public JScrollbar()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
        ControlStyles.ResizeRedraw |
        ControlStyles.AllPaintingInWmPaint, true);

            this.Width = 20;
            this.MinimumSize = new Size(10, 60);
            tumbHeight = 40;
            round = 10;
            roundtum = 10;
            _baseColor = Color.FromArgb(180, 180, 180);
        }
        #endregion

        #region 重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            DrawBack(g);
            DrawScrollHand(g);
        }

        private void DrawBack(Graphics g)
        {
            int x = 0;
            int y = this.Padding.Top;
            int wid = Width;
            int hei = Height - this.Padding.Bottom-this.Padding.Top;

            Rectangle rect = new Rectangle(x, y, wid, hei);
            GraphicsPath path = GetGraphicPath.CreatePath(rect, round, RoundStyle.All, true);
            LinearGradientBrush lb = new LinearGradientBrush(rect, BackColor, BackColor, LinearGradientMode.Horizontal);
            g.FillPath(lb, path);
        }

        private void DrawScrollHand(Graphics g)
        {
            int x = 1;
            int y;
            if (renew != Rectangle.Empty)
            {
                y = renew.Y;
            }
            else
            {
                y = this.Padding.Top + 2;
            }
            int wid = Width - 3;
            int hei = tumbHeight;

            Rectangle rectcrollHand1 = new Rectangle(x, y, wid, hei / 3);
            Rectangle rectcrollHand2 = new Rectangle(x, y + hei / 3, wid, hei / 3);
            Rectangle rectcrollHand3 = new Rectangle(x, y + hei / 3 * 2, wid, hei / 3);
            g.FillEllipse(new SolidBrush(_baseColor), rectcrollHand1);
            g.FillEllipse(new SolidBrush(_baseColor), rectcrollHand2);
            g.FillEllipse(new SolidBrush(_baseColor), rectcrollHand3);

            rectcrollHand = new Rectangle(x, y, wid, hei);

            //GraphicsPath path = GetGraphicPath.CreatePath(rectcrollHand, roundtum, RoundStyle.All, true);
            //Color[] cl;
            //if (MouseOn || MouseD)
            //{
            //    cl = new Color[] { Color.LightPink, Color.White, Color.Pink };
            //}
            //else
            //{
            //    cl = new Color[] { Color.LightGray, Color.White, Color.Gray };
            //}
            //float[] fl = new float[] { 0f, 0.15f, 1f };
            //LinearGradientBrush lb = GetlinearB(rectcrollHand, LinearGradientMode.Horizontal, cl, fl);
            //g.FillPath(lb, path);
            //g.DrawPath(new Pen(Color.LightGray), path);

            //Point p1 = new Point(x + (wid - x) / 5, y + hei / 2 - 3);
            //Point p2 = new Point(wid - (wid - x) / 5 * 2, y + hei / 2 - 3);
            //Point p3 = new Point(x + (wid - x) / 5, y + hei / 2);
            //Point p4 = new Point(wid - (wid - x) / 5 * 2, y + hei / 2);
            //Point p5 = new Point(x + (wid - x) / 5, y + hei / 2 + 3);
            //Point p6 = new Point(wid - (wid - x) / 5 * 2, y + hei / 2 + 3);
            //g.DrawLine(new Pen(Color.Black), p1, p2);
            //g.DrawLine(new Pen(Color.Black), p3, p4);
            //g.DrawLine(new Pen(Color.Black), p5, p6);
        }
        #endregion

        #region 私有方法
        private LinearGradientBrush GetlinearB(Rectangle rect, LinearGradientMode mode, Color[] cl, float[] fl)
        {
            LinearGradientBrush brush = new LinearGradientBrush(
                            rect, Color.Transparent, Color.Transparent, mode);
            Color[] colors = cl;
            ColorBlend blend = new ColorBlend();
            blend.Positions = fl;
            blend.Colors = colors;
            brush.InterpolationColors = blend;
            return brush;
        }
        #endregion

        #region 鼠标事件
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (rectcrollHand.Contains(e.Location))
            {
                MouseD = true;
                startY = e.Location.Y;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseD = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (MouseD)
            {
                if (e.Location.Y != startY)
                {
                    int bsy = startY;
                    int cj = e.Location.Y - startY;
                    startY = e.Location.Y;
                    Graphics g = Graphics.FromHwnd(this.Handle);

                    renew = rectcrollHand;
                    renew.Y += cj;
                    if (renew.Y < this.Padding.Top + 2)
                    {
                        renew.Y = this.Padding.Top + 2;
                        startY = bsy;
                        cj = 0;
                    }
                    else if (renew.Y > Height - this.Padding.Bottom - tumbHeight - 2)
                    {
                        renew.Y = Height - this.Padding.Bottom - tumbHeight - 2;
                        startY = bsy;
                        cj = 0;
                    }
                    Application.DoEvents();
                    float canmoveH = Height - (Padding.Top + Padding.Bottom + tumbHeight + 4);
                    float oneV = canmoveH / (Maximum - Minimum);
                    float mv = (renew.Y - (2 + Padding.Top)) / oneV;
                    moValue = (int)mv;

                    if (ValueChanged != null)
                        ValueChanged(this, new EventArgs());

                    if (Scroll != null)
                        Scroll(this, new EventArgs());

                    this.Invalidate();//this.Invalidate(re1);
                }
            }
            else
            {
                if (rectcrollHand.Contains(e.Location))
                {
                    if (!MouseOn)
                    {
                        Graphics g = Graphics.FromHwnd(this.Handle);
                        MouseOn = true;
                        this.Invalidate(rectcrollHand);
                    }

                }
                else
                {
                    if (MouseOn)
                    {
                        Graphics g = Graphics.FromHwnd(this.Handle);
                        MouseOn = false;
                        this.Invalidate(rectcrollHand);
                    }
                }
            }
        }
        #endregion

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            if (renew != Rectangle.Empty)
            {
                renew.Y = this.Padding.Top + 2;
            }
            Invalidate();
        }
    }

    internal class ScrollbarControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(this.Component)["AutoSize"];
                if (propDescriptor != null)
                {
                    bool autoSize = (bool)propDescriptor.GetValue(this.Component);
                    if (autoSize)
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                    }
                    else
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;
                    }
                }
                return selectionRules;
            }
        }
    }
}
