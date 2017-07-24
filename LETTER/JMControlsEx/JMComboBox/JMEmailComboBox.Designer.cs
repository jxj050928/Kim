namespace JMControlsEx
{
    partial class JMEmailComboBox
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
            this.jmComboBox1 = new JMControlsEx.JMComboBox();
            this.SuspendLayout();
            // 
            // jmComboBox1
            // 
            this.jmComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.jmComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jmComboBox1.FormattingEnabled = true;
            this.jmComboBox1.Items.AddRange(new object[] {
            "@qq.com",
            "@vip.qq.com",
            "@163.com",
            "@126.com",
            "@sohu.com",
            "@sina.com",
            "@gmail.com",
            "@foxmail.com",
            "@hotmail.com",
            "@yeah.net",
            "@chinaren.com",
            "@21cn.com",
            "@139.com",
            "@189.cn",
            "@tom.com",
            "@live.cn",
            "@263.com",
            "@yahoo.com",
            "@example.com"});
            this.jmComboBox1.Location = new System.Drawing.Point(1, 5);
            this.jmComboBox1.Name = "jmComboBox1";
            this.jmComboBox1.Size = new System.Drawing.Size(107, 20);
            this.jmComboBox1.TabIndex = 0;
            this.jmComboBox1.ZArrowColor = System.Drawing.Color.Black;
            this.jmComboBox1.ZBaseColor = System.Drawing.Color.White;
            this.jmComboBox1.ZBorderColor = System.Drawing.Color.White;
            this.jmComboBox1.Leave += new System.EventHandler(this.jmComboBox1_Leave);
            this.jmComboBox1.Enter += new System.EventHandler(this.jmComboBox1_Enter);
            // 
            // JMEmailComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jmComboBox1);
            this.MinimumSize = new System.Drawing.Size(110, 27);
            this.Name = "JMEmailComboBox";
            this.Size = new System.Drawing.Size(110, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private JMComboBox jmComboBox1;
    }
}
