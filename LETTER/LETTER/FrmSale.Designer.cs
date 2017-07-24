namespace LETTER
{
    partial class FrmSale
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
            this.btn_ok.Location = new System.Drawing.Point(177, 81);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(60, 25);
            this.btn_ok.TabIndex = 3;
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
            this.btn_cancel.Location = new System.Drawing.Point(105, 81);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(60, 25);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "取 消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.jmButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.jmTextBoxEx1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 129);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // jmTextBoxEx1
            // 
            this.jmTextBoxEx1.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx1.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx1.IsXYK = false;
            this.jmTextBoxEx1.Location = new System.Drawing.Point(68, 37);
            this.jmTextBoxEx1.MaxLen = 3;
            this.jmTextBoxEx1.MaxLength = 3;
            this.jmTextBoxEx1.Name = "jmTextBoxEx1";
            this.jmTextBoxEx1.Size = new System.Drawing.Size(144, 21);
            this.jmTextBoxEx1.TabIndex = 1;
            this.jmTextBoxEx1.Text = "0";
            this.jmTextBoxEx1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.jmTextBoxEx1.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx1.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx1.ZDtype = JMControlsEx.JMDataType.JMDECIMAL;
            this.jmTextBoxEx1.ZFormat = "yyyy-MM-dd";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "折扣：";
            // 
            // FrmSale
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(256, 129);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "折扣管理";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JMControlsEx.JMButton btn_ok;
        private JMControlsEx.JMButton btn_cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private JMControlsEx.JMTextBoxEx jmTextBoxEx1;
        private System.Windows.Forms.Label label1;
    }
}