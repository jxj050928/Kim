using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class PanelRound:Panel
    {
        #region 构造函数
        public PanelRound()
        {
            _borderColor = Color.FromArgb(197, 197, 197);
            _backColorbegin = Color.FromArgb(222, 225, 230);
            _backColorend = Color.FromArgb(238, 242, 245);
            _radius = 8;
        }
        #endregion

        private Color _borderColor;

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        private Color _backColorbegin;

        public Color BackColorbegin
        {
            get { return _backColorbegin; }
            set { _backColorbegin = value; }
        }

        private Color _backColorend;

        public Color BackColorend
        {
            get { return _backColorend; }
            set { _backColorend = value; }
        }

        private int _radius;

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; Invalidate(); }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量

            g.DrawRectangle(new Pen(BackColor), this.ClientRectangle);

            //填充按钮颜色效果
            GraphicsPath gPath = GetGraphicPath.CreatePath(base.ClientRectangle, _radius, RoundStyle.All, true);
            gPath.CloseFigure();
            g.FillPath(new LinearGradientBrush(base.ClientRectangle, _backColorbegin, _backColorend, LinearGradientMode.Vertical), gPath);
            g.DrawPath(new Pen(new SolidBrush(_borderColor)), gPath);
            //g.SetClip(gPath);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }
    }
}
