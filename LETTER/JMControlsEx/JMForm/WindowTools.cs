using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class WindowTools : Panel
    {
        private readonly Size toolSize = new Size(92, 100);

        private bool isMouseOn;
        private bool isMouseDown;

        public bool IsMouseDown
        {
            get { return isMouseDown; }
            set { isMouseDown = value; Invalidate(); }
        }

        public bool IsMouseOn
        {
            get { return isMouseOn; }
            set { isMouseOn = value; Invalidate(); }
        }

        public WindowTools()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(44, 60);
            text = "";
            img = null;
            isMouseOn = false;
            _ZTextLocation = new Point(0, 0);
        }

        /// <summary>
        /// 显示值坐标
        /// </summary>
        private Point _ZTextLocation;

        public Point ZTextLocation
        {
            get { return _ZTextLocation; }
            set { _ZTextLocation = value; Invalidate(); }
        }

        private Image img;

        public Image ZImg
        {
            get { return img; }
            set { img = value; }
        }

        private string text;

        public string ZText
        {
            get { return text; }
            set { text = value; }
        }

        private bool _isNew = false;

        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; Invalidate(); }
        }

        private bool isClick;

        public bool IsClick
        {
            get { return isClick; }
            set
            {
                isClick = value;
                IsMouseDown = value;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.HighQuality; //高质量
                g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                if (IsMouseDown)
                {
                    Color cloh = Color.FromArgb(255, 200, 200, 200);
                    Rectangle rec1 = new Rectangle(0, 0, Width, Height);
                    LinearGradientBrush lb = new LinearGradientBrush(rec1, ColorClass.GetColor(cloh, -135, 0, 0, 0), ColorClass.GetColor(cloh, -253, 0, 0, 0), LinearGradientMode.Vertical);

                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(lb, rec1);
                    g.DrawLine(new Pen(Color.FromArgb(120, 50, 50, 50)), new Point(0, 0), new Point(Width, 0));
                }
                if (isMouseOn)
                {
                    Color cloh = Color.FromArgb(255, 255, 255, 255);
                    Rectangle rec1 = new Rectangle(0, 0, Width, Height);
                    LinearGradientBrush lb = new LinearGradientBrush(rec1, ColorClass.GetColor(cloh, -135, 0, 0, 0), ColorClass.GetColor(cloh, -253, 0, 0, 0), LinearGradientMode.Vertical);
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    g.FillRectangle(lb, rec1);
                    g.DrawLine(new Pen(Color.FromArgb(120, 50, 50, 50)), new Point(0, 0), new Point(Width, 0));
                }

                if (img != null)
                {
                    int x = (Width - img.Width) / 2;
                    int y = (Height - 20 - img.Height) / 2;
                    if (Width <= 0 || Height <= 0)
                    {
                        return;
                    }
                    Rectangle rec = new Rectangle(new Point(x, y), img.Size);
                    g.DrawImage(img, rec);
                }

                if (IsNew)
                {
                    //g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(55, 20, 10, 10));
                    g.DrawImage(Properties.Resources._new, new Rectangle(this.Width-12, 2, 10, 10));
                }

                Rectangle rectext = new Rectangle(_ZTextLocation, new Size(toolSize.Width, 30));
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Near;
                sf.Alignment = StringAlignment.Center;
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }
                g.DrawString(ZText, this.Font, new SolidBrush(ForeColor), rectext, sf);
            }
            catch
            {
                Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            IsMouseOn = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (IsMouseOn)
            {
                IsMouseOn = false;
            }
            if (!isClick)
            {
                if (IsMouseDown)
                {
                    IsMouseDown = false;
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!IsMouseDown)
            {
                IsMouseDown = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!isClick)
            {
                if (IsMouseDown)
                {
                    IsMouseDown = false;
                }
            }
        }
    }
}