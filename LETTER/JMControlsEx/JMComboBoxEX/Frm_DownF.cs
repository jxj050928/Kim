using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace JMControlsEx
{
    internal partial class Frm_DownF : Form
    {
        public event EventHandler ClosedForm;
        Frm_DownS frm;

        private DataTable _data;
        public DataTable DataSrouce
        {
            get { return _data; }
            set
            {
                _data = value;

                if (!this.DesignMode)
                {
                    for (int i = 0; i < _data.Rows.Count; i++)
                    {
                        if (_data.Rows[i]["ID"].ToString().TrimEnd('S').Length == 5)
                        {
                            continue;
                        }
                        TreeNode node = new TreeNode();
                        node.Tag = _data.Rows[i]["ID"].ToString();
                        node.Text = _data.Rows[i]["name"].ToString();
                        node.ImageIndex = Convert.ToInt16(_data.Rows[i]["index"]);
                        treeView1.Nodes.Add(node);
                    }
                    if (25 * (treeView1.Nodes.Count) + 30 > 480)
                    {
                        this.Height = 480;
                    }
                    else
                    {
                        this.Height = 25 * (treeView1.Nodes.Count) + 30;
                    }
                }
            }
        }

        public ImageList ImageList
        {
            get { return treeView1.ImageList; }
            set { treeView1.ImageList = value; }
        }

        Point mypoint = new Point(0, 0);

        internal Frm_DownF(Point _mypoint)
        {
            InitializeComponent();
            mypoint = _mypoint;
            if (25 * (treeView1.Nodes.Count) + 30 > 480)
            {
                this.Height = 480;
            }
            else
            {
                this.Height = 25 * (treeView1.Nodes.Count) + 30;
            }            
        }

        private void Frm_DownF_Load(object sender, EventArgs e)
        {
            this.Location = mypoint;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frm != null && !frm.IsDisposed)
            {
                frm.Close();
            }
            if (ClosedForm != null)
            {
                ClosedForm(sender, EventArgs.Empty);
            }

        }

        TreeNode befronode = null;
        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            TreeNode node = treeView1.GetNodeAt(e.Location);
            treeView1.SelectedNode = node;
            if (befronode != node)
            {
                befronode = node;
                if (node == null)
                {
                    if (frm != null && !frm.IsDisposed)
                    {
                        frm.Close();
                    }
                }
                else
                {
                    DataRow[] dr = _data.Select("len(ID)=5 and ID not like '%S' and ID like '" + node.Tag + "%'");
                    if (dr.Length > 0)
                    {
                        if (frm == null || frm.IsDisposed)
                        {
                            frm = new Frm_DownS();
                            frm.ImageList = ImageList;
                            frm.Show();
                            frm.MouseLeaveEX += new EventHandler(frm_MouseLeaveEX);
                            frm.NodeClicked += new Frm_DownS.NodeClickHandler(frm_NodeClicked);
                        }
                        frm.SetNode(dr);
                        frm.Location = new Point(this.Location.X + this.Width, this.Location.Y + node.Bounds.Y);
                    }
                    else
                    {
                        if (frm != null && !frm.IsDisposed)
                        {
                            frm.Close();
                        }
                    }
                }
            }
        }

        void frm_NodeClicked(int Index, TreeNode node)
        {
            if (befronode != null)
            {
                befronode.ImageIndex = Index;
                foreach (DataRow item in _data.Rows)
                {
                    if (item["ID"] == befronode.Tag)
                    {
                        item["index"] = Index;
                    }
                    if (item["ID"] == node.Tag)
                    {
                        item["index"] = node.ImageIndex;
                    }
                }
            }
        }

        private void Form3_Deactivate(object sender, EventArgs e)
        {
            if (frm == null || frm.IsDisposed)
            {
                this.Hide();
                if (frm != null && !frm.IsDisposed)
                {
                    frm.Close();
                }
                if (ClosedForm != null)
                {
                    ClosedForm(sender, EventArgs.Empty);
                }
            }
        }

        private void treeView1_MouseLeave(object sender, EventArgs e)
        {
            if (frm != null && !frm.IsDisposed)
            {
                Rectangle rect = new Rectangle(frm.Location.X - 18, frm.Location.Y, frm.Size.Width+18, frm.Size.Height);
                if (!rect.Contains(MousePosition))
                {
                    befronode = null;
                    frm.Close();
                }
            }
        }

        void frm_MouseLeaveEX(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle(Location.X, Location.Y, Size.Width + 1, Size.Height);
            if (!rect.Contains(MousePosition))
            {
                befronode = null;
                frm.Close();
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            foreach (DataRow item in _data.Rows)
            {
                if (item["ID"].ToString().StartsWith(e.Node.Tag.ToString()))
                {
                    item["index"] = e.Node.ImageIndex;
                }
            }

            if (frm != null && !frm.IsDisposed)
            {
                frm.CheckAll(e.Node.ImageIndex);
            }

            if (e.Node.ImageIndex < 2 && checkBox1.Checked)
            {
                checkBox1.CheckedChanged -= new EventHandler(checkBox1_CheckedChanged);
                checkBox1.Checked = false;
                checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            }
            else if (e.Node.ImageIndex == 2 && !checkBox1.Checked)
            {
                bool alltrue = true;
                foreach (DataRow item in _data.Rows)
                {
                    if (Convert.ToInt16(item["index"]) != 2)
                    {
                        alltrue = false;
                        break;
                    }
                }
                if (alltrue)
                {
                    checkBox1.CheckedChanged -= new EventHandler(checkBox1_CheckedChanged);
                    checkBox1.Checked = true;
                    checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int imgindex = checkBox1.Checked ? 2 : 0;
            foreach (TreeNode item in treeView1.Nodes)
            {
                item.ImageIndex = imgindex;
            }
            foreach (DataRow row in _data.Rows)
            {
                row["index"] = imgindex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Frm_DownF_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.White), new Point(1, 0), new Point(87, 0));
        }
    }
}
