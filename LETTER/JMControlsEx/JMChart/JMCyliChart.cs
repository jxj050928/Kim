using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JMCyliChart : Panel
    {
        private const int paddings = 60;

        #region 私有变量
        private decimal maxValue = 0;

        private decimal[] m_values = null;
        private string[] m_text = null;
        private Color[] m_pieColor = null;
        ToolTip m_toolTip;
        #endregion

        #region 构造函数
        public JMCyliChart()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            m_toolTip = new ToolTip();

            m_pieColor = new Color[]{
                                    Color.Red,
                                    Color.Green,
                                    Color.Blue,
                                    Color.Yellow,
                                    Color.Purple,
                                    Color.Olive,
                                    Color.Navy,
                                    Color.Aqua,
                                    Color.Lime,
                                    Color.Maroon,
                                    Color.Teal,
                                    Color.Fuchsia
                                  };

            this.Size = new Size(510, 242);
        }
        #endregion

        #region 公共属性



        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value; Invalidate();
            }
        }

        [Description("内容")]
        public string[] ZText
        {
            get { return m_text; }
            set
            {
                m_text = value;
                Invalidate();
            }
        }

        [Description("值")]
        public decimal[] ZValues
        {
            get { return m_values; }
            set
            {
                m_values = value;
                if (value == null)
                {
                    maxValue = 0;
                }
                else
                {
                    maxValue = 0;
                    foreach (decimal item in m_values)
                    {
                        maxValue = maxValue > item ? maxValue : item;
                    }
                }
                Invalidate();
            }
        }

        [Description("颜色")]
        public Color[] ZPieColor
        {
            get { return m_pieColor; }
            set { m_pieColor = value; Invalidate(); }
        }
        #endregion

        #region 重写
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width <= paddings * 2 || Height <= paddings * 2)
                return;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawAllLine(g);
            if (maxValue > 0)
            {
                DrawChart(g);
            }
        }

        #endregion

        #region 私有方法
        private void DrawAllLine(Graphics g)
        {
            Pen mypen = new Pen(Color.DarkGray, 1);
            Pen mypen1 = new Pen(Color.DarkGray, 2);


            int chartW = Width - paddings * 2;
            int chartH = Height - paddings * 2;


            //绘制横向线条
            g.DrawLine(mypen1, paddings, paddings, paddings, Height - paddings);

            Int64 maxV = 10;
            int dc = 5;
            while (maxV < maxValue)
            {
                maxV *= dc;
                dc = dc == 5 ? 2 : 5;
            }
            Int64 spaceV = maxV / 10;

            //绘制纵向线条
            int spaceh = chartH / 10;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.EllipsisPath;
            for (int i = 0; i < 11; i++)
            {
                int sh = paddings + i * spaceh;
                Rectangle rect = new Rectangle(5, sh-3, paddings - 8, 10);
                if (i == 10)
                {
                    g.DrawLine(mypen1, paddings, sh, Width - paddings, sh);
                }
                else if (i > 0)
                {
                    g.DrawLine(mypen, paddings, sh, Width - paddings, sh);
                }
                string drawT = (spaceV * (10 - i)).ToString();
                g.DrawString(drawT, Font, new SolidBrush(this.ForeColor), rect, sf);
            }

            sf.Alignment = StringAlignment.Center;
            int spacew = chartW / (m_values.Length + 1);

            for (int i = 1; i < (m_values.Length + 1); i++)
            {
                int sw = paddings + i * spacew;
                Rectangle rect = new Rectangle(sw - spacew / 2, Height - paddings + 10, spacew, 20);
                string drawT = m_text[i - 1];
                g.DrawString(drawT, Font, new SolidBrush(this.ForeColor), rect, sf);
            }
        }

        private void DrawChart(Graphics g)
        {
            int chartW = Width - paddings * 2;
            int chartH = Height - paddings * 2;

            int spacew = chartW / (m_values.Length + 1);

            Int64 maxV = 10;
            int dc = 5;
            while (maxV < maxValue)
            {
                maxV *= dc;
                dc = dc == 5 ? 2 : 5;
            }

            decimal oneH = Convert.ToDecimal(chartH) / Convert.ToDecimal(maxV);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.EllipsisPath;

            for (int i = 1; i < (m_values.Length + 1); i++)
            {
                int sw = paddings + i * spacew;

                decimal tvalue = m_values[i - 1];

                float cyliH = Convert.ToSingle(oneH * tvalue);
                if (cyliH > 0)
                {
                    RectangleF rect = new RectangleF(sw - 10, Height - paddings - cyliH, 20, cyliH);
                    Color itc = Color.Black;
                    if (m_pieColor.Length < i)
                    {
                        itc = ColorClass.GetColor(m_pieColor[(i - 1) % (m_pieColor.Length - 1)], -20, 20, 6, 30);
                    }
                    else
                    {
                        itc = m_pieColor[i - 1];
                    }
                    g.FillRectangle(new SolidBrush(itc), rect);
                }

                RectangleF rects = new RectangleF(sw - paddings/2, Height - paddings - cyliH - 20, paddings, 20);
                g.DrawString(tvalue.ToString("N2"), Font, new SolidBrush(this.ForeColor), rects, sf);
            }
        }
        #endregion

    }
}
