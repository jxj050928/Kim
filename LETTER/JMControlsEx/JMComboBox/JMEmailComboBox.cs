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
    public partial class JMEmailComboBox : UserControl
    {
        bool bl = false;

        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color _JMFrameLineColor;

        [Description("边框颜色"), DefaultValue(typeof(Color), "201,201,201")]
        public Color JMFrameLineColor
        {
            get { return _JMFrameLineColor; }
            set { _JMFrameLineColor = value; Invalidate(); }
        }

        private Color _JMEnterLineColor;

        [Description("编辑状态时边框颜色"), DefaultValue(typeof(Color), "79, 193, 233")]
        public Color JMEnterLineColor
        {
            get { return _JMEnterLineColor; }
            set { _JMEnterLineColor = value; }
        }

        private Point _JMComboBoxLocation;

        [Description("显示值坐标")]
        public Point JMComboBoxLocation
        {
            get { return _JMComboBoxLocation; }
            set { _JMComboBoxLocation = value; jmComboBox1.Location = value; }
        }

        [Description("显示值")]
        public string JMComboBoxText
        {
            get
            {
                return jmComboBox1.Text;
            }
        }

        public JMEmailComboBox()
        {
            InitializeComponent();
            _JMFrameLineColor = Color.FromArgb(201, 201, 201);
            _JMEnterLineColor = Color.FromArgb(79, 193, 233);
            _JMComboBoxLocation = new Point(1, 5);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Color col = _JMFrameLineColor;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            GraphicsPath FW = GetGraphicPath.CreatePath(rect, 6, RoundStyle.None, true);

            if (bl)
            {
                col = _JMEnterLineColor;
            }

            g.DrawPath(new Pen(col), FW);
        }

        private void jmComboBox1_Enter(object sender, EventArgs e)
        {
            bl = true;
            Invalidate();
        }

        private void jmComboBox1_Leave(object sender, EventArgs e)
        {
            bl = false;
            Invalidate();
        }
    }
}