using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JMControlsEx;
using dal;

namespace LETTER
{
    public partial class FrmMain : FormEx
    {
        public FrmMain()
        {
            InitializeComponent();
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void picSale_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panelMian.Controls.Count == 0 || this.panelMian.Controls[0].GetType().ToString() != "LETTER.Uc_Sale")
                {
                    this.panelMian.Controls.Clear();
                    Uc_Sale ucsale = new Uc_Sale();
                    ucsale.Dock = DockStyle.Fill;
                    this.panelMian.Controls.Add(ucsale);
                }
            }
            catch
            {

            }
        }

        private void picProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panelMian.Controls.Count == 0 || this.panelMian.Controls[0].GetType().ToString() != "LETTER.Uc_Product")
                {
                    this.panelMian.Controls.Clear();
                    Uc_Product ucproduct = new Uc_Product();
                    ucproduct.Dock = DockStyle.Fill;
                    this.panelMian.Controls.Add(ucproduct);
                }
            }
            catch
            {

            }
        }

        private void picPeople_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panelMian.Controls.Count == 0 || this.panelMian.Controls[0].GetType().ToString() != "LETTER.Uc_People")
                {
                    this.panelMian.Controls.Clear();
                    Uc_People ucpeople = new Uc_People();
                    ucpeople.Dock = DockStyle.Fill;
                    this.panelMian.Controls.Add(ucpeople);
                }
            }
            catch
            {

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panelMian.Controls.Count == 0 || this.panelMian.Controls[0].GetType().ToString() != "LETTER.Uc_Charge")
                {
                    this.panelMian.Controls.Clear();
                    Uc_Charge uccharge = new Uc_Charge();
                    uccharge.Dock = DockStyle.Fill;
                    this.panelMian.Controls.Add(uccharge);
                }
            }
            catch
            {

            }
        }

        private void picBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panelMian.Controls.Count == 0 || this.panelMian.Controls[0].GetType().ToString() != "LETTER.Uc_Backup")
                {
                    this.panelMian.Controls.Clear();
                    Uc_Backup ucbackup = new Uc_Backup();
                    ucbackup.Dock = DockStyle.Fill;
                    this.panelMian.Controls.Add(ucbackup);
                }
            }
            catch
            {

            }
        }

        private void picMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panelMian.Controls.Count == 0 || this.panelMian.Controls[0].GetType().ToString() != "LETTER.UC_Main")
                {
                    this.panelMian.Controls.Clear();
                    UC_Main ucmain = new UC_Main();
                    ucmain.Dock = DockStyle.Fill;
                    this.panelMian.Controls.Add(ucmain);
                }
            }
            catch
            {

            }
        }

        private void picSell_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.panelMian.Controls.Count == 0 || this.panelMian.Controls[0].GetType().ToString() != "LETTER.Uc_Sell")
                {
                    this.panelMian.Controls.Clear();
                    Uc_Sell ucsell = new Uc_Sell();
                    ucsell.Dock = DockStyle.Fill;
                    this.panelMian.Controls.Add(ucsell);
                }
            }
            catch
            {

            }
        }
    }
}
