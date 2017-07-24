using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace JMControlsEx
{
    public class JMContextMenuStrip : ContextMenuStrip
    {
        private Color _baseColor;

        public JMContextMenuStrip()
            : base()
        {
            _baseColor = ColorClass.GetBColor();
            this.Renderer = new JNToolStripProfessionalRenderer();
        }

        [Category("Appearance"),
        Description("菜单颜色"),
        DefaultValue(typeof(Color), "51, 161, 224")]
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
