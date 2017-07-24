using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JMControlsEx
{
    internal class TextFormat
    {
        internal static TextFormatFlags GetTextFormatFlags(ContentAlignment alignment, bool rightToleft)
        {
            TextFormatFlags flags = TextFormatFlags.WordBreak | TextFormatFlags.SingleLine;

            if (rightToleft)
            {
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }

            switch (alignment)
            {
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
            }
            return flags;
        }

        //internal static TextFormatFlags GetTextFormatFlags(ContentAlignment alignment, bool rightToleft)
        //{
        //    TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.WordBreak;
        //    if (rightToleft)
        //    {
        //        flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
        //    }
        //    ContentAlignment alignment2 = alignment;
        //    if (alignment2 <= ContentAlignment.MiddleCenter)
        //    {
        //        switch (alignment2)
        //        {
        //            case ContentAlignment.TopLeft:
        //                return flags;

        //            case ContentAlignment.TopCenter:
        //                return (flags | TextFormatFlags.HorizontalCenter);

        //            case (ContentAlignment.TopCenter | ContentAlignment.TopLeft):
        //                return flags;

        //            case ContentAlignment.TopRight:
        //                return (flags | TextFormatFlags.Right);

        //            case ContentAlignment.MiddleLeft:
        //                return (flags | TextFormatFlags.VerticalCenter);

        //            case ContentAlignment.MiddleCenter:
        //                return (flags | (TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter));
        //        }
        //        return flags;
        //    }
        //    if (alignment2 <= ContentAlignment.BottomLeft)
        //    {
        //        switch (alignment2)
        //        {
        //            case ContentAlignment.MiddleRight:
        //                return (flags | (TextFormatFlags.VerticalCenter | TextFormatFlags.Right));

        //            case ContentAlignment.BottomLeft:
        //                return (flags | TextFormatFlags.Bottom);
        //        }
        //        return flags;
        //    }
        //    if (alignment2 != ContentAlignment.BottomCenter)
        //    {
        //        if (alignment2 != ContentAlignment.BottomRight)
        //        {
        //            return flags;
        //        }
        //        return (flags | (TextFormatFlags.Bottom | TextFormatFlags.Right));
        //    }
        //    return (flags | (TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter));
        //}
    }
}
