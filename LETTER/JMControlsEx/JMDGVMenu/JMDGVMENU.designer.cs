namespace JMControlsEx
{
    partial class JMDGVMENU
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.jmTabControl1 = new JMControlsEx.JMTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jmDataGridView2 = new JMControlsEx.JMDataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jmDataGridView1 = new JMControlsEx.JMDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.jmTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jmDataGridView2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jmDataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.jmTabControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(22, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 349);
            this.panel1.TabIndex = 0;
            // 
            // jmTabControl1
            // 
            this.jmTabControl1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(79)))), ((int)(((byte)(125)))));
            this.jmTabControl1.BackColor = System.Drawing.Color.Transparent;
            this.jmTabControl1.Controls.Add(this.tabPage1);
            this.jmTabControl1.Controls.Add(this.tabPage2);
            this.jmTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jmTabControl1.Location = new System.Drawing.Point(0, 57);
            this.jmTabControl1.Name = "jmTabControl1";
            this.jmTabControl1.SelectedIndex = 0;
            this.jmTabControl1.Size = new System.Drawing.Size(182, 292);
            this.jmTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.jmDataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(174, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "筛选";
            // 
            // jmDataGridView2
            // 
            this.jmDataGridView2.AllowUserToAddRows = false;
            this.jmDataGridView2.AllowUserToDeleteRows = false;
            this.jmDataGridView2.AllowUserToOrderColumns = true;
            this.jmDataGridView2.AllowUserToResizeColumns = false;
            this.jmDataGridView2.AllowUserToResizeRows = false;
            this.jmDataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.jmDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jmDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.jmDataGridView2.ColumnHeaderColorBegin = System.Drawing.Color.White;
            this.jmDataGridView2.ColumnHeaderColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.jmDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jmDataGridView2.ColumnHeadersVisible = false;
            this.jmDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5});
            this.jmDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jmDataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.jmDataGridView2.Location = new System.Drawing.Point(3, 3);
            this.jmDataGridView2.Name = "jmDataGridView2";
            this.jmDataGridView2.PrimaryRowcolorBegin = System.Drawing.Color.White;
            this.jmDataGridView2.PrimaryRowcolorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.jmDataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.jmDataGridView2.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            this.jmDataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jmDataGridView2.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.jmDataGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.jmDataGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.jmDataGridView2.RowTemplate.Height = 23;
            this.jmDataGridView2.SecondaryLength = 2;
            this.jmDataGridView2.SecondaryRowColorBegin = System.Drawing.Color.White;
            this.jmDataGridView2.SecondaryRowColorEnd = System.Drawing.Color.White;
            this.jmDataGridView2.SelectedRowColor1 = System.Drawing.Color.White;
            this.jmDataGridView2.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.jmDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jmDataGridView2.Size = new System.Drawing.Size(168, 256);
            this.jmDataGridView2.SxColumnsIndex = null;
            this.jmDataGridView2.SxColumnsIndexLen = null;
            this.jmDataGridView2.TabIndex = 3;
            this.jmDataGridView2.Zxmlname = null;
            this.jmDataGridView2.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.jmDataGridView2_CellMouseUp);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "vs";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.Width = 40;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.jmDataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(174, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "显示隐藏列";
            // 
            // jmDataGridView1
            // 
            this.jmDataGridView1.AllowUserToAddRows = false;
            this.jmDataGridView1.AllowUserToDeleteRows = false;
            this.jmDataGridView1.AllowUserToOrderColumns = true;
            this.jmDataGridView1.AllowUserToResizeColumns = false;
            this.jmDataGridView1.AllowUserToResizeRows = false;
            this.jmDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.jmDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jmDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.jmDataGridView1.ColumnHeaderColorBegin = System.Drawing.Color.White;
            this.jmDataGridView1.ColumnHeaderColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.jmDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jmDataGridView1.ColumnHeadersVisible = false;
            this.jmDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.jmDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jmDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.jmDataGridView1.Location = new System.Drawing.Point(3, 3);
            this.jmDataGridView1.Name = "jmDataGridView1";
            this.jmDataGridView1.PrimaryRowcolorBegin = System.Drawing.Color.White;
            this.jmDataGridView1.PrimaryRowcolorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.jmDataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.jmDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            this.jmDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.jmDataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.jmDataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.jmDataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.jmDataGridView1.RowTemplate.Height = 23;
            this.jmDataGridView1.SecondaryLength = 2;
            this.jmDataGridView1.SecondaryRowColorBegin = System.Drawing.Color.White;
            this.jmDataGridView1.SecondaryRowColorEnd = System.Drawing.Color.White;
            this.jmDataGridView1.SelectedRowColor1 = System.Drawing.Color.White;
            this.jmDataGridView1.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.jmDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jmDataGridView1.Size = new System.Drawing.Size(168, 256);
            this.jmDataGridView1.SxColumnsIndex = null;
            this.jmDataGridView1.SxColumnsIndexLen = null;
            this.jmDataGridView1.TabIndex = 2;
            this.jmDataGridView1.Zxmlname = null;
            this.jmDataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.jmDataGridView1_CellMouseUp);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Cvisble";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Ctext";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Cname";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.linkLabel2);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 57);
            this.panel2.TabIndex = 0;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(24, 34);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(53, 12);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "降序排序";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.White;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(23, 11);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "升序排序";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.White;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // JMDGVMENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 349);
            this.Controls.Add(this.panel1);
            this.Name = "JMDGVMENU";
            this.Text = "JMDGVMENU";
            this.panel1.ResumeLayout(false);
            this.jmTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jmDataGridView2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jmDataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JMTabControl jmTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private JMDataGridView jmDataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private JMDataGridView jmDataGridView2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}