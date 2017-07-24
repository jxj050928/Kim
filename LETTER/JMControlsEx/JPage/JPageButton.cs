using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JPageButton : Panel
    {
        private PageButtonType buttonType;
        private bool _isFoucs;

        public bool IsFoucs
        {
            get { return _isFoucs; }
            set { _isFoucs = value; Invalidate(); }
        }

        private string _pageindex;

        public string Pageindex
        {
            get { return _pageindex; }
            set { _pageindex = value; Invalidate(); }
        }

        #region 构造函数
        public JPageButton()
        {
            buttonType = PageButtonType.None;
            this.BackColor = Color.Transparent;
            _isFoucs = false;
            this.MaximumSize = new Size(31, 31);
            this.MinimumSize = new Size(31, 31);
            _pageindex = "1";
            this.Cursor = Cursors.Hand;
        }
        #endregion

        public PageButtonType ButtonType
        {
            get { return buttonType; }
            set { buttonType = value; Invalidate(); }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(Point.Empty, new Size(31, 31));
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Image pageimg;
            if (PageButtonType.None == buttonType)
            {
                if (_isFoucs)
                {
                    pageimg = Properties.Resources.numS;
                    g.DrawImage(pageimg, Point.Empty);
                    g.DrawString(_pageindex.ToString(), this.Font, new SolidBrush(Color.White), rect, sf);
                }
                else
                {
                    pageimg = Properties.Resources.num;
                    g.DrawImage(pageimg, Point.Empty);
                    g.DrawString(_pageindex.ToString(), this.Font, new SolidBrush(Color.DimGray), rect, sf);
                }
            }
            else if (PageButtonType.First == buttonType)
            {
                if (!Enabled)
                {
                    pageimg = Properties.Resources.firstE;
                    g.DrawImage(pageimg, Point.Empty);
                }
                else
                {
                    pageimg = Properties.Resources.first;
                    g.DrawImage(pageimg, Point.Empty);
                }
            }
            else if (PageButtonType.End == buttonType)
            {
                if (!Enabled)
                {
                    pageimg = Properties.Resources.endE;
                    g.DrawImage(pageimg, Point.Empty);
                }
                else
                {
                    pageimg = Properties.Resources.end;
                    g.DrawImage(pageimg, Point.Empty);
                }
            }
            else if (PageButtonType.Befor == buttonType || PageButtonType.Next == buttonType)
            {
                if (_isFoucs)
                {
                    pageimg = Properties.Resources.numS;
                    g.DrawImage(pageimg, Point.Empty);
                    g.DrawString("...", this.Font, new SolidBrush(Color.White), rect, sf);
                }
                else
                {
                    pageimg = Properties.Resources.num;
                    g.DrawImage(pageimg, Point.Empty);
                    g.DrawString("...", this.Font, new SolidBrush(Color.DimGray), rect, sf);
                }
            }

        }
    }
}
