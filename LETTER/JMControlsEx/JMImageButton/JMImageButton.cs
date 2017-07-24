using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;

namespace JMControlsEx
{
    public class JMImageButton : Panel
    {
        /// <summary>
        /// 是否显示鼠标进入效果
        /// </summary>
        private bool SFVisibleEffect = false;

        #region 属性
        /// <summary>
        /// 显示图像
        /// </summary>
        private Image _JMImage;

        [Description("显示图像")]
        public Image JMImage
        {
            get { return _JMImage; }
            set { _JMImage = value; Invalidate(); }
        }

        /// <summary>
        /// 图片大小
        /// </summary>
        private Size _JMImageSize;

        [Description("图片大小")]
        public Size JMImageSize
        {
            get { return _JMImageSize; }
            set { _JMImageSize = value; Invalidate(); }
        }

        /// <summary>
        /// 显示文本
        /// </summary>
        private string _JMText;

        [Description("显示文本")]
        public string JMText
        {
            get { return _JMText; }
            set { _JMText = value; Invalidate(); }
        }

        /// <summary>
        /// 显示文本颜色
        /// </summary>
        private Color _JMTextColor;

        [Description("显示文本颜色")]
        public Color JMTextColor
        {
            get { return _JMTextColor; }
            set { _JMTextColor = value; Invalidate(); }
        }

        private TextImageRelation _TextImageRelation;
        [Description("文本图片位置")]
        public TextImageRelation TextImageRelation
        {
            get { return _TextImageRelation; }
            set { _TextImageRelation = value; Invalidate(); }
        }
        #endregion

        #region 构造函数
        public JMImageButton()
        {
            _JMImageSize = new Size(20, 20);
            _JMText = "";
            _JMTextColor = Color.Black;
            _TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BackColor = Color.Transparent;
            this.Size = new Size(70, 23);
            this.MinimumSize = new Size(70, 23);
            this.MouseEnter += new EventHandler(JMImageButton_MouseEnter);
            this.MouseLeave += new EventHandler(JMImageButton_MouseLeave);
        }
        #endregion

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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(Margin.Left, Margin.Top, Width - Margin.Left - Margin.Right, Height - Margin.Top - Margin.Bottom);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Color fcolor = _JMTextColor;
            Font ffont = this.Font;

            int imgX = 0;
            int imgY = 0;

            if (SFVisibleEffect)
            {
                fcolor = ColorClass.GetColor(fcolor, 0, 50, 50, 50);
                ffont = new Font(Font, FontStyle.Underline);
            }

            switch (_TextImageRelation)
            {
                case TextImageRelation.ImageAboveText:
                    imgX = (Width - JMImageSize.Width) / 2;
                    imgY = rect.Y;
                    break;
                case TextImageRelation.ImageBeforeText:
                    imgX = rect.X;
                    imgY = (Height - JMImageSize.Height) / 2;
                    sf.Alignment = StringAlignment.Near;
                    rect.X += (JMImageSize.Width);
                    rect.Width -= (JMImageSize.Width);
                    break;
                case TextImageRelation.Overlay:
                    imgX = (Width - JMImageSize.Width) / 2;
                    imgY = (Height - JMImageSize.Height) / 2;
                    break;
                case TextImageRelation.TextAboveImage:
                    imgX = (Width - JMImageSize.Width) / 2;
                    imgY = rect.Y + (rect.Height - JMImageSize.Height);
                    break;
                case TextImageRelation.TextBeforeImage:
                    imgX = rect.X+(rect.Width-JMImageSize.Width);
                    imgY = (Height - JMImageSize.Height) / 2;
                    sf.Alignment = StringAlignment.Far;
                    rect.Width -= (JMImageSize.Width);
                    break;
                default:
                    imgX = (Width - JMImageSize.Width) / 2;
                    imgY = (Height - JMImageSize.Height) / 2;
                    break;
            }

            if (_JMImage != null)
            {
                g.DrawImage(_JMImage, new Rectangle(new Point(imgX, imgY), JMImageSize));
            }

            g.DrawString(_JMText, ffont, new SolidBrush(fcolor), rect, sf);


        }

        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JMImageButton_MouseEnter(object sender, EventArgs e)
        {
            SFVisibleEffect = true;
            Invalidate();
        }

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="e"></param>
        private void JMImageButton_MouseLeave(object sender, EventArgs e)
        {
            SFVisibleEffect = false;
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            SFVisibleEffect = false;
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
    }
}