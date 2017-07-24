using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public partial class JMMenuForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void AnimateWindow(IntPtr hwnd, int stime, int style);

        private ShowType _stype;

        public ShowType Stype
        {
            get { return _stype; }
            set { _stype = value; }
        }

        private Color _baseColor;
        private int _radius;
        private float _basePosition;

        [Category("Appearance"),
        Description("标题栏圆角"),
        DefaultValue(typeof(int), "8")]
        public int ZRadius
        {
            get { return _radius; }
            set { _radius = value; this.Invalidate(); }
        }

        [Category("Appearance"),
        Description("窗体颜色"),
        DefaultValue(typeof(Color), "51, 161, 224")]
        public Color ZBaseColor
        {
            get { return _baseColor; }
            set
            {
                _baseColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance"),
        Description("上半部渐变区域"),
        DefaultValue(typeof(float), "0.30")]
        public float ZBasePosition
        {
            get { return _basePosition; }
            set { _basePosition = value; this.Invalidate(); }
        }
        //private ImageList _himagelist;

        //public ImageList Himagelist
        //{
        //    get { return _himagelist; }
        //    set { _himagelist = value; }
        //}

        public JMMenuForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            _stype = ShowType.Left;
            _basePosition = 0.30F;
            _baseColor = Color.FromArgb(51, 161, 224);
            _radius = 10;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //SoundPlayer sp = new SoundPlayer(Application.StartupPath + "\\msg.wav");
            //this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height - 30);
            //第二个参数就是渐变的时间了
            int st = (int)_stype;
            AnimateWindow(this.Handle, 100, st | 0x40000);
        }

        #region 关闭
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            Close();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            //228, 241, 213
            Color bc = Color.FromArgb(250, 250, 250);
            Rectangle _rect = new Rectangle(1, 1, Width-1, Height-1);
            g.FillRectangle(new SolidBrush(bc), _rect);
            //Color acolor = ColorClass.GetColor(_baseColor, 0, 0, -8, -20);
            //ControlPaintClass.RenderBackgroundInternal(g, rect, acolor, acolor, acolor, RoundStyle.None, _radius, 0.01F, true, false, LinearGradientMode.);

            //Rectangle _bottom = new Rectangle(_rect.Left + 1, _rect.Bottom, _rect.Right, 1);
            //Rectangle _right = new Rectangle(_rect.Right - 1, _rect.Top + 1, 1, _rect.Bottom);

            //LinearGradientBrush bottomBrush = new LinearGradientBrush(_bottom, Color.Black, Color.FromArgb(60, 241, 242, 211), LinearGradientMode.Vertical);
            //LinearGradientBrush rightBrush = new LinearGradientBrush(_right, Color.Black, Color.FromArgb(60, 241, 242, 211), LinearGradientMode.Horizontal);

            //GraphicsPath _bottomPath = new GraphicsPath();
            //_bottomPath.AddLine(_rect.Left + 1, _rect.Bottom, _rect.Right, _rect.Bottom);
            //_bottomPath.AddLine(_rect.Right, _rect.Bottom, _rect.Right + 1, _rect.Bottom + 1);
            //_bottomPath.AddLine(_rect.Right + 1, _rect.Bottom + 1, _rect.Left + 1, _rect.Bottom + 1);
            //_bottomPath.AddLine(_rect.Left + 1, _rect.Bottom + 1, _rect.Left + 1, _rect.Bottom);
            //_bottomPath.CloseAllFigures();

            //GraphicsPath _rightPath = new GraphicsPath();
            //_rightPath.AddLine(_rect.Right, _rect.Top + 1, _rect.Right + 1, _rect.Top + 1);
            //_rightPath.AddLine(_rect.Right + 1, _rect.Top + 1, _rect.Right + 1, _rect.Bottom + 1);
            //_rightPath.AddLine(_rect.Right + 1, _rect.Bottom + 1, _rect.Right, _rect.Bottom);
            //_rightPath.AddLine(_rect.Right, _rect.Bottom, _rect.Right, _rect.Top + 1);
            //_rightPath.CloseAllFigures();

            //e.Graphics.FillPath(bottomBrush, _bottomPath);
            //e.Graphics.FillPath(rightBrush, _rightPath);

            //191,212,211
            _rect = new Rectangle(1, 1, 20, Height - 1);
            Color acolor = ColorClass.GetColor(bc, 0, -20, -20, -20);
            //ControlPaintClass.RenderBackgroundInternal(g, rect, acolor, acolor, Color.FromArgb(128, 210, 210, 210), RoundStyle.None, _radius, 0.01F, false, false, LinearGradientMode.Vertical);
            g.FillRectangle(new SolidBrush(acolor), _rect);

            g.DrawRectangle(new Pen(Color.Silver), new Rectangle(0, 0, Width - 1, Height - 1));
            //rect = new Rectangle(0, 0, Width, Height);
            //GraphicsPath path = ControlPaintClass.CreatePath(rect, _radius, RoundStyle.All, false);
            //this.Region = new Region(path);

        }

    }

    
}