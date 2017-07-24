namespace JMControlsEx
{
    partial class JMMainPanelComboBox
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
            this.components = new System.ComponentModel.Container();
            this.jmPanel1 = new JMControlsEx.JMPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // jmPanel1
            // 
            this.jmPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jmPanel1.JMPanelIndex = 0;
            this.jmPanel1.Location = new System.Drawing.Point(0, 0);
            this.jmPanel1.Name = "jmPanel1";
            this.jmPanel1.Size = new System.Drawing.Size(165, 34);
            this.jmPanel1.TabIndex = 0;
            this.jmPanel1.MouseLeave += new System.EventHandler(this.jmPanel1_MouseLeave);
            this.jmPanel1.JMTZClick += new JMControlsEx.JMDelegate.ClickHandel(this.jmPanel1_JMTZClick);
            this.jmPanel1.JMTitleClick += new JMControlsEx.JMDelegate.ClickHandel(this.jmPanel1_JMTitleClick);
            this.jmPanel1.MouseEnter += new System.EventHandler(this.jmPanel1_MouseEnter);
            // 
            // JMMainPanelComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jmPanel1);
            this.Name = "JMMainPanelComboBox";
            this.Size = new System.Drawing.Size(165, 34);
            this.ResumeLayout(false);

        }

        #endregion

        private JMPanel jmPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
