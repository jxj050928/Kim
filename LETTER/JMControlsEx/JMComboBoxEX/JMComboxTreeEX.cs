using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JMComboxTreeEX : Panel
    {
        Frm_DownF frm;

        private DataTable _DataSrouce = null;
        public DataTable DataSrouce
        {
            get { return _DataSrouce; }
            set
            {
                _DataSrouce = value;
                frm = null;
            }
        }

        public ImageList ImageList
        {
            get;
            set;
        }

        public string SelectedValue
        {
            get
            {
                string selectvalue = "";
                if (DataSrouce != null)
                {
                    foreach (DataRow item in DataSrouce.Rows)
                    {
                        if (Convert.ToInt16(item["index"]) == 2 && item["ID"].ToString().Length > 3)
                        {
                            selectvalue += item["ID"].ToString() + ",";
                        }
                        else if (Convert.ToInt16(item["index"]) == 2 && item["ID"].ToString().Length <= 3)
                        {
                            if (DataSrouce.Select("len(ID)>3 and ID like '" + item["ID"] + "%'").Length < 1)
                            {
                                selectvalue += item["ID"].ToString() + ",";
                            }
                        }
                    }
                }
                return selectvalue.TrimEnd(',');
            }
        }

        private string _ztext;

        public string Ztext
        {
            get { return _ztext; }
            set { _ztext = value; Invalidate(); }
        }

        private int mousetype = 0;

        public JMComboxTreeEX()
        {
            this.Size = new Size(89, 24);
            _ztext = "";
            this.BackgroundImage = Properties.Resources.cbobtn;
            this.Tag = "";
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (mousetype == 0)
            {
                this.BackgroundImage = Properties.Resources.cbobtnO;
                mousetype = 1;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (mousetype == 1)
            {
                this.BackgroundImage = Properties.Resources.cbobtn;
                mousetype = 0;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawString(Ztext, this.Font, new SolidBrush(this.ForeColor), new Point(13, 5));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            mousetype = 2;
            if (!this.DesignMode)
            {
                Point mypoint = new Point(0, 0);

                this.BackgroundImage = Properties.Resources.cbobtnD;

                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                Screen cre = Screen.PrimaryScreen;
                if (CBRect.X + 125 > cre.WorkingArea.Width)
                {
                    mypoint = new Point(CBRect.X - 125 + this.Width, CBRect.Y + this.Height);
                }
                else
                {
                    mypoint = new Point(CBRect.X, CBRect.Y + this.Height);
                }
                if (frm == null || frm.IsDisposed)
                {
                    frm = new Frm_DownF(mypoint);
                    frm.ImageList = ImageList;
                    frm.DataSrouce = DataSrouce;
                }
                frm.Show();
                frm.ClosedForm += new EventHandler(frm_ClosedForm);
            }
        }

        void frm_ClosedForm(object sender, EventArgs e)
        {
            mousetype = 0;
            this.BackgroundImage = Properties.Resources.cbobtn;
        }

    }
}
