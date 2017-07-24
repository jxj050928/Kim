using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx.JMCylinder
{
    public class CylinderEx : Panel
    {
        private decimal _maxValue;

        public decimal MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value <= 0 ? 1 : value; Invalidate(); }
        }
        private decimal _value;

        public decimal Value
        {
            get { return _value; }
            set { _value = value; Invalidate(); }
        }

        private Color ryColor;

        public Color RyColor
        {
            get { return ryColor; }
            set { ryColor = value; Invalidate(); }
        }

        private Color emptyColor;

        public Color EmptyColor
        {
            get { return emptyColor; }
            set { emptyColor = value; Invalidate(); }
        }

        public CylinderEx()
        {
            _maxValue = 100;
            _value = 0;
            ryColor = Color.FromArgb(255, 128, 0);
            emptyColor = Color.FromArgb(220, 220, 220);
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (_maxValue == 0)
            {
                return;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            Pen pen = new Pen(Color.FromArgb(220, 220, 220));

            int cWidth = Width - 1;
            int cHeight = Height - 2;
            Rectangle recry = new Rectangle(0, 0, cWidth, cHeight);//所有区域

            int PieAng = cWidth / 2;//半圆大小

            decimal OnePercentHeight = (cHeight - PieAng) / Convert.ToDecimal(100);

            decimal perCent = _value / _maxValue * 100;//溶液占用比例
            perCent = perCent > 100 ? 100 : perCent;
            perCent = perCent == 0 ? 1 : perCent;
            int hvalue = (cHeight - PieAng / 2) - (int)(OnePercentHeight * perCent);//溶液所在高度

            Rectangle rectTop = new Rectangle(0, 0, cWidth, PieAng);//容器 顶部椭圆区域

            Rectangle rectrTop = new Rectangle(0, hvalue - PieAng / 2, cWidth, PieAng);//溶液 顶部椭圆区域

            Rectangle rect = new Rectangle(0, cHeight - PieAng, cWidth, PieAng);//溶液 底部

            LinearGradientBrush lbry = new LinearGradientBrush(recry, ColorClass.GetColor(ryColor, 0, 0, 70, 10), ColorClass.GetColor(ryColor, 0, -12, -47, 9), LinearGradientMode.Horizontal);
            LinearGradientBrush brushrt = new LinearGradientBrush(recry, ColorClass.GetColor(ryColor, 0, 200, 200, 200), ColorClass.GetColor(ryColor, 0, -4, 70, 2), LinearGradientMode.Horizontal);
            //LinearGradientBrush brushempty = new LinearGradientBrush(recry, ColorClass.GetColor(emptyColor, -100, 200, 200, 200), ColorClass.GetColor(emptyColor, -100, -20, -20, -20), LinearGradientMode.Horizontal);
            LinearGradientBrush brushempty = new LinearGradientBrush(recry, Color.FromArgb(230, 230, 230), Color.FromArgb(200, 200, 200), LinearGradientMode.Horizontal);
             

            if (_value > 0)
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(rect, 0, 180);
                gp.AddArc(rectrTop, 180, -180);
                gp.CloseFigure();
                g.FillPath(lbry, gp);//溶液

                g.FillEllipse(brushrt, rectrTop);//溶液 顶部
            }
            else
            {
                g.DrawEllipse(new Pen(ColorClass.GetColor(emptyColor, 0, 0, 0, 0)), rectrTop);//溶液 顶部
                g.FillEllipse(brushempty, rectrTop);//溶液 顶部

                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(rect, 0, 180);
                gp.AddArc(rectrTop, 180, -180);
                gp.CloseFigure();
                g.FillPath(lbry, gp);//溶液

                g.FillEllipse(brushrt, rectrTop);//溶液 顶部
            }

            if (_value < _maxValue)
            {
                GraphicsPath gp1 = new GraphicsPath();
                gp1.AddArc(rectTop, 0, 180);
                gp1.AddArc(rectrTop, -180, 180);
                gp1.CloseFigure();
                g.FillPath(brushempty, gp1);//溶液
            }

            g.DrawEllipse(pen, rectTop);//容器 顶部

            //if (_value > 0)
            //{
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                g.DrawString(_value.ToString(), Font, new SolidBrush(ForeColor), rectrTop, sf);
            //}
        }
    }
}
