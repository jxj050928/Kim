using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JMPanel : Panel
    {
        [Description("标题单击事件(无参数)")]
        public event JMDelegate.ClickHandel JMTitleClick;
        [Description("标题单击事件(有参数)")]
        public event JMDelegate.IEventHandle JMTitleCZClick;
        [Description("标题图片单击事件")]
        public event JMDelegate.IEventHandle JMTitleImgClick;
        [Description("跳转单击事件(无参数)")]
        public event JMDelegate.ClickHandel JMTZClick;
        [Description("跳转单击事件(有参数)")]
        public event JMDelegate.IEventHandle JMTZCZClick;
        Cursor Cur = null;

        #region 属性
        private int _JMPanelIndex;

        public int JMPanelIndex
        {
            get { return _JMPanelIndex; }
            set { _JMPanelIndex = value; }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color _JMBorderLineColor;

        [Description("边框颜色"), DefaultValue(typeof(Color), "Black")]
        public Color JMBorderLineColor
        {
            get { return _JMBorderLineColor; }
            set { _JMBorderLineColor = value; Invalidate(); }
        }

        private bool _JMBorderStyle;

        [Description("是否显示边框"), DefaultValue(typeof(bool), "false")]
        public bool JMBorderStyle
        {
            get { return _JMBorderStyle; }
            set { _JMBorderStyle = value; Invalidate(); }
        }

        /// <summary>
        /// 按钮圆角样式
        /// </summary>
        private RoundStyle _JMRoundStyle;

        [Category("Appearance"), Description("按钮圆角样式"), DefaultValue(typeof(RoundStyle), "None")]
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

        /// <summary>
        /// 按钮圆角弧度
        /// </summary>
        private int _JMRadius;

        [Category("Appearance"), Description("按钮圆角弧度"), DefaultValue(8)]
        public int JMRadius
        {
            get { return _JMRadius; }
            set { _JMRadius = value; }
        }

        /// <summary>
        /// 鼠标经过跳转按钮显示的光标
        /// </summary>
        private Cursor _JMCursor;

        [Description("鼠标经过跳转按钮显示的光标"), DefaultValue(typeof(Cursor), "Default")]
        public Cursor JMCursor
        {
            get { return _JMCursor; }
            set { _JMCursor = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        private string _JMTitle;

        [Description("标题"), DefaultValue(typeof(string), "")]
        public string JMTitle
        {
            get { return _JMTitle; }
            set { _JMTitle = value; Invalidate(); }
        }

        /// <summary>
        /// 标题颜色
        /// </summary>
        private Color _JMTitleColor;

        [Description("标题颜色"), DefaultValue(typeof(Color), "Black")]
        public Color JMTitleColor
        {
            get { return _JMTitleColor; }
            set { _JMTitleColor = value; Invalidate(); }
        }

        /// <summary>
        /// 是否显示标题
        /// </summary>
        private bool _JMTitleVisible;

        [Description("是否显示标题"), DefaultValue(typeof(bool), "false")]
        public bool JMTitleVisible
        {
            get { return _JMTitleVisible; }
            set { _JMTitleVisible = value; Invalidate(); }
        }

        /// <summary>
        /// 标题坐标
        /// </summary>
        private Point _JMTitleLocation;

        [Description("标题坐标"), DefaultValue(typeof(Point), "40,3")]
        public Point JMTitleLocation
        {
            get { return _JMTitleLocation; }
            set { _JMTitleLocation = value; Invalidate(); }
        }

        /// <summary>
        /// 标题图像
        /// </summary>
        private Image _JMTitleImage;

        [Description("标题图像"), DefaultValue(typeof(Image), "null")]
        public Image JMTitleImage
        {
            get { return _JMTitleImage; }
            set { _JMTitleImage = value; Invalidate(); }
        }

        /// <summary>
        /// 是否显示标题图像
        /// </summary>
        private bool _JMTitleImageVisible;

        [Description("是否显示标题图像"), DefaultValue(typeof(bool), "false")]
        public bool JMTitleImageVisible
        {
            get { return _JMTitleImageVisible; }
            set { _JMTitleImageVisible = value; Invalidate(); }
        }

        /// <summary>
        /// 标题图像坐标
        /// </summary>
        private Point _JMTiTleImageLocation;

        [Description("标题图像坐标"), DefaultValue(typeof(Point), "2,3")]
        public Point JMTiTleImageLocation
        {
            get { return _JMTiTleImageLocation; }
            set { _JMTiTleImageLocation = value; Invalidate(); }
        }

        /// <summary>
        /// 标题图像大小
        /// </summary>
        private Size _JMTitleImageSize;

        [Description("标题图像大小"), DefaultValue(typeof(Size), "22,22")]
        public Size JMTitleImageSize
        {
            get { return _JMTitleImageSize; }
            set { _JMTitleImageSize = value; Invalidate(); }
        }

        /// <summary>
        /// 标题跳转
        /// </summary>
        private Image _JMTitleTiaoZhuan;

        [Description("标题跳转"), DefaultValue(typeof(Image), "null")]
        public Image JMTitleTiaoZhuan
        {
            get { return _JMTitleTiaoZhuan; }
            set { _JMTitleTiaoZhuan = value; Invalidate(); }
        }

        /// <summary>
        /// 是否显示标题跳转
        /// </summary>
        private bool _JMTitleTZVisible;

        [Description("是否显示标题跳转"), DefaultValue(typeof(bool), "false")]
        public bool JMTitleTZVisible
        {
            get { return _JMTitleTZVisible; }
            set { _JMTitleTZVisible = value; Invalidate(); }
        }

        /// <summary>
        /// 标题跳转大小
        /// </summary>
        private Size _JMTitleTZSize;

        [Description("标题跳转大小"), DefaultValue(typeof(Size), "22,22")]
        public Size JMTitleTZSize
        {
            get { return _JMTitleTZSize; }
            set { _JMTitleTZSize = value; Invalidate(); }
        }

        /// <summary>
        /// 标题跳转坐标
        /// </summary>
        private Point _JMTitleTZLocation;

        [Description("标题跳转坐标"), DefaultValue(typeof(Point), "100,3")]
        public Point JMTitleTZLocation
        {
            get { return _JMTitleTZLocation; }
            set { _JMTitleTZLocation = value; Invalidate(); }
        }
        #endregion

        public JMPanel()
        {
            _JMBorderLineColor = Color.Black;
            this._JMRoundStyle = RoundStyle.None;
            _JMRadius = 8;
            _JMBorderStyle = false;
            _JMTitle = "";
            _JMTitleVisible = false;
            _JMTitleLocation = new Point(40, 3);
            _JMTitleImage = null;
            _JMTitleImageVisible = false;
            _JMTiTleImageLocation = new Point(2, 3);
            _JMTitleImageSize = new Size(22, 22);
            _JMTitleColor = Color.Black;
            _JMTitleTiaoZhuan = null;
            _JMTitleTZVisible = false;
            _JMTitleTZSize = new Size(22, 22);
            _JMTitleTZLocation = new Point(100, 3);
            _JMCursor = Cursors.Default;
            _JMPanelIndex = 0;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == Animate.WM_PAINT || m.Msg == 0x133)
            {
                IntPtr hDC = Win32.GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0)
                    return;
                if (_JMBorderStyle)
                {
                    Graphics g = Graphics.FromHdc(hDC);
                    switch (_JMRoundStyle)
                    {
                        case RoundStyle.None:
                            g.DrawRectangle(new Pen(_JMBorderLineColor, 1), 0, 0, this.Width - 1, this.Height - 1);
                            break;
                        case RoundStyle.All:
                            GraphicsPath gp = new GraphicsPath();
                            GraphicsPath gp1 = new GraphicsPath();

                            Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Size.Width - 1, this.Size.Height - 1));
                            Rectangle rec1 = new Rectangle(new Point(0, 0), new Size(this.Size.Width, this.Size.Height));

                            gp = GetGraphicPath.CreatePath(rec, _JMRadius, _JMRoundStyle, true);
                            gp1 = GetGraphicPath.CreatePath(rec1, _JMRadius, _JMRoundStyle, true);
                            this.Region = new Region(gp1);

                            g.DrawPath(new Pen(new SolidBrush(_JMBorderLineColor)), gp);
                            break;
                    }
                }
                if (_JMTitleImageVisible)
                {
                    if (_JMTitleImage != null)
                    {
                        Graphics g = Graphics.FromHdc(hDC);
                        Rectangle rect = new Rectangle(_JMTiTleImageLocation, _JMTitleImageSize);
                        g.DrawImage(_JMTitleImage, rect);
                    }
                }
                if (_JMTitleVisible)
                {
                    if (_JMTitle != "")
                    {
                        Graphics g = Graphics.FromHdc(hDC);
                        SizeF titlesize = g.MeasureString(_JMTitle, this.Font);
                        RectangleF rect = new RectangleF(_JMTitleLocation, titlesize);
                        g.DrawString(_JMTitle, this.Font, new SolidBrush(_JMTitleColor), rect);
                    }
                }
                if (_JMTitleTZVisible)
                {
                    if (_JMTitleTiaoZhuan != null)
                    {
                        Graphics g = Graphics.FromHdc(hDC);
                        Rectangle rect = new Rectangle(_JMTitleTZLocation, _JMTitleTZSize);
                        g.DrawImage(_JMTitleTiaoZhuan, rect);
                    }
                }

                //m.Result = IntPtr.Zero;
                Win32.ReleaseDC(m.HWnd, hDC);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Rectangle rectHeadRight = new Rectangle(_JMTitleTZLocation, _JMTitleTZSize);//向右箭头范围
            Rectangle rectHead = new Rectangle(new Point(0, 0), new Size(this.Width, this.Padding.Top));//整个表头范围
            Rectangle rectHeadLeft = new Rectangle(_JMTiTleImageLocation, _JMTitleImageSize);//表头图片范围
            if (rectHeadRight.Contains(e.Location))
            {
                if (_JMTitleTZVisible)
                {
                    if (_JMTitleTiaoZhuan != null)
                    {
                        if (JMTZClick != null)
                        {
                            //执行单击事件(无参数)
                            JMTZClick();
                        }
                        if (JMTZCZClick != null)
                        {
                            JEventargs ee = new JEventargs();
                            //执行单击事件(带参数)
                            JMTZCZClick(this, ee);
                        }
                    }
                }
            }
            else if (rectHead.Contains(e.Location))
            {
                if (JMTitleClick != null)
                {
                    //执行单击事件
                    JMTitleClick();
                }
                if (JMTitleCZClick != null)
                {
                    JEventargs ee = new JEventargs();
                    JMTitleCZClick(this, ee);
                }
            }
            else if (rectHeadLeft.Contains(e.Location))
            {
                if (_JMTitleImageVisible)
                {
                    if (_JMTitleImage != null)
                    {
                        if (JMTitleImgClick != null)
                        {
                            JEventargs ee = new JEventargs();
                            //执行单击事件
                            JMTitleImgClick(this, ee);
                        }
                    }
                }
            }
            ////单击跳转界面按钮
            //if (_JMTitleTZVisible)
            //{
            //    if (_JMTitleTiaoZhuan != null)
            //    {
            //        Rectangle rect = new Rectangle(_JMTitleTZLocation, _JMTitleTZSize);
            //        //判断鼠标是否为跳转界面按钮范围内
            //        if (rect.Contains(e.Location))
            //        {
            //            if (JMTZClick != null)
            //            {
            //                //执行单击事件
            //                JMTZClick();
            //            }
            //        }
            //    }
            //}
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.Cursor != Cursors.Hand)
            {
                if (_JMTitleTZVisible)
                {
                    if (_JMTitleTiaoZhuan != null)
                    {
                        Rectangle rectHeadRight = new Rectangle(_JMTitleTZLocation, _JMTitleTZSize);//向右箭头范围
                        if (rectHeadRight.Contains(e.Location))
                        {
                            Cur = this.Cursor;
                            this.Cursor = _JMCursor;
                        }
                        else
                        {
                            if (Cur != null)
                            {
                                this.Cursor = Cur;
                                Cur = null;
                            }
                        }
                    }
                }
                if (_JMTitleImageVisible)
                {
                    if (_JMTitleImage != null)
                    {
                        Rectangle rectHeadLeft = new Rectangle(_JMTiTleImageLocation, _JMTitleImageSize);//表头图片范围
                        if (rectHeadLeft.Contains(e.Location))
                        {
                            Cur = this.Cursor;
                            this.Cursor = _JMCursor;
                        }
                        else
                        {
                            if (Cur != null)
                            {
                                this.Cursor = Cur;
                                Cur = null;
                            }
                        }
                    }
                }
            }
        }
    }
}