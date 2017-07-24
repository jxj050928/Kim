using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JMControlsEx
{
    public class JMButtonTriangle:JMButton
    {
        public JMButtonTriangle()
            : base()
        {
            aDirection = ArrowDirection.Down;
        }

        private ArrowDirection aDirection;

        public ArrowDirection ZADirection
        {
            get { return aDirection; }
            set { aDirection = value; this.Invalidate(); }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaintClass.RenderArrowInternal(e.Graphics, e.ClipRectangle, ZADirection, new System.Drawing.SolidBrush(Color.Black));
            //ControlPaintClass.RenderArrowInternal(e.Graphics, e.ClipRectangle, ArrowDirection.Down, new System.Drawing.SolidBrush(Color.Black));
        }
    }
}
