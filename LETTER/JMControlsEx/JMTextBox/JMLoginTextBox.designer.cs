namespace JMControlsEx.JTextBox
{
    partial class JMLoginTextBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.jm_txt_Text = new JMControlsEx.JMTextBox();
            this.SuspendLayout();
            // 
            // jm_txt_Text
            // 
            this.jm_txt_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.jm_txt_Text.BackColor = System.Drawing.Color.White;
            this.jm_txt_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jm_txt_Text.IsXYK = false;
            this.jm_txt_Text.Location = new System.Drawing.Point(40, 5);
            this.jm_txt_Text.MaxLen = 30;
            this.jm_txt_Text.Name = "jm_txt_Text";
            this.jm_txt_Text.Size = new System.Drawing.Size(111, 21);
            this.jm_txt_Text.TabIndex = 0;
            this.jm_txt_Text.ZBlackColor = System.Drawing.Color.White;
            this.jm_txt_Text.ZBorderColor = System.Drawing.Color.White;
            this.jm_txt_Text.ZFormat = "yyyy-MM-dd";
            this.jm_txt_Text.Leave += new System.EventHandler(this.jm_txt_Text_Leave);
            this.jm_txt_Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.jm_txt_Text_KeyPress);
            this.jm_txt_Text.Enter += new System.EventHandler(this.jm_txt_Text_Enter);
            // 
            // JMLoginTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jm_txt_Text);
            this.Name = "JMLoginTextBox";
            this.Size = new System.Drawing.Size(158, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JMTextBox jm_txt_Text;
    }
}
