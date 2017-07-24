using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JMControlsEx
{
    public class CardPanel : Panel
    {
        public event EventHandler ClickSave;
        public event EventHandler ClickCha;

        private const int myPadding = 3;
        private const int myimgPadding = 13;

        private Size imgsize = new Size(65, 45);

        private bool _isLock = false;

        public bool IsLock
        {
            get { return _isLock; }
            set { _isLock = value; }
        }

        private bool _isExpland;

        public bool IsExpland
        {
            get { return _isExpland; }
            set
            {
                _isExpland = value;
                if (!IsLock)
                {
                    if (_isExpland)
                    {
                        this.Size = new Size(252, 90);
                        txt_Name.Text = _text;
                    }
                    else
                    {
                        this.Size = new Size(92, 90);
                    }
                }
                Invalidate();
            }
        }

        private Image _img;

        public Image ZImg
        {
            get { return _img; }
            set { _img = value; Invalidate(); }
        }

        private string _id;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _text;

        public string ZText
        {
            get { return _text; }
            set
            {
                _text = value;
                txt_Name.Text = value;
                Invalidate();
            }
        }

        public string NewText
        {
            get { return txt_Name.Text; }
        }

        public decimal ZUpMoney;

        public decimal ZMoney
        {
            get {
                if (!string.IsNullOrEmpty(txt_JE.Text))
                {
                    return Convert.ToDecimal(txt_JE.Text);
                }
                else
                    return 0.00M;
            }
            set {
                txt_JE.Text = value.ToString();
                ZUpMoney = value;
            }
        }

        public bool IsXyk
        {
            get { return txt_JE.IsXYK; }
            set { txt_JE.IsXYK = value; }
        }

        private System.Windows.Forms.Button btn_Save;
        private JMTextBox txt_JE;
        private JMTextBox txt_Name;
        private System.Windows.Forms.Label lab_Cha;
        private System.Windows.Forms.Label lab_JE;
        private System.Windows.Forms.Label lab_Name;

        public CardPanel()
        {
            _isExpland = false;
            _img = null;
            _text = "";
            _id = "";
            Init();

        }

        private void Init()
        {
            this.lab_Name = new System.Windows.Forms.Label();
            this.lab_JE = new System.Windows.Forms.Label();
            this.txt_Name = new JMTextBox();
            this.txt_JE = new JMTextBox();
            this.lab_Cha = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();

            // 
            // lab_Name
            // 
            this.lab_Name.AutoSize = true;
            this.lab_Name.Font = new System.Drawing.Font("宋体", 9F);
            this.lab_Name.Location = new System.Drawing.Point(92, 13);
            this.lab_Name.Name = "lab_JE";
            this.lab_Name.Size = new System.Drawing.Size(60, 11);
            this.lab_Name.TabIndex = 1;
            this.lab_Name.Text = "修改名称：";
            // 
            // lab_JE
            // 
            this.lab_JE.AutoSize = true;
            this.lab_JE.Font = new System.Drawing.Font("宋体", 9F);
            this.lab_JE.Location = new System.Drawing.Point(169, 13);
            this.lab_JE.Name = "lab_JE";
            this.lab_JE.Size = new System.Drawing.Size(60, 11);
            this.lab_JE.TabIndex = 1;
            this.lab_JE.Text = "录入金额：";
            // 
            // txt_Name
            // 
            this.txt_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Name.Location = new System.Drawing.Point(92, 31);
            this.txt_Name.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(69, 21);
            this.txt_Name.TabIndex = 2;
            this.txt_Name.ZBorderColor = Color.FromArgb(198, 198, 198);
            //this.txt_Name.MaxLength = 5;

            // 
            // txt_JE
            // 
            this.txt_JE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_JE.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_JE.Location = new System.Drawing.Point(165, 31);
            this.txt_JE.Name = "txt_JE";
            this.txt_JE.Size = new System.Drawing.Size(69, 21);
            this.txt_JE.TabIndex = 3;
            this.txt_JE.ZDtype = JMDataType.JMDECIMAL;
            this.txt_JE.ZBorderColor = Color.FromArgb(198, 198, 198);
            this.txt_JE.ZMedian = 2;
            this.txt_JE.MaxLen = 14;
            this.txt_JE.MaxLength = 14;
            this.txt_JE.ZNegative = true;

            ///
            ///lab_Cha
            ///
            this.lab_Cha.AutoSize = false;
            this.lab_Cha.Font = new System.Drawing.Font("宋体", 9F, FontStyle.Underline);
            this.lab_Cha.Cursor = Cursors.Hand;
            this.lab_Cha.Location = new System.Drawing.Point(92, 62);
            this.lab_Cha.ForeColor = Color.FromArgb(0, 63, 133);
            this.lab_Cha.Name = "lab_Cha";
            this.lab_Cha.TabIndex = 4;
            this.lab_Cha.Text = "查流水";
            this.lab_Cha.Click += new EventHandler(lab_Cha_Click);

            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(186, 56);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(48, 24);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new EventHandler(btn_Save_Click);

            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lab_Cha);
            this.Controls.Add(this.txt_JE);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lab_JE);
            this.Controls.Add(this.lab_Name);
        }

        private void lab_Cha_Click(object sender, EventArgs e)
        {
            if (ClickCha != null)
            {
                ClickCha(this, e);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (ClickSave!=null)
            {
                ClickSave(this, e);
            }
        }

        private bool tMouseEnter = false;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            IsExpland = !_isExpland;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            tMouseEnter = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            tMouseEnter = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(myPadding, myPadding, Width - myPadding * 2, Height - myPadding * 2);
            GraphicsPath Borderpath = GetGraphicPath.CreatePath(rect, 8, RoundStyle.All, false);
            Color Bordercolor = Color.FromArgb(198, 198, 198);
            if (tMouseEnter)
            {
                Bordercolor = Color.FromArgb(255, 128, 0);
                string str = ZMoney.ToString("N2");
                if (_isLock)
                {
                    str = "LOCK";
                }
                Rectangle rectText = new Rectangle(myimgPadding, myimgPadding, imgsize.Width, imgsize.Height);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                g.DrawString(str, Font, new SolidBrush(ForeColor), rectText, sf);

                //右上角 删除
                //Rectangle rectClose = new Rectangle(Width-18, 5, 12, 12);
                //g.FillRectangle(Brushes.Red, rectClose);
            }
            else
            {
                if (_img != null)
                {
                    Rectangle rectimg = new Rectangle(myimgPadding, myimgPadding, imgsize.Width, imgsize.Height);
                    g.DrawImage(_img, rectimg);
                }
            }

            if (!string.IsNullOrEmpty(_text))
            {
                Rectangle rectText = new Rectangle(myimgPadding, Height - myimgPadding * 2, imgsize.Width+2, myimgPadding * 1+5);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;

                string str = _text;
                if (_text.Length > 5)
                {
                    str = _text.Substring(0, 5);
                }
                g.DrawString(str, Font, new SolidBrush(ForeColor), rectText, sf);
            }

            g.DrawPath(new Pen(Bordercolor), Borderpath);
        }
    }
}
