namespace JMControlsEx
{
    partial class FrmTreeNodeAdd
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
            this.txtName = new JMControlsEx.JMRundRandTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.jm_btn_Cancel = new JMControlsEx.JMButton();
            this.jm_btn_OK = new JMControlsEx.JMButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.txtName.Location = new System.Drawing.Point(83, 25);
            this.txtName.MinimumSize = new System.Drawing.Size(110, 23);
            this.txtName.Name = "txtName";
            this.txtName.PassWordChar = '\0';
            this.txtName.Size = new System.Drawing.Size(169, 23);
            this.txtName.TabIndex = 4;
            this.txtName.ZBlackColor = System.Drawing.Color.Empty;
            this.txtName.ZEmptyTextTip = "--请输入名称--";
            this.txtName.ZFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.ZFormat = "yyyy-MM-dd";
            this.txtName.ZText = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.jm_btn_Cancel);
            this.panel3.Controls.Add(this.jm_btn_OK);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(298, 123);
            this.panel3.TabIndex = 7;
            // 
            // jm_btn_Cancel
            // 
            this.jm_btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.jm_btn_Cancel.JMBaseColor = System.Drawing.Color.DarkGray;
            this.jm_btn_Cancel.JMBaseColorTwo = System.Drawing.Color.White;
            this.jm_btn_Cancel.Location = new System.Drawing.Point(166, 74);
            this.jm_btn_Cancel.Name = "jm_btn_Cancel";
            this.jm_btn_Cancel.Size = new System.Drawing.Size(80, 30);
            this.jm_btn_Cancel.TabIndex = 6;
            this.jm_btn_Cancel.Text = "取消";
            this.jm_btn_Cancel.UseVisualStyleBackColor = true;
            this.jm_btn_Cancel.Click += new System.EventHandler(this.jm_btn_Cancel_Click);
            // 
            // jm_btn_OK
            // 
            this.jm_btn_OK.JMBaseColor = System.Drawing.Color.DarkGray;
            this.jm_btn_OK.JMBaseColorTwo = System.Drawing.Color.White;
            this.jm_btn_OK.Location = new System.Drawing.Point(53, 74);
            this.jm_btn_OK.Name = "jm_btn_OK";
            this.jm_btn_OK.Size = new System.Drawing.Size(80, 30);
            this.jm_btn_OK.TabIndex = 5;
            this.jm_btn_OK.Text = "确定";
            this.jm_btn_OK.UseVisualStyleBackColor = true;
            this.jm_btn_OK.Click += new System.EventHandler(this.jm_btn_OK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "名称";
            // 
            // FrmTypeAdd
            // 
            this.AcceptButton = this.jm_btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.jm_btn_Cancel;
            this.ClientSize = new System.Drawing.Size(300, 125);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTypeAdd";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmTypeAdd_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JMRundRandTextBox txtName;
        private System.Windows.Forms.Panel panel3;
        private JMButton jm_btn_Cancel;
        private JMButton jm_btn_OK;
        private System.Windows.Forms.Label label2;
    }
}