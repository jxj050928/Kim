namespace LETTER
{
    partial class Uc_Backup
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
            this.jm_dgv = new JMControlsEx.JMDataGridView();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolUpUser = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.jm_dgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.ColDate,
            this.ColBackFile,
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
            this.jm_dgv.Size = new System.Drawing.Size(775, 443);
            this.jm_dgv.SxColumnsIndex = null;
            this.jm_dgv.SxColumnsIndexLen = null;
            this.jm_dgv.TabIndex = 1;
            this.jm_dgv.Zxmlname = null;
            // 
            // ColDate
            // 
            this.ColDate.HeaderText = "备份日期";
            this.ColDate.Name = "ColDate";
            this.ColDate.Width = 150;
            // 
            // ColBackFile
            // 
            this.ColBackFile.HeaderText = "备份文件";
            this.ColBackFile.Name = "ColBackFile";
            this.ColBackFile.Width = 400;
            // 
            // ColID
            // 
            this.ColID.HeaderText = "编号";
            this.ColID.Name = "ColID";
            this.ColID.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolUpdate,
            this.toolStripSeparator1,
            this.toolUpUser});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(775, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAdd
            // 
            this.toolAdd.Image = global::LETTER.Properties.Resources.redo;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(52, 22);
            this.toolAdd.Text = "备份";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::LETTER.Properties.Resources.cancel;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "删除";
            this.toolStripButton1.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolUpdate
            // 
            this.toolUpdate.Image = global::LETTER.Properties.Resources.undo;
            this.toolUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUpdate.Name = "toolUpdate";
            this.toolUpdate.Size = new System.Drawing.Size(52, 22);
            this.toolUpdate.Text = "还原";
            this.toolUpdate.Click += new System.EventHandler(this.toolUpdate_Click);
            // 
            // toolUpUser
            // 
            this.toolUpUser.Image = global::LETTER.Properties.Resources._lock;
            this.toolUpUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUpUser.Name = "toolUpUser";
            this.toolUpUser.Size = new System.Drawing.Size(76, 22);
            this.toolUpUser.Text = "修改密码";
            this.toolUpUser.Click += new System.EventHandler(this.toolUpUser_Click);
            // 
            // Uc_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.jm_dgv);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Uc_Backup";
            this.Size = new System.Drawing.Size(775, 468);
            this.Load += new System.EventHandler(this.Uc_Sale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jm_dgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JMControlsEx.JMDataGridView jm_dgv;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolUpdate;
        private System.Windows.Forms.ToolStripButton toolUpUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
