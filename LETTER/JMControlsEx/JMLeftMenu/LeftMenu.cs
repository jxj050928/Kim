using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace JMControlsEx
{
    [DefaultEvent("ItemClick")]
    public partial class LeftMenu : UserControl
    {
        public event EventHandler ItemClick;

        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color _borderColor;
        /// <summary>
        /// 菜单集合
        /// </summary>
        private LeftMenuItems items = new LeftMenuItems();

        /// <summary>
        /// 高度
        /// </summary>
        private int m_lItemHeight = 42;
        /// <summary>
        /// 宽度
        /// </summary>
        private int m_lItemWidth = 168;

        private Size m_imgsize = new Size(23, 23);

        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        /// <summary>
        /// 获取菜单集合
        /// </summary>
        [Description("集合")]
        public LeftMenuItems Items
        {
            get
            {
                return this.items;
            }
        } 

        public LeftMenuItem SelectedItem
        {
            get {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Checked)
                    {
                        return items[i];
                    }
                }
                return null;
            }
            set {
                bool isInvalidate = false;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i] == value)
                    {
                        if (!items[i].Checked)
                        {
                            isInvalidate = true;
                            items[i].Checked = true;
                        }
                    }
                    else
                    {
                        items[i].Checked = false;
                    }
                }
                if (isInvalidate)
                {
                    this.Invalidate();
                }
            }
        }

        #region 构造函数
        public LeftMenu()
        {
            _borderColor = Color.FromArgb(197, 197, 197);
            InitializeComponent();
            // control styles:
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);

            this.items = new LeftMenuItems(this);
        }
        #endregion

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int lIndex = -1;
            bool bInvalidate = false;

            lIndex = (e.Y + 1) / (m_lItemHeight + 2);

            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (lIndex == i)
                    {
                        if (items[i].Disabled)
                            return;

                        if (!items[i].Checked)
                        {
                            items[i].MouseDown = true;
                            items[i].Checked = true;
                            bInvalidate = true;
                        }

                        if (ItemClick != null)
                            ItemClick(items[i], EventArgs.Empty);

                    }
                    else
                    {
                        if (items[i].Checked)
                        {
                            items[i].Checked = false;
                            bInvalidate = true;
                        }
                    }
                }
            }
            if (bInvalidate)
            {
                Invalidate();
            }

        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            CalculatesMenuSize();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            g.DrawRectangle(new Pen(_borderColor), rect);

            DrawMenuItems(g, rect);
        }

        /// <summary>
        /// Renders menu items.
        /// </summary>
        /// <param name="gfx">Graphics object</param>
        /// <param name="rc">Menu rectangle</param>
        private void DrawMenuItems(
             Graphics gfx,
             Rectangle rc
            )
        {
            Rectangle rcItem = new Rectangle();
            rcItem.X = Width - m_lItemWidth;
            rcItem.Y = 8;
            rcItem.Width = m_lItemWidth;
            rcItem.Height = m_lItemHeight;

            if (items == null || items.Count == 0)
                return;

            foreach (LeftMenuItem item in items)
            {
                Rectangle rcTextRect = rcItem;
                rcTextRect.X += 10;

                string strText = item.Text;

                if (item.Checked)
                {
                    strText += "   (" + item.Description + ")";

                    #region Draw back
                    gfx.DrawImage(
                                Properties.Resources.DHSelected,
                                rcItem
                            );
                    #endregion

                    #region Draw icons
                    if (item.Image != null)
                    {
                        Rectangle rcIcon = new Rectangle();
                        rcIcon.X = rcItem.X + 10;
                        rcIcon.Y = rcItem.Bottom - m_imgsize.Height - 12;
                        rcIcon.Width = m_imgsize.Width;
                        rcIcon.Height = m_imgsize.Height;

                        if (item.Disabled)
                        {
                            ControlPaint.DrawImageDisabled(
                                gfx,
                                item.Image,
                                rcIcon.X,
                                rcIcon.Y,
                                Color.Transparent);
                        }
                        else
                        {
                            gfx.DrawImage(
                                item.Image,
                                rcIcon
                            );
                        }

                        rcTextRect.X += m_imgsize.Width + 5;
                    }
                    #endregion
                }

                StringFormat sfUpper = new StringFormat();
                sfUpper.Trimming = StringTrimming.EllipsisCharacter;
                sfUpper.FormatFlags = StringFormatFlags.LineLimit;
                sfUpper.Alignment = StringAlignment.Near;
                sfUpper.LineAlignment = StringAlignment.Center;

                #region Draw item's text
                gfx.DrawString(strText, this.Font, new SolidBrush(ForeColor), rcTextRect, sfUpper);

                //sfUpper.Dispose();
                #endregion

                rcItem.Y += rcItem.Height + 2;
            }

        }

        #region 公共方法Public methods
        /// <summary>
        /// 重新计算高度
        /// </summary>
        public void CalculatesMenuSize()
        {
            if (!this.DesignMode)
            {
                Invalidate();
            }
        }
        #endregion
    }
}
