using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace JMControlsEx
{
    [Designer(typeof(TextBoxDesigner)), DesignTimeVisibleAttribute(true)]
    [ToolboxBitmap(typeof(System.Windows.Forms.TextBox))]
    public class JMTextBox : TextBox
    {
        public delegate void EventHandler();

        public event EventHandler JMTextChanged;

        public event JMDelegate.ClickHandel jmbeforclick;

        public event JMDelegate.ClickHandel jmendclick;

        private const int WM_PASTE = 0x0302;//粘貼消息 

        #region 私有变量
        //外观
        private Color _BorderColor;//边框颜色
        private Color _HotColor;//热点颜色
        private TextStyle _ShowStyle;//文本框类型 (四边框、线)
        private ControlState isFouc;//是否选中

        private string _emptyTextTip;//水印内容
        private Color _emptyTextTipColor;//水印颜色

        private ToolTip toolTip1;
        private IContainer components;

        private JMDataType _dtype;//显示数据类型

        private Color _ZBlackColor = Color.White;

        //小数点类型
        /// <summary>
        /// 小数位数
        /// </summary>
        private int _median;//
        /// <summary>
        /// 负数
        /// </summary>
        private bool _negative;//
        /// <summary>
        /// 当前光标是否在小数点后
        /// </summary>
        private bool _afternegative;//
        /// <summary>
        /// 当前光标在小数点后第几位
        /// </summary>
        private int _negativemedian;//

        /// <summary>
        /// 日期类型格式
        /// </summary>
        private string _format;

        /// <summary>
        /// 是否为信用卡
        /// </summary>
        private bool _isXYK = false;

        public bool IsXYK
        {
            get { return _isXYK; }
            set { _isXYK = value; }
        }
        #endregion

        #region 构造函数
        public JMTextBox()
            : base()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            _BorderColor = ColorClass.GetBColor();
            _HotColor = ColorClass.GetColor(_BorderColor, _BorderColor.A, 50, 50, 50);
            _ShowStyle = TextStyle.Rec;
            isFouc = ControlState.Normal;
            _emptyTextTip = "--请输入--";
            _emptyTextTipColor = Color.DarkGray;
            _dtype = JMDataType.NONE;

            _median = 0;
            _negative = false;

            _format = "yyyy-MM-dd";
        }
        #endregion

        #region 属性

        [Category("Appearance"),
        Description("日期格式"),
        DefaultValue(typeof(bool), "yyyy-MM-dd")]
        public string ZFormat
        {
            get { return _format; }
            set
            {
                _format = value;
                if (_dtype == JMDataType.JMDATETIME)
                    Text = DateTime.Now.ToString(_format);
            }
        }

        [Category("Appearance"),
        Description("启用负数"),
        DefaultValue(typeof(bool), "false")]
        public bool ZNegative
        {
            get { return _negative; }
            set { _negative = value; }
        }

        [Category("Appearance"),
        Description("小数位数"),
        DefaultValue(typeof(int), "0")]
        public int ZMedian
        {
            get { return _median; }
            set
            {
                _median = value;
                if (_dtype == JMDataType.JMDECIMAL)
                {
                    string txt = "";
                    for (int i = 0; i < _median; i++)
                    {
                        txt += "0";
                    }
                    Text = txt == "" ? "0" : "0." + txt;
                }
            }
        }

        [Category("Appearance"),
        Description("文本框类型"),
        DefaultValue(typeof(TextStyle), "Rec")]
        public TextStyle ZShowStyle
        {
            get { return _ShowStyle; }
            set
            {
                if (value == TextStyle.Rec)
                {
                    this.BorderStyle = BorderStyle.FixedSingle;
                }
                else
                {
                    this.BorderStyle = BorderStyle.None;
                }
                _ShowStyle = value;
            }
        }

        [Category("Appearance"),
        Description("文本框数据类型"),
        DefaultValue(typeof(JMDataType), "NONE")]
        public virtual JMDataType ZDtype
        {
            get { return _dtype; }
            set
            {
                _dtype = value;
                switch (_dtype)
                {
                    case JMDataType.JMDECIMAL:
                        string txt = "";
                        for (int i = 0; i < _median; i++)
                        {
                            txt += "0";
                        }
                        Text = txt == "" ? "0" : "0." + txt;
                        this.TextAlign = HorizontalAlignment.Right;
                        break;
                    case JMDataType.JMDATETIME:
                        Text = DateTime.Now.ToString(_format);
                        this.TextAlign = HorizontalAlignment.Left;
                        break;
                    case JMDataType.JMIP:
                        Text = "   .  .   .   ";
                        this.TextAlign = HorizontalAlignment.Left;
                        break;
                    case JMDataType.NONE:
                        Text = "";
                        this.TextAlign = HorizontalAlignment.Left;
                        break;
                }
            }
        }

        [Category("Appearance"),
        DefaultValue("--请输入--")]
        public string ZEmptyTextTip
        {
            get { return _emptyTextTip; }
            set
            {
                _emptyTextTip = value;
                base.Invalidate();
            }
        }

        [Category("Appearance"),
        DefaultValue(typeof(Color), "DarkGray")]
        public Color ZEmptyTextTipColor
        {
            get { return _emptyTextTipColor; }
            set
            {
                _emptyTextTipColor = value;
                base.Invalidate();
            }
        }

        [Category("Appearance"),
        Description("边框颜色"),
        DefaultValue(typeof(Color), "51, 161, 224")]
        public Color ZBorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                this._BorderColor = value;
                _HotColor = ColorClass.GetColor(_BorderColor, _BorderColor.A, 50, 50, 50);
                this.Invalidate();
            }
        }

        [Category("Appearance"),
        Description("背景颜色"),
        DefaultValue(typeof(Color), "236, 233, 216")]
        public Color ZBlackColor
        {
            get { return _ZBlackColor; }
            set { _ZBlackColor = value; this.BackColor = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DateTime ValueDateTime
        {
            get
            {
                return DateTime.Parse(Text);
            }
            set
            {
                Text = value.ToString(_format);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public decimal ValueDecimal
        {
            get
            {
                return decimal.Parse(Text.Replace(",", ""));
            }
            set
            {
                Text = value.ToString();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public string TextValue
        {
            get
            {
                return Text.Replace(",", "");
            }
            set
            {
                Text = value.ToString();
            }
        }
        #endregion

        private int _maxLen = 30;

        public int MaxLen
        {
            get { return _maxLen; }
            set { _maxLen = value; }
        }

        #region override(鼠标)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_dtype == JMDataType.JMDATETIME)
            {
                if (keyData == Keys.Enter || (int)keyData == 110)
                {
                    System.Windows.Forms.SendKeys.Send("-");
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Cursor = Cursors.IBeam;
            isFouc = ControlState.Normal;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isFouc = ControlState.Hover;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this.ReadOnly || !this.Enabled)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
                return;
            }
            if (this.ZDtype == JMDataType.NONE)
            {
                int allLenth = 0;
                foreach (char item in this.Text.ToCharArray())
                {
                    if ((int)item >= 0x4E00 && (int)item <= 0x9FA5)
                    {
                        allLenth += 2;
                    }
                    else
                    {
                        allLenth++;
                    }
                }

                if ((int)e.KeyChar >= 0x4E00 && (int)e.KeyChar <= 0x9FA5)
                {
                    allLenth += 2;
                }
                else if (e.KeyChar != 8 && e.KeyChar != 3 && e.KeyChar != 24)
                {
                    allLenth++;
                }

                if (allLenth > MaxLen && e.KeyChar != 8)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (this.SelectedText.Length > 1)
            {
                SelectBeforPointText();
            }
            base.OnKeyPress(e);
            if (_dtype == JMDataType.JMDECIMAL)
                e.Handled = InputlawOFdecimal(e);
            else if (_dtype == JMDataType.JMDATETIME)
                e.Handled = InputlawOFdatetime(e);

            if (JMTextChanged != null)
            {
                JMTextChanged();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.ReadOnly || !this.Enabled)
            {
                e.Handled = true;
                return;
            }
            if (this.SelectedText.Length > 1)
            {
                SelectBeforPointText();
            }
            base.OnKeyDown(e);
            if (_dtype == JMDataType.JMDECIMAL)
            {
                e.Handled = InputlawOFdecimalKJ(e);
            }
            else if (_dtype == JMDataType.JMDATETIME)
            {
                e.Handled = InputlawOFdatetimeKJ(e);
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            SelectBeforPointText();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Rectangle rect = new Rectangle(Width - 15, 2, 14, 17);
            if (rect.Contains(e.Location) && _dtype == JMDataType.JMDATETIME)
            {
                Cursor = Cursors.Default;
            }
            else
            {
                Cursor = Cursors.IBeam;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Rectangle rect = new Rectangle(Width - 15, 2, 14, 17);
            if (rect.Contains(e.Location) && _dtype == JMDataType.JMDATETIME)
            {
                if (jmbeforclick != null)
                {
                    jmbeforclick();
                }
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                Frm_DownDate frm = new Frm_DownDate(CBRect.X - 1, CBRect.Y + this.Height, this.Text);
                frm.DateSelected += new DateRangeEventHandler(frm_DateSelected);
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.Show();
            }
            else
            {
                base.OnMouseClick(e);
                SelectBeforPointText();
            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (jmendclick != null)
            {
                jmendclick();
            }
        }

        void frm_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.Text = e.Start.ToString("yyyy-MM-dd");
            
            if (JMTextChanged != null)
            {
                JMTextChanged();
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            Rectangle rect = new Rectangle(Width - 15, 2, 14, 17);
            if (rect.Contains(e.Location) && _dtype == JMDataType.JMDATETIME)
            {
                OnMouseClick(e);
            }
            else
            {
                base.OnMouseDoubleClick(e);
                SelectBeforPointText();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (_dtype == JMDataType.JMDECIMAL)
            {
                Text = string.IsNullOrEmpty(Text) ? "0.00" : Convert.ToDecimal(Text).ToString("n" + _median.ToString());
            }
            //string pattern = @"^[0-9]+(.[0-9]{"+_median.ToString()+"})?$";
            //// 定义正则表达式 ,"  "里面的是表达式

            //Regex.IsMatch(Text, pattern);//验证
        }

        #endregion

        #region 重绘
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_PASTE)
            {
                base.WndProc(ref m);
                if (m.Msg == Animate.WM_PAINT || m.Msg == 0x133)
                {
                    IntPtr hDC = Win32.GetWindowDC(m.HWnd);
                    if (hDC.ToInt32() == 0)
                        return;
                    System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                    DrawBorderAndEmptyText(g);
                    m.Result = IntPtr.Zero;
                    Win32.ReleaseDC(m.HWnd, hDC);
                }
            }
            else
            {
                try
                {
                    string CliText = Clipboard.GetDataObject().GetData(typeof(string)).ToString();

                    if (this.ZDtype == JMDataType.NONE)
                    {
                        string betext = this.Text;
                        base.WndProc(ref m);
                        if (this.Text.IndexOf('\'') >= 0)
                        {
                            MessageBox.Show("您所粘贴的格式不合法!");
                            return;
                        }
                        int allLenth = 0;
                        foreach (char item in this.Text.ToCharArray())
                        {
                            if ((int)item >= 0x4E00 && (int)item <= 0x9FA5)
                            {
                                allLenth += 2;
                            }
                            else
                            {
                                allLenth++;
                            }
                        }

                        if (allLenth > MaxLen)
                        {
                            this.Text = betext;
                            MessageBox.Show("您所粘贴的内容超出长度范围!");
                            return;
                        }

                        //this.Text = CliText;
                    }
                    else if (this.ZDtype == JMDataType.JMDECIMAL)
                    {
                        if (CliText.Length > this.MaxLength)
                        {
                            MessageBox.Show("您所粘贴的内容超出长度范围!");
                            return;
                        }
                        try
                        {
                            string va = Convert.ToDecimal(CliText).ToString("N" + this.ZMedian.ToString());
                            this.Text = va;
                        }
                        catch
                        {
                            MessageBox.Show("您所粘贴的格式不合法!");
                            return;
                        }
                    }
                    else if (this.ZDtype == JMDataType.JMDATETIME)
                    {
                        if (CliText.Length > this.MaxLength)
                        {
                            MessageBox.Show("您所粘贴的内容超出长度范围!");
                            return;
                        }
                        if (IsDateTime(CliText))
                            this.Text = Convert.ToDateTime(CliText).ToString(_format);
                        else
                        {
                            MessageBox.Show("您所粘贴的格式不合法!");
                            return;
                        }
                    }
                }
                catch
                {

                }
            }
        }
        #endregion

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (_dtype == JMDataType.JMDECIMAL)
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return;
                }
                if (Text[0] == '-')
                {
                    if (!_isXYK)
                    {
                        this.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.ForeColor = Color.Black;
                    }
                }
                else
                {
                    if (!_isXYK)
                    {
                        this.ForeColor = Color.Black;
                    }
                    else
                    {
                        this.ForeColor = Color.Red;
                    }
                }
            }
        }

        #region 小数点输入法则
        private bool InputlawOFdecimal(KeyPressEventArgs e)
        {
            bool result = false;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.' || e.KeyChar == 8 || e.KeyChar == '-')
            {
                if (e.KeyChar == '-')
                {
                    if (_negative)
                    {
                        if (this.Text[0].ToString() == "-")
                        {
                            this.Text = this.Text.Substring(1);
                        }
                        else
                        {
                            this.Text = "-" + this.Text;
                            this.Select(1, 1);
                        }
                    }
                    result = true;
                }

                #region 小数点
                else if (e.KeyChar == '.' && !_afternegative)
                {
                    if (_median < 1)
                        return true;
                    _afternegative = true;
                    _negativemedian = 0;
                    result = true;
                    this.Select(this.Text.Split('.')[0].ToString().Length + 1, 1);
                }
                #endregion

                #region 擦除键
                else if (e.KeyChar == 8)
                {
                    if (_median < 1)
                        return false;
                    //全选则把小数点前的改为0
                    if (this.SelectedText == this.Text)
                    {
                        result = true;
                        if (Text[0] == '-')
                        {
                            this.Select(1, this.Text.Split('.')[0].ToString().Length - 1);
                            this.SelectedText = "0";
                            this.Select(1, this.Text.Split('.')[0].ToString().Length - 1);
                        }
                        else
                        {
                            this.Select(0, this.Text.Split('.')[0].ToString().Length);
                            this.SelectedText = "0";
                            this.Select(0, this.Text.Split('.')[0].ToString().Length);
                        }
                        _afternegative = false;
                        _negativemedian = 0;
                        return result;
                    }
                    //小数点前剩下一位则 把该字符改为0
                    if (this.SelectionStart < this.Text.Split('.')[0].ToString().Length + 1)
                    {
                        if (Text[0] == '-' && this.SelectionStart == 2)
                        {
                            if (this.Text.Split('.')[0].ToString().Length - SelectionStart <= 1 && Text.Substring(SelectionStart, 1) == ".")
                            {
                                this.Select(1, 1);
                                this.SelectedText = "0";
                                this.Select(1, 1);
                                result = true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (Text[0] == '-' && this.SelectionStart == 1)
                        {
                            if (Text.Substring(SelectionStart + 1, 1) == ".")
                            {
                                this.Select(1, 1);
                                this.SelectedText = "0";
                                this.Select(1, 1);
                                this.Text = this.Text.Substring(1);
                                result = true;
                            }
                            else
                            {
                                this.Select(SelectionStart, 1);
                                return false;
                            }
                        }
                        else if (Text[0] == '-' && this.SelectionStart == 0)
                        {
                            this.Select(1, 1);
                            this.SelectedText = "0";
                            this.Select(1, 1);
                            result = true;
                        }
                        else if (this.SelectionStart == 1 || this.SelectionStart == 0 && this.Text.Split('.')[0].ToString().Length == 1)
                        {
                            this.Select(0, 1);
                            this.SelectedText = "0";
                            this.Select(0, 1);
                            result = true;
                        }
                        return result;
                    }

                    result = true;
                    //光标在第一个位子则不做任何操作
                    if (this.SelectionStart == 0)
                        return result;
                    else
                    {
                        if (_negativemedian != 0)
                            _negativemedian--;

                        this.Select(this.SelectionStart - 1, 1);

                        if (this.SelectedText == ".")
                        {
                            this.Select(this.SelectionStart - 1, 1);
                            _negativemedian = 0;
                            _afternegative = false;
                            return result;
                        }
                        else if (this.SelectionStart >= this.Text.Split('.')[0].ToString().Length + 1)
                        {
                            this.SelectedText = "0";
                            this.Select(this.SelectionStart - 1, 1);
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    return result;
                }
                #endregion

                #region 数字 小数点前
                else if (!_afternegative)
                {
                    if (_median < 1)
                        return checkZero(e);
                    if (this.SelectedText == this.Text)
                    {
                        result = true;
                        this.Select(0, this.Text.Split('.')[0].ToString().Length);
                        if (!checkZero(e))
                        {
                            this.SelectedText = e.KeyChar.ToString();
                        }
                        _afternegative = false;
                        _negativemedian = 0;
                        return result;
                    }
                    else
                    {

                        if (this.Text.Substring(0, 1) == "-")
                        {
                            if (this.SelectionStart == 0)
                            {
                                this.SelectionStart = 1;
                                return checkZero(e);
                            }
                            else
                                return checkZero(e);
                        }
                        else
                            return checkZero(e);
                    }

                }
                #endregion
                #region 数字 小数点后
                else if (_afternegative)
                {
                    if (_median < 1)
                        return false;
                    if (this.SelectedText == this.Text)
                    {
                        result = true;
                        this.Select(0, this.Text.Split('.')[0].ToString().Length);
                        this.SelectedText = e.KeyChar.ToString();
                        _afternegative = false;
                        _negativemedian = 0;
                        return result;
                    }
                    if (e.KeyChar == '.')
                    {
                        result = true;
                        return result;
                    }
                    _negativemedian++;
                    if (_negativemedian > _median)
                    {
                        result = true;
                        _negativemedian--;
                        return result;
                    }
                    this.Select(this.SelectionStart, 1);
                }
                #endregion
            }
            else
            {
                result = true;
            }
            return result;
        }

        private bool InputlawOFdecimalKJ(KeyEventArgs e)
        {
            bool result = false;
            if (_median < 1)
                return false;
            #region 上，左
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {

                if (this.SelectionStart == 0)
                    return result;
                else
                {
                    if (_negativemedian != 0)
                        _negativemedian--;
                    this.Select(this.SelectionStart - 1, 1);

                    if (this.SelectedText == ".")
                    {
                        this.Select(this.SelectionStart - 1, 1);
                        _negativemedian = 0;
                        _afternegative = false;
                    }
                }
                result = true;
                return result;
            }
            #endregion

            #region 下，右
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                result = true;
                if (this.SelectionStart >= this.Text.Length)
                    return result;
                else
                {
                    this.Select(this.SelectionStart, 1);
                    if (this.SelectedText == ".")
                    {
                        this.Select(this.SelectionStart, 1);
                        _negativemedian = 0;
                        _afternegative = true;
                    }
                    this.Select(this.SelectionStart + 1, 1);
                    if (this.SelectedText == ".")
                    {
                        this.Select(this.SelectionStart + 1, 1);
                        _negativemedian = 0;
                        _afternegative = true;
                    }
                    else if (this.SelectionStart > this.Text.Split('.')[0].ToString().Length + 1)
                    {
                        _negativemedian++;
                        this.Select(this.SelectionStart, 1);
                    }
                    else
                    {
                        this.Select(this.SelectionStart, 1);
                    }
                }
                return result;
            }
            #endregion

            #region delete
            if (e.KeyCode == Keys.Delete)
            {

                this.Select(this.SelectionStart, 1);
                if (SelectedText == "-")
                    this.Select(this.SelectionStart + 1, 1);
                //光标下一位是 小数点  则 跳到下一个位子
                if (this.SelectedText == ".")
                {
                    this.Select(this.SelectionStart + 1, 1);
                    result = true;
                    _negativemedian = 0;
                    _afternegative = true;
                    return result;
                }

                //小数位数后面 一律不删除 都改为0
                if (this.SelectionStart >= this.Text.Split('.')[0].ToString().Length + 1)
                {
                    _negativemedian++;
                    if (_negativemedian > _median)
                    {
                        result = true;
                        _negativemedian--;
                    }
                    else
                    {
                        this.SelectedText = "0";
                        this.Select(this.SelectionStart, 1);
                        result = true;
                    }
                    return result;
                }

                //小数点前 剩下一位 则 不删除 改为 0
                if (this.Text.Split('.')[0].ToString().Length == 1 && this.SelectionStart <= this.Text.Split('.')[0].ToString().Length || Text[0] == '-' && this.Text.Split('.')[0].ToString().Length == this.SelectionStart + 1)
                {
                    if (this.Text.Split('.')[0].ToString().Length == this.SelectionStart)
                    {
                        this.Select(this.SelectionStart + 1, 1);
                        _negativemedian = 0;
                        _afternegative = true;
                    }
                    else
                    {
                        this.SelectedText = "0";
                        this.Select(this.SelectionStart + 1, 1);
                        _negativemedian = 0;
                        _afternegative = true;
                    }
                    result = true;
                    return result;
                }
            }
            #endregion
            #region end
            if (e.KeyCode == Keys.End)
            {
                _negativemedian = _median;
                _afternegative = true;
            }
            #endregion
            #region Home
            if (e.KeyCode == Keys.Home)
            {
                _negativemedian = 0;
                _afternegative = false;
                if (Text[0] == '-')
                    Select(1, 1);
            }
            #endregion

            return result;
        }
        #endregion

        /// <summary>
        /// 控制输入“0”
        /// </summary>
        /// <returns></returns>
        private bool checkZero(KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return false;
            }
            if (e.KeyChar == '0')
            {
                if (Text[0] == '-')
                {
                    if (SelectionStart == 1)
                    {
                        if (SelectedText == "")
                            return true;
                        else
                        {
                            if (Text.IndexOf('.') > 2)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        if (Text[1] == '0')
                            return true;
                        else
                            return false;
                    }
                }
                else
                {
                    if (SelectionStart == 0)
                    {
                        if (SelectedText == "")
                            return true;
                        else
                        {
                            if (Text.IndexOf('.') > 1)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        if (Text[0] == '0')
                            return true;
                        else
                            return false;
                    }
                }
            }
            else
            {
                if (Text[0] == '-')
                {
                    if (Text[1] == '0' && SelectionStart > 1)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (Text[0] == '0' && SelectionStart > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        /// <summary>
        /// 获取指定索引是否是指定字符
        /// </summary>
        /// <param name="col">索引</param>
        /// <param name="cha">字符</param>
        /// <returns></returns>
        private bool GetIndex(int col, char cha)
        {
            if (col == 0)
                return false;
            if (Text[col - 1] == cha)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取所有索引
        /// </summary>
        /// <param name="cha"></param>
        /// <returns></returns>
        private List<int> GetIndexs(char cha)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] == cha)
                    result.Add(i);
            }
            return result;
        }

        /// <summary>
        /// 自动选中下一个字符
        /// </summary>
        /// <param name="chaindexs"></param>
        /// <param name="index"></param>
        private void next(List<int> chaindexs, int index)
        {
            if (SelectionStart + SelectionLength <= chaindexs[index])
                Select(chaindexs[index] + 1, 1);
            else
                if (index < chaindexs.Count - 1)
                    next(chaindexs, ++index);
        }

        #region 日期输入法则
        private bool InputlawOFdatetime(KeyPressEventArgs e)
        {
            bool result = false;

            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-')// || e.KeyChar == 8
            {
                if (e.KeyChar == '-')
                {
                    List<int> chaindexs = GetIndexs('-');
                    if (chaindexs.Count > 0)
                    {
                        next(chaindexs, 0);
                    }
                    result = true;
                }

                #region 擦除键
                else if (e.KeyChar == 8)
                {
                    if (this.SelectionStart == 0)
                        return true;
                    if (GetIndex(SelectionStart, '-'))
                    {
                        this.Select(this.SelectionStart - 2, 1);
                        this.SelectedText = "0";
                        this.Select(this.SelectionStart - 1, 1);
                    }
                    else
                    {
                        this.Select(this.SelectionStart - 1, 1);
                        this.SelectedText = "0";
                        this.Select(this.SelectionStart - 1, 1);
                    }
                    result = true;
                    return result;
                }
                #endregion

                #region 输入数字
                else
                {
                    string befortext = this.Text;
                    int beforindex = this.SelectionStart;
                    this.SelectedText = e.KeyChar.ToString();
                    if (!IsDateTime(this.Text))
                    {
                        this.Text = befortext;
                        if (beforindex < 5)
                        {
                            this.Select(beforindex, 1);
                        }
                        else if (beforindex == 5)
                        {
                            if (e.KeyChar > '1')
                            {
                                try
                                {
                                    this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-0" + e.KeyChar.ToString() + "-" + this.ValueDateTime.Day.ToString("00")).ToString(_format);
                                }
                                catch
                                {
                                    this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-" + (Convert.ToInt32(e.KeyChar.ToString()) + 1).ToString("00") + "-01").AddDays(-1).ToString(_format);
                                }
                            }
                            else
                            {
                                if (e.KeyChar == '0' && this.Text[6] == '0')
                                {
                                    this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-01-" + this.ValueDateTime.Day.ToString("00")).ToString(_format);
                                }
                                else
                                {
                                    this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-" + e.KeyChar.ToString() + "0-" + this.ValueDateTime.Day.ToString("00")).ToString(_format);
                                }
                            }
                            if (!IsDateTime(this.Text))
                            {
                                this.Text = Convert.ToDateTime(this.Text.Substring(0, 8) + "01").ToString(_format);
                            }
                            this.Select(beforindex + 1, 1);
                        }
                        else if (beforindex == 6)
                        {
                            if (e.KeyChar == '0' && this.Text[5] == '0')
                            {
                                this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-01-" + this.ValueDateTime.Day.ToString("00")).ToString(_format);
                            }
                            else
                            {
                                try
                                {
                                    this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-0" + e.KeyChar.ToString() + "-" + this.ValueDateTime.Day.ToString("00")).ToString(_format);
                                }
                                catch
                                {
                                    this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-" + (Convert.ToInt32(e.KeyChar.ToString()) + 1).ToString("00") + "-01").AddDays(-1).ToString(_format);
                                }
                            }
                            if (!IsDateTime(this.Text))
                            {
                                this.Text = Convert.ToDateTime(this.Text.Substring(0, 8) + "01").ToString(_format);
                            }
                            this.Select(beforindex + 2, 1);
                        }
                        else if (beforindex == 8)
                        {
                            if (e.KeyChar > '3')
                            {
                                this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-" + this.ValueDateTime.Month.ToString("00") + "-0" + e.KeyChar.ToString()).ToString(_format);
                            }
                            else
                            {
                                if (e.KeyChar == '3' && this.ValueDateTime.Month == 2)
                                {
                                    this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-" + this.ValueDateTime.Month.ToString("00") + "-0" + e.KeyChar.ToString()).ToString(_format);
                                }
                                else
                                {
                                    if (e.KeyChar.ToString() == "0")
                                    {
                                        this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-" + this.ValueDateTime.Month.ToString("00") + "-" + e.KeyChar.ToString() + "1").ToString(_format);
                                    }
                                    else
                                    {
                                        this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-" + this.ValueDateTime.Month.ToString("00") + "-" + e.KeyChar.ToString() + "0").ToString(_format);
                                    }
                                }
                            }
                            this.Select(beforindex + 1, 1);
                        }
                        else if (beforindex == 9)
                        {
                            if (e.KeyChar.ToString() == "0")
                            {
                                this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-" + this.ValueDateTime.Month.ToString("00") + "-1" + e.KeyChar.ToString()).ToString(_format);
                            }
                            else
                            {
                                this.Text = Convert.ToDateTime(this.ValueDateTime.Year.ToString() + "-" + this.ValueDateTime.Month.ToString("00") + "-0" + e.KeyChar.ToString()).ToString(_format);
                            }
                            if (!IsDateTime(this.Text))
                            {
                                this.Text = Convert.ToDateTime(this.Text.Substring(0, 8) + "01").ToString(_format);
                            }
                            this.Select(9, 1);
                        }
                    }
                    else
                    {
                        if (SelectionStart == Text.Length)
                            this.Select(this.SelectionStart - 1, 1);
                        else if (GetIndex(SelectionStart + 1, '-'))
                            this.Select(this.SelectionStart + 1, 1);
                        else
                            this.Select(this.SelectionStart, 1);
                    }
                    result = true;
                    return result;
                }
                #endregion
            }
            else
            {
                result = true;
            }
            return result;
        }
        private bool InputlawOFdatetimeKJ(KeyEventArgs e)
        {
            bool result = false;

            #region 上，左
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                if (this.SelectionStart == 0)
                {
                    Select(Text.Length, 1);
                }
                if (GetIndex(SelectionStart, '-'))
                {
                    this.Select(this.SelectionStart - 2, 1);
                }
                else
                {
                    this.Select(this.SelectionStart - 1, 1);
                }
                result = true;
                return result;
            }
            #endregion

            #region 下，右
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Delete)
            {
                result = true;
                if (SelectionStart == Text.Length - 1)
                    this.Select(0, 1);
                else if (GetIndex(SelectionStart + 2, '-'))
                    this.Select(this.SelectionStart + 2, 1);
                else
                    this.Select(this.SelectionStart + 1, 1);
                return result;
            }
            #endregion

            #region delete
            //if (e.KeyCode == Keys.Delete)
            //{
            //    this.SelectedText = "0";
            //    if (SelectionStart == Text.Length)
            //        this.Select(this.SelectionStart - 1, 1);
            //    else if (GetIndex(SelectionStart + 1, '-'))
            //        this.Select(this.SelectionStart + 1, 1);
            //    else
            //        this.Select(this.SelectionStart, 1);
            //    result = true;
            //    return result;
            //}
            #endregion

            #region end
            if (e.KeyCode == Keys.End)
            {
                Select(Text.Length - 1, 1);
                result = true;
            }
            #endregion

            #region Home
            if (e.KeyCode == Keys.Home)
            {
                Select(0, 1);
                result = true;
            }
            #endregion

            return result;
        }
        #endregion

        /// <summary>
        /// 判断用户输入是否为日期
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        /// <remarks>
        /// 可判断格式如下（其中-可替换为/，不影响验证)
        /// YYYY | YYYY-MM | YYYY-MM-DD | YYYY-MM-DD HH:MM:SS | YYYY-MM-DD HH:MM:SS.FFF
        /// </remarks>
        private bool IsDateTime(string strValue)
        {
            if (null == strValue)
            {
                return false;
            }
            try
            {
                Convert.ToDateTime(strValue);
                return true;
            }
            catch
            {
                return false;
            }
            //if (strValue.EndsWith("08-31"))
            //    return true;
            //string regexDate = @"[1-9]{1}[0-9]{3}((-|\/){1}(([0]?[1-9]{1})|(1[0-2]{1}))((-|\/){1}((([0]?[1-9]{1})|([1-2]{1}[0-9]{1})|(3[0-1]{1})))( (([0-1]{1}[0-9]{1})|2[0-3]{1}):([0-5]{1}[0-9]{1}):([0-5]{1}[0-9]{1})(\.[0-9]{3})?)?)?)?$";

            //if (Regex.IsMatch(strValue, regexDate))
            //{
            //    //以下各月份日期验证，保证验证的完整性
            //    int _IndexY = -1;
            //    int _IndexM = -1;
            //    int _IndexD = -1;

            //    if (-1 != (_IndexY = strValue.IndexOf("-")))
            //    {
            //        _IndexM = strValue.IndexOf("-", _IndexY + 1);
            //        _IndexD = strValue.IndexOf(":");
            //    }
            //    else
            //    {
            //        _IndexY = strValue.IndexOf("/");
            //        _IndexM = strValue.IndexOf("/", _IndexY + 1);
            //        _IndexD = strValue.IndexOf(":");
            //    }

            //    //不包含日期部分，直接返回true
            //    if (-1 == _IndexM)
            //        return true;

            //    if (-1 == _IndexD)
            //    {
            //        _IndexD = strValue.Length + 3;
            //    }

            //    int iYear = Convert.ToInt32(strValue.Substring(0, _IndexY));
            //    int iMonth = Convert.ToInt32(strValue.Substring(_IndexY + 1, _IndexM - _IndexY - 1));
            //    int iDate = Convert.ToInt32(strValue.Substring(_IndexM + 1, _IndexD - _IndexM - 4));

            //    //判断月份日期
            //    if ((iMonth < 8 && 1 == iMonth % 2) || (iMonth > 8 && 0 == iMonth % 2))
            //    {
            //        if (iDate < 32)
            //            return true;
            //    }
            //    else
            //    {
            //        if (iMonth != 2)
            //        {
            //            if (iDate < 31)
            //                return true;
            //        }
            //        else
            //        {
            //            //闰年
            //            if ((0 == iYear % 400) || (0 == iYear % 4 && 0 < iYear % 100))
            //            {
            //                if (iDate < 30)
            //                    return true;
            //            }
            //            else
            //            {
            //                if (iDate < 29)
            //                    return true;
            //            }
            //        }
            //    }
            //}

            //return false;
        }

        /// <summary>
        /// 选中小数点前内容
        /// </summary>
        private void SelectBeforPointText()
        {
            if (_dtype == JMDataType.JMDECIMAL)
            {
                Text = Text.Replace(",", "");
                if (Text[0] == '-')
                    this.Select(1, this.Text.Split('.')[0].ToString().Length - 1);
                else
                    this.Select(0, this.Text.Split('.')[0].ToString().Length);
                _afternegative = false;
                _negativemedian = 0;
            }
            if (_dtype == JMDataType.JMDATETIME)
            {
                if (this.SelectionStart == 4)
                {
                    this.Select(this.SelectionStart + 1, 1);
                }
                else if (this.SelectionStart == 7)
                {
                    this.Select(this.SelectionStart + 1, 1);
                }
                else if (this.SelectionStart >= 10)
                {
                    this.Select(9, 1);
                }
                else
                {
                    this.Select(this.SelectionStart, 1);
                }
            }
        }

        /// <summary>
        /// 边框与水印
        /// </summary>
        /// <param name="g"></param>
        private void DrawBorderAndEmptyText(Graphics g)
        {
            //Graphics g = Graphics.FromImage(myAlphaBitmap);
            //边框形状
            if (this.BorderStyle == BorderStyle.FixedSingle && ZShowStyle == TextStyle.Rec)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (isFouc == ControlState.Normal)
                {
                    g.DrawRectangle(new Pen(this.ZBorderColor, 1), 0, 0, this.Width - 1, this.Height - 1);
                }
                else
                {
                    Pen p = new Pen(this._HotColor, 1);
                    g.DrawRectangle(p, 1, 1, this.Width - 3, this.Height - 3);
                    g.DrawRectangle(new Pen(this.ZBorderColor, 1), 0, 0, this.Width - 1, this.Height - 1);
                }

            }
            //线形状
            else if (this.BorderStyle == BorderStyle.None && ZShowStyle == TextStyle.Line)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (isFouc == ControlState.Normal)
                {
                    g.DrawLine(new Pen(this.ZBorderColor, 1), new Point(0, this.Height - 1), new Point(this.Width - 1, this.Height - 1));
                }
                else
                {
                    g.DrawLine(new Pen(this._HotColor, 1), new Point(0, this.Height - 1), new Point(this.Width - 1, this.Height - 1));
                }
            }

            if (string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(_emptyTextTip) && !Focused)
            {
                TextRenderer.DrawText(
                    g,
                    _emptyTextTip,
                    Font,
                    base.ClientRectangle,
                    _emptyTextTipColor,
                    TextFormat.GetTextFormatFlags(ContentAlignment.MiddleLeft, false));
            }

            if (_dtype == JMDataType.JMDATETIME)
            {
                Rectangle rect = new Rectangle(Width - 15, 2, 14, 17);
                if (isFouc != ControlState.Normal)
                {
                    ControlPaintClass.RenderArrowInternal(g, rect, ArrowDirection.Down, 4, new SolidBrush(Color.Blue));
                }
                else
                {
                    ControlPaintClass.RenderArrowInternal(g, rect, ArrowDirection.Down, 4, new SolidBrush(Color.Black));
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

    } //End JMtextbox Class

    #region 控件右上角属性编辑器
    internal class TextBoxDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {
        #region 构造函数
        public TextBoxDesigner()
        {
        }
        #endregion

        #region 重写方法属性
        //public override void Initialize(System.ComponentModel.IComponent component)
        //{
        //    base.Initialize(component);
        //}

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // 初始化属性集合
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                // 添加属性集合
                actionLists.Add(new TextBoxDesignerActionList(this.Component));

                // 返回属性集合
                return actionLists;
            }
        }

        //protected override void OnPaintAdornments(PaintEventArgs e)
        //{
        //    base.OnPaintAdornments(e);
        //}
        #endregion
    }
    #endregion

    #region 属性集合类
    internal class TextBoxDesignerActionList : DesignerActionList
    {
        #region 公共属性
        private JMTextBox Textbox
        {
            get { return (JMTextBox)this.Component; }
        }

        public TextStyle ZShowStyle
        {
            get { return this.Textbox.ZShowStyle; }
            set { SetProperty("ZShowStyle", value); }
        }

        public JMDataType ZDtype
        {
            get { return this.Textbox.ZDtype; }
            set { SetProperty("ZDtype", value); }
        }

        public string ZEmptyTextTip
        {
            get { return this.Textbox.ZEmptyTextTip; }
            set { SetProperty("ZEmptyTextTip", value); }
        }

        public Color ZBorderColor
        {
            get { return this.Textbox.ZBorderColor; }
            set { SetProperty("ZBorderColor", value); }
        }
        #endregion

        #region 构造函数
        public TextBoxDesignerActionList(System.ComponentModel.IComponent component)
            : base(component)
        {
            //自动显示属性菜单
            base.AutoShow = true;
        }
        #endregion

        #region 重写方法
        /// <summary>
        /// 属性集合
        /// </summary>
        /// <returns></returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            // Create list to store designer action items
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();

            actionItems.Add(
                new DesignerActionPropertyItem(
                "ZShowStyle",//属性名称
                "样式:",//注释
                GetCategory(this.Textbox, "ZShowStyle")));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "ZEmptyTextTip",//属性名称
                "水印内容:",//注释
                GetCategory(this.Textbox, "ZEmptyTextTip")));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "ZDtype",
                "数据类型:",
                GetCategory(this.Textbox, "ZDtype")));

            actionItems.Add(
                new DesignerActionPropertyItem(
                "ZBorderColor",
                "边框颜色:",
                GetCategory(this.Textbox, "ZBorderColor")));

            return actionItems;
        }
        #endregion

        #region 私有方法
        // 获取属性并赋值
        private void SetProperty(string propertyName, object value)
        {
            // 获取属性
            System.ComponentModel.PropertyDescriptor property
                = System.ComponentModel.TypeDescriptor.GetProperties(this.Textbox)[propertyName];
            // 给属性赋值
            property.SetValue(this.Textbox, value);
        }

        // 获取属性类别
        private static string GetCategory(object source, string propertyName)
        {
            System.Reflection.PropertyInfo property = source.GetType().GetProperty(propertyName);
            CategoryAttribute attribute = (CategoryAttribute)property.GetCustomAttributes(typeof(CategoryAttribute), false)[0];
            if (attribute == null) return null;
            return attribute.Category;
        }
        #endregion
    }
    #endregion
}
