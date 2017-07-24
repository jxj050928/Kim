using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JToolStripProfessionalRenderer : ToolStripProfessionalRenderer
    {
        #region old
        private Color _baseColor;

        public Color BaseColor
        {
            get { return _baseColor; }
            set { _baseColor = value; }
        }

        public JToolStripProfessionalRenderer()
            : base()
        {
            _baseColor = ColorClass.GetBColor();
            this.RoundedEdges = true;
        }

        public JToolStripProfessionalRenderer(Color _color)
            : base()
        {
            _baseColor = _color;
            this.RoundedEdges = true;
        }

        //渲染项 不调用基类同名方法
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            ToolStripItem item = e.Item;
            ToolStrip toolstrip = e.ToolStrip;

            //渲染顶级项
            if (toolstrip is MenuStrip)
            {
                LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(0, item.Height), Color.FromArgb(100, Color.White), Color.FromArgb(0, Color.White));
                SolidBrush brush = new SolidBrush(Color.FromArgb(255, Color.White));
                if (e.Item.Selected)
                {
                    //GraphicsPath gp = GetRoundedRectPath(new Rectangle(new Point(0, 0), item.Size), 5);
                    //g.FillPath(lgbrush, gp);
                }
                if (item.Pressed)
                {
                    g.FillRectangle(Brushes.White, new Rectangle(Point.Empty, item.Size));
                }
            }
            //渲染下拉项
            else if (toolstrip is ToolStripDropDown)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(item.Width, 0), Color.FromArgb(50, Color.Gray), Color.FromArgb(50, Color.Gray));
                if (item.Selected)
                {
                    Rectangle gp = new Rectangle(0, 0, item.Width, item.Height);
                    g.FillRectangle(lgbrush, gp);
                    gp.Height -= 1;
                    g.DrawRectangle(new Pen(Color.FromArgb(80, Color.Gray)), gp);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }

        //包括menustrip背景 toolstripDropDown背景
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿

            Rectangle bounds = e.AffectedBounds;
            SolidBrush lgbrush = new SolidBrush(_baseColor);
            Pen lgpen = new Pen(_baseColor);
            if (toolStrip is MenuStrip)
            {
                //由menuStrip的Paint方法定义 这里不做操作
                base.OnRenderToolStripBackground(e);
            }
            else if (toolStrip is ToolStrip)
            {
                if (toolStrip is ToolStripDropDown)
                {
                    base.OnRenderToolStripBackground(e);
                }
                else
                {
                    base.OnRenderToolStripBackground(e);
                }
            }
            else
            {
                base.OnRenderToolStripBackground(e);
            }
        }

        //渲染边框 不绘制边框
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
            Rectangle rec = e.AffectedBounds;
            rec.Width -= 1;
            rec.Height -= 1;
            e.Graphics.DrawRectangle(new Pen(ColorClass.GetColor(BaseColor, 0, -30, -30, -30)), rec);
        }

        //渲染图片区域 下拉菜单左边的图片区域
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            //base.OnRenderImageMargin(e);
            //屏蔽掉左边图片竖条
            Rectangle recback = e.AffectedBounds;
            recback.Width += 2;
            LinearGradientBrush lb = new LinearGradientBrush(e.AffectedBounds, BaseColor, BaseColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(lb, recback);
            if (e.AffectedBounds.Height > 30)
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                Rectangle rec = e.AffectedBounds;
                rec.X += 2;
                //rec.Width -= 1;
                Color fc = Color.FromArgb(71, 71, 71);
                if (BaseColor.R + BaseColor.B + BaseColor.G <= 280)
                {
                    fc = Color.White;
                }
                e.Graphics.DrawString("BApim", new Font("Nina", 9f, FontStyle.Bold), new SolidBrush(fc), rec, sf);
            }

            e.Graphics.DrawLine(new Pen(ColorClass.GetColor(BaseColor, 0, -30, -30, -30)), new Point(recback.Width + recback.X, recback.Y), new Point(recback.Width + recback.X, recback.Y + recback.Height));
        }

        //渲染图片区域
        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            //base.OnRenderItemImage(e);

            //Image img = e.Image;
            //Rectangle rect = e.ImageRectangle;
            //rect.X += 20;
            //e.Graphics.DrawImage(img, rect);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            //e.Graphics.DrawString(e.Text, e.TextFont, new SolidBrush(e.TextColor), new Point(e.TextRectangle.X + 10, e.TextRectangle.Y));
            if (e.Item.Tag != null)
            {
                Rectangle rectcrl = new Rectangle(e.TextRectangle.X + e.TextRectangle.Width - 8, e.TextRectangle.Y + 4, 9, 9);
                e.Graphics.DrawImage(Properties.Resources._new, rectcrl);
            }
        }

        //渲染分界线
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(e.Item.Width, 0), Color.Gray, Color.FromArgb(0, Color.Gray));
            g.FillRectangle(lgbrush, new Rectangle(33, e.Item.Height / 2, e.Item.Width - 30, 1));
        }

        //更改箭头颜色
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Color.Gray;
            base.OnRenderArrow(e);
        }
        #endregion end old
    }
}
