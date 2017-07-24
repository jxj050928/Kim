namespace JMControlsEx
{
    partial class JMTextNumCalc
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.jmTextBox1 = new JMControlsEx.JMTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::JMControlsEx.Properties.Resources.jsq;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(150, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 21);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // jmTextBox1
            // 
            this.jmTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBox1.Location = new System.Drawing.Point(0, 0);
            this.jmTextBox1.MaxLen = 30;
            this.jmTextBox1.MaxLength = 14;
            this.jmTextBox1.Name = "jmTextBox1";
            this.jmTextBox1.Size = new System.Drawing.Size(150, 21);
            this.jmTextBox1.TabIndex = 0;
            this.jmTextBox1.Text = "0.00";
            this.jmTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.jmTextBox1.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBox1.ZDtype = JMControlsEx.JMDataType.JMDECIMAL;
            this.jmTextBox1.ZFormat = "yyyy-MM-dd";
            this.jmTextBox1.ZMedian = 2;
            this.jmTextBox1.TextChanged += new System.EventHandler(this.jmTextBox1_TextChanged);
            // 
            // JMTextNumCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.jmTextBox1);
            this.Name = "JMTextNumCalc";
            this.Size = new System.Drawing.Size(171, 21);
            this.Resize += new System.EventHandler(this.JMTextNumCalc_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JMTextBox jmTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
