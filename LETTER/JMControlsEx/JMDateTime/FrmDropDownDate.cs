using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class FrmDropDownDate : Form
    {
        public event DateRangeEventHandler DateSelected;

        public FrmDropDownDate()
        {
            InitializeComponent();
        }

        private void FrmDropDownDate_Deactivate(object sender, EventArgs e)
        {
            Hide();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (DateSelected!=null)
            {
                DateSelected(sender, e);
            }
            this.Hide();
        }

        private void FrmDropDownDate_Load(object sender, EventArgs e)
        {
            this.Size = monthCalendar1.Size;
        }

    }
}