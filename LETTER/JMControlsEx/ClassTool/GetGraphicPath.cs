using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace JMControlsEx
{
    /// <summary>
    /// 获取各种图形路径
    /// </summary>
    internal static class GetGraphicPath
    {
        /// <summary>
        /// 建立带有圆角样式的路径。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="_radius">圆角的大小。</param>
        /// <param name="style">圆角的样式。</param>
        /// <param name="correction">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>建立的路径。</returns>
        internal static GraphicsPath CreatePath(Rectangle rect, int radius, RoundStyle style, bool correction)
        {
            GraphicsPath path = new GraphicsPath();
            int radiusCorrection = correction ? 1 : 0;
            switch (style)
            {
                case RoundStyle.None:
                    path.AddRectangle(rect);
                    break;
                case RoundStyle.All:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius, 0, 90);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    break;
                case RoundStyle.Left:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddLine(
                        rect.Right - radiusCorrection, rect.Y,
                        rect.Right - radiusCorrection, rect.Bottom - radiusCorrection);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    break;
                case RoundStyle.Right:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddArc(
                       rect.Right - radius - radiusCorrection,
                       rect.Bottom - radius - radiusCorrection,
                       radius,
                       radius,
                       0,
                       90);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
                    break;
                case RoundStyle.Top:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddLine(
                        rect.Right - radiusCorrection, rect.Bottom - radiusCorrection,
                        rect.X, rect.Bottom - radiusCorrection);
                    break;
                case RoundStyle.Bottom:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        0,
                        90);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    break;
                case RoundStyle.BottomLeft:
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    path.AddLine(
                        rect.Right - radiusCorrection,
                        rect.Y,
                        rect.Right - radiusCorrection,
                        rect.Bottom - radiusCorrection);
                    break;
                case RoundStyle.BottomRight:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        0,
                        90);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    break;
                case RoundStyle.TopRight:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddLine(
                        rect.Right - radiusCorrection, rect.Bottom - radiusCorrection,
                        rect.X, rect.Bottom - radiusCorrection);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
                    break;
                case RoundStyle.TopLeft:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddLine(
                        rect.Right - radiusCorrection, rect.Y,
                        rect.Right - radiusCorrection, rect.Bottom - radiusCorrection);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y + radius);
                    break;
            }
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// 建立带有圆角样式的路径上半部。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="_radius">圆角的大小。</param>
        /// <param name="correction">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>建立的路径。</returns>
        internal static GraphicsPath CreatePathTOP(Rectangle rect, int radius, bool correction, int jd)
        {
            GraphicsPath path = new GraphicsPath();
            int radiusCorrection = correction ? 1 : 0;
            path.AddArc(rect.X, rect.Y, radius, radius, 270 - jd, jd);
            path.AddArc(
                rect.Right - radius - radiusCorrection,
                rect.Y,
                radius,
                radius,
                270,
                jd);
            return path;
        }

        /// <summary>
        /// 建立带有圆角样式的路径底部。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="_radius">圆角的大小。</param>
        /// <param name="correction">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>建立的路径。</returns>
        internal static GraphicsPath CreatePathBottom(Rectangle rect, int radius, bool correction, int jd)
        {
            GraphicsPath path = new GraphicsPath();
            int radiusCorrection = correction ? 1 : 0;
            path.AddArc(
                rect.Right - radius - radiusCorrection,
                rect.Bottom - radius - radiusCorrection,
                radius,
                radius,
                90 - jd,
                jd);
            path.AddArc(
                rect.X,
                rect.Bottom - radius - radiusCorrection,
                radius,
                radius,
                90,
                jd);

            return path;
        }

        /// <summary>
        /// 建立带有圆角样式的路径。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="_radius">圆角的大小。</param>
        /// <param name="style">圆角的样式。</param>
        /// <param name="correction">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>建立的路径。</returns>
        internal static GraphicsPath CreatePathSJ(Rectangle rect, int radius, RoundStyle style, bool correction)
        {
            GraphicsPath path = new GraphicsPath();
            int radiusCorrection = correction ? 1 : 0;
            path.AddLine(new Point(0, rect.Height / 2), new Point(rect.Width / 4, 0));
            path.AddArc(
                rect.Right - radius - radiusCorrection,
                rect.Y,
                radius,
                radius,
                270,
                90);
            path.AddArc(
                rect.Right - radius - radiusCorrection,
                rect.Bottom - radius - radiusCorrection,
                radius,
                radius, 0, 90);
            path.AddLine(new Point(rect.Width, rect.Height), new Point(rect.Width / 4, rect.Height));
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// X路径
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <returns>建立的路径。</returns>
        internal static GraphicsPath CreateCloseFlagPath(Rectangle rect)
        {
            PointF centerPoint = new PointF(
                rect.X + rect.Width / 2.0f,
                rect.Y + rect.Height / 2.0f);

            GraphicsPath path = new GraphicsPath();

            path.AddLine(
                centerPoint.X,
                centerPoint.Y - 2,
                centerPoint.X - 2,
                centerPoint.Y - 4);
            path.AddLine(
                centerPoint.X - 2,
                centerPoint.Y - 4,
                centerPoint.X - 6,
                centerPoint.Y - 4);
            path.AddLine(
                centerPoint.X - 6,
                centerPoint.Y - 4,
                centerPoint.X - 2,
                centerPoint.Y);
            path.AddLine(
                centerPoint.X - 2,
                centerPoint.Y,
                centerPoint.X - 6,
                centerPoint.Y + 4);
            path.AddLine(
                centerPoint.X - 6,
                centerPoint.Y + 4,
                centerPoint.X - 2,
                centerPoint.Y + 4);
            path.AddLine(
                centerPoint.X - 2,
                centerPoint.Y + 4,
                centerPoint.X,
                centerPoint.Y + 2);
            path.AddLine(
                centerPoint.X,
                centerPoint.Y + 2,
                centerPoint.X + 2,
                centerPoint.Y + 4);
            path.AddLine(
               centerPoint.X + 2,
               centerPoint.Y + 4,
               centerPoint.X + 6,
               centerPoint.Y + 4);
            path.AddLine(
              centerPoint.X + 6,
              centerPoint.Y + 4,
              centerPoint.X + 2,
              centerPoint.Y);
            path.AddLine(
             centerPoint.X + 2,
             centerPoint.Y,
             centerPoint.X + 6,
             centerPoint.Y - 4);
            path.AddLine(
             centerPoint.X + 6,
             centerPoint.Y - 4,
             centerPoint.X + 2,
             centerPoint.Y - 4);

            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// (最小化)路径
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <returns>建立的路径。</returns>
        internal static GraphicsPath CreateMinimizeFlagPath(Rectangle rect)
        {
            PointF centerPoint = new PointF(
                rect.X + rect.Width / 2.0f,
                rect.Y + rect.Height / 2.0f);

            GraphicsPath path = new GraphicsPath();

            path.AddRectangle(new RectangleF(
                centerPoint.X - 6,
                centerPoint.Y + 1,
                12,
                3));
            return path;
        }

        /// <summary>
        /// (最大化与还原)路径
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="maximize">是否最大化</param>
        /// <returns>建立的路径。</returns>
        internal static GraphicsPath CreateMaximizeFlafPath(
            Rectangle rect, bool maximize)
        {
            PointF centerPoint = new PointF(
               rect.X + rect.Width / 2.0f,
               rect.Y + rect.Height / 2.0f);

            GraphicsPath path = new GraphicsPath();

            if (maximize)
            {
                path.AddLine(
                    centerPoint.X - 3,
                    centerPoint.Y - 3,
                    centerPoint.X - 6,
                    centerPoint.Y - 3);
                path.AddLine(
                    centerPoint.X - 6,
                    centerPoint.Y - 3,
                    centerPoint.X - 6,
                    centerPoint.Y + 5);
                path.AddLine(
                    centerPoint.X - 6,
                    centerPoint.Y + 5,
                    centerPoint.X + 3,
                    centerPoint.Y + 5);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y + 5,
                    centerPoint.X + 3,
                    centerPoint.Y + 1);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y + 1,
                    centerPoint.X + 6,
                    centerPoint.Y + 1);
                path.AddLine(
                    centerPoint.X + 6,
                    centerPoint.Y + 1,
                    centerPoint.X + 6,
                    centerPoint.Y - 6);
                path.AddLine(
                    centerPoint.X + 6,
                    centerPoint.Y - 6,
                    centerPoint.X - 3,
                    centerPoint.Y - 6);
                path.CloseFigure();

                path.AddRectangle(new RectangleF(
                    centerPoint.X - 4,
                    centerPoint.Y,
                    5,
                    3));

                path.AddLine(
                    centerPoint.X - 1,
                    centerPoint.Y - 4,
                    centerPoint.X + 4,
                    centerPoint.Y - 4);
                path.AddLine(
                    centerPoint.X + 4,
                    centerPoint.Y - 4,
                    centerPoint.X + 4,
                    centerPoint.Y - 1);
                path.AddLine(
                    centerPoint.X + 4,
                    centerPoint.Y - 1,
                    centerPoint.X + 3,
                    centerPoint.Y - 1);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y - 1,
                    centerPoint.X + 3,
                    centerPoint.Y - 3);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y - 3,
                    centerPoint.X - 1,
                    centerPoint.Y - 3);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(new RectangleF(
                    centerPoint.X - 6,
                    centerPoint.Y - 4,
                    12,
                    8));
                path.AddRectangle(new RectangleF(
                    centerPoint.X - 3,
                    centerPoint.Y - 1,
                    6,
                    3));
            }

            return path;
        }

        /// <summary>
        /// 获取扇形厚度路径（3D）
        /// </summary>
        /// <param name="m_boundingRectangle">扇形绘制区域</param>
        /// <param name="startAngle">起始角度</param>
        /// <param name="endAngle">终止角度</param>
        /// <param name="pointStart">起始角度坐标</param>
        /// <param name="pointEnd">终止角度坐标</param>
        /// <param name="He">高度</param>
        /// <returns></returns>
        internal static GraphicsPath CreatePathForCylinderSurfaceSection(Rectangle m_boundingRectangle, float startAngle, float endAngle, PointF pointStart, PointF pointEnd, int He)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(m_boundingRectangle, startAngle, endAngle - startAngle);
            //path.AddLine(pointEnd.X, pointEnd.Y, pointEnd.X, pointEnd.Y + He);
            path.AddArc(m_boundingRectangle.X, m_boundingRectangle.Y + He, m_boundingRectangle.Width, m_boundingRectangle.Height, endAngle, startAngle - endAngle);
            //path.AddLine(pointStart.X, pointStart.Y + He, pointStart.X, pointStart.Y);
            return path;
        }

        internal static GraphicsPath CreateTrackBarThumbPath(
            Rectangle rect, ThumbArrowDirection arrowDirection)
        {
            GraphicsPath path = new GraphicsPath();
            PointF centerPoint = new PointF(
                rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
            float offset = 0;

            switch (arrowDirection)
            {
                case ThumbArrowDirection.Left:
                case ThumbArrowDirection.Right:
                    offset = rect.Width / 2f - 4;
                    break;
                case ThumbArrowDirection.Up:
                case ThumbArrowDirection.Down:
                    offset = rect.Height / 2f - 4;
                    break;
            }

            switch (arrowDirection)
            {
                case ThumbArrowDirection.Left:
                    path.AddLine(
                        rect.X, centerPoint.Y, rect.X + offset, rect.Y);
                    path.AddLine(
                        rect.Right, rect.Y, rect.Right, rect.Bottom);
                    path.AddLine(
                        rect.X + offset, rect.Bottom, rect.X, centerPoint.Y);
                    break;
                case ThumbArrowDirection.Right:
                    path.AddLine(
                        rect.Right, centerPoint.Y, rect.Right - offset, rect.Bottom);
                    path.AddLine(
                        rect.X, rect.Bottom, rect.X, rect.Y);
                    path.AddLine(
                        rect.Right - offset, rect.Y, rect.Right, centerPoint.Y);
                    break;
                case ThumbArrowDirection.Up:
                    path.AddLine(
                        centerPoint.X, rect.Y, rect.X, rect.Y + offset);
                    path.AddLine(
                        rect.X, rect.Bottom, rect.Right, rect.Bottom);
                    path.AddLine(
                        rect.Right, rect.Y + offset, centerPoint.X, rect.Y);
                    break;
                case ThumbArrowDirection.Down:
                    path.AddLine(
                         centerPoint.X, rect.Bottom, rect.X, rect.Bottom - offset);
                    path.AddLine(
                        rect.X, rect.Y, rect.Right, rect.Y);
                    path.AddLine(
                        rect.Right, rect.Bottom - offset, centerPoint.X, rect.Bottom);
                    break;
                case ThumbArrowDirection.LeftRight:
                    break;
                case ThumbArrowDirection.UpDown:
                    break;
                case ThumbArrowDirection.None:
                    path.AddRectangle(rect);
                    break;
            }

            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// 放大镜
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        internal static GraphicsPath CreateMagnifierPath(
            Rectangle rect)
        {
            //rect.Offset(rect.Width / 4, rect.Height / 4);
            //rect.Width -= rect.Width / 2;
            //rect.Height -= rect.Height / 2;

            int pyl = 7;
            int r;
            int cx;
            int cy;
            double angle = 40;
            if (rect.Width >= rect.Height)
            {
                r = rect.Height / 6;
                cx = rect.X + r + (rect.Width - rect.Height);
                cy = rect.Y + r;
            }
            else
            {
                r = rect.Width / 6;
                cx = rect.X + r;
                cy = rect.Y + r + (rect.Height - rect.Width);
            }

            cx += pyl;
            cy += pyl;

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(cx - r, cy - r, 2 * r, 2 * r);
            PointF pt = HillangleFun.getxy(cx, cy, angle, r);
            PointF pt1 = HillangleFun.getxy(cx, cy, angle, 4 * r);
            path.AddLine(pt1, pt);
            return path;
        }

        /// <summary>
        /// V形
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        internal static GraphicsPath CreateVPath(
            Rectangle rect)
        {

            GraphicsPath path = new GraphicsPath();
            PointF pt = new PointF(rect.X + rect.Width / 2, rect.Y + (rect.Height - rect.Height / 5 * 2 - 2));
            PointF pt1 = new PointF(rect.X + rect.Width / 3, rect.Y + rect.Height / 3 + 2);
            PointF pt2 = new PointF(rect.X + (rect.Width - rect.Width / 3), rect.Y + rect.Height / 3 + 2);
            path.AddLine(pt1, pt);
            path.AddLine(pt2, pt);
            return path;
        }

        /// <summary>
        /// V形
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        internal static GraphicsPath CreateVPath(
            Rectangle rect, int py, bool bl)
        {
            GraphicsPath path = new GraphicsPath();
            int rx = rect.Width / 2;
            int ry = rect.Height / 2;
            PointF pt;
            PointF pt1;
            PointF pt2;
            if (bl)
            {
                ry -= 2;
                pt = new PointF(rect.X + rx, rect.Y + ry + py);
                pt1 = new PointF(rect.X + rx - py * 2.5f, rect.Y + ry - py * 2);
                pt2 = new PointF(rect.X + rx + py * 2.5f, rect.Y + ry - py * 2);
            }
            else
            {
                ry -= 2;
                pt = new PointF(rect.X + rx + py, rect.Y + ry);
                pt1 = new PointF(rect.X + rx - py * 2, rect.Y + ry - py * 2.5f);
                pt2 = new PointF(rect.X + rx - py * 2, rect.Y + ry + py * 2.5f);
            }
            path.AddLine(pt1, pt);
            path.AddLine(pt2, pt);
            return path;
        }

        internal static GraphicsPath CreateUnExPlanPath(
            Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            int rx = (rect.Width) / 2;
            int ry = (rect.Height) / 2;

            
            Point pth1 = new Point(rect.X + 2, rect.Y + ry);
            Point pth2 = new Point(rect.X + rect.Width - 2, rect.Y + ry);
            path.AddLine(pth1, pth2);

            path.AddRectangle(rect);

            Point ptv1 = new Point(rect.X + rx, rect.Y + 2);
            Point ptv2 = new Point(rect.X + rx, rect.Y + rect.Height - 2);
            path.AddLine(ptv1, ptv2);
            
            return path;
        }

        /// <summary>
        /// 山脚形
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        internal static GraphicsPath CreateShanJiaoPath(
            Rectangle rect)
        {
            int w3 = rect.Width / 3;
            int w6 = rect.Width / 6;
            int h3 = rect.Height / 3;

            GraphicsPath path = new GraphicsPath();
            PointF pt = new PointF(rect.X + w3, rect.Y + h3);
            PointF pt1 = new PointF(rect.X + rect.Width - w3, rect.Y + h3);
            PointF pt2 = new PointF(rect.X + w3 + w6, rect.Y + (rect.Height - h3));
            path.AddLine(pt1, pt);
            path.AddLine(pt, pt2);
            path.AddLine(pt2, pt1);
            return path;
        }
    }
}
