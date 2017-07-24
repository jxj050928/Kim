namespace LETTER
{
    partial class FrmLogin
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.jm_btn_Login = new JMControlsEx.JMButton();
            this.jm_txt_Pwd = new JMControlsEx.JMPwdTextBox();
            this.jm_txt_Name = new JMControlsEx.JMPwdTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_Close = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.jm_btn_Login);
            this.panel3.Controls.Add(this.jm_txt_Pwd);
            this.panel3.Controls.Add(this.jm_txt_Name);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(60, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(492, 245);
            this.panel3.TabIndex = 2;
            // 
            // jm_btn_Login
            // 
            this.jm_btn_Login.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.jm_btn_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(104)))), ((int)(((byte)(117)))));
            this.jm_btn_Login.JMBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.jm_btn_Login.JMBaseColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(193)))), ((int)(((byte)(233)))));
            this.jm_btn_Login.JMRadius = 10;
            this.jm_btn_Login.Location = new System.Drawing.Point(271, 190);
            this.jm_btn_Login.Name = "jm_btn_Login";
            this.jm_btn_Login.Size = new System.Drawing.Size(197, 40);
            this.jm_btn_Login.TabIndex = 5;
            this.jm_btn_Login.Text = "登录 / Login";
            this.jm_btn_Login.UseVisualStyleBackColor = true;
            this.jm_btn_Login.Click += new System.EventHandler(this.jm_btn_Login_Click);
            // 
            // jm_txt_Pwd
            // 
            this.jm_txt_Pwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jm_txt_Pwd.BackColor = System.Drawing.Color.White;
            this.jm_txt_Pwd.JMEnterImage = global::LETTER.Properties.Resources.PassEnter;
            this.jm_txt_Pwd.JMImage = global::LETTER.Properties.Resources.pass;
            this.jm_txt_Pwd.JMImageLocation = new System.Drawing.Point(1, 1);
            this.jm_txt_Pwd.JMImgaeSize = new System.Drawing.Size(36, 38);
            this.jm_txt_Pwd.JMMaxLenght = 30;
            this.jm_txt_Pwd.JMPasswordChar = '*';
            this.jm_txt_Pwd.JMTBLableBlackColor = System.Drawing.Color.White;
            this.jm_txt_Pwd.JMTBLableColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.jm_txt_Pwd.JMTBLableFont = new System.Drawing.Font("宋体", 9.5F);
            this.jm_txt_Pwd.JMTBLableVisible = true;
            this.jm_txt_Pwd.JMText = "";
            this.jm_txt_Pwd.JMTextBoxLable = "";
            this.jm_txt_Pwd.JMTextBoxLocation = new System.Drawing.Point(40, 5);
            this.jm_txt_Pwd.JMTextTip = "";
            this.jm_txt_Pwd.Location = new System.Drawing.Point(25, 132);
            this.jm_txt_Pwd.MinimumSize = new System.Drawing.Size(212, 27);
            this.jm_txt_Pwd.Name = "jm_txt_Pwd";
            this.jm_txt_Pwd.Size = new System.Drawing.Size(443, 40);
            this.jm_txt_Pwd.TabIndex = 3;
            // 
            // jm_txt_Name
            // 
            this.jm_txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jm_txt_Name.BackColor = System.Drawing.Color.White;
            this.jm_txt_Name.JMEnterImage = global::LETTER.Properties.Resources.UserEnter;
            this.jm_txt_Name.JMImage = global::LETTER.Properties.Resources.user;
            this.jm_txt_Name.JMImageLocation = new System.Drawing.Point(1, 1);
            this.jm_txt_Name.JMImgaeSize = new System.Drawing.Size(36, 38);
            this.jm_txt_Name.JMMaxLenght = 30;
            this.jm_txt_Name.JMPasswordChar = '\0';
            this.jm_txt_Name.JMTBLableBlackColor = System.Drawing.Color.White;
            this.jm_txt_Name.JMTBLableColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.jm_txt_Name.JMTBLableFont = new System.Drawing.Font("宋体", 9.5F);
            this.jm_txt_Name.JMTBLableVisible = true;
            this.jm_txt_Name.JMText = "";
            this.jm_txt_Name.JMTextBoxLable = "";
            this.jm_txt_Name.JMTextBoxLocation = new System.Drawing.Point(40, 5);
            this.jm_txt_Name.JMTextTip = "";
            this.jm_txt_Name.Location = new System.Drawing.Point(25, 48);
            this.jm_txt_Name.MinimumSize = new System.Drawing.Size(212, 27);
            this.jm_txt_Name.Name = "jm_txt_Name";
            this.jm_txt_Name.Size = new System.Drawing.Size(443, 40);
            this.jm_txt_Name.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(129)))), ((int)(((byte)(136)))));
            this.label7.Location = new System.Drawing.Point(23, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "密码 / Password：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(129)))), ((int)(((byte)(136)))));
            this.label6.Location = new System.Drawing.Point(23, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "用户名 / User name：";
            // 
            // pnl_Close
            // 
            this.pnl_Close.BackgroundImage = global::LETTER.Properties.Resources.close;
            this.pnl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnl_Close.Location = new System.Drawing.Point(546, 33);
            this.pnl_Close.Name = "pnl_Close";
            this.pnl_Close.Size = new System.Drawing.Size(32, 32);
            this.pnl_Close.TabIndex = 3;
            this.pnl_Close.Click += new System.EventHandler(this.pnl_Close_Click);
            this.pnl_Close.MouseEnter += new System.EventHandler(this.pnl_Close_MouseEnter);
            this.pnl_Close.MouseLeave += new System.EventHandler(this.pnl_Close_MouseLeave);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.jm_btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LETTER.Properties.Resources.Login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.pnl_Close);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private JMControlsEx.JMPwdTextBox jm_txt_Name;
        private JMControlsEx.JMPwdTextBox jm_txt_Pwd;
        private JMControlsEx.JMButton jm_btn_Login;
        private System.Windows.Forms.Panel pnl_Close;


    }
}