using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;

namespace JMControlsEx
{
    public class ComboTreeNode : Panel
    {
        public event MouseEventHandler TextSelected;
        public event MouseEventHandler Explaned;
        public event EventHandler MouseDownMinut;

        protected bool ismouserdownminut = false;

        private SelectType IsEnter = SelectType.None;

        /// <summary>
        /// 图片宽度
        /// </summary>
        private const int C_ImgHeight = 13;

        /// <summary>
        /// 控件固定高度
        /// </summary>
        private const int C_Height = 17;

        /// <summary>
        /// 控件宽度 默认100 自动计算
        /// </summary>
        private int autoWidth = 100;

        /// <summary>
        /// 是否展开
        /// </summary>
        private bool isExpland = false;

        private string _ZText = "";

        private object _ZID = "";

        public bool IsExpland
        {
            get { return isExpland; }
            set
            {
                isExpland = value;
                autoSize();
            }
        }

        public string ZText
        {
            get { return _ZText; }
            set
            {
                _ZText = value;
                autoSize();
            }
        }

        public object ZID
        {
            get { return _ZID; }
            set { _ZID = value; }
        }

        private void autoSize()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            autoWidth = (int)g.MeasureString(ZText, Font).Width + (IsExpland ? 2 : C_ImgHeight + 2);
            Width = autoWidth;
        }

        Timer timer1;
        #region 构造函数
        public ComboTreeNode()
        {
            this.BackColor = Color.Transparent;
            this.Height = C_Height;
            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Enabled = false;
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int beforwidth = 1;

            Color textcolor = ForeColor;
            Font textFont = Font;
            if (IsEnter == SelectType.TextSelect)
            {
                Rectangle rect = new Rectangle(0, 0, Width, Height);
                GraphicsPath aa = GetGraphicPath.CreatePath(base.ClientRectangle, 5, RoundStyle.Left, true);
                g.FillPath(new SolidBrush(Color.FromArgb(204, 225, 210)), aa);
                //textcolor = Color.Blue;
                //textFont = new Font(Font.Name, Font.Size, FontStyle.Underline);
            }

            if (!IsExpland)
            {
                //g.DrawImage(Properties.Resources.TreePlus, new Point(3, 2));
                beforwidth += C_ImgHeight;
            }

            
            g.DrawString(ZText, textFont, new SolidBrush(textcolor), beforwidth, 2);


        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (ismouserdownminut)
                {
                    ismouserdownminut = false;
                    return;
                }
                if (!IsExpland)
                {
                    Rectangle imgRect = new Rectangle(0, 0, C_ImgHeight + 2, C_Height);
                    if (imgRect.Contains(e.Location))
                    {
                        if (Explaned != null)
                        {
                            Explaned(this, e);
                        }
                    }
                    else
                    {
                        if (TextSelected != null)
                        {
                            TextSelected(this, e);
                        }
                    }
                }
                else
                {
                    if (TextSelected != null)
                    {
                        TextSelected(this, e);
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!IsExpland)
            {
                Rectangle imgRect = new Rectangle(0, 0, C_ImgHeight + 2, C_Height);
                if (imgRect.Contains(e.Location))
                {
                    if (IsEnter != SelectType.ExplanSelect)
                    {
                        IsEnter = SelectType.ExplanSelect;
                        Invalidate();
                    }
                }
                else
                {
                    if (IsEnter != SelectType.TextSelect)
                    {
                        IsEnter = SelectType.TextSelect;
                        Invalidate();
                    }
                }
            }
            else
            {
                if (IsEnter != SelectType.TextSelect)
                {
                    IsEnter = SelectType.TextSelect;
                    Invalidate();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            IsEnter = SelectType.None;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            timer1.Enabled = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            timer1.Enabled = false;
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ismouserdownminut = true;
            Invalidate();
            if (MouseDownMinut != null)
            {
                MouseDownMinut(this, e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Height = C_Height;
            Width = autoWidth;
            Invalidate();
        }

        enum SelectType
        {
            ExplanSelect,
            TextSelect,
            None
        }
    }
}