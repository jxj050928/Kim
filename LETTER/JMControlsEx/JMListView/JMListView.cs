using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class JMListView : ListView
    {
        private Color _rowBackColor1;
        //private Color _rowBackColor3;

        //public Color RowBackColor3
        //{
        //    get { return _rowBackColor3; }
        //    set { _rowBackColor3 = value; }
        //}
        //private Color _rowBackColor4;

        //public Color RowBackColor4
        //{
        //    get { return _rowBackColor4; }
        //    set { _rowBackColor4 = value; }
        //}
        private Color _rowBackColor2;
        private Color _selectedColor;
        private Color _headColor;

        public JMListView()
            : base()
        {
            base.OwnerDraw = true;
            _rowBackColor1 = Color.White;
            _rowBackColor2 = SystemColors.Info;
            //_rowBackColor3 = Color.FromArgb(254, 216, 249);
            //_rowBackColor4 = Color.FromArgb(254, 216, 249);
            _selectedColor = Color.FromArgb(166, 222, 255);
            _headColor = Color.DeepSkyBlue;
        }

        [DefaultValue(typeof(Color), "White")]
        public Color RowBackColor1
        {
            get { return _rowBackColor1; }
            set
            {
                _rowBackColor1 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Info")]
        public Color RowBackColor2
        {
            get { return _rowBackColor2; }
            set
            {
                _rowBackColor2 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "166, 222, 255")]
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "DeepSkyBlue")]
        public Color HeadColor
        {
            get { return _headColor; }
            set
            {
                _headColor = value;
                base.Invalidate();
            }
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);
            
            Graphics g = e.Graphics;
            Rectangle bounds = e.Bounds;
            bounds.X += 1;
            bounds.Width -= 1;
            Color baseColor = _headColor;
            Color borderColor = _headColor;
            Color innerBorderColor = Color.FromArgb(200, 255, 255);

            DrawLinearGradient(bounds, g, borderColor, Color.White);
            //RenderBackgroundInternal(
            //    g,
            //    bounds,
            //    baseColor,
            //    borderColor,
            //    innerBorderColor,
            //    0.35f,
            //    true,
            //    LinearGradientMode.Vertical);

            TextFormatFlags flags = GetFormatFlags(e.Header.TextAlign);
            Rectangle textRect = new Rectangle(
                       bounds.X + 3,
                       bounds.Y,
                       bounds.Width - 6,
                       bounds.Height); ;

            if (e.Header.ImageList != null)
            {
                Image image = e.Header.ImageIndex == -1 ?
                    null : e.Header.ImageList.Images[e.Header.ImageIndex];
                if (image != null)
                {
                    Rectangle imageRect = new Rectangle(
                        bounds.X + 3,
                        bounds.Y + 2,
                        bounds.Height - 4,
                        bounds.Height - 4);
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    g.DrawImage(image, imageRect);

                    textRect.X = imageRect.Right + 3;
                    textRect.Width -= imageRect.Width;
                }
            }
            TextRenderer.DrawText(
                   g,
                   e.Header.Text,
                   e.Font,
                   textRect,
                   e.ForeColor,
                   flags);
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (View != View.Details)
            {
                e.DrawDefault = true;
            }
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            base.OnDrawSubItem(e);
            if (View != View.Details)
            {
                return;
            }
            if (e.ItemIndex == -1)
            {
                return;
            }
            Rectangle bounds = e.Bounds;
            ListViewItemStates itemState = e.ItemState;
            Graphics g = e.Graphics;
            if ((itemState & ListViewItemStates.Selected)
                == ListViewItemStates.Selected)
            {
                bounds.Height--;
                Color baseColor = _selectedColor;
                Color borderColor = _selectedColor;
                Color innerBorderColor = Color.FromArgb(200, 255, 255);

                DrawLinearGradient(bounds, g, baseColor, Color.White);
                //RenderBackgroundInternal(
                //    g,
                //    bounds,
                //    baseColor,
                //    borderColor,
                //    innerBorderColor,
                //    0.35f,
                //    true,
                //    LinearGradientMode.Vertical);
                bounds.Height++;
            }
            else
            {
                bounds.Height--;
                Color backColor = e.ItemIndex % 2 == 0 ?
                _rowBackColor1 : _rowBackColor2;

                //Color backColor2 = e.ItemIndex % 2 == 0 ?
                //_rowBackColor3 : _rowBackColor4;

                //DrawLinearGradient(bounds, g, backColor, backColor2);
                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    g.FillRectangle(brush, bounds);
                }
                bounds.Height++;
            }

            TextFormatFlags flags = GetFormatFlags(e.Header.TextAlign);

            if (e.ColumnIndex == 0)
            {
                if (e.Item.ImageList == null)
                {
                    e.DrawText(flags);
                    return;
                }
                Image image = e.Item.ImageIndex == -1 ?
                    null : e.Item.ImageList.Images[e.Item.ImageIndex];
                if (image == null)
                {
                    e.DrawText(flags);
                    return;
                }
                Rectangle imageRect = new Rectangle(
                    bounds.X + 4,
                    bounds.Y + 2,
                    bounds.Height - 4,
                    bounds.Height - 4);
                g.DrawImage(image, imageRect);

                Rectangle textRect = new Rectangle(
                    imageRect.Right + 3,
                    bounds.Y,
                    bounds.Width - imageRect.Right - 3,
                    bounds.Height);
                TextRenderer.DrawText(
                    g,
                    e.Item.Text,
                    e.Item.Font,
                    textRect,
                    e.Item.ForeColor,
                    flags);
                return;
            }
            e.DrawText(flags);
        }

        protected TextFormatFlags GetFormatFlags(HorizontalAlignment align)
        {
            TextFormatFlags flags =
                    TextFormatFlags.EndEllipsis |
                    TextFormatFlags.VerticalCenter;

            switch (align)
            {
                case HorizontalAlignment.Center:
                    flags |= TextFormatFlags.HorizontalCenter;
                    break;
                case HorizontalAlignment.Right:
                    flags |= TextFormatFlags.Right;
                    break;
                case HorizontalAlignment.Left:
                    flags |= TextFormatFlags.Left;
                    break;
            }

            return flags;
        }

        internal void RenderBackgroundInternal(
          Graphics g,
          Rectangle rect,
          Color baseColor,
          Color borderColor,
          Color innerBorderColor,
          float basePosition,
          bool drawBorder,
          LinearGradientMode mode)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(
               rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 68, 69, 54);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, rect);
            }
            if (baseColor.A > 80)
            {
                Rectangle rectTop = rect;
                if (mode == LinearGradientMode.Vertical)
                {
                    rectTop.Height = (int)(rectTop.Height * basePosition);
                }
                else
                {
                    rectTop.Width = (int)(rect.Width * basePosition);
                }
                using (SolidBrush brushAlpha =
                    new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                {
                    g.FillRectangle(brushAlpha, rectTop);
                }
            }

            if (drawBorder)
            {
                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawRectangle(pen, rect);
                }

                rect.Inflate(-1, -1);
                using (Pen pen = new Pen(innerBorderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = a + a0; }
            if (r + r0 > 255) { r = 255; } else { r = r + r0; }
            if (g + g0 > 255) { g = 255; } else { g = g + g0; }
            if (b + b0 > 255) { b = 255; } else { b = b + b0; }

            return Color.FromArgb(a, r, g, b);
        }

        private static void DrawLinearGradient(Rectangle Rec, Graphics Grp, Color Color1, Color Color2)
        {
            if (Color1 == Color2)
            {
                Brush backbrush = new SolidBrush(Color1);
                Grp.FillRectangle(backbrush, Rec);
            }
            else
            {
                using (Brush backbrush =
                    new LinearGradientBrush(Rec, Color2, Color1, 
                                            LinearGradientMode.
                                                Vertical))
                {
                    Grp.FillRectangle(backbrush, Rec);
                }
            }
        }
    }
}