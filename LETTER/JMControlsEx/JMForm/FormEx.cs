using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class FormEx : Form
    {
        /// <summary>
        /// vip单击//
        /// </summary>
        public event JMDelegate.ClickHandel VipClick;

        /// <summary>
        /// skin单击
        /// </summary>
        public event JMDelegate.ClickHandel SkinClick;

        /// <summary>
        /// 用户反馈单击
        /// </summary>
        public event JMDelegate.ClickHandel UserClick;

        /// <summary>
        /// 
        /// </summary>
        public event JMDelegate.ClickHandel MainClick;

        /// <summary>
        /// 当前窗体的状态(是否靠边)
        /// </summary>
        internal AnchorStyles StopAanhor = AnchorStyles.None;

        private const int C_BottomHeight = 30;//状态栏高度
        private Size cmmSize = new Size(25, 25);//最大化 最小化 关闭 等按钮 大小
        private const int cmmjj = 7;//最大化 最小化 关闭 等按钮 间距大小

        #region const
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0Xf010;
        private const int HTCAPTION = 0x0002;
        #endregion

        private WinButState winButState = WinButState.NONE;

        private Rectangle Userrect;
        private Rectangle VIPrect;
        private Rectangle pfrect;
        private Rectangle Minrect;
        private Rectangle maxrect;
        private Rectangle closerect;
        private Rectangle Mainrect;

        private int _captionHeight;

        public int CaptionHeight
        {
            get { return _captionHeight; }
            set { _captionHeight = value; Invalidate(); }
        }
        private bool _pfBox;
        private bool _vipBox;
        private string _bottomText;

        public string BottomText
        {
            get { return _bottomText; }
            set { _bottomText = value; Invalidate(); }
        }

        private bool isDrawBackground;
        
        public bool IsDrawBackground
        {
            get { return isDrawBackground; }
            set { isDrawBackground = value; Invalidate(); }
        }

        /// <summary>
        /// 是否显示皮肤按钮
        /// </summary>
        private bool _ZSkinVisible;

        public bool ZSkinVisible
        {
            get { return _ZSkinVisible; }
            set { _ZSkinVisible = value; Invalidate(); }
        }

        /// <summary>
        /// 是否显示VIP按钮
        /// </summary>
        private bool _ZVipVisible;

        public bool ZVipVisible
        {
            get { return _ZVipVisible; }
            set { _ZVipVisible = value; Invalidate(); }
        }

        private bool _ZUserVisible;

        public bool ZUserVisible
        {
            get { return _ZUserVisible; }
            set { _ZUserVisible = value; Invalidate(); }
        }

        private bool _ZMainVisible;

        public bool ZMainVisible
        {
            get { return _ZMainVisible; }
            set { _ZMainVisible = value; Invalidate(); }
        }

        private bool _JMDoubleclick;

        public bool JMDoubleclick
        {
            get { return _JMDoubleclick; }
            set { _JMDoubleclick = value; }
        }

        private bool _JMBTUrl;

        public bool JMBTUrl
        {
            get { return _JMBTUrl; }
            set { _JMBTUrl = value; }
        }

        Timer doubletimer = new Timer();
        private bool doubleclike = false;

        #region 构造函数
        public FormEx()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;//最大化时不超出屏幕


            //默认属性
            isDrawBackground = false;
            _captionHeight = 150;
            _pfBox = true;
            _vipBox = true;
            _bottomText = "版权所有：长春佳盟信息科技有限公司";
            _ZSkinVisible = false;
            _ZVipVisible = false;
            _ZUserVisible = false;
            _ZMainVisible = false;
            _JMDoubleclick = true;

            doubletimer.Interval = 100;
            doubletimer.Tick += new EventHandler(doubletimer_Tick);
        }

        void doubletimer_Tick(object sender, EventArgs e)
        {
            if (doubleclike)
            {
                doubletimer.Interval = 100;
                doubleclike = false;
                doubletimer.Enabled = false;
            }
            else
            {
                doubletimer.Interval = 300;
                doubleclike = true;
            }
        }
        #endregion

        //const int WS_CLIPCHILDREN = 0x2000000;
        //const int WS_MINIMIZEBOX = 0x20000;
        //const int WS_MAXIMIZEBOX = 0x10000;
        //const int WS_SYSMENU = 0x80000;
        //const int CS_DBLCLKS = 0x8;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.Style = WS_CLIPCHILDREN | WS_MINIMIZEBOX | WS_SYSMENU;
        //        cp.ClassStyle = CS_DBLCLKS;
        //        return cp;
        //    }
        //}

        #region 调整窗体大小的方法 鼠标移动事件
        protected override void WndProc(ref Message m)//调整窗体大小的方法 鼠标移动事件
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);//将指定屏幕点的位置计算成工作区坐标
                if (pos.X >= this.ClientSize.Width - 4 && pos.Y >= this.ClientSize.Height - 4)
                {
                    m.Result = (IntPtr)17; //右下
                    return;
                }
                if (pos.X <= 10 && pos.Y >= this.ClientSize.Height - 4)
                {
                    m.Result = (IntPtr)16; //左下
                    return;
                }
                if (pos.X >= this.ClientSize.Width - 10 && pos.Y <= 4)
                {
                    m.Result = (IntPtr)14; //右上
                    return;
                }
                if (pos.X <= 10 && pos.Y <= 4)
                {
                    m.Result = (IntPtr)13; //左上
                    return;
                }
                if (pos.Y >= this.ClientSize.Height - 4)
                {
                    m.Result = (IntPtr)15; //下
                    return;
                }
                if (pos.Y <= 4)
                {
                    m.Result = (IntPtr)12; //上
                    return;
                }
                if (pos.X <= 4)
                {
                    m.Result = (IntPtr)10; //左
                    return;
                }
                if (pos.X >= this.ClientSize.Width - 4)
                {
                    m.Result = (IntPtr)11; //右
                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Userrect = Rectangle.Empty;
            VIPrect = Rectangle.Empty;
            pfrect = Rectangle.Empty;
            Minrect = Rectangle.Empty;
            maxrect = Rectangle.Empty;
            closerect = Rectangle.Empty;

            //base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量

            if (Width <= 0 || Height <= 0)
            {
                return;
            }

            try
            {
                DrawIcon(g);
                DrawText(g);

                DrawClose(g);
                DrawMax(g);
                DrawMin(g);
                if (_ZSkinVisible)
                {
                    DrawPF(g);
                }
                if (_ZVipVisible)
                {
                    DrawVIP(g);
                }
                if (_ZUserVisible)
                {
                    DrawUserFeedback(g);
                }
                if (_ZMainVisible)
                {
                    DrawMain(g);
                }
                DrawBottomText(g);
            }
            catch
            {
                Invalidate();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                //base.OnPaintBackground(e);
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.HighQuality; //高质量

                if (Width <= 0 || Height <= 0)
                {
                    return;
                }

                DrawBackGround(g);
            }
            catch
            {
                Invalidate();
            }
        }

        /// <summary>
        /// 画最下面文字(版权所有)
        /// </summary>
        /// <param name="g"></param>
        private void DrawBottomText(Graphics g)
        {
            Rectangle rectbt = new Rectangle(0, Height - C_BottomHeight, Width - 10, C_BottomHeight + 5);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Far;
            if (Width <= 0 || Height <= 0)
            {
                return;
            }
            g.DrawString(_bottomText, Font, new SolidBrush(ForeColor), rectbt, sf);
        }

        /// <summary>
        /// 画窗体左上角图标
        /// </summary>
        /// <param name="g"></param>
        private void DrawIcon(Graphics g)
        {
            if (ShowIcon)
            {
                Rectangle rect = new Rectangle(new Point(3, 3), new Size(16, 18));
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.DrawIcon(this.Icon, rect);
            }
        }

        /// <summary>
        /// 画标题文字
        /// </summary>
        /// <param name="g"></param>
        private void DrawText(Graphics g)
        {
            Point p = new Point(3, 6);
            if (ShowIcon)
            {
                p.X += 18;
            }
            if (Width <= 0 || Height <= 0)
            {
                return;
            }
            Font fon = new Font("宋体", 9);
            g.DrawString(Text, fon, new SolidBrush(ForeColor), p);
        }

        #region 窗口右上角按钮
        /// <summary>
        /// 画关闭
        /// </summary>
        /// <param name="g"></param>
        private void DrawClose(Graphics g)
        {
            closerect = new Rectangle(new Point(Width - cmmSize.Width - cmmjj, 1), cmmSize);
            if (WinButState.CLOP == winButState)
            {
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.FillRectangle(new SolidBrush(Color.FromArgb(188, 0, 0)), closerect);
            }
            else if (WinButState.CLOH == winButState)
            {
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.FillRectangle(new SolidBrush(Color.FromArgb(188, 0, 0)), closerect);
            }
            Image closeimage = Properties.Resources.h_close;
            Rectangle imgrect = new Rectangle(new Point(closerect.X + (cmmSize.Width - closeimage.Width) / 2, closerect.Y + (cmmSize.Height - closeimage.Height) / 2), closeimage.Size);
            if (Width <= 0 || Height <= 0)
            {
                return;
            }
            g.DrawImage(closeimage, imgrect);
        }

        /// <summary>
        /// 画最大化
        /// </summary>
        /// <param name="g"></param>
        private void DrawMax(Graphics g)
        {
            if (MaximizeBox)
            {
                maxrect = new Rectangle(new Point(Width - cmmSize.Width * 2 - cmmjj * 2, 1), cmmSize);
                if (WinButState.MAXP == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), maxrect);
                }
                else if (WinButState.MAXH == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), maxrect);
                }
                Image closeimage = Properties.Resources.h_max;
                Rectangle imgrect = new Rectangle(new Point(maxrect.X + (cmmSize.Width - closeimage.Width) / 2, maxrect.Y + (cmmSize.Height - closeimage.Height) / 2), closeimage.Size);
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.DrawImage(closeimage, imgrect);
            }
        }

        /// <summary>
        /// 画最小化
        /// </summary>
        /// <param name="g"></param>
        private void DrawMin(Graphics g)
        {
            if (MinimizeBox)
            {
                int c = MaximizeBox ? 3 : 2;
                Minrect = new Rectangle(new Point(Width - cmmSize.Width * c - cmmjj * c, 1), cmmSize);
                if (WinButState.MINP == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), Minrect);
                }
                else if (WinButState.MINH == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), Minrect);
                }
                Image closeimage = Properties.Resources.h_min;
                Rectangle imgrect = new Rectangle(new Point(Minrect.X + (cmmSize.Width - closeimage.Width) / 2, Minrect.Y + (cmmSize.Height - closeimage.Height) / 2), closeimage.Size);
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.DrawImage(closeimage, imgrect);
            }
        }

        /// <summary>
        /// 画皮肤
        /// </summary>
        /// <param name="g"></param>
        private void DrawPF(Graphics g)
        {
            if (_pfBox)
            {
                int c = 2;
                if (MaximizeBox)
                    c++;
                if (MinimizeBox)
                    c++;
                pfrect = new Rectangle(new Point(Width - cmmSize.Width * c - cmmjj * c, 1), cmmSize);
                if (WinButState.PFP == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), pfrect);
                }
                else if (WinButState.PFH == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), pfrect);
                }
                Image closeimage = Properties.Resources.h_pf;
                Rectangle imgrect = new Rectangle(new Point(pfrect.X + (cmmSize.Width - closeimage.Width) / 2, pfrect.Y + (cmmSize.Height - closeimage.Height) / 2), closeimage.Size);
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.DrawImage(closeimage, imgrect);
            }
        }

        /// <summary>
        /// 画VIP
        /// </summary>
        /// <param name="g"></param>
        private void DrawVIP(Graphics g)
        {
            if (_vipBox)
            {
                int c = 2;
                if (MaximizeBox)
                    c++;
                if (MinimizeBox)
                    c++;
                if (_ZSkinVisible)
                {
                    if (_pfBox)
                        c++;
                }
                VIPrect = new Rectangle(new Point(Width - cmmSize.Width * c - cmmjj * c, 1), cmmSize);
                if (WinButState.VIPP == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), VIPrect);
                }
                else if (WinButState.VIPH == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), VIPrect);
                }
                Image closeimage = Properties.Resources.h_vip;
                Rectangle imgrect = new Rectangle(new Point(VIPrect.X + (cmmSize.Width - closeimage.Width) / 2, VIPrect.Y + (cmmSize.Height - closeimage.Height) / 2), closeimage.Size);
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.DrawImage(closeimage, imgrect);
            }
        }

        /// <summary>
        /// 画用户反馈
        /// </summary>
        /// <param name="g"></param>
        private void DrawUserFeedback(Graphics g)
        {
            if (_ZUserVisible)
            {
                int c = 1;
                if (MaximizeBox)
                    c++;
                if (MinimizeBox)
                    c++;
                if (_ZSkinVisible)
                {
                    if (_pfBox)
                        c++;
                }
                if (_ZVipVisible)
                {
                    if (_vipBox)
                        c++;
                }
                SizeF txtsize = g.MeasureString("用户反馈", new Font("宋体", 9f, FontStyle.Bold));
                Size txsize = new Size(Convert.ToInt32(txtsize.Width), Convert.ToInt32(txtsize.Height));
                Userrect = new Rectangle(new Point(Width - cmmSize.Width * c - cmmjj * c - txsize.Width - cmmjj, 1), txsize);
                Rectangle rect = new Rectangle(Width - cmmSize.Width * c - cmmjj * c - txsize.Width - cmmjj, 1, txsize.Width - 1, cmmSize.Height);
                if (WinButState.UserP == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), rect);
                }
                else if (WinButState.UserH == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), rect);
                }

                Rectangle txtrect = new Rectangle(new Point(Userrect.X, Userrect.Y + (txsize.Height) / 2), txsize);
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }

                g.DrawString("用户反馈", new Font("宋体", 9f, FontStyle.Bold), new SolidBrush(Color.White), txtrect);
            }
        }

        /// <summary>
        /// 画主界面按钮
        /// </summary>
        /// <param name="g"></param>
        private void DrawMain(Graphics g)
        {
            if (_ZMainVisible)
            {
                int c = 1;
                if (MaximizeBox)
                    c++;
                if (MinimizeBox)
                    c++;
                if (_ZSkinVisible)
                {
                    if (_pfBox)
                        c++;
                }
                if (_ZVipVisible)
                {
                    if (_vipBox)
                        c++;
                }
                if (_ZUserVisible)
                {
                    c++;
                }
                SizeF txtsize = g.MeasureString("用户反馈", new Font("宋体", 9f, FontStyle.Bold));
                Size txsize = new Size(Convert.ToInt32(txtsize.Width), Convert.ToInt32(txtsize.Height));
                Mainrect = new Rectangle(new Point(Width - cmmSize.Width * c - cmmjj * c - txsize.Width, 1), cmmSize);
                if (WinButState.MainP == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), Mainrect);
                }
                else if (WinButState.MainH == winButState)
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), Mainrect);
                }
                Image closeimage = Properties.Resources.top_Main;
                Rectangle imgrect = new Rectangle(new Point(Mainrect.X + (cmmSize.Width - closeimage.Width) / 2, Mainrect.Y + (cmmSize.Height - closeimage.Height) / 2), closeimage.Size);
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.DrawImage(closeimage, imgrect);
            }
        }
        #endregion

        private void DrawBackGround(Graphics g)
        {
            if (Width <= 0 || Height <= 0)
            {
                return;
            }

            g.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
            if (this.BackgroundImage != null && isDrawBackground)
            {
                //图片填充
                Rectangle rect = new Rectangle(1, 1, Width - 2, CaptionHeight);
                Rectangle rectimg = new Rectangle(0, 0, BackgroundImage.Width, CaptionHeight);
                if (BackgroundImage.Width < rect.Width)
                {
                    rect = new Rectangle(Width - BackgroundImage.Width, 0, BackgroundImage.Width, rect.Height);
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.DrawImage(BackgroundImage, rect, rectimg, GraphicsUnit.Pixel);
                }
                else
                {
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.DrawImage(BackgroundImage, rect, rectimg, GraphicsUnit.Pixel);
                }
            }

            Rectangle rectm = new Rectangle(1, _captionHeight, Width - 3, Height - _captionHeight - C_BottomHeight);

            if (Width <= 0 || Height <= 0)
            {
                return;
            }
            g.FillRectangle(Brushes.White, rectm);

            Rectangle rectborder = new Rectangle(0, 0, Width - 1, Height - 1);

            if (Width <= 0 || Height <= 0)
            {
                return;
            }
            g.DrawRectangle(Pens.Black, rectborder);
        }

        #region 拖动窗体
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Rectangle baoti = new Rectangle(new Point(3, 3), new Size(140, 18));
            Rectangle cmmrect = new Rectangle(new Point(Width - cmmSize.Width * 5 - cmmjj * 5 - 53 - cmmjj - 1, 0), new Size(cmmSize.Width * 5 + cmmjj * 5 + 53 + cmmjj, cmmSize.Height + 1));

            if (Width <= 0 || Height <= 0)
            {
                return;
            }
            //if (baoti.Contains(e.Location))
            //{
            //    //System.Diagnostics.Process.Start("http://www.baeit.com");
            //}
            //else 
            if (closerect.Contains(e.Location))
            {
                winButState = WinButState.CLOP;
                Invalidate(cmmrect);
            }
            else if (maxrect.Contains(e.Location))
            {
                winButState = WinButState.MAXP;
                Invalidate(cmmrect);
            }
            else if (Minrect.Contains(e.Location))
            {
                winButState = WinButState.MINP;
                Invalidate(cmmrect);
            }
            else if (pfrect.Contains(e.Location))
            {
                winButState = WinButState.PFP;
                Invalidate(cmmrect);
            }
            else if (VIPrect.Contains(e.Location))
            {
                winButState = WinButState.VIPP;
                Invalidate(cmmrect);
            }
            else if (Userrect.Contains(e.Location))
            {
                winButState = WinButState.UserP;
                Invalidate(cmmrect);
            }
            else if (Mainrect.Contains(e.Location))
            {
                winButState = WinButState.MainP;
                Invalidate(cmmrect);
            }
            else if (e.Y < _captionHeight)
            {
                winButState = WinButState.NONE;
                Invalidate(cmmrect);
                //if (_JMDoubleclick)
                //{
                //    if (doubleclike)
                //    {
                //        if (this.WindowState == FormWindowState.Maximized)
                //        {
                //            this.WindowState = FormWindowState.Normal;
                //        }
                //        else
                //        {
                //            this.WindowState = FormWindowState.Maximized;
                //        }
                //        return;
                //    }
                //    doubletimer.Enabled = true;
                //}
                if (!doubleclike)
                {
                    Win32.ReleaseCapture();
                    Win32.SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
                }
            }
            else
            {
                winButState = WinButState.NONE;
                Invalidate(cmmrect);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Rectangle baoti = new Rectangle(new Point(3, 3), new Size(140, 18));

            Rectangle cmmrect = new Rectangle(new Point(Width - cmmSize.Width * 5 - cmmjj * 5 - 53 - cmmjj - 1, 0), new Size(cmmSize.Width * 5 + cmmjj * 5 + 53 + cmmjj, cmmSize.Height + 1));

            if (baoti.Contains(e.Location))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
            if (closerect.Contains(e.Location))
            {
                winButState = WinButState.CLOH;
                Invalidate(cmmrect);
            }
            else if (maxrect.Contains(e.Location))
            {
                winButState = WinButState.MAXH;
                Invalidate(cmmrect);
            }
            else if (Minrect.Contains(e.Location))
            {
                winButState = WinButState.MINH;
                Invalidate(cmmrect);
            }
            else if (pfrect.Contains(e.Location))
            {
                winButState = WinButState.PFH;
                Invalidate(cmmrect);
            }
            else if (VIPrect.Contains(e.Location))
            {
                winButState = WinButState.VIPH;
                Invalidate(cmmrect);
            }
            else if (Userrect.Contains(e.Location))
            {
                winButState = WinButState.UserH;
                Invalidate(cmmrect);
            }
            else if (Mainrect.Contains(e.Location))
            {
                winButState = WinButState.MainH;
                Invalidate(cmmrect);
            }
            else
            {
                winButState = WinButState.NONE;
                Invalidate(cmmrect);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (closerect.Contains(e.Location))
            {
                Close();
            }
            else if (maxrect.Contains(e.Location))
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            else if (Minrect.Contains(e.Location))
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (pfrect.Contains(e.Location))
            {
                if (SkinClick != null)
                {
                    SkinClick();
                }
            }
            else if (VIPrect.Contains(e.Location))
            {
                if (VipClick != null)
                {
                    VipClick();
                }
            }
            else if (Userrect.Contains(e.Location))
            {
                if (UserClick != null)
                {
                    UserClick();
                }
            }
            else if (Mainrect.Contains(e.Location))
            {
                if (MainClick != null)
                {
                    MainClick();
                }
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            //if (e.Y < _captionHeight)
            //{
            //    if (WindowState == FormWindowState.Maximized)
            //        this.WindowState = FormWindowState.Minimized;
            //    else
            //        this.WindowState = FormWindowState.Maximized;
            //}
        }

        protected override void OnResize(EventArgs e)
        {
            winButState = WinButState.NONE;
            base.OnResize(e);
            Invalidate();
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormEx
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "FormEx";
            this.ResumeLayout(false);

        }
    }
}
