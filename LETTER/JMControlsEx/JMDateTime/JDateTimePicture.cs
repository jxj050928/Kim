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
    public class JDateTimePicture : Panel
    {
        Rectangle recDrop;

        JMTextBox jmtb;
        FrmDropDownDate frm;

        private bool _mouse;

        private Color _borderColor;

        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        private string _formatString;

        public string FormatString
        {
            get { return _formatString; }
            set { _formatString = value; }
        }

        public string ZText
        {
            get { return jmtb.Text; }
            set { jmtb.Text = value; }
        }

        public JDateTimePicture()
        {
            this.Size = new Size(161, 23);
            this.MinimumSize = new Size(161, 23);

            //添加TextBox
            jmtb = new JMTextBox();
            jmtb.Name = "jmTextBox1";
            jmtb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            jmtb.BorderStyle = BorderStyle.None;
            jmtb.Location = new Point(8, 5);
            jmtb.Multiline = false;
            jmtb.ZEmptyTextTip = "";
            jmtb.Text = "";
            jmtb.Width = 133;
            jmtb.Enter += new EventHandler(jmtb_Enter);
            jmtb.Leave += new EventHandler(jmtb_Leave);
            jmtb.ReadOnly = true;
            this.Controls.Add(jmtb);

            frm = new FrmDropDownDate();
            frm.DateSelected += new DateRangeEventHandler(frm_DateSelected);
            _borderColor = Color.FromArgb(170, 170, 170);
            _formatString = "yyyy-MM-dd";
            _mouse = false;
        }

        private void jmtb_Leave(object sender, EventArgs e)
        {
            if (!frm.Visible)
            {
                if (_mouse)
                {
                    _mouse = false;
                    Invalidate();
                }
            }

        }

        private void jmtb_Enter(object sender, EventArgs e)
        {
            if (!_mouse)
            {
                _mouse = true;
                Invalidate();
            }
        }

        private void frm_DateSelected(object sender, DateRangeEventArgs e)
        {
            jmtb.Text = e.Start.ToString(_formatString);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rec = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = GetGraphicPath.CreatePath(rec, 23, RoundStyle.None, true);
            g.FillPath(new SolidBrush(Color.White), path);
            g.DrawPath(new Pen(_borderColor), path);
            rec.Offset(0, 1);

            g.DrawRectangle(new Pen(_borderColor), rec);

            //path = GetGraphicPath.CreatePathTOP(rec, 19, false, 45);
            //g.DrawPath(new Pen(ColorClass.GetColor(_borderColor, 0, -20, -20, -20)), path);

            recDrop = new Rectangle(Width - 28, 5, 20, 16);
            //if (_mouse)
            //{
                Rectangle recDrop1 = new Rectangle(Width - 26, 0, 28, 23);
                GraphicsPath pathDrop = GetGraphicPath.CreateVPath(recDrop1);
                g.DrawPath(new Pen(ColorClass.GetColor(_borderColor, 0, -20, -20, -20), 3), pathDrop);
            //}
        }

        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (frm.Visible)
            {
                frm.Hide();
            }
            else
            {
                if (recDrop.Contains(e.Location))
                {
                    Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                    frm.Show();
                    frm.BringToFront();
                    frm.Location = new Point(CBRect.X, CBRect.Y + this.Height);
                }
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (recDrop.Contains(e.Location))
            {
                if (!_mouse)
                {
                    _mouse = true;
                    Invalidate();
                }
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            Invalidate();
        }
    }
}