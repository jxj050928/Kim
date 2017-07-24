namespace LETTER
{
    partial class FrmCharge
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
            this.btnReadCard = new JMControlsEx.JMButton();
            this.label_PeoBalance = new System.Windows.Forms.Label();
            this.label_Peoname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_search = new JMControlsEx.JMButton();
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
            this.btn_ok.Location = new System.Drawing.Point(232, 177);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(60, 25);
            this.btn_ok.TabIndex = 9;
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
            this.btn_cancel.Location = new System.Drawing.Point(160, 177);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(60, 25);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "取 消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.jmButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnReadCard);
            this.panel1.Controls.Add(this.label_PeoBalance);
            this.panel1.Controls.Add(this.label_Peoname);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.jmTextBoxEx2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.jmTextBoxEx1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 219);
            this.panel1.TabIndex = 0;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadCard.Font = new System.Drawing.Font("宋体", 9F);
            this.btnReadCard.ForeColor = System.Drawing.Color.White;
            this.btnReadCard.JMBaseColor = System.Drawing.Color.Maroon;
            this.btnReadCard.JMBaseColorTwo = System.Drawing.Color.Maroon;
            this.btnReadCard.JMRadius = 1;
            this.btnReadCard.Location = new System.Drawing.Point(221, 21);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(39, 21);
            this.btnReadCard.TabIndex = 11;
            this.btnReadCard.Text = "读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // label_PeoBalance
            // 
            this.label_PeoBalance.AutoSize = true;
            this.label_PeoBalance.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_PeoBalance.ForeColor = System.Drawing.Color.Green;
            this.label_PeoBalance.Location = new System.Drawing.Point(79, 130);
            this.label_PeoBalance.Name = "label_PeoBalance";
            this.label_PeoBalance.Size = new System.Drawing.Size(53, 20);
            this.label_PeoBalance.TabIndex = 8;
            this.label_PeoBalance.Text = "0.00";
            // 
            // label_Peoname
            // 
            this.label_Peoname.AutoSize = true;
            this.label_Peoname.ForeColor = System.Drawing.Color.Green;
            this.label_Peoname.Location = new System.Drawing.Point(79, 100);
            this.label_Peoname.Name = "label_Peoname";
            this.label_Peoname.Size = new System.Drawing.Size(0, 12);
            this.label_Peoname.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "当前余额";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "会员姓名";
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.JMBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            this.btn_search.JMBaseColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            this.btn_search.JMRadius = 1;
            this.btn_search.Location = new System.Drawing.Point(260, 21);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(39, 21);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // jmTextBoxEx2
            // 
            this.jmTextBoxEx2.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx2.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx2.IsXYK = false;
            this.jmTextBoxEx2.Location = new System.Drawing.Point(79, 57);
            this.jmTextBoxEx2.MaxLen = 10;
            this.jmTextBoxEx2.MaxLength = 20;
            this.jmTextBoxEx2.Name = "jmTextBoxEx2";
            this.jmTextBoxEx2.Size = new System.Drawing.Size(220, 21);
            this.jmTextBoxEx2.TabIndex = 4;
            this.jmTextBoxEx2.Text = "0.00";
            this.jmTextBoxEx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.jmTextBoxEx2.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx2.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx2.ZDtype = JMControlsEx.JMDataType.JMDECIMAL;
            this.jmTextBoxEx2.ZFormat = "yyyy-MM-dd";
            this.jmTextBoxEx2.ZMedian = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "充值金额";
            // 
            // jmTextBoxEx1
            // 
            this.jmTextBoxEx1.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx1.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx1.IsXYK = false;
            this.jmTextBoxEx1.Location = new System.Drawing.Point(79, 21);
            this.jmTextBoxEx1.MaxLen = 20;
            this.jmTextBoxEx1.MaxLength = 20;
            this.jmTextBoxEx1.Name = "jmTextBoxEx1";
            this.jmTextBoxEx1.Size = new System.Drawing.Size(141, 21);
            this.jmTextBoxEx1.TabIndex = 1;
            this.jmTextBoxEx1.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx1.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx1.ZEmptyTextTip = "";
            this.jmTextBoxEx1.ZFormat = "yyyy-MM-dd";
            this.jmTextBoxEx1.TextChanged += new System.EventHandler(this.jmTextBoxEx1_TextChanged);
            this.jmTextBoxEx1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.jmTextBoxEx1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手机号码";
            // 
            // FrmCharge
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(314, 219);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "充值";
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
        private JMControlsEx.JMButton btn_search;
        private System.Windows.Forms.Label label_PeoBalance;
        private System.Windows.Forms.Label label_Peoname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private JMControlsEx.JMButton btnReadCard;
    }
}