using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JMDateImageItem : JMImageItem
    {
        private const int Wx = 10;
        private const int Wxx = 20;

        public JMDateImageItem()
            : base()
        {
            _shouru = 0;
            _zhichu = 0;
            theMonth = "";
            _MonthFont = new Font("宋体", 12, FontStyle.Bold);
            benyue = false;
        }

        private bool benyue = false;

        public bool Benyue
        {
            get { return benyue; }
            set { benyue = value; this.Invalidate(); }
        }

        private Font _MonthFont = new Font("宋体", 12, FontStyle.Bold);

        public Font MonthFont
        {
            get { return _MonthFont; }
            set { _MonthFont = value; this.Invalidate(); }
        }

        private decimal _shouru = 0;

        public decimal Shouru
        {
            get { return _shouru; }
            set { _shouru = value; this.Invalidate(); }
        }

        private decimal _zhichu = 0;

        public decimal Zhichu
        {
            get { return _zhichu; }
            set { _zhichu = value; this.Invalidate(); }
        }

        private string theMonth = "";

        public string TheMonth
        {
            get { return theMonth; }
            set { theMonth = value; this.Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            StringFormat sfor = new StringFormat();
            sfor.Alignment = StringAlignment.Center;
            sfor.LineAlignment = StringAlignment.Center;
            g.DrawString(TheMonth, MonthFont, new SolidBrush(Color.Black), new Rectangle(Width / 2 + Wx, 0, Width / 2, Height), sfor);

            if (benyue)
            {
                sfor = new StringFormat();
                sfor.Alignment = StringAlignment.Far;
                sfor.LineAlignment = StringAlignment.Near;
                g.DrawString("本月", this.Font, new SolidBrush(Color.Gray), new Rectangle(Width / 2 + Wx, 0, Width / 2, Height), sfor);
            }

            sfor = new StringFormat();
            sfor.Alignment = StringAlignment.Far;
            sfor.LineAlignment = StringAlignment.Far;
            Color scolor = Color.Gray;
            if (Shouru > 0)
                scolor = Color.Red;
            g.DrawString("+" + Shouru.ToString("N2"), this.Font, new SolidBrush(scolor), new Rectangle(0, 0, Width / 2 + Wxx, Height / 3 - 2), sfor);



            LinearGradientBrush lgbrush = new LinearGradientBrush(new Point(0, 0), new Point(Width / 2 + Wxx, 0), Color.Gray, Color.FromArgb(0, Color.Gray));
            g.FillRectangle(lgbrush, new Rectangle(0, Height / 3, Width / 2 + Wxx, 1));

            sfor = new StringFormat();
            sfor.Alignment = StringAlignment.Far;
            sfor.LineAlignment = StringAlignment.Near;
            Color zcolor = Color.Gray;
            if (Zhichu > 0)
                zcolor = Color.Green;
            g.DrawString("-" + Zhichu.ToString("N2"), this.Font, new SolidBrush(zcolor), new Rectangle(0, Height / 3 + 2, Width / 2 + Wxx, Height / 3), sfor);

            sfor.Trimming = StringTrimming.EllipsisCharacter;
            g.DrawString("余" + (Shouru - Zhichu).ToString("N2"), this.Font, new SolidBrush(Color.FromArgb(255, 102, 0)), new Rectangle(0, Height / 3 * 2 + 2, Width / 2 + Wxx, Height / 3 - 5), sfor);

            g.DrawLine(new Pen(Color.Gray), new Point(0, Height - 1), new Point(Width, Height - 1));
        }
    }
}