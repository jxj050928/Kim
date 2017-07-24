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
    public class JMDropDownData : ScrollableControl
    {
        public event EventHandler SelectItemChanged;

        #region 私有变量
        //滚动条旧区域
        private Rectangle rectcrollHand;
        //滚动条新区域
        private Rectangle renew;
        //鼠标进入
        private bool MouseOn = false;
        //鼠标按下
        private bool MouseD = false;
        //开始移动y坐标
        private int startY = 0;
        //滚动条高度
        private int tumbHeight;
        //滚动条外框弧度
        private int round;
        /// <summary>
        /// 滚动条宽度
        /// </summary>
        private int ScrollWidth = 12;
        /// <summary>
        /// 滚动条手柄颜色
        /// </summary>
        private Color _baseColor;
        /// <summary>
        /// 项集合
        /// </summary>
        private JMDropDownCollection _Items;
        /// <summary>
        /// 选中项集合
        /// </summary>
        private List<JMComboBoxButton> _SelectedItems;
        #endregion

        #region 滚动条用
        protected int moMinimum = 0;
        protected int moMaximum = 100;
        protected int moValue = 0;
        #endregion

        #region 鼠标滑轮用
        private int ScrollValue = 0;
        private int ScrollMinValue = 0;
        private int ScrollMaxValue = 0;
        #endregion

        #region 构造函数
        public JMDropDownData()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.UpdateStyles();

            _Items = new JMDropDownCollection(this);
            _SelectedItems = new List<JMComboBoxButton>();
            tumbHeight = 30;
            round = 12;
            _baseColor = Color.White;
        }
        #endregion

        #region 属性
        [EditorBrowsable(EditorBrowsableState.Always),
        Category("Behavior"), Description("滚动条当前值")]
        internal int Value
        {
            get { return moValue; }
            set
            {
                moValue = value;
                if (renew == Rectangle.Empty)
                {
                    renew = rectcrollHand;
                }
                float canmoveH = Height - (Padding.Top + Padding.Bottom + tumbHeight + 4);
                float oneV = canmoveH / (moMaximum - moMinimum);
                float ry = moValue * oneV + 2 + Padding.Top;
                renew.Y = (int)ry;

                //this.Invalidate(rectcrollHand);
                //this.Invalidate(renew);
                this.Invalidate();

                for (int i = 1; i <= this._Items.Count; i++)
                {
                    this._Items[i-1].Location = new Point(this._Items[i-1].Location.X, -moValue + this._Items[i-1].Height * (i-1));
                }
            }
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
        [Editor(typeof(JMDropDownCollectionEditor), typeof(UITypeEditor))]
        public JMDropDownCollection Items
        {
            get { return _Items; }
        }

        [Category("Collections"),
        Browsable(false),
        Description("日记主题栏选中项")]
        public List<JMComboBoxButton> SelectedItems
        {
            get { return _SelectedItems; }
        }
        #endregion

        #region 重写 add remove resize事件
        protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
        {
            base.OnControlAdded(e);
            JMComboBoxButton xpanderPanel = e.Control as JMComboBoxButton;
            if (xpanderPanel != null)
            {
                xpanderPanel.Parent = this;
                xpanderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                xpanderPanel.Left = this.Padding.Left;
                xpanderPanel.Width = this.ClientRectangle.Width - ScrollWidth
                    - this.Padding.Left
                    - this.Padding.Right;
                
                xpanderPanel.Top = this.GetTopPosition();
                xpanderPanel.Click += new EventHandler(xpanderPanel_Click);
            }
            else
            {
                throw new InvalidOperationException("只能添加JMComboBoxButton对象");
            }
        }

        protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            JMComboBoxButton xpanderPanel = e.Control as JMComboBoxButton;

            if (xpanderPanel != null)
            {
                xpanderPanel.Click -= new EventHandler(xpanderPanel_Click);
            }
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            int iXPanderPanelCaptionHeight = 0;

            if (this._Items != null)
            {
                foreach (JMComboBoxButton xpanderPanel in this._Items)
                {
                    xpanderPanel.Width = this.ClientRectangle.Width
                        - this.Padding.Left
                        - this.Padding.Right - ScrollWidth;
                    if (xpanderPanel.Visible == false)
                    {
                        iXPanderPanelCaptionHeight -= xpanderPanel.Height;
                    }
                    iXPanderPanelCaptionHeight += xpanderPanel.Height;
                }

                //foreach (JMComboBoxButton xpanderPanel in this._Items)
                //{
                //    xpanderPanel.Height =
                //        this.Height
                //        - iXPanderPanelCaptionHeight
                //        - this.Padding.Top
                //        - this.Padding.Bottom
                //        + xpanderPanel.Height;
                //    return;
                //}
            }
        }
        #endregion

        #region 画滚动条
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            if (this._Items.Count > 0)
            {
                if (this.Items[0].Height * _Items.Count > this.Height)
                {
                    DrawBack(g);
                    DrawScrollHand(g);
                }
            }
        }

        /// <summary>
        /// 画滚动条背景
        /// </summary>
        /// <param name="g"></param>
        private void DrawBack(Graphics g)
        {
            int x = Width - ScrollWidth;
            int y = this.Padding.Top;
            int wid = ScrollWidth;
            int hei = Height - this.Padding.Bottom - this.Padding.Top;

            Rectangle rect = new Rectangle(x, y, wid, hei);
            GraphicsPath path = GetGraphicPath.CreatePath(rect, round, RoundStyle.All, true);
            LinearGradientBrush lb = new LinearGradientBrush(rect, Color.FromArgb(0, 61, 130), Color.FromArgb(0, 61, 130), LinearGradientMode.Horizontal);
            g.FillPath(lb, path);
        }

        /// <summary>
        /// 花滚动条手柄
        /// </summary>
        /// <param name="g"></param>
        private void DrawScrollHand(Graphics g)
        {
            int x = Width - ScrollWidth + 1;
            int y;
            if (renew != Rectangle.Empty)
            {
                y = renew.Y;
            }
            else
            {
                y = this.Padding.Top + 2;
            }
            int wid = ScrollWidth - 3;
            int hei = tumbHeight;

            Rectangle rectcrollHand1 = new Rectangle(x, y, wid, hei / 3);
            Rectangle rectcrollHand2 = new Rectangle(x, y + hei / 3, wid, hei / 3);
            Rectangle rectcrollHand3 = new Rectangle(x, y + hei / 3 * 2, wid, hei / 3);
            g.FillEllipse(new SolidBrush(_baseColor), rectcrollHand1);
            g.FillEllipse(new SolidBrush(_baseColor), rectcrollHand2);
            g.FillEllipse(new SolidBrush(_baseColor), rectcrollHand3);

            rectcrollHand = new Rectangle(x, y, wid, hei);
        }
        #endregion

        #region 鼠标事件
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (rectcrollHand.Contains(e.Location))
            {
                ScrollMaxValue = 0;
                ScrollMinValue = this.Height - _Items[0].Height * this._Items.Count;
                moMaximum = -ScrollMinValue;
                MouseD = true;
                startY = e.Location.Y;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseD = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (MouseD)
            {
                if (e.Location.Y != startY)
                {
                    int bsy = startY;
                    int cj = e.Location.Y - startY;
                    startY = e.Location.Y;
                    Graphics g = Graphics.FromHwnd(this.Handle);

                    renew = rectcrollHand;
                    renew.Y += cj;
                    if (renew.Y < this.Padding.Top + 2)
                    {
                        renew.Y = this.Padding.Top + 2;
                        startY = bsy;
                        cj = 0;
                    }
                    else if (renew.Y > Height - this.Padding.Bottom - tumbHeight - 2)
                    {
                        renew.Y = Height - this.Padding.Bottom - tumbHeight - 2;
                        startY = bsy;
                        cj = 0;
                    }
                    Application.DoEvents();
                    float canmoveH = Height - (Padding.Top + Padding.Bottom + tumbHeight + 4);
                    float oneV = canmoveH / (moMaximum - moMinimum);
                    float mv = (renew.Y - (2 + Padding.Top)) / oneV;

                    Value = (int)Math.Round(mv, 0);
                    //this.Invalidate(rectcrollHand);
                    //this.Invalidate(renew);
                }
            }
            else
            {
                if (rectcrollHand.Contains(e.Location))
                {
                    if (!MouseOn)
                    {
                        Graphics g = Graphics.FromHwnd(this.Handle);
                        MouseOn = true;
                        this.Invalidate(rectcrollHand);
                    }

                }
                else
                {
                    if (MouseOn)
                    {
                        Graphics g = Graphics.FromHwnd(this.Handle);
                        MouseOn = false;
                        this.Invalidate(rectcrollHand);
                    }
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (this.Items.Count > 0)
            {
                if (this.Items[0].Height * _Items.Count > this.Height)
                {
                    ScrollMaxValue = 0;
                    ScrollMinValue = this.Height - _Items[0].Height * this._Items.Count;
                    moMaximum = -ScrollMinValue;
                    if (e.Delta < 0)
                    {
                        if (ScrollValue > ScrollMinValue)
                        {
                            int h = ScrollValue + e.Delta < ScrollMinValue ? ScrollMinValue - ScrollValue : e.Delta;
                            ScrollValue += h;
                        }

                    }
                    else
                    {
                        if (ScrollMaxValue > ScrollValue)
                        {
                            int h = ScrollValue + e.Delta > ScrollMaxValue ? ScrollMaxValue - ScrollValue : e.Delta;
                            ScrollValue += h;
                        }
                    }
                    Value = -ScrollValue;
                }
            }
        }
        #endregion

        #region 集合每项单机事件
        private void xpanderPanel_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                // Control按下了
                //(sender as JMComboBoxButton).IsFoucs = !(sender as JMComboBoxButton).IsFoucs;
                //if ((sender as JMComboBoxButton).IsFoucs)
                //{
                //    this.SelectedItems.Add((sender as JMComboBoxButton));
                //}
                //else
                //{
                //    this.SelectedItems.Remove((sender as JMComboBoxButton));
                //}
            }
            else
            {
                foreach (JMComboBoxButton item in this._Items)
                {
                    if (item.Name == (sender as JMComboBoxButton).Name)
                    {
                        //item.IsFoucs = true;
                        if (SelectedItems.IndexOf(item) < 0)
                        {
                            this.SelectedItems.Add(item);
                        }

                    }
                    else
                    {
                        //item.IsFoucs = false;
                        this.SelectedItems.Remove(item);
                    }
                }
            }
            if (SelectItemChanged!=null)
            {
                SelectItemChanged(sender, e);
            }
        }
        #endregion

        /// <summary>
        /// 获取控件y坐标
        /// </summary>
        /// <returns></returns>
        private int GetTopPosition()
        {
            int iTopPosition = this.Padding.Top;
            int iNextTopPosition = 0;

            IEnumerator enumerator = this.Items.GetEnumerator();
            while (enumerator.MoveNext())
            {
                JMComboBoxButton xpanderPanel = (JMComboBoxButton)enumerator.Current;

                if (xpanderPanel.Visible == true)
                {
                    if (iNextTopPosition == this.Padding.Top)
                    {
                        iTopPosition = this.Padding.Top;
                    }
                    else
                    {
                        iTopPosition = iNextTopPosition;
                    }
                    iNextTopPosition = iTopPosition + xpanderPanel.Height;
                }
            }
            return iTopPosition;
        }
    }
}
