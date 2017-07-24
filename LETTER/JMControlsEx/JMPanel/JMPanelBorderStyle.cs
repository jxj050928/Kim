using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JMPanelBorderStyle : Panel
    {
        #region 属性
        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color _JMBorderLineColor;

        [Description("边框颜色"), DefaultValue(typeof(Color), "Black")]
        public Color JMBorderLineColor
        {
            get { return _JMBorderLineColor; }
            set { _JMBorderLineColor = value; Invalidate(); }
        }

        private bool _JMBorderStyle;

        [Description("是否显示边框"), DefaultValue(typeof(bool), "false")]
        public bool JMBorderStyle
        {
            get { return _JMBorderStyle; }
            set { _JMBorderStyle = value; Invalidate(); }
        }

        /// <summary>
        /// 按钮圆角样式
        /// </summary>
        private RoundStyle _JMRoundStyle;

        [Category("Appearance"), Description("按钮圆角样式"), DefaultValue(typeof(RoundStyle), "None")]
        public RoundStyle JMRoundStyle
        {
            get { return _JMRoundStyle; }
            set
            {
                if (_JMRoundStyle != value)
                {
                    _JMRoundStyle = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 按钮圆角弧度
        /// </summary>
        private int _JMRadius;

        [Category("Appearance"), Description("按钮圆角弧度"), DefaultValue(8)]
        public int JMRadius
        {
            get { return _JMRadius; }
            set { _JMRadius = value; }
        }
        #endregion

        public JMPanelBorderStyle()
        {
            _JMBorderLineColor = Color.Black;
            this._JMRoundStyle = RoundStyle.None;
            _JMRadius = 8;
            _JMBorderStyle = false;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == Animate.WM_PAINT || m.Msg == 0x133)
            {
                IntPtr hDC = Win32.GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0)
                    return;
                if (_JMBorderStyle)
                {
                    Graphics g = Graphics.FromHdc(hDC);
                    switch (_JMRoundStyle)
                    {
                        case RoundStyle.None:
                            g.DrawRectangle(new Pen(_JMBorderLineColor, 1), 0, 0, this.Width - 1, this.Height - 1);
                            break;
                        case RoundStyle.All:
                            GraphicsPath gp = new GraphicsPath();
                            GraphicsPath gp1 = new GraphicsPath();

                            Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Size.Width - 1, this.Size.Height - 1));
                            Rectangle rec1 = new Rectangle(new Point(0, 0), new Size(this.Size.Width, this.Size.Height));

                            gp = GetGraphicPath.CreatePath(rec, _JMRadius, _JMRoundStyle, true);
                            gp1 = GetGraphicPath.CreatePath(rec1, _JMRadius, _JMRoundStyle, true);
                            this.Region = new Region(gp1);

                            g.DrawPath(new Pen(new SolidBrush(_JMBorderLineColor)), gp);
                            break;
                    }
                }
                m.Result = IntPtr.Zero;
                Win32.ReleaseDC(m.HWnd, hDC);
            }
        }
    }
}