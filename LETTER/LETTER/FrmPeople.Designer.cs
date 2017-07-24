namespace LETTER
{
    partial class FrmPeople
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ok = new JMControlsEx.JMButton();
            this.btn_cancel = new JMControlsEx.JMButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.jmTextBoxEx4 = new JMControlsEx.JMTextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.jmDateTime1 = new JMControlsEx.JMDateTime();
            this.label5 = new System.Windows.Forms.Label();
            this.jmRadioButton2 = new JMControlsEx.JMRadioButton();
            this.jmRadioButton1 = new JMControlsEx.JMRadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.jmTextBoxEx3 = new JMControlsEx.JMTextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.jmTextBoxEx2 = new JMControlsEx.JMTextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.jmTextBoxEx1 = new JMControlsEx.JMTextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.JMBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            this.btn_ok.JMBaseColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            this.btn_ok.JMRadius = 25;
            this.btn_ok.Location = new System.Drawing.Point(364, 153);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 25);
            this.btn_ok.TabIndex = 13;
            this.btn_ok.Text = "确 定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.jm_btn_Login_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_cancel.JMBaseColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.JMBaseColorTwo = System.Drawing.SystemColors.Control;
            this.btn_cancel.JMRadius = 25;
            this.btn_cancel.Location = new System.Drawing.Point(270, 153);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_cancel.TabIndex = 14;
            this.btn_cancel.Text = "取 消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.jmButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.jmTextBoxEx4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.jmDateTime1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.jmRadioButton2);
            this.panel1.Controls.Add(this.jmRadioButton1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.jmTextBoxEx3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.jmTextBoxEx2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.jmTextBoxEx1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 194);
            this.panel1.TabIndex = 0;
            // 
            // jmTextBoxEx4
            // 
            this.jmTextBoxEx4.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx4.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx4.IsXYK = false;
            this.jmTextBoxEx4.Location = new System.Drawing.Point(78, 85);
            this.jmTextBoxEx4.MaxLen = 18;
            this.jmTextBoxEx4.MaxLength = 500;
            this.jmTextBoxEx4.Name = "jmTextBoxEx4";
            this.jmTextBoxEx4.Size = new System.Drawing.Size(365, 21);
            this.jmTextBoxEx4.TabIndex = 10;
            this.jmTextBoxEx4.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx4.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx4.ZEmptyTextTip = "";
            this.jmTextBoxEx4.ZFormat = "yyyy-MM-dd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "身份证号";
            // 
            // jmDateTime1
            // 
            this.jmDateTime1.BackColor = System.Drawing.Color.White;
            this.jmDateTime1.BorderColor = System.Drawing.Color.Silver;
            this.jmDateTime1.Location = new System.Drawing.Point(303, 53);
            this.jmDateTime1.MonthBorderColor = System.Drawing.Color.Silver;
            this.jmDateTime1.Name = "jmDateTime1";
            this.jmDateTime1.Size = new System.Drawing.Size(140, 21);
            this.jmDateTime1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "出生日期";
            // 
            // jmRadioButton2
            // 
            this.jmRadioButton2.AutoSize = true;
            this.jmRadioButton2.Location = new System.Drawing.Point(146, 55);
            this.jmRadioButton2.Name = "jmRadioButton2";
            this.jmRadioButton2.Size = new System.Drawing.Size(35, 16);
            this.jmRadioButton2.TabIndex = 6;
            this.jmRadioButton2.TabStop = true;
            this.jmRadioButton2.Text = "女";
            this.jmRadioButton2.UseVisualStyleBackColor = true;
            this.jmRadioButton2.ZBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            // 
            // jmRadioButton1
            // 
            this.jmRadioButton1.AutoSize = true;
            this.jmRadioButton1.Location = new System.Drawing.Point(93, 55);
            this.jmRadioButton1.Name = "jmRadioButton1";
            this.jmRadioButton1.Size = new System.Drawing.Size(35, 16);
            this.jmRadioButton1.TabIndex = 5;
            this.jmRadioButton1.TabStop = true;
            this.jmRadioButton1.Text = "男";
            this.jmRadioButton1.UseVisualStyleBackColor = true;
            this.jmRadioButton1.ZBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "会员性别";
            // 
            // jmTextBoxEx3
            // 
            this.jmTextBoxEx3.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx3.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx3.IsXYK = false;
            this.jmTextBoxEx3.Location = new System.Drawing.Point(78, 119);
            this.jmTextBoxEx3.MaxLen = 240;
            this.jmTextBoxEx3.MaxLength = 500;
            this.jmTextBoxEx3.Name = "jmTextBoxEx3";
            this.jmTextBoxEx3.Size = new System.Drawing.Size(365, 21);
            this.jmTextBoxEx3.TabIndex = 12;
            this.jmTextBoxEx3.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx3.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx3.ZEmptyTextTip = "";
            this.jmTextBoxEx3.ZFormat = "yyyy-MM-dd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "家庭住址";
            // 
            // jmTextBoxEx2
            // 
            this.jmTextBoxEx2.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx2.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx2.IsXYK = false;
            this.jmTextBoxEx2.Location = new System.Drawing.Point(303, 20);
            this.jmTextBoxEx2.MaxLen = 11;
            this.jmTextBoxEx2.MaxLength = 20;
            this.jmTextBoxEx2.Name = "jmTextBoxEx2";
            this.jmTextBoxEx2.Size = new System.Drawing.Size(140, 21);
            this.jmTextBoxEx2.TabIndex = 3;
            this.jmTextBoxEx2.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx2.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx2.ZEmptyTextTip = "";
            this.jmTextBoxEx2.ZFormat = "yyyy-MM-dd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(240, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "手机号码";
            // 
            // jmTextBoxEx1
            // 
            this.jmTextBoxEx1.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx1.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx1.IsXYK = false;
            this.jmTextBoxEx1.Location = new System.Drawing.Point(78, 20);
            this.jmTextBoxEx1.MaxLen = 30;
            this.jmTextBoxEx1.MaxLength = 60;
            this.jmTextBoxEx1.Name = "jmTextBoxEx1";
            this.jmTextBoxEx1.Size = new System.Drawing.Size(140, 21);
            this.jmTextBoxEx1.TabIndex = 1;
            this.jmTextBoxEx1.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx1.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx1.ZEmptyTextTip = "";
            this.jmTextBoxEx1.ZFormat = "yyyy-MM-dd";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员姓名";
            // 
            // FrmPeople
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(467, 194);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员管理";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JMControlsEx.JMButton btn_ok;
        private JMControlsEx.JMButton btn_cancel;
        private System.Windows.Forms.Panel panel1;
        private JMControlsEx.JMTextBoxEx jmTextBoxEx1;
        private System.Windows.Forms.Label label1;
        private JMControlsEx.JMTextBoxEx jmTextBoxEx2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private JMControlsEx.JMTextBoxEx jmTextBoxEx3;
        private JMControlsEx.JMDateTime jmDateTime1;
        private System.Windows.Forms.Label label5;
        private JMControlsEx.JMRadioButton jmRadioButton2;
        private JMControlsEx.JMRadioButton jmRadioButton1;
        private System.Windows.Forms.Label label4;
        private JMControlsEx.JMTextBoxEx jmTextBoxEx4;
        private System.Windows.Forms.Label label6;
    }
}