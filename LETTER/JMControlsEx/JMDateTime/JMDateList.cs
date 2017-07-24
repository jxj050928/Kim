using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class JMDateList : UserControl
    {
        public delegate void ClikeEventHand(object sender);
        /// <summary>
        /// 选择项
        /// </summary>
        public event ClikeEventHand ClikeItem;
        /// <summary>
        /// 单击向上
        /// </summary>
        public event ClikeEventHand ClikeUp;
        /// <summary>
        /// 单击向下
        /// </summary>
        public event ClikeEventHand ClikeDown;

        public JMDateList()
        {
            InitializeComponent();
            _zyear = DateTime.Now.Year;
            _DaType=DateListType.Month;
            _month = DateTime.Now.Month;
            _moveColor = ColorClass.GetColor(this.BackColor, 255, -10, -10, -10);
            _selectColor = ColorClass.GetColor(this.BackColor, 255, -20, -20, -20);
        }

        private Color _moveColor;

        public Color ZMoveColor
        {
            get { return _moveColor; }
            set { _moveColor = value; }
        }

        private Color _selectColor;

        public Color ZSelectColor
        {
            get { return _selectColor; }
            set { _selectColor = value; }
        }

        private int _zyear;

        public int Zyear
        {
            get { return _zyear; }
            set { _zyear = value; }
        }

        private int _month;

        public int Zmonth
        {
            get { return _month; }
            set { _month = value; }
        }

        private DateListType _DaType;

        public DateListType ZDaType
        {
            get { return _DaType; }
            set
            {
                _DaType = value;
                if (value == DateListType.Year)
                {
                    jmDateImageItem1.TheMonth = Zyear.ToString();
                    jmDateImageItem2.TheMonth = (Zyear - 1).ToString();
                    jmDateImageItem3.TheMonth = (Zyear - 2).ToString();
                    jmDateImageItem4.TheMonth = (Zyear - 3).ToString();
                    jmDateImageItem5.TheMonth = (Zyear - 4).ToString();
                    jmDateImageItem6.TheMonth = (Zyear - 5).ToString();
                    SetZero();
                }
                else
                {
                    if (DateTime.Now.Month > 6)
                    {
                        jmDateImageItem1.TheMonth = "12月";
                        jmDateImageItem2.TheMonth = "11月";
                        jmDateImageItem3.TheMonth = "10月";
                        jmDateImageItem4.TheMonth = "9月";
                        jmDateImageItem5.TheMonth = "8月";
                        jmDateImageItem6.TheMonth = "7月";
                    }
                    else
                    {
                        jmDateImageItem1.TheMonth = "6月";
                        jmDateImageItem2.TheMonth = "5月";
                        jmDateImageItem3.TheMonth = "4月";
                        jmDateImageItem4.TheMonth = "3月";
                        jmDateImageItem5.TheMonth = "2月";
                        jmDateImageItem6.TheMonth = "1月";
                    }
                }
            }
        }

        private JMDateImageItem _selectItem;

        public JMDateImageItem SelectItem
        {
            get { return _selectItem; }
            set
            {
                _selectItem = value;
                jmDateImageItem1.BackColor = jmDateImageItem1 == value ? ZSelectColor : this.BackColor;
                jmDateImageItem2.BackColor = jmDateImageItem2 == value ? ZSelectColor : this.BackColor;
                jmDateImageItem3.BackColor = jmDateImageItem3 == value ? ZSelectColor : this.BackColor;
                jmDateImageItem4.BackColor = jmDateImageItem4 == value ? ZSelectColor : this.BackColor;
                jmDateImageItem5.BackColor = jmDateImageItem5 == value ? ZSelectColor : this.BackColor;
                jmDateImageItem6.BackColor = jmDateImageItem6 == value ? ZSelectColor : this.BackColor;
            }
        }

        private void JMDateList_Resize(object sender, EventArgs e)
        {
            jmButton1.Width = Width - 1;
            jmButton2.Width = Width - 1;
            jmDateImageItem1.Width = Width - 1;
            jmDateImageItem2.Width = Width - 1;
            jmDateImageItem3.Width = Width - 1;
            jmDateImageItem4.Width = Width - 1;
            jmDateImageItem5.Width = Width - 1;
            jmDateImageItem6.Width = Width - 1;
            int h = (this.Height - 40) / 6;
            jmDateImageItem1.Height = h;
            jmDateImageItem2.Height = h;
            jmDateImageItem3.Height = h;
            jmDateImageItem4.Height = h;
            jmDateImageItem5.Height = h;
            jmDateImageItem6.Height = h;
        }

        private void jmButton1_Click(object sender, EventArgs e)
        {
            SetZero();
            if (_DaType == DateListType.Month)
            {
                if (jmDateImageItem1.TheMonth != "12月")
                {
                    jmDateImageItem1.TheMonth = "12月";
                    jmDateImageItem2.TheMonth = "11月";
                    jmDateImageItem3.TheMonth = "10月";
                    jmDateImageItem4.TheMonth = "9月";
                    jmDateImageItem5.TheMonth = "8月";
                    jmDateImageItem6.TheMonth = "7月";

                    if ((sender as JMButton).Name == "jmButton2")
                    {
                        _zyear--;
                    }
                }
                else
                {
                    jmDateImageItem1.TheMonth = "6月";
                    jmDateImageItem2.TheMonth = "5月";
                    jmDateImageItem3.TheMonth = "4月";
                    jmDateImageItem4.TheMonth = "3月";
                    jmDateImageItem5.TheMonth = "2月";
                    jmDateImageItem6.TheMonth = "1月";

                    if ((sender as JMButton).Name == "jmButton1")
                    {
                        _zyear++;
                    }
                }
            }
            else
            {
                if ((sender as JMButton).Name == "jmButton1")
                {
                    jmDateImageItem1.TheMonth = (Convert.ToInt32(jmDateImageItem1.TheMonth) + 6).ToString();
                    jmDateImageItem2.TheMonth = (Convert.ToInt32(jmDateImageItem2.TheMonth) + 6).ToString();
                    jmDateImageItem3.TheMonth = (Convert.ToInt32(jmDateImageItem3.TheMonth) + 6).ToString();
                    jmDateImageItem4.TheMonth = (Convert.ToInt32(jmDateImageItem4.TheMonth) + 6).ToString();
                    jmDateImageItem5.TheMonth = (Convert.ToInt32(jmDateImageItem5.TheMonth) + 6).ToString();
                    jmDateImageItem6.TheMonth = (Convert.ToInt32(jmDateImageItem6.TheMonth) + 6).ToString();
                }
                else
                {
                    jmDateImageItem1.TheMonth = (Convert.ToInt32(jmDateImageItem1.TheMonth) - 6).ToString();
                    jmDateImageItem2.TheMonth = (Convert.ToInt32(jmDateImageItem2.TheMonth) - 6).ToString();
                    jmDateImageItem3.TheMonth = (Convert.ToInt32(jmDateImageItem3.TheMonth) - 6).ToString();
                    jmDateImageItem4.TheMonth = (Convert.ToInt32(jmDateImageItem4.TheMonth) - 6).ToString();
                    jmDateImageItem5.TheMonth = (Convert.ToInt32(jmDateImageItem5.TheMonth) - 6).ToString();
                    jmDateImageItem6.TheMonth = (Convert.ToInt32(jmDateImageItem6.TheMonth) - 6).ToString();
                }
            }
            if ((sender as JMButton).Name == "jmButton1")
            {
                if (ClikeUp != null)
                {
                    ClikeUp(sender);
                }
            }
            else
            {
                if (ClikeDown != null)
                {
                    ClikeDown(sender);
                }
            }
            SelectItem = null;
        }

        private void SetZero()
        {
            jmDateImageItem1.Shouru = 0;
            jmDateImageItem2.Shouru = 0;
            jmDateImageItem3.Shouru = 0;
            jmDateImageItem4.Shouru = 0;
            jmDateImageItem5.Shouru = 0;
            jmDateImageItem6.Shouru = 0;

            jmDateImageItem1.Zhichu = 0;
            jmDateImageItem2.Zhichu = 0;
            jmDateImageItem3.Zhichu = 0;
            jmDateImageItem4.Zhichu = 0;
            jmDateImageItem5.Zhichu = 0;
            jmDateImageItem6.Zhichu = 0;
        }

        private void SetSelectedColor()
        {
            int month=Convert.ToInt32(jmDateImageItem1.TheMonth.Replace("月", ""));
        }

        private void jmDateImageItem1_Click(object sender, EventArgs e)
        {
            SelectItem = sender as JMDateImageItem;
            if (_DaType == DateListType.Month)
            {
                Zmonth = Convert.ToInt32((sender as JMDateImageItem).TheMonth.Replace("月", ""));
            }
            else
            {
                Zyear = Convert.ToInt32((sender as JMDateImageItem).TheMonth);
            }
            if (ClikeItem != null)
                ClikeItem(sender);
            //switch ((sender as JMDateImageItem).Name)
            //{
            //    case "jmDateImageItem1":
            //        break;
            //    case "jmDateImageItem2":
            //        break;
            //    case "jmDateImageItem3":
            //        break;
            //    case "jmDateImageItem4":
            //        break;
            //    case "jmDateImageItem5":
            //        break;
            //    case "jmDateImageItem6":
            //        break;
            //}
        }

        private void jmDateImageItem1_MouseEnter(object sender, EventArgs e)
        {
            (sender as JMDateImageItem).BackColor = _moveColor;
        }

        private void jmDateImageItem1_MouseLeave(object sender, EventArgs e)
        {
            if (sender as JMDateImageItem == SelectItem)
            {
                (sender as JMDateImageItem).BackColor = ZSelectColor;
            }
            else
            {
                (sender as JMDateImageItem).BackColor = this.BackColor;
            }
        }

        private void JMDateList_BackColorChanged(object sender, EventArgs e)
        {
            jmDateImageItem1.BackColor = this.BackColor;
            jmDateImageItem2.BackColor = this.BackColor;
            jmDateImageItem3.BackColor = this.BackColor;
            jmDateImageItem4.BackColor = this.BackColor;
            jmDateImageItem5.BackColor = this.BackColor;
            jmDateImageItem6.BackColor = this.BackColor;
        }
    }
}
