namespace LETTER
{
    partial class FrmUpUserPwd
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
            this.jmTextBoxEx5 = new JMControlsEx.JMTextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.jmTextBoxEx4 = new JMControlsEx.JMTextBoxEx();
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
            this.btn_ok.Location = new System.Drawing.Point(171, 210);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(60, 25);
            this.btn_ok.TabIndex = 10;
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
            this.btn_cancel.Location = new System.Drawing.Point(99, 210);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(60, 25);
            this.btn_cancel.TabIndex = 11;
            this.btn_cancel.Text = "取 消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.jmButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.jmTextBoxEx5);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.jmTextBoxEx4);
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
            this.panel1.Size = new System.Drawing.Size(264, 254);
            this.panel1.TabIndex = 0;
            // 
            // jmTextBoxEx5
            // 
            this.jmTextBoxEx5.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx5.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx5.IsXYK = false;
            this.jmTextBoxEx5.Location = new System.Drawing.Point(83, 168);
            this.jmTextBoxEx5.MaxLen = 30;
            this.jmTextBoxEx5.MaxLength = 30;
            this.jmTextBoxEx5.Name = "jmTextBoxEx5";
            this.jmTextBoxEx5.PasswordChar = '*';
            this.jmTextBoxEx5.Size = new System.Drawing.Size(153, 21);
            this.jmTextBoxEx5.TabIndex = 9;
            this.jmTextBoxEx5.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx5.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx5.ZEmptyTextTip = "";
            this.jmTextBoxEx5.ZFormat = "yyyy-MM-dd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(20, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "密码确认";
            // 
            // jmTextBoxEx4
            // 
            this.jmTextBoxEx4.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx4.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx4.IsXYK = false;
            this.jmTextBoxEx4.Location = new System.Drawing.Point(83, 132);
            this.jmTextBoxEx4.MaxLen = 30;
            this.jmTextBoxEx4.MaxLength = 30;
            this.jmTextBoxEx4.Name = "jmTextBoxEx4";
            this.jmTextBoxEx4.PasswordChar = '*';
            this.jmTextBoxEx4.Size = new System.Drawing.Size(153, 21);
            this.jmTextBoxEx4.TabIndex = 7;
            this.jmTextBoxEx4.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx4.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx4.ZEmptyTextTip = "";
            this.jmTextBoxEx4.ZFormat = "yyyy-MM-dd";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(20, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "新密码";
            // 
            // jmTextBoxEx3
            // 
            this.jmTextBoxEx3.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx3.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx3.IsXYK = false;
            this.jmTextBoxEx3.Location = new System.Drawing.Point(83, 96);
            this.jmTextBoxEx3.MaxLen = 30;
            this.jmTextBoxEx3.MaxLength = 30;
            this.jmTextBoxEx3.Name = "jmTextBoxEx3";
            this.jmTextBoxEx3.Size = new System.Drawing.Size(153, 21);
            this.jmTextBoxEx3.TabIndex = 5;
            this.jmTextBoxEx3.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx3.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx3.ZEmptyTextTip = "";
            this.jmTextBoxEx3.ZFormat = "yyyy-MM-dd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "新用户名";
            // 
            // jmTextBoxEx2
            // 
            this.jmTextBoxEx2.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx2.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx2.IsXYK = false;
            this.jmTextBoxEx2.Location = new System.Drawing.Point(83, 60);
            this.jmTextBoxEx2.MaxLen = 30;
            this.jmTextBoxEx2.MaxLength = 30;
            this.jmTextBoxEx2.Name = "jmTextBoxEx2";
            this.jmTextBoxEx2.PasswordChar = '*';
            this.jmTextBoxEx2.Size = new System.Drawing.Size(153, 21);
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
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "原密码";
            // 
            // jmTextBoxEx1
            // 
            this.jmTextBoxEx1.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx1.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx1.IsXYK = false;
            this.jmTextBoxEx1.Location = new System.Drawing.Point(83, 24);
            this.jmTextBoxEx1.MaxLen = 30;
            this.jmTextBoxEx1.MaxLength = 30;
            this.jmTextBoxEx1.Name = "jmTextBoxEx1";
            this.jmTextBoxEx1.Size = new System.Drawing.Size(153, 21);
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
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原用户名";
            // 
            // FrmUpUserPwd
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(264, 254);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpUserPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户密码修改";
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
        private JMControlsEx.JMTextBoxEx jmTextBoxEx5;
        private System.Windows.Forms.Label label5;
        private JMControlsEx.JMTextBoxEx jmTextBoxEx4;
        private System.Windows.Forms.Label label4;
        private JMControlsEx.JMTextBoxEx jmTextBoxEx3;
        private System.Windows.Forms.Label label3;
        private JMControlsEx.JMTextBoxEx jmTextBoxEx2;
        private System.Windows.Forms.Label label2;
    }
}