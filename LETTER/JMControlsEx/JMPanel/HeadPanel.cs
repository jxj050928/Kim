using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class HeadPanel : Panel
    {
        private Image _headImage;

        public Image HeadImage
        {
            get { return _headImage; }
            set { _headImage = value; Invalidate(); }
        }

        private Point _headimageLocation;

        public Point HeadimageLocation
        {
            get { return _headimageLocation; }
            set { _headimageLocation = value; Invalidate(); }
        }

        private Size _headimageSize;

        public Size HeadimageSize
        {
            get { return _headimageSize; }
            set { _headimageSize = value; Invalidate(); }
        }

        private string _captionText;

        public string CaptionText
        {
            get { return _captionText; }
            set { _captionText = value; Invalidate(); }
        }

        private int _captionHeight;

        public int CaptionHeight
        {
            get { return _captionHeight; }
            set { _captionHeight = value; Invalidate(); }
        }

        private Color _borderColor;

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        private bool _doubleLine;

        public bool DoubleLine
        {
            get { return _doubleLine; }
            set { _doubleLine = value; }
        }

        public HeadPanel()
        {
            _captionHeight = 55;
            _headImage = null;
            _captionText = "";
            _borderColor = Color.FromArgb(200, 200, 200);
            _headimageLocation = Point.Empty;
            _doubleLine = true;
            _headimageSize = new Size(30, 25);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality; //高质量
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量

            int top = 0;
            if (_doubleLine)
            {
                top = 10;
                g.DrawLine(new Pen(_borderColor), new Point(0, top), new Point(Width, top));
                g.DrawLine(new Pen(_borderColor), new Point(0, _captionHeight), new Point(Width, _captionHeight));
            }

            

            if (HeadImage != null)
            {
                g.DrawImage(HeadImage, new Rectangle(_headimageLocation, _headimageSize));
            }

            if (!string.IsNullOrEmpty(_captionText))
            {
                int x = _headimageLocation.X + _headimageSize.Width + 5;
                Rectangle rect = new Rectangle(x, top, Width - x, _captionHeight);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Near;
                g.DrawString(_captionText, Font, new SolidBrush(ForeColor), rect, sf);
            }
        }
    }
}
