using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace JMControlsEx
{
    public class TabControlSimpleEx : Panel
    {
        public event EventHandler SelectindexChanged;

        /// <summary>
        /// 当前索引
        /// </summary>
        private int _selectindex;

        public int Selectindex
        {
            get { return _selectindex; }
            set
            {
                if (_selectindex != value)
                {
                    _selectindex = value;
                    if (_selectindex >= 0)
                    {
                        Invalidate();
                    }
                    if (SelectindexChanged != null)
                    {
                        SelectindexChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        private int _captionHeight;

        public int CaptionHeight
        {
            get { return _captionHeight; }
            set
            {
                _captionHeight = value;
                this.Padding = new Padding(0, _captionHeight, 0, 0);
            }
        }

        private Color bordercolor;

        public Color Bordercolor
        {
            get { return bordercolor; }
            set { bordercolor = value; Invalidate(); }
        }

        private List<Rectangle> RectList;

        private string[] _items;

        public string[] Items
        {
            get { return _items; }
            set { _items = value; }
        }

        #region 构造函数
        public TabControlSimpleEx()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            _captionHeight = 45;
            this.Padding = new Padding(0, _captionHeight, 0, 0);
            bordercolor = Color.FromArgb(200, 200, 200);
            _selectindex = -1;
        }
        #endregion

        #region 重写
        protected override void OnPaint(PaintEventArgs e)
        {
            RectList = new List<Rectangle>();

            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawLine(new Pen(bordercolor), new Point(0, _captionHeight - 1), new Point(Width, _captionHeight - 1));

            Color selectColor = Color.Gainsboro;

            if (Items != null)
            {
                int count = Items.Length;
                if (count > 0)
                {
                    int aWidth = Width / count;

                    for (int i = 0; i < Items.Length; i++)
                    {
                        Rectangle rectone = new Rectangle(i * aWidth, 0, aWidth, _captionHeight);
                        RectList.Add(rectone);

                        if (i == _selectindex)
                        {
                            g.DrawLine(new Pen(this.BackColor), new Point(rectone.X, _captionHeight - 1), new Point(rectone.X + rectone.Width, _captionHeight - 1));
                            g.FillRectangle(new SolidBrush(selectColor), rectone);
                        }
                        if (i != 0)
                        {
                            g.DrawLine(new Pen(bordercolor), new Point(rectone.X, 0), new Point(rectone.X, _captionHeight - 1));
                        }
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Trimming = StringTrimming.EllipsisCharacter;
                        g.DrawString(Items[i], Font, new SolidBrush(ForeColor), rectone, sf);
                    }
                }
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (RectList == null)
            {
                return;
            }
            if (RectList.Count < 2)
            {
                return;
            }
            if (e.Location.Y < _captionHeight)
            {
                for (int i = 0; i < RectList.Count; i++)
                {
                    if (RectList[i].Contains(e.Location))
                    {
                        Selectindex = i;
                        break;
                    }
                }
            }
        }
        #endregion

    }
}
