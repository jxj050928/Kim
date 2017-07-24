using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JMLinkLabelImage : FlowLayoutPanel
    {
        Label JMLB = new Label();
        PictureBox JMPB = new PictureBox();
        ToolTip too = new ToolTip();

        public event JMDelegate.IEventHandle JMLabelClick;

        int rightwidth = 2;

        /// <summary>
        /// 显示文本值
        /// </summary>
        private string _ZText = "label1";

        [Description("显示文本值")]
        public string ZText
        {
            get { return _ZText; }
            set
            {
                _ZText = value;
                JMLB.Text = value;
                if (!string.IsNullOrEmpty(_ZText))
                {
                    if (JMPB.Image == null)
                    {
                        this.Width = 1 + JMLB.Width + rightwidth;
                    }
                    else
                    {
                        this.Width = 1 + JMLB.Width + 1 + JMPB.Width + rightwidth;
                    }
                }
            }
        }

        /// <summary>
        /// 显示图像值
        /// </summary>
        private Image _ZImage;

        [Description("显示图像值")]
        public Image ZImage
        {
            get { return _ZImage; }
            set
            {
                _ZImage = value;
                JMPB.Image = value;
                if (_ZImage != null)
                {
                    if (!string.IsNullOrEmpty(_ZText))
                    {
                        this.Width = 1 + JMLB.Width + 1 + JMPB.Width + rightwidth;
                    }
                    else
                    {
                        this.Width = 1 + 1 + JMPB.Width + rightwidth;
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标悬停显示内容
        /// </summary>
        private string _ZVipTian;

        [Description("鼠标悬停显示内容")]
        public string ZVipTian
        {
            get { return _ZVipTian; }
            set { _ZVipTian = value; }
        }

        /// <summary>
        /// Xml文件名不含.xml
        /// </summary>
        private string _ZXmlName;

        [Description("Xml文件名不含.xml")]
        public string ZXmlName
        {
            get { return _ZXmlName; }
            set { _ZXmlName = value; JMLB.Tag = value; }
        }

        public JMLinkLabelImage()
        {
            ///
            ///添加label
            ///
            JMLB.Name = "Label1";
            JMLB.AutoSize = true;
            JMLB.ForeColor = Color.FromArgb(0, 0, 255);
            JMLB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline);
            JMLB.Cursor = Cursors.Hand;
            JMLB.Click += new EventHandler(JMLB_Click);
            JMLB.Text = _ZText;
            JMLB.Visible = true;

            ///
            ///添加picturebox
            ///
            JMPB.Name = "picturebox1";
            JMPB.Image = _ZImage;
            //JMPB.Size = new Size(29, 13);
            //JMPB.SizeMode = PictureBoxSizeMode.Normal;
            JMPB.SizeMode = PictureBoxSizeMode.AutoSize;
            JMPB.MouseEnter += new EventHandler(JMPB_MouseEnter);
            JMPB.Visible = true;

            this.Size = new Size(100, 20);
            this.Padding = new Padding(1, (this.Height - 12) / 2, 0, 0);
            JMLB.Margin = new Padding(0, 0, 0, 0);
            JMPB.Margin = new Padding(1, (this.Height - JMPB.Height) / 2 - 1, 0, 0);

            this.Controls.Add(JMLB);
            this.Controls.Add(JMPB);
        }

        private void JMLB_Click(object sender, EventArgs e)
        {
            if (JMLabelClick != null)
            {
                JEventargs ee = new JEventargs();
                JMLabelClick(this, ee);
            }
        }

        #region VIP图片鼠标悬停显示内容
        private void JMPB_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_ZVipTian))
            {
                too.SetToolTip(JMPB, _ZVipTian);
            }
        }
        #endregion
    }
}