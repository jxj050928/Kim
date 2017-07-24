using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JNToolStripProfessionalRenderer : ToolStripProfessionalRenderer
    {
        #region old
        private Color _baseColor;

        public Color BaseColor
        {
            get { return _baseColor; }
            set { _baseColor = value; }
        }

        public JNToolStripProfessionalRenderer()
            : base()
        {
            _baseColor = ColorClass.GetBColor();
            this.RoundedEdges = true;
        }

        public JNToolStripProfessionalRenderer(Color _color)
            : base()
        {
            _baseColor = _color;
            this.RoundedEdges = true;
        }

        //渲染项 不调用基类同名方法
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿

            ToolStripItem item = e.Item;
            ToolStrip toolstrip = e.ToolStrip;

            if (toolstrip is ToolStripDropDown)
            {
                if (item.Selected)
                {
                    LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(item.Width, 0), Color.FromArgb(50, Color.Gray), Color.FromArgb(50, Color.Gray));
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
                    //base.OnRenderToolStripBackground(e);
                    g.FillRectangle(lgbrush, bounds);
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
        }

        //渲染图片区域 下拉菜单左边的图片区域
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            //base.OnRenderImageMargin(e);

            //屏蔽掉左边图片竖条
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;//抗锯齿

            Rectangle bounds = e.AffectedBounds;
            SolidBrush lgbrush = new SolidBrush(_baseColor);
            g.FillRectangle(lgbrush, bounds);
        }

        //渲染图片区域
        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemImage(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            //base.OnRenderItemText(e);
            e.Graphics.DrawString(e.Text, e.TextFont, new SolidBrush(e.TextColor), new Point(e.TextRectangle.X-10, e.TextRectangle.Y+2));

            
        }

        //渲染分界线
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            //base.OnRenderSeparator(e);
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
