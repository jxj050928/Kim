using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JContextMenuStrip : ContextMenuStrip
    {
        private Color _baseColor;

        public JContextMenuStrip()
            : base()
        {
            _baseColor = Color.FromArgb(218,218,218);
            this.Renderer = new JToolStripProfessionalRenderer(_baseColor);
        }

        [Category("Appearance"),
        Description("菜单颜色"),
        DefaultValue(typeof(Color), "218,218,218")]
        public Color ZBaseColor
        {
            get
            {
                return this._baseColor;
            }
            set
            {
                this._baseColor = value;
                this.Renderer = new JToolStripProfessionalRenderer(_baseColor);
            }
        }

    }
}
