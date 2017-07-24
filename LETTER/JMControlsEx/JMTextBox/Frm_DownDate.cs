using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class Frm_DownDate : Form
    {
        public event DateRangeEventHandler DateSelected;
        private int x=0;
        private int y = 0;
        public Frm_DownDate(int _x,int _y,string date)
        {
            InitializeComponent();
            monthCalendar1.SelectionStart = Convert.ToDateTime(date);
            monthCalendar1.SelectionEnd = Convert.ToDateTime(date);
            x = _x;
            y = _y;
        }

        private void Frm_DownDate_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_DownDate_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x, y);
            this.Size = monthCalendar1.Size;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Close();
            if (DateSelected!=null)
            {
                DateSelected(sender, e);
            }
        }
    }
}
