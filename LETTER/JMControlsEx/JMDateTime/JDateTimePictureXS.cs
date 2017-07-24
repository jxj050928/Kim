using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public partial class JDateTimePictureXS : UserControl
    {
        #region 属性
        /// <summary>
        /// 显示效果显示文字
        /// </summary>
        private string _ZXSEffecText;

        [Description("显示效果显示文字"), DefaultValue(typeof(string), "")]
        public string ZXSEffecText
        {
            get { return _ZXSEffecText; }
            set { _ZXSEffecText = value; label1.Text = value; }
        }

        private string _JMXZQZ = "";

        [Description("名称列"), DefaultValue(typeof(string), "")]
        public string JMXZQZ
        {
            get { return _JMXZQZ; }
            set
            {
                _JMXZQZ = value;
                if (!string.IsNullOrEmpty(jmRundRandTextBox1.ZText))
                    label1.Text = value + "  " + jmRundRandTextBox1.ZText;
            }
        }

        /// <summary>
        /// 显示效果显示文字颜色
        /// </summary>
        private Color _ZXSEffecTextColor;

        [Description("显示效果显示文字"), DefaultValue(typeof(Color), "Black")]
        public Color ZXSEffecTextColor
        {
            get { return _ZXSEffecTextColor; }
            set { _ZXSEffecTextColor = value; label1.ForeColor = value; }
        }

        public string FormatString
        {
            get { return jmRundRandTextBox1.FormatString; }
            set { jmRundRandTextBox1.FormatString = value; }
        }

        /// <summary>
        /// 是否显示效果文字
        /// </summary>
        private bool _ZSFXSEffecText;

        [Description("显示效果显示文字"), DefaultValue(typeof(bool), "true")]
        public bool ZSFXSEffecText
        {
            get { return _ZSFXSEffecText; }
            set { _ZSFXSEffecText = value; 
                panel1.Visible = value == true ? true : false; }
        }

        public string ZText
        {
            get { return jmRundRandTextBox1.ZText; }
            set
            {
                jmRundRandTextBox1.ZText = value;
                if (!string.IsNullOrEmpty(value))
                    label1.Text = JMXZQZ+"  "+value;
            }
        }
        #endregion

        public JDateTimePictureXS()
        {
            InitializeComponent();
            _ZXSEffecTextColor = Color.Black;
            _ZSFXSEffecText = true;
        }

        /// <summary>
        /// 窗体大小更改事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Height = 23;
        }

        /// <summary>
        /// Label与Panel单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Focus();
        }

        /// <summary>
        /// 窗体获得焦点事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            panel1.Visible = false;
        }

        /// <summary>
        /// 窗体离开事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            panel1.Visible = true;
            if (string.IsNullOrEmpty(jmRundRandTextBox1.ZText))
            {
                label1.Text = ZXSEffecText;
            }
            else
            {
                label1.Text = JMXZQZ + "  " + jmRundRandTextBox1.ZText;
            }
        }
    }
}