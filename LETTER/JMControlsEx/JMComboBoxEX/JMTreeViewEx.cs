using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace JMControlsEx
{
    internal class JMTreeViewEx : TreeView
    {
        internal JMTreeViewEx()
        {
            //设置窗体Style   
            //this.SetStyle(ControlStyles.UserPaint, true);               //支持用户重绘窗体   
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);    //在内存中先绘制界面   
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);   //双缓冲，防止绘制时抖动   
            this.SetStyle(ControlStyles.DoubleBuffer, true);            //双缓冲，防止绘制时抖动    
            this.UpdateStyles();

            //不显示树形节点显示连接线  
            this.ShowLines = false;
            //设置绘制TreeNode的模式  
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            //不显示TreeNode前的“+”和“-”按钮  
            this.ShowPlusMinus = false;
            //不支持CheckedBox  
            this.CheckBoxes = false;
            this.BorderStyle = BorderStyle.None;
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            if (e.Node.Checked)
            {
                //演示为绿底白字
                Rectangle rectSelect = new Rectangle(0, e.Node.Bounds.Y, Width, e.Node.Bounds.Height);
                e.Graphics.FillRectangle(Brushes.LightBlue, rectSelect);
            }

            Rectangle rect = e.Node.Bounds;
            if (ImageList != null)
            {
                int index = e.Node.ImageIndex < 0 ? 0 : e.Node.ImageIndex;
                if (ImageList.Images.Count > index)
                {
                    Image img = ImageList.Images[index];
                    int lx = 5;
                    int ly = rect.Y + (ItemHeight - img.Height) / 2;
                    g.DrawImage(img, new Point(lx, ly));
                }
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            rect.Offset(0, 1);
            rect.Inflate(Width-rect.X-1, 0);
            g.DrawString(e.Node.Text, this.Font, new SolidBrush(this.ForeColor), rect, sf);


        }

        TreeNode beonode = null;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            TreeNode node = GetNodeAt(e.Location);
            if (beonode != node)
            {
                if (beonode != null)
                {
                    beonode.Checked = false;
                    Rectangle rectSelect = new Rectangle(0, beonode.Bounds.Y, Width, beonode.Bounds.Height + 1);
                    Invalidate(rectSelect);
                }
                if (node != null)
                {
                    node.Checked = true;
                    Rectangle rectSelect = new Rectangle(0, node.Bounds.Y, Width, node.Bounds.Height);
                    Invalidate(rectSelect);
                }
                beonode = node;
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (beonode != null)
            {
                beonode.Checked = false;
                Rectangle rectSelect = new Rectangle(0, beonode.Bounds.Y, Width, beonode.Bounds.Height + 1);
                Invalidate(rectSelect);
                beonode = null;
            }
            base.OnMouseLeave(e);
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ImageIndex == 2)
            {
                e.Node.ImageIndex = 0;
            }
            else
            {
                e.Node.ImageIndex = 2;
            }
            base.OnNodeMouseClick(e);
        }
    }
}
