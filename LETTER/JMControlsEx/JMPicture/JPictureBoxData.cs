using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace JMControlsEx
{
    public class JPictureBoxData : ScrollableControl
    {
        public event EventHandler SelectItemChanged;
        public event JMDelegate.DelItemEventHandle DeleteItem;

        #region 私有变量
        /// <summary>
        /// 滚动条手柄颜色
        /// </summary>
        private Color _baseColor;
        /// <summary>
        /// 项集合
        /// </summary>
        private JPictureBoxItemCollection _Items;
        /// <summary>
        /// 选中项集合
        /// </summary>
        private JPictureBox _SelectedItem;
        #endregion

        #region 构造函数
        public JPictureBoxData()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.UpdateStyles();

            _Items = new JPictureBoxItemCollection(this);
            _baseColor = Color.White;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 显示控件的高度
        /// </summary>
        private int _ZHeight = 60;

        public int ZHeight
        {
            get { return _ZHeight; }
            set { _ZHeight = value; Invalidate(); }
        }

        /// <summary>
        /// 每行显示的个数
        /// </summary>
        private int _ZCount = 4;

        public int ZCount
        {
            get { return _ZCount; }
            set { _ZCount = value; Invalidate(); }
        }

        public Color BaseColor
        {
            get { return _baseColor; }
            set { _baseColor = value; Invalidate(); }
        }

        [RefreshProperties(RefreshProperties.Repaint),
        Category("Collections"),
        Browsable(true),
        Description("日记主题栏项")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Editor(typeof(JPictureBoxItemCollectionEditor), typeof(UITypeEditor))]
        public JPictureBoxItemCollection Items
        {
            get { return _Items; }
        }

        [Category("Collections"),
        Browsable(false),
        Description("日记主题栏选中项")]
        public JPictureBox SelectedItem
        {
            get { return _SelectedItem; }
        }
        #endregion

        #region 重写 add remove resize事件
        protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
        {
            base.OnControlAdded(e);
            JPictureBox xpanderPanel = e.Control as JPictureBox;
            if (xpanderPanel != null)
            {
                xpanderPanel.Parent = this;
                xpanderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                xpanderPanel.Width = (Width - this.Padding.Left - this.Padding.Right - 6) / _ZCount;
                xpanderPanel.Height = _ZHeight;
                xpanderPanel.Location = this.GetTopPosition(0);
                xpanderPanel.DeleteClick += new EventHandler(xpanderPanel_DeleteClick);
                xpanderPanel.SelectClick += new EventHandler(xpanderPanel_SelectClick);
            }
            else
            {
                throw new InvalidOperationException("只能添加JPictureBox对象");
            }
        }

        protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            JPictureBox xpanderPanel = e.Control as JPictureBox;

            if (xpanderPanel != null)
            {
                xpanderPanel.DeleteClick -= new EventHandler(xpanderPanel_DeleteClick);
                xpanderPanel.SelectClick -= new EventHandler(xpanderPanel_SelectClick);
            }
            OnResize(EventArgs.Empty);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            if (this._Items != null)
            {
                int i = 1;
                foreach (JPictureBox xpanderPanel in this._Items)
                {
                    xpanderPanel.Width = (Width - this.Padding.Left - this.Padding.Right - 6) / _ZCount;
                    xpanderPanel.Height = _ZHeight;
                    xpanderPanel.Location = this.GetTopPosition(i);
                    i++;
                }
            }
        }
        #endregion

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xpanderPanel_DeleteClick(object sender, EventArgs e)
        {
            if (DeleteItem != null)
            {
                CancelEventArgs cancel = new CancelEventArgs();
                DeleteItem(sender, cancel);
                if (cancel.Cancel)
                {
                    this.Items.Remove(sender as JPictureBox);
                }
            }
        }

        private void xpanderPanel_SelectClick(object sender, EventArgs e)
        {
            foreach (JPictureBox item in this._Items)
            {
                if (item != (sender as JPictureBox))
                {
                    item.IsFoucs = false;
                }
                else
                {
                    _SelectedItem = item;
                    if (SelectItemChanged != null)
                    {
                        SelectItemChanged(sender, e);
                    }
                }
            }
        }

        /// <summary>
        /// 获取控件y坐标
        /// </summary>
        /// <returns></returns>
        private Point GetTopPosition(int i)
        {
            int x = Padding.Left;
            int y = Padding.Top;

            int count = i == 0 ? this.Items.Count : i;

            int w = (Width - this.Padding.Left - this.Padding.Right - 6) / _ZCount;
            int h = _ZHeight;
            int ct = count % _ZCount == 0 ? _ZCount - 1 : count % _ZCount - 1;
            int ch = count % _ZCount == 0 ? (int)count / _ZCount - 1 : (int)count / _ZCount;
            x = x + (w + 2) * ct;
            y = y + ch * (h + 2);

            return new Point(x, y);
        }
    }
}
