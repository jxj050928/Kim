using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JMComboBox : ComboBox
    {
        #region 常量
        public static readonly IntPtr FALSE = IntPtr.Zero;
        public static readonly IntPtr TRUE = new IntPtr(1);

        public const int WM_PAINT = 0x000F;//重绘消息

        private const int WM_PASTE = 0x0302;//粘貼消息 
        #endregion

        #region 私有变量
        private IntPtr _editHandle;
        private ControlState _buttonState;
        private Color _baseColor = Color.FromArgb(51, 161, 224);
        private Color _borderColor = Color.FromArgb(51, 161, 224);
        private Color _arrowColor = Color.FromArgb(19, 88, 128);
        private bool _bPainting;
        private ControlState isFouc;//是否选中
        private string _ZEmptyTextTip;
        #endregion

        #region 构造函数
        public JMComboBox()
            : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            _baseColor = ColorClass.GetBColor();
            _borderColor = ColorClass.GetBColor();
        }
        #endregion

        #region RECT
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(Rectangle rect)
            {
                Left = rect.Left;
                Top = rect.Top;
                Right = rect.Right;
                Bottom = rect.Bottom;
            }

            public Rectangle Rect
            {
                get
                {
                    return new Rectangle(
                        Left,
                        Top,
                        Right - Left,
                        Bottom - Top);
                }
            }

            public Size Size
            {
                get
                {
                    return new Size(Right - Left, Bottom - Top);
                }
            }

            public static RECT FromXYWH(int x, int y, int width, int height)
            {
                return new RECT(x,
                                y,
                                x + width,
                                y + height);
            }

            public static RECT FromRectangle(Rectangle rect)
            {
                return new RECT(rect.Left,
                                 rect.Top,
                                 rect.Right,
                                 rect.Bottom);
            }
        }
        #endregion

        #region ComboBoxInfo Struct
        [StructLayout(LayoutKind.Sequential)]
        public struct ComboBoxInfo
        {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public ComboBoxButtonState stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndEdit;
            public IntPtr hwndList;
        }
        #endregion

        #region PAINTSTRUCT
        [StructLayout(LayoutKind.Sequential)]
        public struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public int fErase;
            public RECT rcPaint;
            public int fRestore;
            public int fIncUpdate;
            public int Reserved1;
            public int Reserved2;
            public int Reserved3;
            public int Reserved4;
            public int Reserved5;
            public int Reserved6;
            public int Reserved7;
            public int Reserved8;
        }
        #endregion

        #region API
        //获取combobox相关信息
        [DllImport("user32.dll")]
        public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref ComboBoxInfo info);

        //返回指定窗口的边框矩形的尺寸、该尺寸以相对于屏幕坐标左上角的屏幕坐标给出
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        //为指定窗口进行绘图工作的准备，并用将和绘图有关的信息填充到一个PAINTSTRUCT结构中。
        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        //函数标记指定窗口的绘画过程结束;这个函数在每次调用BeginPaint函数之后被请求,但仅仅在绘画完成以后。
        [DllImport("user32.dll")]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        #endregion

        #region 公共属性
        [DefaultValue(typeof(Color), "51, 161, 224")]
        public Color ZBaseColor
        {
            get { return _baseColor; }
            set
            {
                if (_baseColor != value)
                {
                    _baseColor = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "51, 161, 224")]
        public Color ZBorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "19, 88, 128")]
        public Color ZArrowColor
        {
            get { return _arrowColor; }
            set
            {
                if (_arrowColor != value)
                {
                    _arrowColor = value;
                    base.Invalidate();
                }
            }
        }

        internal ControlState ButtonState
        {
            get { return _buttonState; }
            set
            {
                if (_buttonState != value)
                {
                    _buttonState = value;
                    Invalidate(ButtonRect);
                }
            }
        }

        internal Rectangle ButtonRect
        {
            get
            {
                return GetDropDownButtonRect();
            }
        }

        internal bool ButtonPressed
        {
            get
            {
                if (IsHandleCreated)
                {
                    return GetComboBoxButtonPressed();
                }
                return false;
            }
        }

        internal IntPtr EditHandle
        {
            get { return _editHandle; }
        }

        internal Rectangle EditRect
        {
            get
            {
                if (DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    Rectangle rect = new Rectangle(
                        3, 3, Width - ButtonRect.Width - 6, Height - 6);
                    if (RightToLeft == RightToLeft.Yes)
                    {
                        rect.X += ButtonRect.Right;
                    }
                    return rect;
                }
                if (IsHandleCreated && EditHandle != IntPtr.Zero)
                {
                    RECT rcClient = new RECT();
                    GetWindowRect(EditHandle, ref rcClient);
                    return RectangleToClient(rcClient.Rect);
                }
                return Rectangle.Empty;
            }
        }

        [Description("水印内容"), DefaultValue(typeof(string), "")]
        public string ZEmptyTextTip
        {
            get { return _ZEmptyTextTip; }
            set { _ZEmptyTextTip = value; Invalidate(); }
        }
        #endregion

        #region Override
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            ComboBoxInfo cbi = GetTheComboBoxInfo();
            _editHandle = cbi.hwndEdit;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point point = e.Location;
            if (ButtonRect.Contains(point))
            {
                ButtonState = ControlState.Hover;
            }
            else
            {
                ButtonState = ControlState.Normal;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isFouc = ControlState.Hover;

            Point point = PointToClient(Cursor.Position);
            if (ButtonRect.Contains(point))
            {
                ButtonState = ControlState.Hover;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isFouc = ControlState.Normal;
            ButtonState = ControlState.Normal;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ButtonState = ControlState.Normal;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_PASTE)
            {
                switch (m.Msg)
                {
                    case WM_PAINT:
                        WmPaint(ref m);
                        IntPtr hDC = Win32.GetWindowDC(m.HWnd);
                        if (hDC.ToInt32() == 0)
                            return;
                        System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                        DrawString(g);
                        m.Result = IntPtr.Zero;
                        Win32.ReleaseDC(m.HWnd, hDC);
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Graphics g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //DrawString(g);
        }
        #endregion

        /// <summary>
        /// 画水印效果
        /// </summary>
        /// <param name="g"></param>
        protected void DrawString(Graphics g)
        {
            if (_ZEmptyTextTip != "" && string.IsNullOrEmpty(this.Text) && !Focused)
            {
                Font fon = new Font("宋体", 9);
                TextRenderer.DrawText(
                        g,
                        _ZEmptyTextTip,
                        Font,
                        base.ClientRectangle,
                        Color.DarkGray,
                        TextFormat.GetTextFormatFlags(ContentAlignment.MiddleLeft, false));
            }
        }

        #region 方法

        private void WmPaint(ref Message m)
        {
            if (base.DropDownStyle == ComboBoxStyle.Simple)
            {
                base.WndProc(ref m);
                return;
            }

            if (base.DropDownStyle == ComboBoxStyle.DropDown)
            {
                if (!_bPainting)
                {
                    PAINTSTRUCT ps = new PAINTSTRUCT();

                    _bPainting = true;
                    BeginPaint(m.HWnd, ref ps);

                    RenderComboBox(ref m);

                    EndPaint(m.HWnd, ref ps);
                    _bPainting = false;
                    m.Result = TRUE;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
                RenderComboBox(ref m);
            }
        }

        private void RenderComboBox(ref Message m)
        {
            Rectangle rect = new Rectangle(Point.Empty, Size);
            Rectangle buttonRect = ButtonRect;
            ControlState state = ButtonPressed ? ControlState.Pressed : ButtonState;
            using (Graphics g = Graphics.FromHwnd(m.HWnd))
            {
                //画背景
                RenderComboBoxBackground(g, rect, buttonRect);
                //画按钮
                RenderConboBoxDropDownButton(g, ButtonRect, state);
                //画边框
                RenderConboBoxBorder(g, rect);
            }
        }

        private void RenderConboBoxBorder(
            Graphics g, Rectangle rect)
        {
            Color borderColor = base.Enabled ? _borderColor : SystemColors.ControlDarkDark;
            using (Pen pen = new Pen(borderColor))
            {
                rect.Width--;
                rect.Height--;
                g.DrawRectangle(pen, rect);
                if (isFouc == ControlState.Hover && base.Enabled)
                {
                    Color cl = ColorClass.GetColor(borderColor, borderColor.A, 50, 50, 50);
                    rect.Width -= 2;
                    rect.Height -= 2;
                    rect.X++;
                    rect.Y++;
                    g.DrawRectangle(new Pen(cl), rect);
                }
            }
        }

        private void RenderComboBoxBackground(
            Graphics g,
            Rectangle rect,
            Rectangle buttonRect)
        {
            Color backColor = base.Enabled ? base.BackColor : SystemColors.Control;
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                buttonRect.Inflate(-1, -1);
                rect.Inflate(-1, -1);
                using (Region region = new Region(rect))
                {
                    region.Exclude(buttonRect);
                    region.Exclude(EditRect);
                    g.FillRegion(brush, region);
                }
            }
        }

        private void RenderConboBoxDropDownButton(
            Graphics g,
            Rectangle buttonRect,
            ControlState state)
        {
            Color baseColor;
            Color backColor = Color.FromArgb(160, 250, 250, 250);
            Color borderColor = base.Enabled ?
                _borderColor : SystemColors.ControlDarkDark;
            Color arrowColor = base.Enabled ?
                _arrowColor : SystemColors.ControlDarkDark;
            Rectangle rect = buttonRect;

            if (base.Enabled)
            {
                switch (state)
                {
                    case ControlState.Hover:
                        baseColor = ColorClass.GetColor(
                            _baseColor, 0, -33, -22, -13);
                        break;
                    case ControlState.Pressed:
                        baseColor = ColorClass.GetColor(
                            _baseColor, 0, -65, -47, -25);
                        break;
                    default:
                        baseColor = _baseColor;
                        break;
                }
            }
            else
            {
                baseColor = SystemColors.ControlDark;
            }

            rect.Inflate(-1, -1);

            RenderScrollBarArrowInternal(
                g,
                rect,
                baseColor,
                borderColor,
                backColor,
                arrowColor,
                RoundStyle.None,
                true,
                false,
                ArrowDirection.Down,
                LinearGradientMode.Vertical);
        }

        internal void RenderScrollBarArrowInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           Color arrowColor,
           RoundStyle roundStyle,
           bool drawBorder,
           bool drawGlass,
           ArrowDirection arrowDirection,
           LinearGradientMode mode)
        {
            ControlPaintClass.RenderBackgroundInternal(
               g,
               rect,
               baseColor,
               borderColor,
               innerBorderColor,
               roundStyle,
               0,
               .45F,
               drawBorder,
               drawGlass,
               mode);

            using (SolidBrush brush = new SolidBrush(arrowColor))
            {
                RenderArrowInternal(
                    g,
                    rect,
                    arrowDirection,
                    brush);
            }
        }

        internal void RenderArrowInternal(
            Graphics g,
            Rectangle dropDownRect,
            ArrowDirection direction,
            Brush brush)
        {
            Point point = new Point(
                dropDownRect.Left + (dropDownRect.Width / 2),
                dropDownRect.Top + (dropDownRect.Height / 2));
            Point[] points = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new Point[] { 
                        new Point(point.X + 2, point.Y - 3), 
                        new Point(point.X + 2, point.Y + 3), 
                        new Point(point.X - 1, point.Y) };
                    break;

                case ArrowDirection.Up:
                    points = new Point[] { 
                        new Point(point.X - 3, point.Y + 2), 
                        new Point(point.X + 3, point.Y + 2), 
                        new Point(point.X, point.Y - 2) };
                    break;

                case ArrowDirection.Right:
                    points = new Point[] {
                        new Point(point.X - 2, point.Y - 3), 
                        new Point(point.X - 2, point.Y + 3), 
                        new Point(point.X + 1, point.Y) };
                    break;

                default:
                    points = new Point[] {
                        new Point(point.X - 2, point.Y - 1), 
                        new Point(point.X + 3, point.Y - 1), 
                        new Point(point.X, point.Y + 2) };
                    break;
            }
            g.FillPolygon(brush, points);
        }

        /// <summary>
        /// 获取ComboBox相关信息
        /// </summary>
        /// <returns>ComboBox结构对象</returns>
        private ComboBoxInfo GetTheComboBoxInfo()
        {
            ComboBoxInfo cbi = new ComboBoxInfo();
            cbi.cbSize = Marshal.SizeOf(cbi);
            GetComboBoxInfo(base.Handle, ref cbi);
            return cbi;
        }

        /// <summary>
        /// 下拉框范围
        /// </summary>
        /// <returns></returns>
        private Rectangle GetDropDownButtonRect()
        {
            ComboBoxInfo cbi = GetTheComboBoxInfo();

            return cbi.rcButton.Rect;
        }

        /// <summary>
        /// 是否按下
        /// </summary>
        /// <returns></returns>
        private bool GetComboBoxButtonPressed()
        {
            ComboBoxInfo cbi = GetTheComboBoxInfo();
            return cbi.stateButton == ComboBoxButtonState.STATE_SYSTEM_PRESSED;
        }
        #endregion
    }
}
