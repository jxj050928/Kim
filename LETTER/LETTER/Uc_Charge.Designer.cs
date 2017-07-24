namespace LETTER
{
    partial class Uc_Charge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolCharge = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.jm_dgv = new JMControlsEx.JMDataGridView();
            this.ColChargeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCharteMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChargeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pager1 = new LETTER.Pager();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jm_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCharge,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1010, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolCharge
            // 
            this.toolCharge.Image = global::LETTER.Properties.Resources.large_smartart;
            this.toolCharge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCharge.Name = "toolCharge";
            this.toolCharge.Size = new System.Drawing.Size(52, 22);
            this.toolCharge.Text = "充值";
            this.toolCharge.Click += new System.EventHandler(this.toolCharge_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel1.Text = "手机号 ";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolSearch
            // 
            this.toolSearch.Image = global::LETTER.Properties.Resources.search;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(52, 22);
            this.toolSearch.Text = "查询";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // jm_dgv
            // 
            this.jm_dgv.AllowUserToAddRows = false;
            this.jm_dgv.AllowUserToDeleteRows = false;
            this.jm_dgv.AllowUserToOrderColumns = true;
            this.jm_dgv.AllowUserToResizeRows = false;
            this.jm_dgv.BackgroundColor = System.Drawing.Color.White;
            this.jm_dgv.ColumnHeaderColorBegin = System.Drawing.Color.White;
            this.jm_dgv.ColumnHeaderColorEnd = System.Drawing.Color.Gainsboro;
            this.jm_dgv.ColumnHeadersHeight = 30;
            this.jm_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColChargeDate,
            this.ColCharteMoney,
            this.ColName,
            this.ColPhone,
            this.ColChargeID,
            this.ColID});
            this.jm_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jm_dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.jm_dgv.Location = new System.Drawing.Point(0, 25);
            this.jm_dgv.Name = "jm_dgv";
            this.jm_dgv.PrimaryRowcolorBegin = System.Drawing.Color.White;
            this.jm_dgv.PrimaryRowcolorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.jm_dgv.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            this.jm_dgv.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jm_dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.jm_dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.jm_dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.jm_dgv.RowTemplate.Height = 23;
            this.jm_dgv.SecondaryLength = 2;
            this.jm_dgv.SecondaryRowColorBegin = System.Drawing.Color.White;
            this.jm_dgv.SecondaryRowColorEnd = System.Drawing.Color.White;
            this.jm_dgv.SelectedRowColor1 = System.Drawing.Color.White;
            this.jm_dgv.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.jm_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jm_dgv.Size = new System.Drawing.Size(1010, 413);
            this.jm_dgv.SxColumnsIndex = null;
            this.jm_dgv.SxColumnsIndexLen = null;
            this.jm_dgv.TabIndex = 1;
            this.jm_dgv.Zxmlname = null;
            // 
            // ColChargeDate
            // 
            this.ColChargeDate.HeaderText = "充值日期";
            this.ColChargeDate.Name = "ColChargeDate";
            this.ColChargeDate.Width = 150;
            // 
            // ColCharteMoney
            // 
            this.ColCharteMoney.HeaderText = "充值金额";
            this.ColCharteMoney.Name = "ColCharteMoney";
            // 
            // ColName
            // 
            this.ColName.HeaderText = "会员姓名";
            this.ColName.Name = "ColName";
            // 
            // ColPhone
            // 
            this.ColPhone.HeaderText = "手机号";
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.Width = 120;
            // 
            // ColChargeID
            // 
            this.ColChargeID.HeaderText = "编号";
            this.ColChargeID.Name = "ColChargeID";
            this.ColChargeID.Visible = false;
            // 
            // ColID
            // 
            this.ColID.HeaderText = "会员编号";
            this.ColID.Name = "ColID";
            this.ColID.Visible = false;
            this.ColID.Width = 70;
            // 
            // pager1
            // 
            this.pager1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager1.Location = new System.Drawing.Point(0, 438);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 0;
            this.pager1.PageSize = 15;
            this.pager1.Size = new System.Drawing.Size(1010, 30);
            this.pager1.TabIndex = 3;
            this.pager1.EventPaging += new LETTER.EventPagingHandler(this.pager1_EventPaging);
            // 
            // Uc_Charge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.jm_dgv);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Uc_Charge";
            this.Size = new System.Drawing.Size(1010, 468);
            this.Load += new System.EventHandler(this.Uc_Sale_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jm_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JMControlsEx.JMDataGridView jm_dgv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolCharge;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private Pager pager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChargeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCharteMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChargeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
    }
}
