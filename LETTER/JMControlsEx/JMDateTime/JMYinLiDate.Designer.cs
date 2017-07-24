namespace JMControlsEx
{
    partial class JMYinLiDate
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
            this.jm_pn_Hao = new JMControlsEx.JMPanel();
            this.jm_pn_Month = new JMControlsEx.JMPanel();
            this.jm_txt_Nian = new JMControlsEx.JMTextBox();
            this.SuspendLayout();
            // 
            // jm_pn_Hao
            // 
            this.jm_pn_Hao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jm_pn_Hao.JMPanelIndex = 0;
            this.jm_pn_Hao.JMTitle = "初一";
            this.jm_pn_Hao.JMTitleLocation = new System.Drawing.Point(2, 4);
            this.jm_pn_Hao.JMTitleTiaoZhuan = global::JMControlsEx.Properties.Resources.sanjiao;
            this.jm_pn_Hao.JMTitleTZLocation = new System.Drawing.Point(31, 0);
            this.jm_pn_Hao.JMTitleTZSize = new System.Drawing.Size(19, 19);
            this.jm_pn_Hao.JMTitleTZVisible = true;
            this.jm_pn_Hao.JMTitleVisible = true;
            this.jm_pn_Hao.Location = new System.Drawing.Point(108, 1);
            this.jm_pn_Hao.Name = "jm_pn_Hao";
            this.jm_pn_Hao.Size = new System.Drawing.Size(51, 19);
            this.jm_pn_Hao.TabIndex = 2;
            this.jm_pn_Hao.Click += new System.EventHandler(this.jm_pn_Hao_Click);
            // 
            // jm_pn_Month
            // 
            this.jm_pn_Month.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jm_pn_Month.JMPanelIndex = 0;
            this.jm_pn_Month.JMTitle = "十一月";
            this.jm_pn_Month.JMTitleLocation = new System.Drawing.Point(2, 4);
            this.jm_pn_Month.JMTitleTiaoZhuan = global::JMControlsEx.Properties.Resources.sanjiao;
            this.jm_pn_Month.JMTitleTZLocation = new System.Drawing.Point(41, 0);
            this.jm_pn_Month.JMTitleTZSize = new System.Drawing.Size(19, 19);
            this.jm_pn_Month.JMTitleTZVisible = true;
            this.jm_pn_Month.JMTitleVisible = true;
            this.jm_pn_Month.Location = new System.Drawing.Point(41, 1);
            this.jm_pn_Month.Name = "jm_pn_Month";
            this.jm_pn_Month.Size = new System.Drawing.Size(61, 19);
            this.jm_pn_Month.TabIndex = 1;
            this.jm_pn_Month.Click += new System.EventHandler(this.jm_pn_Month_Click);
            // 
            // jm_txt_Nian
            // 
            this.jm_txt_Nian.BackColor = System.Drawing.Color.White;
            this.jm_txt_Nian.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jm_txt_Nian.IsXYK = false;
            this.jm_txt_Nian.Location = new System.Drawing.Point(4, 4);
            this.jm_txt_Nian.MaxLen = 4;
            this.jm_txt_Nian.MaxLength = 4;
            this.jm_txt_Nian.Name = "jm_txt_Nian";
            this.jm_txt_Nian.Size = new System.Drawing.Size(32, 14);
            this.jm_txt_Nian.TabIndex = 0;
            this.jm_txt_Nian.Text = "2015";
            this.jm_txt_Nian.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.jm_txt_Nian.ZBlackColor = System.Drawing.Color.White;
            this.jm_txt_Nian.ZBorderColor = System.Drawing.Color.White;
            this.jm_txt_Nian.ZEmptyTextTip = "";
            this.jm_txt_Nian.ZFormat = "yyyy-MM-dd";
            this.jm_txt_Nian.Leave += new System.EventHandler(this.jm_txt_Nian_Leave);
            this.jm_txt_Nian.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.jm_txt_Nian_KeyPress);
            this.jm_txt_Nian.TextChanged += new System.EventHandler(this.jm_txt_Nian_TextChanged);
            // 
            // JMYinLiDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.jm_pn_Hao);
            this.Controls.Add(this.jm_pn_Month);
            this.Controls.Add(this.jm_txt_Nian);
            this.MinimumSize = new System.Drawing.Size(162, 21);
            this.Name = "JMYinLiDate";
            this.Size = new System.Drawing.Size(162, 21);
            this.Load += new System.EventHandler(this.JMYinLiDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JMTextBox jm_txt_Nian;
        private JMPanel jm_pn_Month;
        private JMPanel jm_pn_Hao;
    }
}
