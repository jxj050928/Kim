using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace JMControlsEx
{
    public class JMProgressKJ : Panel
    {
        private string[] allkj = new string[] { "0mb", "25mb", "100mb", "200mb" };
        private string[] allkjde = new string[] { "", "免费", "VIP1", "VIP2" };//"", "免费", "VIP1(38元/年)", "58元/年"

        private double yyValue;

        public double YyValue
        {
            get { return yyValue; }
            set { yyValue = value; Invalidate(); }
        }
        private double kyMaxValue;

        public double KyMaxValue
        {
            get { return kyMaxValue; }
            set { kyMaxValue = value; Invalidate(); }
        }
        private double maxValue;

        public double MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; Invalidate(); }
        }

        private int processHeight;

        public int ProcessHeight
        {
            get { return processHeight; }
            set { processHeight = value; Invalidate(); }
        }

        #region 构造函数
        public JMProgressKJ()
        {
            maxValue = 200;
            kyMaxValue = 25;
            yyValue = 0;
            processHeight = 30;
        }
        #endregion

        #region 重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int _x = this.Padding.Left;
            int _y = this.Padding.Top;
            int _w = Width - _x - this.Padding.Right;
            int _h = Height - _y - this.Padding.Bottom;

            Rectangle rec = new Rectangle(_x, _y, Width, Height);

            //整个灰色 进度条
            Rectangle recprocess = new Rectangle(_x, (Height - processHeight) / 2, Width, processHeight);
            GraphicsPath proPath = GetGraphicPath.CreatePath(recprocess, 10, RoundStyle.All, false);
            g.FillPath(new SolidBrush(Color.LightGray), proPath);

            //可用空间 进度条
            int kyw = (int)((Width - _x) / maxValue * kyMaxValue);
            Rectangle recky = new Rectangle(_x, (Height - processHeight) / 2, kyw, processHeight);
            GraphicsPath kyPath = GetGraphicPath.CreatePath(recky, 10, RoundStyle.Left, false);
            g.FillPath(new SolidBrush(Color.Orange), kyPath);

            //已用空间 进度条
            int yyw = (int)((Width - _x) / maxValue * yyValue);
            if (yyw > 0)
            {
                Rectangle recyy = new Rectangle(_x, (Height - processHeight) / 2, yyw, processHeight);
                GraphicsPath yyPath = GetGraphicPath.CreatePath(recyy, 10, RoundStyle.Left, false);
                g.FillPath(new SolidBrush(Color.Blue), yyPath);

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                int yyfw = (int)g.MeasureString(" " + yyValue + "mb", Font).Width;
                if (yyw >= yyfw)
                {
                    g.DrawString(" " + yyValue + "mb", Font, new SolidBrush(Color.White), recyy, sf);
                }
            }

            #region 竖线
            int mfw = (int)((Width - _x) / maxValue * 25);
            g.DrawLine(new Pen(Color.White, 2), new Point(mfw, recky.Y), new Point(mfw, recky.Bottom));
            int vip1w = (int)((Width - _x) / maxValue * 100);
            g.DrawLine(new Pen(Color.White, 2), new Point(vip1w, recky.Y), new Point(vip1w, recky.Bottom));
            #endregion

            #region 画上下string
            int ty = (Height - processHeight) / 2 - 12;
            int by = (Height - processHeight) / 2 + processHeight + 4;

            g.DrawString(allkj[0], Font, new SolidBrush(ForeColor), new Point(_x, ty));

            int _mfx = mfw - (int)(g.MeasureString(allkj[1], Font).Width / 2);
            g.DrawString(allkj[1], Font, new SolidBrush(ForeColor), new Point(_mfx, ty));

            int _mfdex = mfw - (int)(g.MeasureString(allkjde[1], Font).Width / 2);
            g.DrawString(allkjde[1], Font, new SolidBrush(ForeColor), new Point(_mfdex, by));

            int _vipx = vip1w - (int)(g.MeasureString(allkj[2], Font).Width / 2);
            g.DrawString(allkj[2], Font, new SolidBrush(ForeColor), new Point(_vipx, ty));

            int _vipdex = vip1w - (int)(g.MeasureString(allkjde[2], Font).Width / 2);
            g.DrawString(allkjde[2], Font, new SolidBrush(ForeColor), new Point(_vipdex, by));

            int _vip2x = Width - (int)(g.MeasureString(allkj[3], Font).Width);
            g.DrawString(allkj[3], Font, new SolidBrush(ForeColor), new Point(_vip2x, ty));

            int _vipde2x = Width - (int)(g.MeasureString(allkjde[3], Font).Width);
            g.DrawString(allkjde[3], Font, new SolidBrush(ForeColor), new Point(_vipde2x, by));
            #endregion
        }
        #endregion

    }
}
