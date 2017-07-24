using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;

namespace JMControlsEx
{
    public class JMComboBoxButton : Panel
    {
        ToolTip tt = new ToolTip();

        Label jmlb;

        JMTextBox jmtb;

        PictureBox jmpb;

        PictureBox jmpb1;

        #region 属性
        /// <summary>
        /// 修改图像
        /// </summary>
        private Image _JMUpdateImage;

        [Description("修改图像")]
        public Image JMUpdateImage
        {
            get { return _JMUpdateImage; }
            set { _JMUpdateImage = value; jmpb.Image = value; KJLocation(); }
        }

        /// <summary>
        /// 删除图像
        /// </summary>
        private Image _JMDeleteImage;

        [Description("删除图像")]
        public Image JMDeleteImage
        {
            get { return _JMDeleteImage; }
            set { _JMDeleteImage = value; jmpb1.Image = value; KJLocation(); }
        }

        /// <summary>
        /// 保存图像
        /// </summary>
        private Image _JMSaveImage;

        [Description("保存图像")]
        public Image JMSaveImage
        {
            get { return _JMSaveImage; }
            set { _JMSaveImage = value; }
        }

        /// <summary>
        /// 图片大小
        /// </summary>
        private Size _JMImageSize;

        [Description("图片大小")]
        public Size JMImageSize
        {
            get { return _JMImageSize; }
            set { _JMImageSize = value; jmpb.Size = value; jmpb1.Size = value; KJLocation(); }
        }

        private string _JMTextID;

        [Description("显示文本编号")]
        public string JMTextID
        {
            get { return _JMTextID; }
            set { _JMTextID = value; jmlb.Tag = value; }
        }

        /// <summary>
        /// 显示文本
        /// </summary>
        private string _JMText;

        [Description("显示文本")]
        public string JMText
        {
            get { return _JMText; }
            set { _JMText = value; jmlb.Text = value; KJLocation(); }
        }

        /// <summary>
        /// 显示文本
        /// </summary>
        private string _JMNewText="";

        [Description("显示文本")]
        public string JMNewText
        {
            get { return _JMNewText; }
            set { _JMNewText = value; }
        }

        /// <summary>
        /// 显示文本颜色
        /// </summary>
        private Color _JMTextColor;

        [Description("显示文本颜色")]
        public Color JMTextColor
        {
            get { return _JMTextColor; }
            set { _JMTextColor = value; jmlb.ForeColor = value; KJLocation(); }
        }

        /// <summary>
        /// 值为空提示
        /// </summary>
        private string _JMMessage;

        [Description("值为空提示")]
        public string JMMessage
        {
            get { return _JMMessage; }
            set { _JMMessage = value; }
        }

        /// <summary>
        /// 限制最大字符
        /// </summary>
        private int _MaxLen;

        [Description("限制最大字符")]
        public int MaxLen
        {
            get { return _MaxLen; }
            set { _MaxLen = value; jmtb.MaxLen = value; }
        }
        #endregion

        #region 事件
        [Description("单击事件")]
        public event JMDelegate.DelItemEventHandle JM_Click;

        [Description("单击选择事件")]
        public event JMDelegate.ClickDeleteHandel JM_ChooseClick;

        [Description("单击删除事件")]
        public event JMDelegate.DelItemEventHandle JM_DeleteClick;
        #endregion

        private void KJLocation()
        {
            jmlb.Location = new Point(8, (this.Height - jmlb.Height) / 2);
            jmtb.Location = new Point(8, (this.Height - jmtb.Height) / 2);
            jmpb.Location = new Point(jmtb.Location.X + jmtb.Width + 6, (this.Height - jmpb.Height) / 2);
            jmpb1.Location = new Point(jmpb.Location.X + jmpb.Width + 6, (this.Height - jmpb1.Height) / 2);
        }

