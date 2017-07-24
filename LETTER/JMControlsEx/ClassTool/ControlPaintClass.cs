using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JMControlsEx
{
    /// <summary>
    /// 画各种形状
    /// </summary>
    public static class ControlPaintClass
    {
        internal static void JDrawPath(
            Graphics g,
            GraphicsPath path,
            Color borderColor,
            float width)
        {
            g.DrawPath(new Pen(borderColor, width), path);
        }

        internal static void JFillPaht(
            Graphics g,
            GraphicsPath path,
            LinearGradientBrush lbrush)
        {
            g.FillPath(lbrush, path);
        }

        /// <summary>
        /// 画圆角渐变矩形(圆角弧度默认为8)
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="rect">矩形区域</param>
        /// <param name="baseColor">填充颜色</param>
        /// <param name="borderColor">外边框颜色</param>
        /// <param name="innerBorderColor">内边框颜色</param>
        /// <param name="style">圆角样式</param>
        /// <param name="drawBorder">是否画边框</param>
        /// <param name="drawGlass">是否画高亮区域</param>
        /// <param name="mode">渐变方向</param>
        internal static void RenderBackgroundInternal(
            Graphics g,
            Rectangle rect,
            Color baseColor,
            Color borderColor,
            Color innerBorderColor,
            RoundStyle style,
            bool drawBorder,
            bool drawGlass,
            LinearGradientMode mode)
        {
            RenderBackgroundInternal(
                g,
                rect,
                baseColor,
                borderColor,
                innerBorderColor,
                style,
                8,
                drawBorder,
                drawGlass,
                mode);
        }

        /// <summary>
        /// 画圆角渐变矩形
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="rect">矩形区域</param>
        /// <param name="baseColor">填充颜色</param>
        /// <param name="borderColor">外边框颜色</param>
        /// <param name="innerBorderColor">内边框颜色</param>
        /// <param name="style">圆角样式</param>
        /// <param name="roundWidth">圆角弧度</param>
        /// <param name="drawBorder">是否画边框</param>
        /// <param name="drawGlass">是否画高亮区域</param>
        /// <param name="mode">渐变方向</param>
        internal static void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           RoundStyle style,
           int roundWidth,
           bool drawBorder,
           bool drawGlass,
           LinearGradientMode mode)
        {
            RenderBackgroundInternal(
                 g,
                 rect,
                 baseColor,
                 borderColor,
                 innerBorderColor,
                 style,
                 8,
                 0.45f,
                 drawBorder,
                 drawGlass,
                 150,
                 mode);
        }

        /// <summary>
        /// 画圆角渐变矩形
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="rect">矩形区域</param>
        /// <param name="baseColor">填充颜色</param>
        /// <param name="borderColor">外边框颜色</param>
        /// <param name="innerBorderColor">内边框颜色</param>
        /// <param name="style">圆角样式</param>
        /// <param name="roundWidth">圆角弧度</param>
        /// <param name="basePosition">渐变占用比率(0.5为一半)</param>
        /// <param name="drawBorder">是否画边框</param>
        /// <param name="drawGlass">是否画高亮区域</param>
        /// <param name="GlassLight">高亮亮度</param>
        /// <param name="mode">渐变方向</param>
        internal static void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           RoundStyle style,
           int roundWidth,
           float basePosition,
           bool drawBorder,
           bool drawGlass,
           LinearGradientMode mode)
        {
            RenderBackgroundInternal(
                 g,
                 rect,
                 baseColor,
                 borderColor,
                 innerBorderColor,
                 style,
                 8,
                 basePosition,
                 drawBorder,
                 drawGlass,
                 150,
                 mode);
        }

        /// <summary>
        /// 画圆角渐变矩形
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="rect">矩形区域</param>
        /// <param name="baseColor">填充颜色</param>
        /// <param name="borderColor">外边框颜色</param>
        /// <param name="innerBorderColor">内边框颜色</param>
        /// <param name="style">圆角样式</param>
        /// <param name="roundWidth">圆角弧度</param>
        /// <param name="basePosition">渐变占用比率(0.5为一半)</param>
        /// <param name="drawBorder">是否画边框</param>
        /// <param name="drawGlass">是否画高亮区域</param>
        /// <param name="GlassLight">高亮亮度</param>
        /// <param name="mode">渐变方向</param>
        internal static void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           RoundStyle style,
           int roundWidth,
           float basePosition,
           bool drawBorder,
           bool drawGlass,
            int GlassLight,
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
                colors[0] = ColorClass.GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = ColorClass.GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = ColorClass.GetColor(baseColor, 0, 35, 24, 9);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                if (style != RoundStyle.None)
                {
                    using (GraphicsPath path =
                        GetGraphicPath.CreatePath(rect, roundWidth, style, false))
                    {
                        g.FillPath(brush, path);
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
                        using (GraphicsPath pathTop = GetGraphicPath.CreatePath(
                            rectTop, roundWidth, RoundStyle.Top, false))
                        {
                            using (SolidBrush brushAlpha =
                                new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                            {
                                g.FillPath(brushAlpha, pathTop);
                            }
                        }
                    }

                    if (drawGlass)
                    {
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + rect.Height * basePosition;
                            glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                        }
                        else
                        {
                            glassRect.X = rect.X + rect.Width * basePosition;
                            glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                        }
                        DrawGlass(g, glassRect, GlassLight, 0);
                    }

                    if (drawBorder)
                    {
                        using (GraphicsPath path =
                            GetGraphicPath.CreatePath(rect, roundWidth, style, false))
                        {
                            using (Pen pen = new Pen(borderColor))
                            {
                                g.DrawPath(pen, path);
                            }
                        }

                        rect.Inflate(-1, -1);
                        using (GraphicsPath path =
                            GetGraphicPath.CreatePath(rect, roundWidth, style, false))
                        {
                            using (Pen pen = new Pen(innerBorderColor))
                            {
                                g.DrawPath(pen, path);
                            }
                        }
                    }
                }
                else
                {
                    g.FillRectangle(brush, rect);
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
                            new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                        {
                            g.FillRectangle(brushAlpha, rectTop);
                        }
                    }

                    if (drawGlass)
                    {
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + rect.Height * basePosition;
                            glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                        }
                        else
                        {
                            glassRect.X = rect.X + rect.Width * basePosition;
                            glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                        }
                        DrawGlass(g, glassRect, GlassLight, 0);
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
            }
        }

        /// <summary>
        /// 画山角(默认大小4)
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="dropDownRect">矩形区域</param>
        /// <param name="direction">山角号指向</param>
        /// <param name="brush">画刷</param>
        internal static void RenderArrowInternal(
            Graphics g,
            Rectangle dropDownRect,
            ArrowDirection direction,
            Brush brush)
        {
            RenderArrowInternal(
            g,
            dropDownRect,
            direction,
            4,
            brush);
        }

        /// <summary>
        /// 画山角
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="dropDownRect">矩形区域</param>
        /// <param name="direction">山角号指向</param>
        /// <param name="size">大小</param>
        /// <param name="brush">画刷</param>
        internal static void RenderArrowInternal(
            Graphics g,
            Rectangle dropDownRect,
            ArrowDirection direction,
            int size,
            Brush brush)
        {
            Point point = new Point(
                dropDownRect.Left + (dropDownRect.Width / 2),
                dropDownRect.Top + (dropDownRect.Height / 2));
            Point[] points = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new Point[] { 
                        new Point(point.X + size/2, point.Y - size), 
                        new Point(point.X + size/2, point.Y + size), 
                        new Point(point.X - size/2, point.Y) };
                    break;

                case ArrowDirection.Up:
                    points = new Point[] { 
                        new Point(point.X - size, point.Y + size/2), 
                        new Point(point.X + size, point.Y + size/2), 
                        new Point(point.X, point.Y - size/2) };
                    break;

                case ArrowDirection.Right:
                    points = new Point[] {
                        new Point(point.X - size/2, point.Y - size), 
                        new Point(point.X - size/2, point.Y + size), 
                        new Point(point.X + size/2, point.Y) };
                    break;

                default:
                    points = new Point[] {
                        new Point(point.X - size, point.Y - size/2), 
                        new Point(point.X + size, point.Y - size/2), 
                        new Point(point.X, point.Y + size/2) };
                    break;
            }
            g.FillPolygon(brush, points);
        }

        /// <summary>
        /// 画高亮区域
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="glassRect">矩形区域</param>
        /// <param name="alphaCenter"></param>
        /// <param name="alphaSurround"></param>
        internal static void DrawGlass(
            Graphics g, RectangleF glassRect, int alphaCenter, int alphaSurround)
        {
            DrawGlass(g, glassRect, Color.White, alphaCenter, alphaSurround);
        }

        /// <summary>
        /// 画高亮区域
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="glassRect">矩形区域</param>
        /// <param name="glassColor"></param>
        /// <param name="alphaCenter"></param>
        /// <param name="alphaSurround"></param>
        internal static void DrawGlass(
           Graphics g,
            RectangleF glassRect,
            Color glassColor,
            int alphaCenter,
            int alphaSurround)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(glassRect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(alphaCenter, glassColor);
                    brush.SurroundColors = new Color[] { 
                        Color.FromArgb(alphaSurround, glassColor) };
                    brush.CenterPoint = new PointF(
                        glassRect.X + glassRect.Width / 2,
                        glassRect.Y + glassRect.Height / 2);
                    g.FillPath(brush, path);
                }
            }
        }

        /// <summary>
        /// 有“点”填充区域
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="rect">矩形区域</param>
        /// <param name="pixelsBetweenDots">每个点距离</param>
        /// <param name="outerColor">点的颜色</param>
        internal static void RenderGrid(
            Graphics g,
            Rectangle rect,
            Size pixelsBetweenDots,
            Color outerColor)
        {
            int outerWin32Corlor = ColorTranslator.ToWin32(outerColor);//获取颜色
            IntPtr hdc = g.GetHdc();//创建画板句柄

            //循环横坐标
            for (int x = rect.X; x <= rect.Right; x += pixelsBetweenDots.Width)
            {
                //循环纵坐标
                for (int y = rect.Y; y <= rect.Bottom; y += pixelsBetweenDots.Height)
                {
                    //画一个点
                    Win32.SetPixel(hdc, x, y, outerWin32Corlor);
                }
            }
            g.ReleaseHdc(hdc);//释放画板句柄
        }


    }
}