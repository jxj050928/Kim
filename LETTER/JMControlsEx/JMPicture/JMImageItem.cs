using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JMControlsEx
{
    public class JMImageItem : Control
    {
        private ControlState m_IsEnter;//是否选中

        public JMImageItem()
            : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            _displayStyle = ToolStripItemDisplayStyle.Text;
            m_IsEnter = ControlState.Normal;
        }

        private ToolStripItemDisplayStyle _displayStyle;

        public ToolStripItemDisplayStyle DisplayStyle
        {
            get { return _displayStyle; }
            set { _displayStyle = value; }
        }

        private Image _backimage;

        public Image Backimage
        {
            get { return _backimage; }
            set { _backimage = value; }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            m_IsEnter = ControlState.Hover;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            m_IsEnter = ControlState.Normal;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (_displayStyle == ToolStripItemDisplayStyle.Image)
            {
                if (_backimage != null)
                {
                    g.DrawImage(_backimage, 3, 3, Width - 6, Height - 6);
                }
            }
            else if (_displayStyle == ToolStripItemDisplayStyle.Text)
            {
                StringFormat sfor = new StringFormat();
                sfor.Alignment = StringAlignment.Center;
                sfor.LineAlignment = StringAlignment.Center;
                g.DrawString(Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(0, 0, Width, Height), sfor);
            }

            if (m_IsEnter == ControlState.Hover)
            {
                Rectangle rec=e.ClipRectangle;
                SolidBrush sbrush=new SolidBrush(Color.FromArgb(100,255,255,255));
                rec.Inflate(-1,-1);
                g.FillRectangle(sbrush, rec);
                g.DrawRectangle(new Pen(Color.FromArgb(100, 150, 255, 255)), rec);
            }
        }
    }
}
