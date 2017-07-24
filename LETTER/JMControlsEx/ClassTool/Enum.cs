using System;
using System.Collections.Generic;
using System.Text;

namespace JMControlsEx
{
    public enum PageButtonType
    {
        None,
        First,
        End,
        Befor,
        Next
    }

    public enum Weekzh
    {
        周一,
        周二,
        周三,
        周四,
        周五,
        周六,
        周日
    }

    public enum DateListType
    {
        Year, Month
    }

    public enum SearchMode
    {
        StartWith, Contains
    }

    internal enum SpliterPanelState
    {
        Collapsed = 0,
        Expanded = 1,
    }

    /// <summary>
    /// 点击SplitContainer控件收缩按钮时隐藏的Panel。
    /// </summary>
    public enum CollapsePanel
    {
        None = 0,
        Panel1 = 1,
        Panel2 = 2,
    }

    internal enum HistTest
    {
        None,
        Button,
        Spliter
    }

    public enum VistaCalendarStyle
    {
        Default,
        Blue
    }

    /// <summary>
    /// 滚动方式
    /// </summary>
    public enum ScrollDirection
    {
        RightToLeft,
        LeftToRight,
        Bouncing,
        TopToBotom,
        BotomToTop,
        TopWithBotom
    }

    /// <summary>
    /// 水平对齐方式
    /// </summary>
    public enum VerticleTextPosition
    {
        Top,
        Center,
        Botom
    }

    /// <summary>
    /// 水平对齐方式
    /// </summary>
    public enum HorTextPosition
    {
        Left,
        Center,
        Right
    }

    /// <summary>
    /// 显示方式
    /// </summary>
    public enum JMDataType
    {
        NONE = 1,
        JMDATETIME = 2,
        JMDECIMAL = 3,
        JMEMAIL = 4,
        JMIP = 5
    }

    /// <summary>
    /// 显示方式
    /// </summary>
    public enum ShowType
    {
        Left = 0x0001,
        Right = 0x0002,
        Top = 0x0004,
        Bottom = 0x0008
    }

    /// <summary>
    /// 最大化、最小化、关闭3种按钮状态
    /// </summary>
    public enum WinButState
    {
        /// <summary>
        /// 无
        /// </summary>
        NONE = 0,
        /// <summary>
        /// 最小化激活
        /// </summary>
        MINH = 1,
        /// <summary>
        /// 最小化按下
        /// </summary>
        MINP = 2,
        /// <summary>
        /// 最大化激活
        /// </summary>
        MAXH = 3,
        /// <summary>
        /// 最大化按下
        /// </summary>
        MAXP = 4,
        /// <summary>
        /// 关闭激活
        /// </summary>
        CLOH = 5,
        /// <summary>
        /// 关闭按下
        /// </summary>
        CLOP = 6,
        /// <summary>
        /// 皮肤激活
        /// </summary>
        PFH = 7,
        /// <summary>
        /// 皮肤按下
        /// </summary>
        PFP = 8,
        /// <summary>
        /// VIP激活
        /// </summary>
        VIPH = 9,
        /// <summary>
        /// VIP按下
        /// </summary>
        VIPP = 10,
        /// <summary>
        /// 用户反馈激活
        /// </summary>
        UserH = 11,
        /// <summary>
        /// 用户反馈按下
        /// </summary>
        UserP = 12,
        /// <summary>
        /// 主界面激活
        /// </summary>
        MainH = 13,
        /// <summary>
        /// 主界面按下
        /// </summary>
        MainP = 14
    }

    /// <summary>
    /// 下拉框按钮状态
    /// </summary>
    public enum ComboBoxButtonState
    {
        /// <summary>
        /// 默认
        /// </summary>
        STATE_SYSTEM_NONE = 0,
        /// <summary>
        /// 不可用
        /// </summary>
        STATE_SYSTEM_INVISIBLE = 0x00008000,
        /// <summary>
        /// 按下
        /// </summary>
        STATE_SYSTEM_PRESSED = 0x00000008
    }

    /// <summary>
    /// 文本框类型
    /// </summary>
    public enum TextStyle
    {
        /// <summary>
        /// 底线
        /// </summary>
        Line,
        /// <summary>
        /// 边框
        /// </summary>
        Rec
    }

    /// <summary>
    /// 控件的状态。
    /// </summary>
    public enum ControlState
    {
        /// <summary>
        ///  正常。
        /// </summary>
        Normal,
        /// <summary>
        /// 鼠标进入。
        /// </summary>
        Hover,
        /// <summary>
        /// 鼠标按下。
        /// </summary>
        Pressed,
        /// <summary>
        /// 获得焦点。
        /// </summary>
        Focused,
    }

    /// <summary>
    /// 建立圆角路径的样式。
    /// </summary>
    public enum RoundStyle
    {
        /// <summary>
        /// 四个角都不是圆角。
        /// </summary>
        None = 0,
        /// <summary>
        /// 四个角都为圆角。
        /// </summary>
        All = 1,
        /// <summary>
        /// 左边两个角为圆角。
        /// </summary>
        Left = 2,
        /// <summary>
        /// 右边两个角为圆角。
        /// </summary>
        Right = 3,
        /// <summary>
        /// 上边两个角为圆角。
        /// </summary>
        Top = 4,
        /// <summary>
        /// 下边两个角为圆角。
        /// </summary>
        Bottom = 5,
        /// <summary>
        /// 左下角为圆角。
        /// </summary>
        BottomLeft = 6,
        /// <summary>
        /// 右下角为圆角。
        /// </summary>
        BottomRight = 7,
        /// <summary>
        /// 左上角为圆角。
        /// </summary>
        TopLeft = 8,
        /// <summary>
        /// 右上角为圆角。
        /// </summary>
        TopRight = 9,
    }

    public enum ThumbArrowDirection
    {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4,
        LeftRight = 5,
        UpDown = 6
    }

    public enum JMDisplayStyle
    {
        None,
        Cylinder,
        Cube
    }

    public enum ShowAlign
    {
        Top,
        Left,
        Right,
        Bottom,
        BottomRight
    }
}
