using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    internal partial class Frm_DownS : Form
    {
        public event EventHandler MouseLeaveEX;
        public delegate void NodeClickHandler(int Index, TreeNode node);
        public event NodeClickHandler NodeClicked;

        internal Frm_DownS()
        {
            InitializeComponent();
        }

        public ImageList ImageList
        {
            get { return treeView1.ImageList; }
            set { treeView1.ImageList = value; }
        }

        public void SetNode(DataRow[] _data)
        {
            treeView1.Nodes.Clear();
            for (int i = 0; i < _data.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Tag = _data[i]["ID"].ToString();
                node.Text = _data[i]["name"].ToString();
                node.ImageIndex = Convert.ToInt16(_data[i]["index"]);
                treeView1.Nodes.Add(node);
            }
            this.Height = treeView1.Nodes.Count * 25;
        }

        public void CheckAll(int imageindex)
        {
            foreach (TreeNode item in treeView1.Nodes)
            {
                item.ImageIndex = imageindex;
            }
        }

        private void Form4_Deactivate(object sender, EventArgs e)
        {
            //Close();
        }

        private void treeView1_MouseLeave(object sender, EventArgs e)
        {
            if (MouseLeaveEX != null)
                MouseLeaveEX(sender, e);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int index = -1;
            foreach (TreeNode item in treeView1.Nodes)
            {
                if (index == -1)
                {
                    index = item.ImageIndex;
                    continue;
                }
                if (item.ImageIndex != index && index != -1)
                {
                    index = 1;
                    break;
                }
            }
            if (NodeClicked != null)
            {
                NodeClicked(index, e.Node);
            }
        }
    }
}
