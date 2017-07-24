namespace JMControlsEx
{
    partial class JMDateTime
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtDatetime = new JMControlsEx.JMTextBox();
            this.jm_pb_Date = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.jm_pb_Date)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.TrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // txtDatetime
            // 
            this.txtDatetime.BackColor = System.Drawing.Color.White;
            this.txtDatetime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatetime.Location = new System.Drawing.Point(0, 0);
            this.txtDatetime.MaxLen = 30;
            this.txtDatetime.Name = "txtDatetime";
            this.txtDatetime.Size = new System.Drawing.Size(135, 21);
            this.txtDatetime.TabIndex = 0;
            this.txtDatetime.ZBlackColor = System.Drawing.Color.White;
            this.txtDatetime.ZEmptyTextTip = "";
            this.txtDatetime.ZFormat = "yyyy-MM-dd";
            this.txtDatetime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDatetime_KeyDown);
            this.txtDatetime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDatetime_KeyPress);
            // 
            // jm_pb_Date
            // 
            this.jm_pb_Date.BackColor = System.Drawing.Color.Transparent;
            this.jm_pb_Date.Image = global::JMControlsEx.Properties.Resources.date;
            this.jm_pb_Date.Location = new System.Drawing.Point(135, 0);
            this.jm_pb_Date.Name = "jm_pb_Date";
            this.jm_pb_Date.Size = new System.Drawing.Size(21, 21);
            this.jm_pb_Date.TabIndex = 2;
            this.jm_pb_Date.TabStop = false;
            this.jm_pb_Date.Click += new System.EventHandler(this.jm_pb_Date_Click);
            // 
            // JMDateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.jm_pb_Date);
            this.Controls.Add(this.txtDatetime);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "JMDateTime";
            this.Size = new System.Drawing.Size(156, 21);
            this.Load += new System.EventHandler(this.JMDateTime_Load);
            this.SizeChanged += new System.EventHandler(this.JMDateTime_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.jm_pb_Date)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JMTextBox txtDatetime;
        private System.Windows.Forms.PictureBox jm_pb_Date;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}
