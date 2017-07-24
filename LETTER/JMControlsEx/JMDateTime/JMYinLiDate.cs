using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public partial class JMYinLiDate : UserControl
    {
        FrmYLMonth frm = new FrmYLMonth();
        FrmYLRiQi frmrq = new FrmYLRiQi();
        //阴历月份的天数
        int tianshu = 30;

        public JMYinLiDate()
        {
            InitializeComponent();
            _JMBorderStyle = true;
            _JMBorderLineColor = Color.Black;
            _JMRoundStyle = RoundStyle.None;
            _JMRadius = 8;
            //Fun_YinLiDate();
        }

        private string _JMText;

        public string JMText
        {
            get { return _JMText; }
            set
            {
                _JMText = value;
                if (!string.IsNullOrEmpty(value))
                {
                    string[] str = value.Split('-');
                    string strmonth = ChineseCalendar.ChineseMonthName[Convert.ToInt32(str[1]) - 1];
                    jm_pn_Hao.Tag = str[2];
                    jm_pn_Month.Tag = str[1];
                    jm_txt_Nian.Text = str[0];
                    jm_pn_Month.JMTitle = strmonth == "十二" ? "腊月" : strmonth + "月";
                    jm_pn_Hao.JMTitle = ChineseCalendar.ChineseDayName[Convert.ToInt32(str[2]) - 1];
                    tianshu = new ChineseCalendar().Fun_GetYueTianShu(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]));
                }
            }
        }

        private bool _JMBorderStyle;

        [Category("Appearance"), Description("边框颜色"), DefaultValue(typeof(bool), "true")]
        public bool JMBorderStyle
        {
            get { return _JMBorderStyle; }
            set { _JMBorderStyle = value; Invalidate(); }
        }

        private Color _JMBorderLineColor;

        [Category("Appearance"), Description("边框颜色"), DefaultValue(typeof(Color), "black")]
        public Color JMBorderLineColor
        {
            get { return _JMBorderLineColor; }
            set { _JMBorderLineColor = value; Invalidate(); }
        }

        /// <summary>
        /// 按钮圆角样式
        /// </summary>
        private RoundStyle _JMRoundStyle;

        [Category("Appearance"), Description("按钮圆角样式"), DefaultValue(typeof(RoundStyle), "None")]
        public RoundStyle JMRoundStyle
        {
            get { return _JMRoundStyle; }
            set
            {
                if (_JMRoundStyle != value)
                {
                    _JMRoundStyle = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 按钮圆角弧度
        /// </summary>
        private int _JMRadius;

        [Category("Appearance"), Description("按钮圆角弧度"), DefaultValue(8)]
        public int JMRadius
        {
            get { return _JMRadius; }
            set { _JMRadius = value; }
        }

        /// <summary>
        /// 把阳历转成阴历
        /// </summary>
        private void Fun_YinLiDate()
        {
            ChineseCalendar cc = new ChineseCalendar(DateTime.Now);
            jm_txt_Nian.Text = cc.LunarYear.ToString();
            jm_pn_Month.Tag = cc.LunarMonth;//数字月
            jm_pn_Month.JMTitle = cc.LunarMonthText + "月";//文本月
            jm_pn_Hao.Tag = cc.LunarDay;//数字日期
            jm_pn_Hao.JMTitle = cc.LunarDayText;//文本日期
            tianshu = cc.Fun_GetYueTianShu(cc.LunarYear, cc.LunarMonth);
            JMText = jm_txt_Nian.Text.Trim() + "-" + jm_pn_Month.Tag.ToString() + "-" + jm_pn_Hao.Tag.ToString();
        }

        /// <summary>
        /// 阴历月份文本转数字
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        private int Fun_MonthTextToInt(string _value)
        {
            ChineseCalendar cc = new ChineseCalendar(DateTime.Now);
            int I_Month = cc.LunarMonth;
            switch (_value)
            {
                case "正月":
                case "一月":
                    I_Month = 1;
                    break;
                case "二月":
                    I_Month = 2;
                    break;
                case "三月":
                    I_Month = 3;
                    break;
                case "四月":
                    I_Month = 4;
                    break;
                case "五月":
                    I_Month = 5;
                    break;
                case "六月":
                    I_Month = 6;
                    break;
                case "七月":
                    I_Month = 7;
                    break;
                case "八月":
                    I_Month = 8;
                    break;
                case "九月":
                    I_Month = 9;
                    break;
                case "十月":
                    I_Month = 10;
                    break;
                case "十一月":
                    I_Month = 11;
                    break;
                case "腊月":
                case "十二月":
                    I_Month = 12;
                    break;
            }
            return I_Month;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (_JMBorderStyle)
            {
                switch (_JMRoundStyle)
                {
                    case RoundStyle.None:
                        g.DrawRectangle(new Pen(_JMBorderLineColor, 1), 0, 0, this.Width - 1, this.Height - 1);
                        break;
                    case RoundStyle.All:
                        GraphicsPath gp = new GraphicsPath();
                        GraphicsPath gp1 = new GraphicsPath();

                        Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Size.Width - 1, this.Size.Height - 1));
                        Rectangle rec1 = new Rectangle(new Point(0, 0), new Size(this.Size.Width, this.Size.Height));

                        gp = GetGraphicPath.CreatePath(rec, _JMRadius, _JMRoundStyle, true);
                        gp1 = GetGraphicPath.CreatePath(rec1, _JMRadius, _JMRoundStyle, true);
                        this.Region = new Region(gp1);

                        g.DrawPath(new Pen(new SolidBrush(_JMBorderLineColor)), gp);
                        break;
                }
            }
        }

        private void jm_txt_Nian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #region 窗体加载
        private void JMYinLiDate_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                frm.JMYLMonthClick += new JMDelegate.DelItemEventHandle(frm_JMYLMonthClick);
                frmrq.JMYLHaoClick += new JMDelegate.DelItemEventHandle(frmrq_JMYLHaoClick);
            }
        }
        #endregion

        #region 阴历月份单击事件（显示下拉）
        private void jm_pn_Month_Click(object sender, EventArgs e)
        {
            //显示阴历月份下拉并且修改坐标
            Rectangle CBRect = jm_pn_Month.RectangleToScreen(jm_pn_Month.ClientRectangle);
            Screen cre = Screen.PrimaryScreen;
            frm.Show();
            frm.Focus();
            frm.Location = new Point(CBRect.X - frm.Width + jm_pn_Month.Width, CBRect.Y + jm_pn_Month.Height);
        }
        #endregion

        #region 阴历天数单击事件（显示下拉）
        private void jm_pn_Hao_Click(object sender, EventArgs e)
        {
            //显示阴历月份下拉并且修改坐标
            Rectangle CBRect = jm_pn_Hao.RectangleToScreen(jm_pn_Hao.ClientRectangle);
            Screen cre = Screen.PrimaryScreen;
            frmrq.Fun_FillHao(tianshu);
            frmrq.Show();
            frmrq.Focus();
            frmrq.Location = new Point(CBRect.X, CBRect.Y + jm_pn_Hao.Height);
        }
        #endregion

        #region 阴历月份赋值(选择)
        private void frm_JMYLMonthClick(object sender, CancelEventArgs e)
        {
            Label lb = (sender as Label);
            jm_pn_Month.Tag = lb.Tag;
            jm_pn_Month.JMTitle = lb.Text;
            ChineseCalendar cc = new ChineseCalendar();
            tianshu = cc.Fun_GetYueTianShu(Convert.ToInt32(jm_txt_Nian.Text.Trim()), Convert.ToInt32(lb.Tag));
            if (tianshu < Convert.ToInt32(jm_pn_Hao.Tag))
            {
                jm_pn_Hao.Tag = (tianshu - 1).ToString("00");
                jm_pn_Hao.JMTitle = ChineseCalendar.ChineseDayName[tianshu - 1];
            }
            _JMText = jm_txt_Nian.Text.Trim() + "-" + jm_pn_Month.Tag.ToString() + "-" + jm_pn_Hao.Tag.ToString();
        }
        #endregion

        #region 阴历天数赋值(选择)
        private void frmrq_JMYLHaoClick(object sender, CancelEventArgs e)
        {
            jm_pn_Hao.Tag = (sender as Label).Tag;
            jm_pn_Hao.JMTitle = (sender as Label).Text;
            _JMText = jm_txt_Nian.Text.Trim() + "-" + jm_pn_Month.Tag.ToString() + "-" + jm_pn_Hao.Tag.ToString();
        }
        #endregion

        #region 年份计算阴历月份天数
        private void jm_txt_Nian_Leave(object sender, EventArgs e)
        {
            if (jm_txt_Nian.Text.Trim().Length < 4 || jm_txt_Nian.Text.Trim().Length > 4)
            {
                jm_txt_Nian.Text = DateTime.Now.ToString("yyyy");
            }
            ChineseCalendar cc = new ChineseCalendar();
            tianshu = cc.Fun_GetYueTianShu(Convert.ToInt32(jm_txt_Nian.Text.Trim()), Convert.ToInt32(jm_pn_Month.Tag));
            if (tianshu < Convert.ToInt32(jm_pn_Hao.Tag))
            {
                jm_pn_Hao.Tag = (tianshu - 1).ToString("00");
                jm_pn_Hao.JMTitle = ChineseCalendar.ChineseDayName[tianshu - 1];
            }
            _JMText = jm_txt_Nian.Text.Trim() + "-" + jm_pn_Month.Tag.ToString() + "-" + jm_pn_Hao.Tag.ToString();
        }

        private void jm_txt_Nian_TextChanged(object sender, EventArgs e)
        {
            if (jm_txt_Nian.Text.Trim().Length == 4)
            {
                ChineseCalendar cc = new ChineseCalendar();
                tianshu = cc.Fun_GetYueTianShu(Convert.ToInt32(jm_txt_Nian.Text.Trim()), Convert.ToInt32(jm_pn_Month.Tag));
                if (tianshu < Convert.ToInt32(jm_pn_Hao.Tag))
                {
                    jm_pn_Hao.Tag = (tianshu - 1).ToString("00");
                    jm_pn_Hao.JMTitle = ChineseCalendar.ChineseDayName[tianshu - 1];
                }
                _JMText = jm_txt_Nian.Text.Trim() + "-" + jm_pn_Month.Tag.ToString() + "-" + jm_pn_Hao.Tag.ToString();
            }
        }
        #endregion
    }
}