using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public partial class JMProgressBar : UserControl
    {
        #region 属性
        /// <summary>
        /// 百分比值
        /// </summary>
        private float _JMPercentage;

        [Description("百分比值")]
        public float JMPercentage
        {
            get { return _JMPercentage; }
            set { _JMPercentage = value; Invalidate(); }
        }

        /// <summary>
        /// 是否横向显示
        /// </summary>
        private bool _JMSFTransverse;

        [Description("是否横向显示")]
        public bool JMSFTransverse
        {
            get { return _JMSFTransverse; }
            set { _JMSFTransverse = value; Invalidate(); }
        }

        /// <summary>
        /// 顶部椭圆渐变颜色1
        /// </summary>
        private Color _JMTopColor1;

        [Description("顶部椭圆渐变颜色1")]
        public Color JMTopColor1
        {
            get { return _JMTopColor1; }
            set { _JMTopColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// 顶部椭圆渐变颜色2
        /// </summary>
        private Color _JMTopColor2;

        [Description("顶部椭圆渐变颜色2")]
        public Color JMTopColor2
        {
            get { return _JMTopColor2; }
            set { _JMTopColor2 = value; Invalidate(); }
        }

        /// <summary>
        /// 顶部椭圆渐变颜色3
        /// </summary>
        private Color _JMTopColor3;

        [Description("顶部椭圆渐变颜色3")]
        public Color JMTopColor3
        {
            get { return _JMTopColor3; }
            set { _JMTopColor3 = value; Invalidate(); }
        }

        /// <summary>
        /// 上下弧线边区域渐变颜色1
        /// </summary>
        private Color _JMTopDownColor1;

        [Description("上下弧线边区域渐变颜色1")]
        public Color JMTopDownColor1
        {
            get { return _JMTopDownColor1; }
            set { _JMTopDownColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// 上下弧线边区域渐变颜色2
        /// </summary>
        private Color _JMTopDownColor2;

        [Description("上下弧线边区域渐变颜色2")]
        public Color JMTopDownColor2
        {
            get { return _JMTopDownColor2; }
            set { _JMTopDownColor2 = value; Invalidate(); }
        }

        /// <summary>
        /// 上下弧线边区域渐变颜色3
        /// </summary>
        private Color _JMTopDownColor3;

        [Description("上下弧线边区域渐变颜色3")]
        public Color JMTopDownColor3
        {
            get { return _JMTopDownColor3; }
            set { _JMTopDownColor3 = value; Invalidate(); }
        }

        /// <summary>
        /// 上下弧线边区域渐变颜色4
        /// </summary>
        private Color _JMTopDownColor4;

        [Description("上下弧线边区域渐变颜色4")]
        public Color JMTopDownColor4
        {
            get { return _JMTopDownColor4; }
            set { _JMTopDownColor4 = value; Invalidate(); }
        }

        /// <summary>
        /// 上下弧线边区域渐变颜色5
        /// </summary>
        private Color _JMTopDownColor5;

        [Description("上下弧线边区域渐变颜色5")]
        public Color JMTopDownColor5
        {
            get { return _JMTopDownColor5; }
            set { _JMTopDownColor5 = value; Invalidate(); }
        }

        /// <summary>
        /// 中间液体渐变颜色1
        /// </summary>
        private Color _JMMiddleLiquid1;

        [Description("中间液体渐变颜色1")]
        public Color JMMiddleLiquid1
        {
            get { return _JMMiddleLiquid1; }
            set { _JMMiddleLiquid1 = value; Invalidate(); }
        }

        /// <summary>
        /// 中间液体渐变颜色2
        /// </summary>
        private Color _JMMiddleLiquid2;

        [Description("中间液体渐变颜色2")]
        public Color JMMiddleLiquid2
        {
            get { return _JMMiddleLiquid2; }
            set { _JMMiddleLiquid2 = value; Invalidate(); }
        }

        /// <summary>
        /// 中间液体渐变颜色3
        /// </summary>
        private Color _JMMiddleLiquid3;

        [Description("中间液体渐变颜色3")]
        public Color JMMiddleLiquid3
        {
            get { return _JMMiddleLiquid3; }
            set { _JMMiddleLiquid3 = value; Invalidate(); }
        }

        /// <summary>
        /// 中间液体顶部渐变颜色1
        /// </summary>
        private Color _JMLiquidTop1;

        [Description("中间液体顶部渐变颜色1")]
        public Color JMLiquidTop1
        {
            get { return _JMLiquidTop1; }
            set { _JMLiquidTop1 = value; Invalidate(); }
        }

        /// <summary>
        /// 中间液体顶部渐变颜色2
        /// </summary>
        private Color _JMLiquidTop2;

        [Description("中间液体顶部渐变颜色2")]
        public Color JMLiquidTop2
        {
            get { return _JMLiquidTop2; }
            set { _JMLiquidTop2 = value; Invalidate(); }
        }

        /// <summary>
        /// 中间液体顶部渐变颜色3
        /// </summary>
        private Color _JMLiquidTop3;

        [Description("中间液体顶部渐变颜色3")]
        public Color JMLiquidTop3
        {
            get { return _JMLiquidTop3; }
            set { _JMLiquidTop3 = value; Invalidate(); }
        }

        /// <summary>
        /// 中间液体底部渐变颜色1
        /// </summary>
        private Color _JMLiquidDown1;

        [Description("中间液体底部渐变颜色1")]
        public Color JMLiquidDown1
        {
            get { return _JMLiquidDown1; }
            set { _JMLiquidDown1 = value; Invalidate(); }
        }

        /// <summary>
        /// 中间液体底部渐变颜色2
        /// </summary>
        private Color _JMLiquidDown2;

        [Description("中间液体底部渐变颜色2")]
        public Color JMLiquidDown2
        {
            get { return _JMLiquidDown2; }
            set { _JMLiquidDown2 = value; Invalidate(); }
        }

        /// <summary>
        /// 中间液体底部渐变颜色3
        /// </summary>
        private Color _JMLiquidDown3;

        [Description("中间液体底部渐变颜色3")]
        public Color JMLiquidDown3
        {
            get { return _JMLiquidDown3; }
            set { _JMLiquidDown3 = value; Invalidate(); }
        }

        /// <summary>
        /// 平面液体显示颜色
        /// </summary>
        private Color _JMFlatColor;

        [Description("平面液体显示颜色")]
        public Color JMFlatColor
        {
            get { return _JMFlatColor; }
            set { _JMFlatColor = value; Invalidate(); }
        }

        /// <summary>
        /// 平面底色
        /// </summary>
        private Color _JMFlatMRColor;

        [Description("平面底色")]
        public Color JMFlatMRColor
        {
            get { return _JMFlatMRColor; }
            set { _JMFlatMRColor = value; Invalidate(); }
        }

        /// <summary>
        /// 显示样式
        /// </summary>
        private JMDisplayStyle _JMDisplayStyle;

        [Description("显示样式")]
        public JMDisplayStyle JMDisplayStyle
        {
            get { return _JMDisplayStyle; }
            set { _JMDisplayStyle = value; Invalidate(); }
        }

        /// <summary>
        /// 液体背景颜色
        /// </summary>
        private Color _JMCubeBackColor;

        [Description("液体背景颜色")]
        public Color JMCubeBackColor
        {
            get { return _JMCubeBackColor; }
            set { _JMCubeBackColor = value; Invalidate(); }
        }

        /// <summary>
        /// 立方体顶部渐变颜色1
        /// </summary>
        private Color _JMCubeColor1;

        [Description("立方体顶部渐变颜色1")]
        public Color JMCubeColor1
        {
            get { return _JMCubeColor1; }
            set { _JMCubeColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// 立方体顶部渐变颜色2
        /// </summary>
        private Color _JMCubeColor2;

        [Description("立方体顶部渐变颜色2")]
        public Color JMCubeColor2
        {
            get { return _JMCubeColor2; }
            set { _JMCubeColor2 = value; Invalidate(); }
        }

        /// <summary>
        /// 立方体线条颜色
        /// </summary>
        private Color _JMCubeLineColor;

        [Description("立方体线条颜色")]
        public Color JMCubeLineColor
        {
            get { return _JMCubeLineColor; }
            set { _JMCubeLineColor = value; Invalidate(); }
        }

        /// <summary>
        /// 立方体液体颜色
        /// </summary>
        private Color _JMCubeLiquidColor;

        [Description("立方体液体颜色")]
        public Color JMCubeLiquidColor
        {
            get { return _JMCubeLiquidColor; }
            set { _JMCubeLiquidColor = value; Invalidate(); }
        }
        #endregion

        /// <summary>
        /// 显示值
        /// </summary>
        private string _JMJDText;

        [Description("平面横向显示值")]
        public string JMJDText
        {
            get { return _JMJDText; }
            set { _JMJDText = value; Invalidate(); }
        }

        /// <summary>
        /// 标题值
        /// </summary>
        private string _JMJDBiaoTi;

        [Description("平面横向标题值")]
        public string JMJDBiaoTi
        {
            get { return _JMJDBiaoTi; }
            set { _JMJDBiaoTi = value; Invalidate(); }
        }

        private Color _JMJDForeColor;

        [Description("平面横向进度字体颜色")]
        public Color JMJDForeColor
        {
            get { return _JMJDForeColor; }
            set { _JMJDForeColor = value; Invalidate(); }
        }

        /// <summary>
        /// 液体高度
        /// </summary>
        private int CubeLiquidHeight = 0;

        public JMProgressBar()
        {
            InitializeComponent();
            _JMPercentage = 0;
            _JMSFTransverse = true;
            _JMTopColor1 = Color.FromArgb(193, 193, 193);
            _JMTopColor2 = Color.FromArgb(193, 193, 193);
            _JMTopColor3 = Color.FromArgb(193, 193, 193);
            _JMTopDownColor1 = Color.FromArgb(219, 219, 219);
            _JMTopDownColor2 = Color.FromArgb(129, 129, 129);
            _JMTopDownColor3 = Color.FromArgb(91, 91, 91);
            _JMTopDownColor4 = Color.FromArgb(32, 32, 32);
            _JMTopDownColor5 = Color.FromArgb(126, 126, 126);
            _JMMiddleLiquid1 = Color.FromArgb(46, 185, 6);
            _JMMiddleLiquid2 = Color.FromArgb(107, 241, 33);
            _JMMiddleLiquid3 = Color.FromArgb(116, 211, 83);
            _JMLiquidTop1 = Color.FromArgb(149, 233, 119);
            _JMLiquidTop2 = Color.FromArgb(216, 253, 160);
            _JMLiquidTop3 = Color.FromArgb(199, 251, 169);
            _JMLiquidDown1 = Color.FromArgb(46, 185, 6);
            _JMLiquidDown2 = Color.FromArgb(107, 241, 33);
            _JMLiquidDown3 = Color.FromArgb(116, 211, 83);
            _JMFlatColor = Color.Gainsboro;
            _JMFlatMRColor = Color.Gainsboro;
            _JMJDForeColor = Color.White;
            _JMJDBiaoTi = "";
            _JMJDText = "";
            _JMCubeBackColor = Color.FromArgb(184, 224, 254);
            _JMCubeColor1 = Color.FromArgb(164, 204, 234);
            _JMCubeColor2 = Color.FromArgb(184, 224, 254);
            _JMCubeLineColor = Color.Aqua;
            _JMCubeLiquidColor = Color.FromArgb(200, 255, 0, 0);
        }

        /// <summary>
        /// 颜色渐变效果
        /// </summary>
        /// <param name="rec">坐标和大小</param>
        /// <param name="_JBColorOne">起始渐变颜色</param>
        /// <param name="_JBColorTwo">中间渐变颜色</param>
        /// <param name="_JBColorThree">结束渐变颜色</param>
        /// <param name="lgm">渐变方向</param>
        /// <returns></returns>
        private LinearGradientBrush ColorGradient(Rectangle rec, Color _JBColorOne, Color _JBColorTwo, Color _JBColorThree, LinearGradientMode lgm)
        {
            LinearGradientBrush lb = new LinearGradientBrush(rec, _JBColorOne, _JBColorTwo, lgm);

            Color[] colors = new Color[3];
            colors[0] = _JBColorOne;
            colors[1] = _JBColorTwo;
            colors[2] = _JBColorThree;

            ColorBlend blend = new ColorBlend();
            blend.Positions = new float[] { 0.0f, 0.5f, 1.0f };
            blend.Colors = colors;
            lb.InterpolationColors = blend;
            return lb;
        }

        /// <summary>
        /// 颜色渐变效果
        /// </summary>
        /// <param name="rec">渐变坐标和大小</param>
        /// <param name="_JBColorOne">渐变颜色1</param>
        /// <param name="_JBColorTwo">渐变颜色2</param>
        /// <param name="_JBColorThree">渐变颜色3</param>
        /// <param name="_JBColorFour">渐变颜色4</param>
        /// <param name="_JBColorFive">渐变颜色5</param>
        /// <param name="lgm">渐变方向</param>
        /// <returns></returns>
        private LinearGradientBrush ColorGradient(Rectangle rec, Color _JBColorOne, Color _JBColorTwo, Color _JBColorThree, Color _JBColorFour, Color _JBColorFive, LinearGradientMode lgm)
        {
            LinearGradientBrush lb = new LinearGradientBrush(rec, _JBColorOne, _JBColorTwo, lgm);

            Color[] colors = new Color[5];
            colors[0] = _JBColorOne;
            colors[1] = _JBColorTwo;
            colors[2] = _JBColorThree;
            colors[3] = _JBColorFour;
            colors[4] = _JBColorFive;

            ColorBlend blend = new ColorBlend();
            blend.Positions = new float[] { 0.0f, 0.3f, 0.6f, 0.9f, 1.0f };
            blend.Colors = colors;
            lb.InterpolationColors = blend;
            return lb;
        }

        /// <summary>
        /// 创建控件与颜色
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            #region 平面显示
            if (_JMDisplayStyle.ToString() == "None")
            {
                //矩形默认颜色
                Rectangle Rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));

                //矩形液体颜色
                Rectangle YTRect;

                //百分值
                float Percentage = (!_JMSFTransverse ? this.Height : this.Width) / Convert.ToSingle(100);

                //液体高度
                int LiquidHeight = Convert.ToInt32(Percentage * _JMPercentage);

                //竖向显示
                if (!_JMSFTransverse)
                {
                    YTRect = new Rectangle(new Point(0, this.Height - LiquidHeight), new Size(this.Width - 1, LiquidHeight - 1));
                }
                else//横向显示
                {
                    YTRect = new Rectangle(new Point(0, 0), new Size(LiquidHeight - 1, this.Height - 1));
                }
                //画底
                g.DrawRectangle(new Pen(new SolidBrush(_JMFlatMRColor)), Rect);
                g.FillRectangle(new SolidBrush(_JMFlatMRColor), Rect);
                //画液体
                if (LiquidHeight > 0)
                {
                    g.DrawRectangle(new Pen(new SolidBrush(_JMFlatColor)), YTRect);
                    g.FillRectangle(new SolidBrush(_JMFlatColor), YTRect);
                }
                
                if (_JMSFTransverse)
                {
                    Rectangle textRect = new Rectangle(2, 0, Width - 1, Height);
                    Rectangle valueRect = new Rectangle(2, 0, YTRect.Width-2, Height);
                    StringFormat sformat = new StringFormat();
                    sformat.LineAlignment = StringAlignment.Center;

                    //画标题
                    //计算标题+内容长度是否大于液体长度
                    SizeF sf = g.MeasureString(_JMJDBiaoTi + "  " + _JMJDText, this.Font);
                    if (sf.Width + 4 > YTRect.Width)//大于
                    {
                        //正常画标题和内容
                        g.DrawString(_JMJDBiaoTi + "  " + _JMJDText, this.Font, new SolidBrush(_JMJDForeColor), textRect, sformat);
                    }
                    else//小于
                    {
                        //画标题
                        g.DrawString(_JMJDBiaoTi, this.Font, new SolidBrush(_JMJDForeColor), textRect, sformat);

                        //对齐方式
                        sformat.Alignment = StringAlignment.Far;
                        //画内容
                        g.DrawString(_JMJDText, this.Font, new SolidBrush(_JMJDForeColor), valueRect, sformat);
                    }
                }
            }
            #endregion

            #region 圆柱体
            else if (_JMDisplayStyle.ToString() == "Cylinder")
            {
                #region 竖向显示
                if (!_JMSFTransverse)
                {
                    //中间透明区域中间渐变颜色
                    Color a = Color.FromArgb(100, 255, 255, 255);
                    //中间透明区域起始和结束渐变颜色
                    Color b = Color.FromArgb(20, 160, 160, 160);

                    //中间透明区域上边
                    Rectangle RecUp3 = new Rectangle(new Point(1, 11), new Size(this.Width - 3, 15));

                    //中间透明区域下边
                    Rectangle RecDown3 = new Rectangle(new Point(1, this.Height - 21), new Size(this.Width - 3, 15));

                    //最上面椭圆矩形区域上边
                    Rectangle RecUp1 = new Rectangle(new Point(1, 2), new Size(this.Width - 3, 15));

                    //最上面椭圆矩形区域下边
                    Rectangle RecUp2 = new Rectangle(new Point(1, 5), new Size(this.Width - 3, 15));

                    //最下面椭圆矩形区域下边
                    Rectangle RecDown1 = new Rectangle(new Point(1, this.Height - 17), new Size(this.Width - 3, 15));

                    //最下面椭圆矩形区域上边
                    Rectangle RecDown2 = new Rectangle(new Point(1, this.Height - 21), new Size(this.Width - 3, 15));

                    //直线矩形内渐变颜色
                    LinearGradientBrush lb = ColorGradient(new Rectangle(1, 13, this.Width - 3, this.Height - 13), b, a, b, LinearGradientMode.Horizontal);

                    //最上面椭圆渐变颜色
                    LinearGradientBrush lb1 = ColorGradient(new Rectangle(1, 2, this.Width - 3, 15), _JMTopDownColor1, _JMTopDownColor2, _JMTopDownColor3, _JMTopDownColor4, _JMTopDownColor5, LinearGradientMode.Horizontal);

                    //最下面椭圆渐变颜色
                    LinearGradientBrush lb2 = ColorGradient(new Rectangle(1, this.Height - 27, this.Width - 3, 15), _JMTopDownColor1, _JMTopDownColor2, _JMTopDownColor3, _JMTopDownColor4, _JMTopDownColor5, LinearGradientMode.Horizontal);

                    //中间液体椭圆区域渐变颜色
                    LinearGradientBrush lb5 = ColorGradient(new Rectangle(1, 30, this.Width - 3, 15), _JMMiddleLiquid1, _JMMiddleLiquid2, _JMMiddleLiquid3, LinearGradientMode.Horizontal);

                    //中间液体顶部椭圆渐变颜色
                    LinearGradientBrush lb6 = ColorGradient(new Rectangle(1, 45, this.Width - 3, 15), _JMLiquidTop1, _JMLiquidTop2, _JMLiquidTop3, LinearGradientMode.Horizontal);

                    //最上面椭圆(即椭圆的盖)
                    LinearGradientBrush lb7 = ColorGradient(new Rectangle(1, 2, this.Width - 3, 15), _JMTopColor1, _JMTopColor2, _JMTopColor3, LinearGradientMode.Horizontal);

                    //液体底部椭圆渐变
                    LinearGradientBrush lb8 = ColorGradient(new Rectangle(1, this.Height - 21, this.Width - 3, 15), _JMLiquidDown1, _JMLiquidDown2, _JMLiquidDown3, LinearGradientMode.Horizontal);

                    //中间透明区域
                    GraphicsPath rr = new GraphicsPath();
                    rr.AddArc(RecUp3, 0, -180);
                    rr.AddArc(RecDown3, 180, -180);
                    rr.CloseFigure();
                    g.FillPath(lb, rr);

                    if (_JMPercentage > 0)
                    {
                        //百分值
                        float Percentage = (this.Height - 5 - 21) / Convert.ToSingle(100);

                        //液体高度
                        int LiquidHeight = Convert.ToInt32(Percentage * _JMPercentage);

                        //中间液体下边Y坐标
                        int LiquidYZhou = this.Height - 21;

                        //中间液体椭圆矩形区域上边
                        Rectangle recEllipse3 = new Rectangle(new Point(1, LiquidYZhou - LiquidHeight - 1), new Size(this.Width - 3, 15));

                        //中间液体椭圆矩形区域下边
                        Rectangle recEllipse4 = new Rectangle(new Point(1, LiquidYZhou), new Size(this.Width - 3, 15));

                        //中间液体的区域与填充
                        GraphicsPath gp = new GraphicsPath();
                        gp.AddArc(recEllipse3, 0, 180);
                        gp.AddArc(recEllipse4, 180, -180);
                        gp.CloseFigure();
                        g.FillPath(lb5, gp);

                        //中间液体椭圆顶部--椭圆线的颜色、起始坐标、宽度高度
                        g.DrawEllipse(new Pen(Color.FromArgb(40, 0, 0, 0), 1), recEllipse3);

                        //中间液体椭圆顶部--渐变起始坐标、渐变结束坐标、起始颜色、结束颜色，--要填充的椭圆起始坐标、椭圆宽度高度
                        g.FillEllipse(lb6, recEllipse3);

                        if (LiquidYZhou - LiquidHeight + 12 <= this.Height - 21 - 12 + 7)
                        {
                            //液体底部椭圆
                            g.DrawEllipse(new Pen(Color.FromArgb(200, 200, 200), 1), RecDown2);

                            //液体底部椭圆渐变填充
                            g.FillEllipse(lb8, RecDown2);
                        }
                    }
                    else
                    {
                        //液体底部椭圆
                        g.DrawEllipse(new Pen(Color.FromArgb(200, 200, 200), 1), RecDown2);
                    }

                    //最上面椭圆渐变(即椭圆的盖)
                    g.FillEllipse(lb7, RecUp1);

                    //最上面椭圆区域
                    GraphicsPath qq = new GraphicsPath();
                    qq.AddArc(RecUp1, 0, 180);
                    qq.AddArc(RecUp2, 180, -180);
                    qq.CloseFigure();
                    g.FillPath(lb1, qq);

                    //最下面椭圆区域
                    GraphicsPath yy = new GraphicsPath();
                    yy.AddArc(RecDown1, 0, 180);
                    yy.AddArc(RecDown2, 180, -180);
                    yy.CloseFigure();
                    g.FillPath(lb2, yy);

                    //描边
                    GraphicsPath gp1 = new GraphicsPath();
                    gp1.AddArc(RecUp1, 0, -180);
                    gp1.AddArc(RecDown1, 180, -180);
                    gp1.CloseFigure();
                    g.DrawPath(new Pen(Color.FromArgb(70, 255, 255, 255)), gp1);
                }
                #endregion
                #region 横向显示
                else
                {
                    //中间透明区域中间渐变颜色
                    Color a = Color.FromArgb(100, 255, 255, 255);

                    //中间透明区域起始和结束渐变颜色
                    Color b = Color.FromArgb(20, 160, 160, 160);

                    //中间透明区域左边
                    Rectangle RecUp3 = new Rectangle(new Point(4, 2), new Size(15, this.Height - 3));

                    //中间透明区域右边
                    Rectangle RecDown3 = new Rectangle(new Point(this.Width - 22, 2), new Size(15, this.Height - 3));

                    //最右面椭圆矩形区域右边
                    Rectangle RecUp1 = new Rectangle(new Point(this.Width - 19, 2), new Size(15, this.Height - 3));

                    //最右面椭圆矩形区域左边
                    Rectangle RecUp2 = new Rectangle(new Point(this.Width - 22, 2), new Size(15, this.Height - 3));

                    //最左面椭圆矩形区域左边
                    Rectangle RecDown1 = new Rectangle(new Point(1, 2), new Size(15, this.Height - 3));

                    //最左面椭圆矩形区域右边
                    Rectangle RecDown2 = new Rectangle(new Point(4, 2), new Size(15, this.Height - 3));

                    //中间透明区域渐变颜色
                    LinearGradientBrush lb = ColorGradient(new Rectangle(4, 2, this.Width - 22, this.Height - 3), b, a, b, LinearGradientMode.Vertical);

                    //最右面椭圆渐变颜色
                    LinearGradientBrush lb1 = ColorGradient(new Rectangle(this.Width - 19, 2, 15, this.Height - 3), _JMTopDownColor1, _JMTopDownColor2, _JMTopDownColor3, _JMTopDownColor4, _JMTopDownColor5, LinearGradientMode.Vertical);

                    //最左面椭圆渐变颜色
                    LinearGradientBrush lb2 = ColorGradient(new Rectangle(4, 2, 15, this.Height - 3), _JMTopDownColor1, _JMTopDownColor2, _JMTopDownColor3, _JMTopDownColor4, _JMTopDownColor5, LinearGradientMode.Vertical);

                    //中间液体椭圆区域渐变颜色
                    LinearGradientBrush lb5 = ColorGradient(new Rectangle(4, 2, 15, this.Height - 3), _JMMiddleLiquid1, _JMMiddleLiquid2, _JMMiddleLiquid3, LinearGradientMode.Vertical);

                    //最右面椭圆(即椭圆的盖)
                    LinearGradientBrush lb7 = ColorGradient(new Rectangle(this.Width - 19, 2, 15, this.Height - 3), _JMTopColor1, _JMTopColor2, _JMTopColor3, LinearGradientMode.Vertical);

                    //液体底部椭圆渐变
                    LinearGradientBrush lb8 = ColorGradient(new Rectangle(4, 2, 15, this.Height - 3), _JMLiquidDown1, _JMLiquidDown2, _JMLiquidDown3, LinearGradientMode.Vertical);

                    //中间透明区域
                    GraphicsPath rr = new GraphicsPath();
                    rr.AddArc(RecUp3, 270, 180);
                    rr.AddArc(RecDown3, 90, 180);
                    rr.CloseFigure();
                    g.FillPath(lb, rr);

                    if (_JMPercentage > 0)
                    {
                        //百分值
                        float Percentage = (this.Width - 4 - 22) / Convert.ToSingle(100);

                        //液体高度
                        int LiquidHeight = Convert.ToInt32(Percentage * _JMPercentage);

                        //中间液体左边X坐标
                        int LiquidXZhou = 4;

                        //中间液体椭圆矩形区域左边
                        Rectangle recEllipse3 = new Rectangle(new Point(4, 2), new Size(15, this.Height - 3));

                        //中间液体椭圆矩形区域右边
                        Rectangle recEllipse4 = new Rectangle(new Point(LiquidXZhou + LiquidHeight, 2), new Size(15, this.Height - 3));

                        //中间液体顶部椭圆渐变颜色
                        LinearGradientBrush lb6 = ColorGradient(new Rectangle(LiquidXZhou - LiquidHeight, 2, 15, this.Height - 3), _JMLiquidTop1, _JMLiquidTop2, _JMLiquidTop3, LinearGradientMode.Vertical);

                        //中间液体的区域与填充
                        GraphicsPath gp = new GraphicsPath();
                        gp.AddArc(recEllipse3, 90, 180);
                        gp.AddArc(recEllipse4, -90, -180);
                        gp.CloseFigure();
                        g.FillPath(lb5, gp);

                        //中间液体椭圆顶部--椭圆线的颜色、起始坐标、宽度高度
                        g.DrawEllipse(new Pen(Color.FromArgb(40, 0, 0, 0), 1), recEllipse4);

                        //中间液体椭圆顶部--渐变起始坐标、渐变结束坐标、起始颜色、结束颜色，--要填充的椭圆起始坐标、椭圆宽度高度
                        g.FillEllipse(lb6, recEllipse4);

                        if (4 + 15 <= LiquidXZhou + LiquidHeight)
                        {
                            //液体底部椭圆
                            g.DrawEllipse(new Pen(Color.FromArgb(200, 200, 200), 1), RecDown2);

                            //液体底部椭圆渐变填充
                            g.FillEllipse(lb8, RecDown2);
                        }
                    }
                    else
                    {
                        //液体底部椭圆
                        g.DrawEllipse(new Pen(Color.FromArgb(200, 200, 200), 1), RecDown2);
                    }

                    //最右面椭圆渐变(即椭圆的盖)
                    g.FillEllipse(lb7, RecUp1);

                    //最右面椭圆区域
                    GraphicsPath qq = new GraphicsPath();
                    qq.AddArc(RecUp1, 90, 180);
                    qq.AddArc(RecUp2, -90, -180);
                    qq.CloseFigure();
                    g.FillPath(lb1, qq);

                    //最左面椭圆区域
                    GraphicsPath yy = new GraphicsPath();
                    yy.AddArc(RecDown1, -270, 180);
                    yy.AddArc(RecDown2, -90, -180);
                    yy.CloseFigure();
                    g.FillPath(lb2, yy);

                    //描边
                    GraphicsPath gp1 = new GraphicsPath();
                    gp1.AddArc(RecUp1, 90, -180);
                    gp1.AddArc(RecDown1, -90, -180);
                    gp1.CloseFigure();
                    g.DrawPath(new Pen(Color.FromArgb(70, 255, 255, 255)), gp1);
                }
                #endregion
            }
            #endregion

            #region 立方体
            else if (_JMDisplayStyle.ToString() == "Cube")
            {
                //顶部多边形坐标、颜色填充宽/高度
                Rectangle rect = new Rectangle(18, 1, this.Width - 1, 17);

                //左侧多边形坐标、颜色填充宽/高度
                Rectangle rect1 = new Rectangle(18, 1, 17, this.Height - 1);

                //右侧多边形坐标、颜色填充宽/高度
                Rectangle rect2 = new Rectangle(this.Width - 1, 1, 17, this.Height - 1);

                //底部多边形坐标、颜色填充宽/高度
                Rectangle rect3 = new Rectangle(18, this.Height - 17, this.Width - 1, 17);

                //后面矩形坐标、颜色填充宽/高度
                Rectangle rect4 = new Rectangle(18, 17, this.Width - 18 * 2, this.Height - 18);

                //顶部多边形填充颜色、填充样式
                LinearGradientBrush lb = new LinearGradientBrush(rect, _JMCubeColor1, _JMCubeColor2, LinearGradientMode.Vertical);

                //左侧多边形填充颜色、填充样式
                LinearGradientBrush lb1 = new LinearGradientBrush(rect1, _JMCubeBackColor, _JMCubeBackColor, LinearGradientMode.Vertical);

                //右侧多边形填充颜色、填充样式
                LinearGradientBrush lb2 = new LinearGradientBrush(rect2, _JMCubeBackColor, _JMCubeBackColor, LinearGradientMode.Vertical);

                //底部多边形填充颜色、填充样式
                LinearGradientBrush lb3 = new LinearGradientBrush(rect3, _JMCubeBackColor, _JMCubeBackColor, LinearGradientMode.Vertical);

                //后面矩形填充颜色、填充样式
                LinearGradientBrush lb4 = new LinearGradientBrush(rect4, _JMCubeBackColor, _JMCubeBackColor, LinearGradientMode.Vertical);

                //后面矩形填充颜色
                g.FillRectangle(lb4, rect4);

                //左侧多边形填充颜色
                g.FillPolygon(lb1, new Point[] { new Point(18, 1), new Point(1, 17), new Point(1, this.Height - 1), new Point(18, this.Height - 17) });
                //底部多边形填充颜色
                g.FillPolygon(lb3, new Point[] { new Point(18, this.Height - 17), new Point(1, this.Height - 1), new Point(this.Width - 18, this.Height - 1), new Point(this.Width - 1, this.Height - 17) });
                //右侧多边形填充颜色
                g.FillPolygon(lb2, new Point[] { new Point(this.Width - 1, 1), new Point(this.Width - 18, 17), new Point(this.Width - 18, this.Height - 1), new Point(this.Width - 1, this.Height - 17) });

                //左
                g.DrawPolygon(new Pen(new SolidBrush(ColorClass.GetColor(Color.Aqua, -180, 0, 0, 255))), new Point[] { new Point(18, 1), new Point(1, 17), new Point(1, this.Height - 1), new Point(18, this.Height - 17) });
                //底
                g.DrawPolygon(new Pen(new SolidBrush(ColorClass.GetColor(Color.Aqua, -100, 0, 0, 255))), new Point[] { new Point(18, this.Height - 17), new Point(1, this.Height - 1), new Point(this.Width - 18, this.Height - 1), new Point(this.Width - 1, this.Height - 17) });

                if (_JMPercentage > 0)
                {
                    //百分值
                    float Percentage = (this.Height - 17 - 2) / Convert.ToSingle(100);

                    //液体高度
                    CubeLiquidHeight = Convert.ToInt32(Percentage * _JMPercentage);

                    //中间液体下边X坐标
                    int LiquidXZhou = this.Width - 1;

                    //前面液体矩形坐标、颜色填充宽/高度
                    Rectangle rect5 = new Rectangle(1, this.Height - (CubeLiquidHeight + 2), this.Width - (18 + 1), this.Height - (this.Height - CubeLiquidHeight - 1));

                    //前面矩形填充颜色
                    g.FillRectangle(new SolidBrush(_JMCubeLiquidColor), rect5);
                    //右侧液体多边形坐标、颜色填充
                    g.FillPolygon(new SolidBrush(_JMCubeLiquidColor), new Point[] { new Point(this.Width - 18, this.Height - (CubeLiquidHeight + 1)), new Point(this.Width - 1, this.Height - (CubeLiquidHeight + 1) - 17), new Point(this.Width - 1, this.Height - 17), new Point(this.Width - 18, this.Height - 1) });
                    //液体顶部多边形坐标、颜色填充
                    g.FillPolygon(new SolidBrush(_JMCubeLiquidColor), new Point[] { new Point(1, this.Height - (CubeLiquidHeight + 2)), new Point(18, this.Height - (CubeLiquidHeight + 1) - 17), new Point(this.Width - 1, this.Height - (CubeLiquidHeight + 1) - 17), new Point(this.Width - 18, this.Height - (CubeLiquidHeight + 2)) });
                }

                //顶部多边形填充颜色
                g.FillPolygon(lb, new Point[] { new Point(18, 1), new Point(1, 17), new Point(this.Width - 18, 17), new Point(this.Width - 1, 1) });
                //右
                g.DrawPolygon(new Pen(new SolidBrush(Color.Aqua)), new Point[] { new Point(this.Width - 1, 1), new Point(this.Width - 18, 17), new Point(this.Width - 18, this.Height - 1), new Point(this.Width - 1, this.Height - 17) });
                //顶
                g.DrawPolygon(new Pen(new SolidBrush(Color.Aqua)), new Point[] { new Point(18, 1), new Point(1, 17), new Point(this.Width - 18, 17), new Point(this.Width - 1, 1) });

                //描边
                g.DrawPolygon(new Pen(new SolidBrush(Color.Aqua)), new Point[] { new Point(18, 1), new Point(1, 17), new Point(1, this.Height - 1), new Point(this.Width - 18, this.Height - 1), new Point(this.Width - 1, this.Height - 17), new Point(this.Width - 1, 1) });
            }
            #endregion
        }
    }
}