﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class JMSplitContainer : SplitContainer
    {
        private Color _zBaseColor;

        [DefaultValue(typeof(Color), "105, 200, 254")]
        public Color ZBaseColor
        {
            get { return _zBaseColor; }
            set { _zBaseColor = value; Invalidate(); }
        }

        private Color _zArrowColor;

        [DefaultValue(typeof(Color), "21, 66, 139")]
        public Color ZArrowColor
        {
            get { return _zArrowColor; }
            set { _zArrowColor = value; Invalidate(); }
        }
        private CollapsePanel _collapsePanel = CollapsePanel.Panel1;
        private SpliterPanelState _spliterPanelState = SpliterPanelState.Expanded;
        private ControlState _mouseState;
        private int _lastDistance;
        private int _minSize;
        private HistTest _histTest;
        private readonly object EventCollapseClick = new object();

        public JMSplitContainer()
        {
            base.SetStyle(
                ControlStyles.UserPaint | 
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            _lastDistance = base.SplitterDistance;
            _zBaseColor = Color.FromArgb(105, 200, 254);
            _zArrowColor = Color.FromArgb(21, 66, 139);
        }

        public event EventHandler CollapseClick
        {
            add { base.Events.AddHandler(EventCollapseClick, value); }
            remove { base.Events.RemoveHandler(EventCollapseClick, value); }
        }

        [DefaultValue(typeof(CollapsePanel), "1")]
        public CollapsePanel CollapsePanel
        {
            get { return _collapsePanel; }
            set
            {
                if (_collapsePanel != value)
                {
                    Expand();
                    _collapsePanel = value;
                }
            }
        }

        protected virtual int DefaultCollapseWidth
        {
            get { return 80; }
        }

        protected virtual int DefaultArrowWidth
        {
            get { return 16; }
        }

        protected Rectangle CollapseRect
        {
            get
            {
                if (_collapsePanel == CollapsePanel.None)
                {
                    return Rectangle.Empty;
                }

                Rectangle rect = base.SplitterRectangle;
                if (base.Orientation == Orientation.Horizontal)
                {
                    rect.X = (base.Width - DefaultCollapseWidth) / 2;
                    rect.Width = DefaultCollapseWidth;
                }
                else
                {
                    rect.Y = (base.Height - DefaultCollapseWidth) / 2;
                    rect.Height = DefaultCollapseWidth;
                }

                return rect;
            }
        }

        internal SpliterPanelState SpliterPanelState
        {
            get { return _spliterPanelState; }
            set
            {
                if (_spliterPanelState != value)
                {
                    switch (value)
                    {
                        case SpliterPanelState.Expanded:
                            Expand();
                            break;
                        case SpliterPanelState.Collapsed:
                            Collapse();
                            break;

                    }
                    _spliterPanelState = value;
                }
            }
        }

        internal ControlState MouseState
        {
            get { return _mouseState; }
            set
            {
                if (_mouseState != value)
                {
                    _mouseState = value;
                    base.Invalidate(CollapseRect);
                }
            }
        }

        public void Collapse()
        {
            if (_collapsePanel != CollapsePanel.None &&
                _spliterPanelState == SpliterPanelState.Expanded)
            {
                _lastDistance = base.SplitterDistance;
                if (_collapsePanel == CollapsePanel.Panel1)
                {
                    _minSize = base.Panel1MinSize;
                    base.Panel1MinSize = 0;
                    base.SplitterDistance = 0;
                    if (_spliterPanelState != SpliterPanelState.Collapsed)
                    {
                        _spliterPanelState = SpliterPanelState.Collapsed;
                    }
                }
                else
                {
                    int width = base.Orientation == Orientation.Horizontal ?
                        base.Height : base.Width;
                    _minSize = base.Panel2MinSize;
                    base.Panel2MinSize = 0;
                    if (_spliterPanelState != SpliterPanelState.Collapsed)
                    {
                        _spliterPanelState = SpliterPanelState.Collapsed;
                    }
                    base.SplitterDistance = width - base.SplitterWidth- base.Padding.Vertical;
                }
                base.Invalidate(base.SplitterRectangle);
            }
        }

        public void Expand()
        {
            if (_collapsePanel != CollapsePanel.None &&
               _spliterPanelState == SpliterPanelState.Collapsed)
            {
                if (_collapsePanel == CollapsePanel.Panel1)
                {
                    base.Panel1MinSize = _minSize;
                }
                else
                {
                    base.Panel2MinSize = _minSize;
                }
                if (_spliterPanelState != SpliterPanelState.Expanded)
                {
                    _spliterPanelState = SpliterPanelState.Expanded;
                }
                base.SplitterDistance = _lastDistance;
                base.Invalidate(base.SplitterRectangle);

            }
        }

        protected virtual void OnCollapseClick(EventArgs e)
        {
            if (_spliterPanelState == SpliterPanelState.Collapsed)
            {
                SpliterPanelState = SpliterPanelState.Expanded;
            }
            else
            {
                SpliterPanelState = SpliterPanelState.Collapsed;
            }

            EventHandler handler = base.Events[EventCollapseClick] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (base.Panel1Collapsed || base.Panel2Collapsed)
            {
                return;
            }

            Graphics g = e.Graphics;
            Rectangle rect = base.SplitterRectangle;
            if (rect.Width <= 0 || rect.Height <= 0)
            {
                return;
            }

            bool bHorizontal = base.Orientation == Orientation.Horizontal;

            LinearGradientMode gradientMode = bHorizontal ? 
                LinearGradientMode.Vertical : LinearGradientMode.Horizontal;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, ColorClass.GetColor(_zBaseColor, 0, 100, 35, 0),
                _zBaseColor, gradientMode))//Color.FromArgb(105, 200, 254)
            {
                Blend blend = new Blend();
                blend.Positions = new float[] { 0f, .5f, 1f };
                blend.Factors = new float[] { .5F, 1F, .5F };

                brush.Blend = blend;
                g.FillRectangle(brush, rect);
            }

            if (_collapsePanel == CollapsePanel.None)
            {
                return;
            }

            Rectangle arrowRect;
            Rectangle topLeftRect;
            Rectangle bottomRightRect;

            CalculateRect(
                CollapseRect,
                out arrowRect,
                out topLeftRect,
                out bottomRightRect);

            ArrowDirection direction = ArrowDirection.Left;

            switch (_collapsePanel)
            {
                case CollapsePanel.Panel1:
                    if (bHorizontal)
                    {
                        direction =
                            _spliterPanelState == SpliterPanelState.Collapsed ?
                            ArrowDirection.Down : ArrowDirection.Up;
                    }
                    else
                    {
                        direction =
                            _spliterPanelState == SpliterPanelState.Collapsed ?
                            ArrowDirection.Right : ArrowDirection.Left;
                    }
                    break;
                case CollapsePanel.Panel2:
                    if (bHorizontal)
                    {
                        direction =
                            _spliterPanelState == SpliterPanelState.Collapsed ?
                            ArrowDirection.Up : ArrowDirection.Down;
                    }
                    else
                    {
                        direction =
                            _spliterPanelState == SpliterPanelState.Collapsed ?
                            ArrowDirection.Left : ArrowDirection.Right;
                    }
                    break;
            }

            Color foreColor = _mouseState == ControlState.Hover ?
                _zArrowColor : ColorClass.GetColor(_zArrowColor, 0, 60, 70, 90);
            using (SmoothingModeGraphics sg = new SmoothingModeGraphics(g))
            {
                ControlPaintClass.RenderGrid(g, topLeftRect, new Size(3, 3), foreColor);
                ControlPaintClass.RenderGrid(g, bottomRightRect, new Size(3, 3), foreColor);

                using (Brush brush = new SolidBrush(foreColor))
                {
                    ControlPaintClass.RenderArrowInternal(
                        g,
                        arrowRect,
                        direction,
                        brush);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //如果鼠标的左键没有按下，重置HistTest
            if (e.Button != MouseButtons.Left)
            {
                _histTest = HistTest.None;
            }

            Rectangle collapseRect = CollapseRect;
            Point mousePoint = e.Location;

            //鼠标在Button矩形里，并且不是在拖动
            if (collapseRect.Contains(mousePoint) &&
                _histTest != HistTest.Spliter)
            {
                base.Capture = false;
                SetCursor(Cursors.Hand);
                MouseState = ControlState.Hover;
                return;
            }//鼠标在分隔栏矩形里
            else if (base.SplitterRectangle.Contains(mousePoint))
            {
                MouseState = ControlState.Normal;

                //如果已经在按钮按下了鼠标或者已经收缩，就不允许拖动了
                if (_histTest == HistTest.Button ||
                    (_collapsePanel != CollapsePanel.None &&
                    _spliterPanelState == SpliterPanelState.Collapsed))
                {
                    base.Capture = false;
                    base.Cursor = Cursors.Default;
                    return;
                }

                //鼠标没有按下，设置Split光标
                if (_histTest == HistTest.None &&
                    !base.IsSplitterFixed)
                {
                    if (base.Orientation == Orientation.Horizontal)
                    {
                        SetCursor(Cursors.HSplit);
                    }
                    else
                    {
                        SetCursor(Cursors.VSplit);
                    }
                    return;
                }
            }

            MouseState = ControlState.Normal;

            //正在拖动分隔栏
            if (_histTest == HistTest.Spliter &&
                !base.IsSplitterFixed)
            {
                if (base.Orientation == Orientation.Horizontal)
                {
                    SetCursor(Cursors.HSplit);
                }
                else
                {
                    SetCursor(Cursors.VSplit);
                }
                base.OnMouseMove(e);
                return;
            }

            base.Cursor = Cursors.Default;
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.Cursor = Cursors.Default;
            MouseState = ControlState.Normal;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Rectangle collapseRect = CollapseRect;
            Point mousePoint = e.Location;

            if (collapseRect.Contains(mousePoint) ||
                (_collapsePanel != CollapsePanel.None &&
                _spliterPanelState == SpliterPanelState.Collapsed))
            {
                _histTest = HistTest.Button;
                return;
            }

            if (base.SplitterRectangle.Contains(mousePoint))
            {
                _histTest = HistTest.Spliter;
            }

            base.OnMouseDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            base.Invalidate(base.SplitterRectangle);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base.Invalidate(base.SplitterRectangle);

            Rectangle collapseRect = CollapseRect;
            Point mousePoint = e.Location;

            if (_histTest == HistTest.Button && 
                e.Button == MouseButtons.Left &&
                collapseRect.Contains(mousePoint))
            {
                OnCollapseClick(EventArgs.Empty);
            }
            _histTest = HistTest.None;
        }

        private void SetCursor(Cursor cursor)
        {
            if (base.Cursor != cursor)
            {
                base.Cursor = cursor;
            }
        }

        private void CalculateRect(
            Rectangle collapseRect,
            out Rectangle arrowRect,
            out Rectangle topLeftRect,
            out Rectangle bottomRightRect)
        {
            int width;
            if (base.Orientation == Orientation.Horizontal)
            {
                width = (collapseRect.Width - DefaultArrowWidth) / 2;
                arrowRect = new Rectangle(
                    collapseRect.X + width,
                    collapseRect.Y,
                    DefaultArrowWidth,
                    collapseRect.Height);

                topLeftRect = new Rectangle(
                    collapseRect.X,
                    collapseRect.Y + 1,
                    width,
                    collapseRect.Height - 2);

                bottomRightRect = new Rectangle(
                    arrowRect.Right,
                    collapseRect.Y + 1,
                    width,
                    collapseRect.Height - 2);
            }
            else
            {
                width = (collapseRect.Height - DefaultArrowWidth) / 2;
                arrowRect = new Rectangle(
                    collapseRect.X,
                    collapseRect.Y + width,
                    collapseRect.Width,
                    DefaultArrowWidth);

                topLeftRect = new Rectangle(
                    collapseRect.X + 1,
                    collapseRect.Y,
                    collapseRect.Width - 2,
                    width);

                bottomRightRect = new Rectangle(
                    collapseRect.X + 1,
                    arrowRect.Bottom,
                    collapseRect.Width - 2,
                    width);
            }
        }

    }
}
