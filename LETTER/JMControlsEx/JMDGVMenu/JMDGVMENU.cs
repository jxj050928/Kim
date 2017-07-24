using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    internal partial class JMDGVMENU : JMMenuForm
    {
        public delegate void ColumnVisbleHandel(bool cstate, string _cname);
        public event ColumnVisbleHandel ColumnVisbleChange;

        public delegate void ColumnOrderHandel(ListSortDirection lsd,string _cname);
        public event ColumnOrderHandel ColumnOrderChange;

        public delegate void ColumnValueHandel(List<string> values, string _cname);
        public event ColumnValueHandel ColumnValueChange;

        private string coluname;
        public JMDGVMENU(List<columninfo> _columname,string _cname,DataTable dt)
        {
            InitializeComponent();
            jmDataGridView1.DataSource = _columname;
            Column5.DataPropertyName = dt.Columns[1].ColumnName;
            jmDataGridView2.DataSource = dt;
            coluname = _cname;
        }

        private void jmDataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (jmDataGridView1.Columns[e.ColumnIndex].Name == "Column1")
            {
                if (ColumnVisbleChange != null)
                {
                    ColumnVisbleChange(Convert.ToBoolean(Convert.ToInt32(jmDataGridView1.Rows[e.RowIndex].Cells["Column1"].EditedFormattedValue)), jmDataGridView1.Rows[e.RowIndex].Cells["Column3"].EditedFormattedValue.ToString());
                }
            }
        }

        #region ÅÅÐò
        //ÉýÐò
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ColumnOrderChange != null)
            {
                ColumnOrderChange(ListSortDirection.Ascending, coluname);
            }
        }
        //½µÐò
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ColumnOrderChange != null)
            {
                ColumnOrderChange(ListSortDirection.Descending, coluname);
            }
        }
        #endregion

        private void jmDataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (jmDataGridView2.Columns[e.ColumnIndex].Name == "Column4")
            {
                if (ColumnValueChange != null)
                {
                    //string value = "";
                    List<string> ls = new List<string>();
                    foreach (DataGridViewRow var in jmDataGridView2.Rows)
                    {
                        if (!Convert.ToBoolean(var.Cells["Column4"].EditedFormattedValue))
                        {
                            if (var.Cells["Column5"].Value == null)
                            {
                                //value += "'',";
                                ls.Add("");
                            }
                            else
                            {
                                //value += "'" + var.Cells[1].Value.ToString() + "',";
                                ls.Add(var.Cells["Column5"].Value.ToString());
                            }
                        }
                    }
                    //value.TrimEnd(',');
                    ColumnValueChange(ls, coluname);
                }
            }
        }

    }

    internal class columninfo
    {
        private string ctext;

        public string Ctext
        {
            get { return ctext; }
            set { ctext = value; }
        }
        private string cname;

        public string Cname
        {
            get { return cname; }
            set { cname = value; }
        }
        private bool cvisble;

        public bool Cvisble
        {
            get { return cvisble; }
            set { cvisble = value; }
        }
    }
}