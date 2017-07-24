using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace JMControlsEx
{
    [DefaultEvent("ZHeaderClick")]
    public class JMPanelHeadSplit : JMPanelHead
    {
        public delegate void ClikeEventHandle(object sender, WizardClickEventArgs e);
        public event ClikeEventHandle BeforExplan;
        public event EventHandler ZHeaderClick;
        private bool _isExplan;
        List<Rectangle> rects = new List<Rectangle>();
        private ControlState _cstate;
        private int _theight;

        public JMPanelHeadSplit()
            : base()
        {
            this.CaptionFont = new Font("Arial", SystemFonts.MenuFont.SizeInPoints, FontStyle.Bold);
            this.CaptionForeColor = Color.FromArgb(51, 161, 224);
            this.BorderColor = Color.Gray;
            _isExplan = true;
            _cstate = ControlState.Normal;
            this.Click += new EventHandler(JMPanelHeadSplit_Click);
            _theight = this.Height;
        }

        private void JMPanelHeadSplit_Click(object sender, EventArgs e)
        {
            if (_cstate == ControlState.Pressed)
            {
                if (BeforExplan != null)
                {
                    WizardClickEventArgs we = new WizardClickEventArgs();
                    BeforExplan(sender, we);
                    if (!_isExplan)
                    {
                        if (!we.Cancel)
                            ZIsExplan = !_isExplan;
                    }
                    else
                        ZIsExplan = !_isExplan;
                }
                else
                {
                    ZIsExplan = !_isExplan;
                }
            }
            else if (_cstate == ControlState.Hover)
            {
                if (ZHeaderClick != null)
                    ZHeaderClick(sender, e);
            }
        }

        public int ZTheight
        {
            get { return _theight; }
            set
            {
                _theight = value;
                if (_isExplan)
                    this.Height = _theight;
            }
        }

        protected ControlState ZCstate
        {
            get { return _cstate; }
            set
            {
                _cstate = value;
                this.Invalidate();
            }
        }

        [DefaultValue(true)]
        public bool ZIsExplan
        {
            get { return _isExplan; }
            set
            {
                _isExplan = value;
                if (value)
                {
                    this.Height = _theight;
                }
                else
                {
                    this.Height = this.CaptionHeight;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// 是否显示设置按钮
        /// </summary>
        private bool _ZImageVisible = false;

        [Description("是否显示设置按钮"), DefaultValue(typeof(bool), "False")]
        public bool ZImageVisible
        {
            get { return _ZImageVisible; }
            set { _ZImageVisible = value; Invalidate(); }
        }

        /// <summary>
        /// 是否显示下拉三角按钮
        /// </summary>
        private bool _ZDownVisible = true;

        [Description("是否显示下拉三角按钮"), DefaultValue(typeof(bool), "True")]
        public bool ZDownVisible
        {
            get { return _ZDownVisible; }
            set { _ZDownVisible = value; Invalidate(); }
        }

        private Image Zcl = global::JMControlsEx.Properties.Resources.shezhi;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            rects = new List<Rectangle>();
            //Rectangle rec = new Rectangle(Width - 40, (CaptionHeight - 15) / 2, 35, 15);
            //GraphicsPath fk = GetGraphicPath.CreatePath(rec, 4, RoundStyle.All, false);
            //e.Graphics.DrawPath(new Pen(Color.Gray), fk);

            if (_ZDownVisible)
            {
                Rectangle rec = new Rectangle(Width - 20, (CaptionHeight - 15) / 2, 17, 15);
                if (_cstate == ControlState.Pressed)
                {
                    GraphicsPath fk = GetGraphicPath.CreatePath(rec, 4, RoundStyle.All, false);
                    e.Graphics.DrawPath(new Pen(Color.Gray), fk);
                }
                ControlPaintClass.RenderArrowInternal(e.Graphics, rec, _isExplan ? ArrowDirection.Up : ArrowDirection.Down, new SolidBrush(Color.Black));
                rects.Add(rec);
            }

            if (_ZImageVisible)
            {
                Rectangle rec1 = new Rectangle(Width - 35, (CaptionHeight - 10) / 2, 10, 10);
                if (_cstate == ControlState.Hover)
                {
                    Rectangle rec11 = new Rectangle(Width - 40, (CaptionHeight - 15) / 2, 20, 15);
                    GraphicsPath fk = GetGraphicPath.CreatePath(rec11, 4, RoundStyle.All, false);
                    e.Graphics.DrawPath(new Pen(Color.Gray), fk);
                }
                e.Graphics.DrawImage(Zcl, rec1);
                rects.Add(rec1);
            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (rects.Count > 1)
            {
                if (rects[0].Contains(e.Location))
                {
                    ZCstate = ControlState.Pressed;
                }
                else if (rects[1].Contains(e.Location))
                {
                    ZCstate = ControlState.Hover;
                }
                else
                {
                    ZCstate = ControlState.Normal;
                }
            }
            else if (rects.Count > 0)
            {
                if (rects[0].Contains(e.Location))
                {
                    ZCstate = ControlState.Pressed;
                }
                else
                {
                    ZCstate = ControlState.Normal;
                }
            }
            else
            {
                ZCstate = ControlState.Normal;
            }
        }
    }
}
