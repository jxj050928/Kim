using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JMPieChart : Panel
    {
        #region 私有变量
        private decimal sumValue = 0;
        private int m_height3D;
        private int m_pieWidth;
        private int m_pieHeight;
        private Point m_pieOrigin;

        private decimal[] m_values = null;
        private string[] m_text = null;
        private double[] allRadius = null;
        private Color[] m_pieColor = null;
        ToolTip m_toolTip;
        #endregion

        int clickshu = 0;

        private int CanMoveScroll = 0;
        private int scroll = 0;

        public int Z_Scroll
        {
            get { return scroll; }
            set
            {
                //if (value + CanMoveScroll < 0)
                //{
                //    return;
                //}
                //if (value > 0)
                //{
                //    return;
                //}
                scroll = value;
                Invalidate();
                if (scroll < 0)
                {
                    jmButtonTriangle1.Visible = true;
                }
                else
                {
                    jmButtonTriangle1.Visible = false;
                }
                if (CanMoveScroll > 0 && -value < CanMoveScroll)
                {
                    jmButtonTriangle2.Visible = true;
                }
                else
                {
                    jmButtonTriangle2.Visible = false;
                }
            }
        }

        private JMControlsEx.JMButtonTriangle jmButtonTriangle2;
        private JMControlsEx.JMButtonTriangle jmButtonTriangle1;

        private void InitializeComponent()
        {
            this.jmButtonTriangle1 = new JMControlsEx.JMButtonTriangle();
            this.jmButtonTriangle2 = new JMControlsEx.JMButtonTriangle();
            // 
            // jmButtonTriangle1
            // 
            this.jmButtonTriangle1.JMBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(209)))));
            this.jmButtonTriangle1.JMBaseColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(235)))));
            this.jmButtonTriangle1.Location = new System.Drawing.Point(326, 2);
            this.jmButtonTriangle1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.jmButtonTriangle1.Margin = new System.Windows.Forms.Padding(0);
            this.jmButtonTriangle1.Name = "jmButtonTriangle1";
            this.jmButtonTriangle1.Size = new System.Drawing.Size(40, 15);
            this.jmButtonTriangle1.TabIndex = 15;
            this.jmButtonTriangle1.UseVisualStyleBackColor = true;
            this.jmButtonTriangle1.ZADirection = System.Windows.Forms.ArrowDirection.Up;
            this.jmButtonTriangle1.Click += new System.EventHandler(this.jmButtonTriangle1_Click);
            jmButtonTriangle1.Visible = false;
            // 
            // jmButtonTriangle2
            // 
            this.jmButtonTriangle2.JMBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(209)))));
            this.jmButtonTriangle2.JMBaseColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(235)))));
            this.jmButtonTriangle2.Location = new System.Drawing.Point(326, 223);
            this.jmButtonTriangle2.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.jmButtonTriangle2.Margin = new System.Windows.Forms.Padding(0);
            this.jmButtonTriangle2.Name = "jmButtonTriangle2";
            this.jmButtonTriangle2.Size = new System.Drawing.Size(40, 15);
            this.jmButtonTriangle2.TabIndex = 16;
            this.jmButtonTriangle2.UseVisualStyleBackColor = true;
            this.jmButtonTriangle2.ZADirection = System.Windows.Forms.ArrowDirection.Down;
            this.jmButtonTriangle2.Click += new System.EventHandler(this.jmButtonTriangle2_Click);
            jmButtonTriangle2.Visible = false;

            this.Controls.Add(this.jmButtonTriangle2);
            this.Controls.Add(this.jmButtonTriangle1);
        }


        private void jmButtonTriangle2_Click(object sender, EventArgs e)
        {
            clickshu++;
            if (clickshu > m_values.Length - 16)
            {
                clickshu--;
                jmButtonTriangle2.Visible = false;
            }
            else
            {
                Z_Scroll -= 20;// jmPieChart1.Z_Scroll - 20 < 0 ? 0 : jmPieChart1.Z_Scroll - 20;
            }
        }

        private void jmButtonTriangle1_Click(object sender, EventArgs e)
        {
            clickshu--;
            Z_Scroll += 20;
            if (clickshu < 0)
            {
                clickshu = 0;
            }
        }

        #region 构造函数
        public JMPieChart()
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

            m_pieWidth = (this.Width - 1) / 2;
            m_pieHeight = (this.Height - 31 - ZHeight3D) / 2;
            m_pieOrigin = new Point(m_pieWidth / 2 + 15, m_pieHeight);
            m_height3D = 15;
            this.Size = new Size(510, 242);
            InitializeComponent();
        }
        #endregion

        #region 公共属性

        public int ZHeight3D
        {
            get { return m_height3D; }
            set
            {
                m_height3D = value;
                m_pieWidth = (this.Width - 1) / 2;
                m_pieHeight = (this.Height - 31 - ZHeight3D) / 2;
                m_pieOrigin = new Point(m_pieWidth / 2 + 15, m_pieHeight);
                Invalidate();
            }
        }

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
                CanMoveScroll = 0;
                scroll = 0;
                Invalidate();
            }
        }

        [Description("值")]
        public decimal[] ZValues
        {
            get { return m_values; }
            set
            {
                CanMoveScroll = 0;
                scroll = 0;
                m_values = value;
                if (value == null)
                {
                    allRadius = null;
                    sumValue = 0;
                }
                else
                {
                    allRadius = new double[value.Length];
                    sumValue = 0;
                    foreach (decimal item in m_values)
                    {
                        sumValue += item;
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

        public int PieHeight
        {
            get { return m_pieHeight; }
        }

        public int PieWidth
        {
            get { return m_pieWidth; }
        }

        public Point PieOrigin
        {
            get { return m_pieOrigin; }
        }
        #endregion

        #region 重写
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            m_pieWidth = (this.Width - 1) / 2;
            m_pieHeight = (this.Height - 31 - ZHeight3D) / 2;
            m_pieOrigin = new Point(m_pieWidth / 2 + 15, m_pieHeight);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width <= 0 || Height <= 0)
                return;
            //if (m_values == null || m_values.Length < 1)
            //{
            //    return;
            //}
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawChart(e.Graphics);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (allRadius == null)
            {
                return;
            }
            if (sumValue <= 0)
            {
                return;
            }
            if (getIsInner(e.Location))
            {
                Cursor = Cursors.Hand;
                double angle = GetAngle(PieOrigin, e.Location, new Point(PieWidth, PieOrigin.Y));
                for (int i = 0; i < allRadius.Length; i++)
                {
                    if (angle <= allRadius[i])
                    {
                        string tiptext = "";
                        string strbfb = "";
                        if (m_text == null)
                        {
                            strbfb = sumValue == 0 ? "0.00%" : (m_values[i] / sumValue).ToString("p");
                            tiptext = m_values[i].ToString() + " (" + strbfb + ")";
                        }
                        else if (i >= m_text.Length)
                        {
                            strbfb = sumValue == 0 ? "0.00%" : (m_values[i] / sumValue).ToString("p");
                            tiptext = m_values[i].ToString() + " (" + strbfb + ")";
                        }
                        else
                        {
                            strbfb = sumValue == 0 ? "0.00%" : (m_values[i] / sumValue).ToString("p");
                            tiptext = m_text[i] + " " + m_values[i].ToString() + " (" + strbfb + ")";
                        }
                        if (m_toolTip.GetToolTip(this) != tiptext)
                        {
                            m_toolTip.SetToolTip(this, tiptext);
                        }
                        return;
                    }
                }
            }
            else
            {
                bool tpshow = false;
                for (int i = 0; i < m_values.Length; i++)
                {
                    if ((i * 20 + 9 + scroll) > 0 && (i * 20 + 9 + scroll) < this.Height - 40)
                    {
                        //画明细
                        Rectangle rectmx = new Rectangle(Width / 2 + 37, (i + 1) * 20 + 3 + scroll, 11, 11);

                        string tiptext = "";
                        string strbfb = "";
                        if (m_text == null)
                        {
                            strbfb = sumValue == 0 ? "0.00%" : (m_values[i] / sumValue).ToString("p");
                            tiptext = m_values[i].ToString() + " (" + strbfb + ")";
                        }
                        else if (i >= m_text.Length)
                        {
                            strbfb = sumValue == 0 ? "0.00%" : (m_values[i] / sumValue).ToString("p");
                            tiptext = m_values[i].ToString() + " (" + strbfb + ")";
                        }
                        else
                        {
                            strbfb = sumValue == 0 ? "0.00%" : (m_values[i] / sumValue).ToString("p");
                            tiptext = m_text[i] + " " + m_values[i].ToString() + "(" + strbfb + ")";
                        }
                        Graphics g = Graphics.FromHwnd(this.Handle);
                        SizeF textsize = g.MeasureString(tiptext, Font);

                        Rectangle recttext = new Rectangle(rectmx.X + rectmx.Width + 5, (i + 1) * 20 + 3 + scroll, (int)textsize.Width, (int)textsize.Height);
                        if (recttext.Contains(e.Location))
                        {
                            m_toolTip.SetToolTip(this, tiptext);
                            tpshow = true;
                            break;
                        }
                    }
                }

                if (!tpshow)
                {
                    Cursor = Cursors.Default;
                    m_toolTip.RemoveAll();
                }
            }
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 画饼图
        /// </summary>
        /// <param name="g">画布</param>
        private void DrawChart(Graphics g)
        {
            CanMoveScroll = 0;
            Rectangle rec = new Rectangle(15, PieHeight / 2, PieWidth, PieHeight);//

            //起始角度
            float startAngle = 0f;
            //弧度
            float sweepAngle = 0f;


            PointF startP = new PointF(PieWidth, PieOrigin.Y);
            PointF endP = new PointF(0, PieOrigin.Y);
            if (m_values == null)
            {
                Color itc = Color.Gray;
                sweepAngle = 360;

                g.FillPie(new SolidBrush(itc), rec, startAngle, sweepAngle);
                g.DrawPie(new Pen(Color.FromArgb(224, 224, 224)), rec, startAngle, sweepAngle);

                //画底部
                if (startAngle < 180)
                {
                    float endang = startAngle + sweepAngle > 180 ? 180 : startAngle + sweepAngle;
                    GraphicsPath gpath = GetGraphicPath.CreatePathForCylinderSurfaceSection(rec, startAngle, endang, startP, endP, m_height3D);
                    g.FillPath(new SolidBrush(ColorClass.GetColor(itc, 0, -80, -80, -80)), gpath);
                }
                Rectangle rectmx = new Rectangle(Width / 2 + 40, 20 + 3, 11, 11);
                g.DrawString("无数据", Font, new SolidBrush(ForeColor), new PointF(rectmx.X + rectmx.Width + 5, 20 + 3));
                jmButtonTriangle2.Visible = false;
            }
            else
            {
                //画所有饼块
                for (int i = 0; i < m_values.Length; i++)
                {
                    decimal item = m_values[i];
                    Color itc = Color.Black;
                    Color ite = new Color();
                    if (m_pieColor.Length - 1 < i)
                    {
                        itc = ColorClass.GetColor(m_pieColor[i % (m_pieColor.Length - 1)], -20, 20, 6, 30);
                    }
                    else
                    {
                        itc = m_pieColor[i];
                    }
                    if (item <= 0)
                    {
                        if (sumValue == 0)
                        {
                            ite = Color.Gray;
                            g.FillPie(new SolidBrush(ite), rec, startAngle, 360);
                            g.DrawPie(new Pen(Color.FromArgb(224, 224, 224)), rec, startAngle, 360);
                            sweepAngle = 0;
                        }
                        else
                        {
                            sweepAngle = 0;
                        }
                    }
                    else
                    {
                        sweepAngle = (float)(360 / (sumValue / item));
                    }

                    g.FillPie(new SolidBrush(itc), rec, startAngle, sweepAngle);
                    g.DrawPie(new Pen(Color.FromArgb(224, 224, 224)), rec, startAngle, sweepAngle);

                    //画底部
                    if (startAngle < 180)
                    {
                        float endang = startAngle + sweepAngle > 180 ? 180 : startAngle + sweepAngle;
                        GraphicsPath gpath = GetGraphicPath.CreatePathForCylinderSurfaceSection(rec, startAngle, sumValue == 0 ? 180 : endang, startP, endP, m_height3D);
                        g.FillPath(new SolidBrush(ColorClass.GetColor(sumValue == 0 ? ite : itc, 0, -80, -80, -80)), gpath);
                    }

                    if ((i * 20 + 9 + scroll) > 0 && (i * 20 + 9 + scroll) < this.Height - 40)
                    {
                        //画明细
                        Rectangle rectmx = new Rectangle(Width / 2 + 34, (i + 1) * 20 + 3 + scroll, 11, 11);
                        g.FillRectangle(new SolidBrush(itc), rectmx);

                        string tiptext = "";
                        string strbfb = "";
                        if (m_text == null)
                        {
                            strbfb = sumValue == 0 ? "0.00%" : (m_values[i] / sumValue).ToString("p");
                            tiptext = m_values[i].ToString() + " (" + strbfb + ")";
                        }
                        else if (i >= m_text.Length)
                        {
                            strbfb = sumValue == 0 ? "0.00%" : (m_values[i] / sumValue).ToString("p");
                            tiptext = m_values[i].ToString() + " (" + strbfb + ")";
                        }
                        else
                        {
                            string st = m_text[i].Length > 4 ? m_text[i].Substring(0, 4).ToString() + "..." : m_text[i];
                            string money = m_values[i].ToString().Length > 6 ? m_values[i].ToString().Substring(0, 3) + "..." : m_values[i].ToString();
                            //百分比
                            strbfb = sumValue == 0 ? "0.00%" : (m_values[i] / sumValue).ToString("p");
                            tiptext = st + " " + money + "(" + strbfb + ")";
                        }
                        g.DrawString(tiptext, Font, new SolidBrush(ForeColor), new PointF(rectmx.X + rectmx.Width + 3, (i + 1) * 20 + 3 + scroll));
                    }
                    else
                    {
                        CanMoveScroll += 20;
                    }
                    startAngle += sweepAngle;
                    allRadius[i] = startAngle;
                    //if (CanMoveScroll > 0 && -scroll < CanMoveScroll)
                    //{
                    //    jmButtonTriangle2.Visible = true;
                    //}
                    //else
                    //{
                    //    jmButtonTriangle2.Visible = false;
                    //}
                }

                if ((m_values.Length > 16 && clickshu == 0) || (m_values.Length > 16 && clickshu < m_values.Length - 16))
                {
                    jmButtonTriangle2.Visible = true;
                }
                else
                {
                    jmButtonTriangle2.Visible = false;
                }

                //底部3D
                //GraphicsPath gpath = GetGraphicPath.CreatePathForCylinderSurfaceSection(rec, 120, 180, startP, endP, m_height3D);
                //g.FillPath(new SolidBrush(Color.FromArgb(100, 100, 100)), gpath);

                Rectangle recs = new Rectangle(15, PieHeight / 2 + PieHeight + ZHeight3D, Width / 2, 30);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center; ;
                g.DrawString(Text + sumValue.ToString(), this.Font, new SolidBrush(Color.Black), recs, sf);
                //g.FillRectangle(Brushes.Blue, recs);
            }
        }

        /// <summary>
        /// 检查是否在椭圆内
        /// </summary>
        /// <param name="MoveP">任意点</param>
        /// <returns></returns>
        private bool getIsInner(Point MoveP)
        {
            double dA = Math.Pow(MoveP.X - PieOrigin.X, 2) / Math.Pow(PieOrigin.X, 2);
            double dB = Math.Pow(MoveP.Y - PieOrigin.Y, 2) / Math.Pow(PieOrigin.Y, 2);
            //double dA = Math.Pow(MoveP.X + 15, 2) / Math.Pow(PieWidth, 2);
            //double dB = Math.Pow(MoveP.Y + PieHeight / 2, 2) / Math.Pow(PieHeight, 2);
            if (dA + dB <= 1)
            {
                if (MoveP.X >= PieOrigin.X - PieWidth / 2 && MoveP.X <= PieOrigin.X + PieWidth / 2)
                {
                    if (MoveP.Y >= PieOrigin.Y - PieHeight / 2 && MoveP.Y <= PieOrigin.Y + PieHeight / 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 获取顺时针角度
        /// </summary>
        /// <param name="cen">点A(圆心)</param>
        /// <param name="first">点B(鼠标坐标)</param>
        /// <param name="second">点C(0度坐标)</param>
        /// <returns>角度</returns>
        private double GetAngle(Point cen, Point first, Point second)
        {
            float dx1, dx2, dy1, dy2;
            float angle;
            dx1 = first.X - cen.X;
            dy1 = first.Y - cen.Y;
            dx2 = second.X - cen.X;
            dy2 = second.Y - cen.Y;
            float c = (float)Math.Sqrt(dx1 * dx1 + dy1 * dy1) * (float)Math.Sqrt(dx2 * dx2 + dy2 * dy2);
            if (c == 0)
                return -1;
            angle = (float)(Math.Acos((dx1 * dx2 + dy1 * dy2) / c) * 180 / Math.PI);
            return (first.Y - cen.Y < 0) ? 360 - angle : angle;
        }

        private PointF getEndPoint(double pAngle)
        {
            float rx = 0;
            float ry = 0;

            //计算圆心坐标
            float centerX = PieWidth / 2;
            float centerY = PieHeight / 2;

            //角度 d 必须用弧度表示。乘以 π/180 将角度转换成弧度。
            double Angle = Math.PI * pAngle / 180.0;

            if (pAngle < 90)
            {
                rx = (centerX + (float)(Math.Cos(Angle)) * PieHeight / 2);
                ry = (centerY + (float)(Math.Sin(Angle)) * PieWidth / 2);//
            }
            else if (pAngle == 90)
            {
                rx = centerX;
                ry = PieHeight;
            }
            else if (pAngle > 90 && pAngle < 180)
            {
                Angle = Math.PI * (180 - pAngle) / 180.0;
                rx = centerX - (float)(Math.Cos(Angle)) * PieHeight / 2;
                ry = centerY + (float)(Math.Sin(Angle)) * PieWidth / 2;
            }
            else if (pAngle == 180)
            {
                rx = 0;
                ry = centerY;
            }

            return new PointF(rx, ry);
        }

        //protected float TransformAngle(float angle)
        //{
        //double x = m_pieWidth * Math.Cos(angle * Math.PI / 180);
        //double y = m_pieHeight * Math.Sin(angle * Math.PI / 180);
        //float result = (float)(Math.Atan2(y, x) * 180 / Math.PI);
        //if (result < 0)
        //    return result + 360;
        //return result;
        //}

        /// <summary>
        ///   Calculates the point on ellipse periphery for angle.
        /// </summary>
        /// <param name="xCenter">
        ///   x-coordinate of the center of the ellipse.
        /// </param>
        /// <param name="yCenter">
        ///   y-coordinate of the center of the ellipse.
        /// </param>
        /// <param name="semiMajor">
        ///   Horizontal semi-axis.
        /// </param>
        /// <param name="semiMinor">
        ///   Vertical semi-axis.
        /// </param>
        /// <param name="angleDegrees">
        ///   Angle (in degrees) for which corresponding periphery point has to 
        ///   be obtained.
        /// </param>
        /// <returns>
        ///   <c>PointF</c> on the ellipse.
        /// </returns>
        protected PointF PeripheralPoint(float xCenter, float yCenter, float semiMajor, float semiMinor, float angleDegrees)
        {
            double angleRadians = angleDegrees * Math.PI / 180;
            return new PointF(xCenter + (float)(semiMajor * Math.Cos(angleRadians)), yCenter + (float)(semiMinor * Math.Sin(angleRadians)));
        }

        /// <summary>
        /// 获取扇形中间位置
        /// </summary>
        /// <param name="x">圆心x坐标</param>
        /// <param name="y">圆心y坐标</param>
        /// <param name="r">半径</param>
        /// <param name="c1">扇形弧度</param>
        /// <returns></returns>
        private Point GetMidelPoint(int x, int y, int r, float c1)
        {
            //(r+0)中的0如果改为10，则可以使得坐标离圆心距离大于r(根据需要自行设置)
            int x1 = (int)(x + Math.Sin((double)c1 / 2) * (r + 0));
            int y1 = (int)(y + Math.Cos((double)c1 / 2) * (r + 0));
            return new Point(x1, y1);
        }
        #endregion

    }
}
