using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace JMControlsEx
{
    public class HillangleFun
    {
        /// <summary>
        /// drawpie画圆，已知圆心坐标，半径，扇形角度，求扇形终射线与圆弧交叉点的坐标
        /// </summary>
        /// <param name="centerx">圆心x坐标</param>
        /// <param name="centery">圆心y坐标</param>
        /// <param name="rx">求出的坐标</param>
        /// <param name="ry">求出的坐标</param>
        /// <param name="pangle">角度</param>
        /// <param name="bj">半径</param>
        public static PointF getxy(float centerx, float centery, double pangle, float bj)
        {
            float rx;
            float ry;

            float r = bj;

            //角度 d 必须用弧度表示。乘以 π/180 将角度转换成弧度。
            double angle = Math.PI * pangle / 180.0;

            if (pangle == 0 || pangle == 360)
            {
                rx = centerx + (float)(Math.Cos(angle)) * r;
                ry = centery + (float)(Math.Sin(angle)) * r;
            }
            else if (pangle < 90)
            {
                rx = centerx + (float)(Math.Cos(angle)) * r;
                ry = centery + (float)(Math.Sin(angle)) * r;
            }
            else if (pangle == 90)
            {
                rx = centerx;
                ry = centery + r;
            }
            else if (pangle > 90 && pangle < 180)
            {
                angle = Math.PI * (180 - pangle) / 180.0;
                rx = centerx - (float)(Math.Cos(angle)) * r;
                ry = centery + (float)(Math.Sin(angle)) * r;
            }
            else if (pangle == 180)
            {
                rx = centerx - r;
                ry = centery;
            }
            else if (pangle > 180 && pangle < 270)
            {
                angle = Math.PI * (pangle - 180) / 180.0;
                rx = centerx - (float)(Math.Cos(angle)) * r;
                ry = centery - (float)(Math.Sin(angle)) * r;
            }
            else if (pangle == 270)
            {
                rx = centerx;
                ry = centery - r;
            }
            else
            {
                angle = Math.PI * (360 - pangle) / 180.0;
                rx = centerx + (float)(Math.Cos(angle)) * r - 10;
                ry = centery - (float)(Math.Sin(angle)) * r;
            }

            return new PointF(rx, ry);
        }
    }
}