        public JMComboBoxButton()
        {
            _JMImageSize = new Size(20, 20);
            _MaxLen = 30;
            _JMText = "";
            _JMTextColor = Color.Black;
            this.BackColor = Color.Transparent;
            this.Cursor = Cursors.Hand;
            this.MinimumSize = new Size(116, 33);
            this.MouseEnter += new EventHandler(JMImageButton_MouseEnter);
            this.MouseLeave += new EventHandler(JMImageButton_MouseLeave);

            jmlb = new Label();
            jmlb.Name = "label1";
            jmlb.AutoSize = true;
            jmlb.BackColor = Color.Transparent;
            jmlb.Text = "";
            jmlb.Font = this.Font;
            jmlb.ForeColor = _JMTextColor;
            jmlb.Cursor = Cursors.Hand;
            jmlb.Click += new EventHandler(jmlb_Click);
            jmlb.MouseEnter += new EventHandler(JMImageButton_MouseEnter);
            jmlb.MouseLeave += new EventHandler(JMImageButton_MouseLeave);
            this.Controls.Add(jmlb);

            jmtb = new JMTextBox();
            jmtb.Name = "textbox1";
            jmtb.BackColor = Color.White;
            jmtb.ZBorderColor = Color.White;
            jmtb.ZEmptyTextTip = "";
            jmtb.MaxLen = _MaxLen;
            jmtb.Text = "";
            jmtb.Cursor = Cursors.Hand;
            jmtb.Visible = false;
            jmtb.MouseEnter += new EventHandler(JMImageButton_MouseEnter);
            this.Controls.Add(jmtb);
            jmtb.Size = new Size(50, 21);

            jmpb = new PictureBox();
            jmpb.Name = "picturebox1";
            jmpb.Cursor = Cursors.Hand;
            jmpb.Image = _JMUpdateImage;
            jmpb.Size = _JMImageSize;
            jmpb.SizeMode = PictureBoxSizeMode.StretchImage;
            jmpb.BackColor = Color.Transparent;
            jmpb.Click += new EventHandler(jmpb_Click);
            jmpb.MouseEnter += new EventHandler(JMImageButton_MouseEnter);
            this.Controls.Add(jmpb);

            jmpb1 = new PictureBox();
            jmpb1.Name = "picturebox2";
            jmpb1.Cursor = Cursors.Hand;
            jmpb1.Image = _JMUpdateImage;
            jmpb1.Size = _JMImageSize;
            jmpb1.SizeMode = PictureBoxSizeMode.StretchImage;
            jmpb1.BackColor = Color.Transparent;
            jmpb1.Click += new EventHandler(jmpb_Click);
            jmpb1.MouseEnter += new EventHandler(JMImageButton_MouseEnter);
            this.Controls.Add(jmpb1);

            this.Size = new Size(116, 33);

            jmlb.Location = new Point(8, (this.Height - jmlb.Height) / 2);
            jmtb.Location = new Point(8, (this.Height - jmtb.Height) / 2);
            jmpb.Location = new Point(jmtb.Location.X + jmtb.Width + 6, (this.Height - jmpb.Height) / 2);
            jmpb1.Location = new Point(jmpb.Location.X + jmpb.Width + 6, (this.Height - jmpb1.Height) / 2);

            
        }
        
        /// <summary>
        /// 单击修改和删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jmpb_Click(object sender, EventArgs e)
        {
            switch (((PictureBox)(sender)).Name)
            {
                case "picturebox1":
                    if (jmtb.Visible)
                    {
                        if (string.IsNullOrEmpty(jmtb.Text.Trim()))
                        {
                            MessageBox.Show(_JMMessage, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (JM_Click != null)
                        {
                            CancelEventArgs ee = new CancelEventArgs();
                            JMNewText = jmtb.Text;
                            JM_Click(this, ee);
                            if (ee.Cancel)
                            {
                                jmtb.Visible = false;
                                jmlb.Visible = true;
                                ((PictureBox)(sender)).Image = _JMUpdateImage;
                                JMText= jmtb.Text;
                                //jmlb.Text 
                            }
                        }
                    }
                    else
                    {
                        jmtb.Visible = true;
                        jmlb.Visible = false;
                        jmtb.Text = jmlb.Text;
                        ((PictureBox)(sender)).Image = _JMSaveImage;
                        jmtb.Tag = jmlb.Tag;
                        this.Focus();
                        jmtb.Focus();
                    }
                    break;
                case "picturebox2":
                    if (JM_DeleteClick != null)
                    {
                        CancelEventArgs ee = new CancelEventArgs();
                        JM_DeleteClick(this, ee);
                    }
                    break;
            }
        }

        /// <summary>
        /// 单击选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jmlb_Click(object sender, EventArgs e)
        {
            if (JM_ChooseClick != null)
            {
                JM_ChooseClick(jmlb.Tag.ToString(), jmlb.Text.Trim());
            }
        }

        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JMImageButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                if (((PictureBox)(sender)).Name == "picturebox1")
                {
                    if (!jmtb.Visible)
                    {
                        tt.SetToolTip(((PictureBox)(sender)), "修改");
                    }
                    else
                    {
                        tt.SetToolTip(((PictureBox)(sender)), "保存");
                    }
                }
                else if (((PictureBox)(sender)).Name == "picturebox2")
                {
                    tt.SetToolTip(((PictureBox)(sender)), "删除");
                }
            }
            this.BackColor = Color.FromArgb(0, 83, 177);
            jmlb.ForeColor = Color.White;
            this.Focus();
            //jmtb.Focus();
        }

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="e"></param>
        private void JMImageButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
            jmlb.ForeColor = JMTextColor;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.BackColor = Color.Transparent;
            jmlb.ForeColor = JMTextColor;
            jmtb.Visible = false;
            jmlb.Visible = true;
            jmpb.Image = _JMUpdateImage;
        }

        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (JM_ChooseClick != null)
            {
                JM_ChooseClick(jmlb.Tag.ToString(), jmlb.Text.Trim());
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            KJLocation();
        }
    }
}
