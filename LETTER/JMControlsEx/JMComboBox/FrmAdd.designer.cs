namespace JMControlsEx
{
    partial class FrmAdd
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
            this.txtName = new JMControlsEx.JMRundRandTextBox();
            this.txtPath = new JMControlsEx.JMRundRandTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.jm_btn_Cancel = new JMControlsEx.JMButton();
            this.jm_btn_OK = new JMControlsEx.JMButton();
            this.jm_btn_LiuLan = new JMControlsEx.JMButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.txtPath);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.jm_btn_Cancel);
            this.panel3.Controls.Add(this.jm_btn_OK);
            this.panel3.Controls.Add(this.jm_btn_LiuLan);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 123);
            this.panel3.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.txtName.Location = new System.Drawing.Point(131, 50);
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
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.Transparent;
            this.txtPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.txtPath.Location = new System.Drawing.Point(131, 14);
            this.txtPath.MinimumSize = new System.Drawing.Size(110, 23);
            this.txtPath.Name = "txtPath";
            this.txtPath.PassWordChar = '\0';
            this.txtPath.Size = new System.Drawing.Size(125, 23);
            this.txtPath.TabIndex = 1;
            this.txtPath.ZBlackColor = System.Drawing.Color.White;
            this.txtPath.ZEmptyTextTip = "";
            this.txtPath.ZFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPath.ZFormat = "yyyy-MM-dd";
            this.txtPath.ZReadOnly = true;
            this.txtPath.ZText = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(11, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // jm_btn_Cancel
            // 
            this.jm_btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.jm_btn_Cancel.JMBaseColor = System.Drawing.Color.DarkGray;
            this.jm_btn_Cancel.JMBaseColorTwo = System.Drawing.Color.White;
            this.jm_btn_Cancel.Location = new System.Drawing.Point(220, 85);
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
            this.jm_btn_OK.Location = new System.Drawing.Point(133, 85);
            this.jm_btn_OK.Name = "jm_btn_OK";
            this.jm_btn_OK.Size = new System.Drawing.Size(80, 30);
            this.jm_btn_OK.TabIndex = 5;
            this.jm_btn_OK.Text = "确定";
            this.jm_btn_OK.UseVisualStyleBackColor = true;
            this.jm_btn_OK.Click += new System.EventHandler(this.jm_btn_OK_Click);
            // 
            // jm_btn_LiuLan
            // 
            this.jm_btn_LiuLan.JMBaseColor = System.Drawing.Color.DarkGray;
            this.jm_btn_LiuLan.JMBaseColorTwo = System.Drawing.Color.White;
            this.jm_btn_LiuLan.Location = new System.Drawing.Point(262, 14);
            this.jm_btn_LiuLan.Name = "jm_btn_LiuLan";
            this.jm_btn_LiuLan.Size = new System.Drawing.Size(38, 23);
            this.jm_btn_LiuLan.TabIndex = 2;
            this.jm_btn_LiuLan.Text = "浏览";
            this.jm_btn_LiuLan.UseVisualStyleBackColor = true;
            this.jm_btn_LiuLan.Click += new System.EventHandler(this.jm_btn_LiuLan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "路径";
            // 
            // FrmAdd
            // 
            this.AcceptButton = this.jm_btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.jm_btn_Cancel;
            this.ClientSize = new System.Drawing.Size(318, 125);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAdd";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "FrmAdd";
            this.Load += new System.EventHandler(this.FrmAdd_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private JMButton jm_btn_Cancel;
        private JMButton jm_btn_OK;
        private JMButton jm_btn_LiuLan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private JMControlsEx.JMRundRandTextBox txtName;
        private JMControlsEx.JMRundRandTextBox txtPath;
    }
}