using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JNContextMenuStrip : ContextMenuStrip
    {
        private Color _baseColor;

        public JNContextMenuStrip()
            : base()
        {
            _baseColor = Color.FromArgb(204, 225, 210);
            this.Renderer = new JNToolStripProfessionalRenderer(_baseColor);
        }

        [Category("Appearance"),
        Description("菜单颜色"),
        DefaultValue(typeof(Color), "204, 225, 210")]
        public Color ZBaseColor
        {
            get
            {
                return this._baseColor;
            }
            set
            {
                this._baseColor = value;
                this.Renderer = new JNToolStripProfessionalRenderer(_baseColor);
            }
        }

    }
}
