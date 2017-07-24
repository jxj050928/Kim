using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JPictureBox:PictureBox
    {

        public event EventHandler DeleteClick;
        public event EventHandler SelectClick;

        private bool _isMouseIn;
        private bool _isFoucs;
        private bool _Default;
        /// <summary>
        /// 是否显示右上角删除按钮
        /// </summary>
        private bool _SFVisibleClose;
        /// <summary>
        /// VIP标记
        /// </summary>
        private string _ZVip;
        /// <summary>
        /// 皮肤名称
        /// </summary>
        private string _ZImageNames;

        [Description("是否显示右上角删除按钮")]
        public bool SFVisibleClose
        {
            get { return _SFVisibleClose; }
            set { _SFVisibleClose = value; }
        }

        public bool Default
        {
            get { return _Default; }
            set { _Default = value; }
        }

        public bool IsFoucs
        {
            get { return _isFoucs; }
            set { _isFoucs = value; Invalidate(); }
        }

        private bool _isMinX;

        [Description("VIP标记")]
        public string ZVip
        {
            get { return _ZVip; }
            set { _ZVip = value; }
        }

        [Description("皮肤名称")]
        public string ZImageNames
        {
            get { return _ZImageNames; }
            set { _ZImageNames = value; }
        }
        Rectangle recX;

        public JPictureBox()
            : base()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            _isMouseIn = false;
            _isFoucs = false;
            _isMinX = false;
            _Default = false;
            _SFVisibleClose = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rec = new Rectangle(0, 0, Width - 1, Height - 1);
            if (_SFVisibleClose)
            {
                if (_isMouseIn || _isFoucs)
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(200, 100, 100, 100), 2), rec);
                    recX = new Rectangle(Width - 1 - 20, 0, 20, 20);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(200, 0, 0, 150)), recX);
                    GraphicsPath pathX = GetGraphicPath.CreateCloseFlagPath(recX);

                    Color cl = _isMinX ? Color.Red : Color.White;
                    g.FillPath(new SolidBrush(cl), pathX);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (recX.Contains(e.Location))
            {
                if (!_isMinX)
                {
                    _isMinX = true;
                    this.Invalidate(recX);
                }
            }
            else
            {
                if (_isMinX)
                {
                    _isMinX = false;
                    this.Invalidate(recX);
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isMouseIn = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isMouseIn = false;
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (recX.Contains(e.Location))
            {
                if (DeleteClick != null)
                    DeleteClick(this, EventArgs.Empty);
            }
            else
            {

                if (SelectClick != null)
                    SelectClick(this, EventArgs.Empty);
                _isFoucs = true;
                Invalidate();
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _isFoucs = false;
            Invalidate();
        }
    }
}
