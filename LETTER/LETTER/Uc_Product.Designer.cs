namespace LETTER
{
    partial class Uc_Product
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.jm_dgv = new JMControlsEx.JMDataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRemake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
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
            this.ColID,
            this.ColName,
            this.ColPrice,
            this.ColRemake});
            this.jm_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jm_dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.jm_dgv.Location = new System.Drawing.Point(0, 25);
            this.jm_dgv.Name = "jm_dgv";
            this.jm_dgv.PrimaryRowcolorBegin = System.Drawing.Color.White;
            this.jm_dgv.PrimaryRowcolorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.jm_dgv.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            this.jm_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
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
            this.jm_dgv.Size = new System.Drawing.Size(717, 443);
            this.jm_dgv.SxColumnsIndex = null;
            this.jm_dgv.SxColumnsIndexLen = null;
            this.jm_dgv.TabIndex = 1;
            this.jm_dgv.Zxmlname = null;
            // 
            // ColID
            // 
            this.ColID.HeaderText = "产品编号";
            this.ColID.Name = "ColID";
            // 
            // ColName
            // 
            this.ColName.HeaderText = "产品名称";
            this.ColName.Name = "ColName";
            this.ColName.Width = 200;
            // 
            // ColPrice
            // 
            this.ColPrice.HeaderText = "产品单价";
            this.ColPrice.Name = "ColPrice";
            // 
            // ColRemake
            // 
            this.ColRemake.HeaderText = "产品描述";
            this.ColRemake.Name = "ColRemake";
            this.ColRemake.Width = 300;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolUpdate,
            this.toolDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(717, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.Image = global::LETTER.Properties.Resources.edit_add;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(52, 22);
            this.toolAdd.Text = "增加";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolUpdate
            // 
            this.toolUpdate.Image = global::LETTER.Properties.Resources.pencil;
            this.toolUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUpdate.Name = "toolUpdate";
            this.toolUpdate.Size = new System.Drawing.Size(52, 22);
            this.toolUpdate.Text = "修改";
            this.toolUpdate.Click += new System.EventHandler(this.toolUpdate_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = global::LETTER.Properties.Resources.cancel;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(52, 22);
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // Uc_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.jm_dgv);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Uc_Product";
            this.Size = new System.Drawing.Size(717, 468);
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
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRemake;
    }
}
