namespace LETTER
{
    partial class Uc_Sell
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.jmButton3 = new JMControlsEx.JMButton();
            this.txtPhone = new JMControlsEx.JMTextBoxEx();
            this.label_sum = new System.Windows.Forms.Label();
            this.jmDateTime2 = new JMControlsEx.JMDateTime();
            this.jmDateTime1 = new JMControlsEx.JMDateTime();
            this.btn_search = new JMControlsEx.JMButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pager1 = new LETTER.Pager();
            this.ColPeoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPeoPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSellDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSaleNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSellCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSellMoney2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSellMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSellID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPeoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.jm_dgv)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.ColPeoName,
            this.ColPeoPhone,
            this.ColSellDate,
            this.ColProName,
            this.ColProPrice,
            this.ColSaleNum,
            this.ColSellCount,
            this.ColSellMoney2,
            this.ColSellMoney,
            this.ColID,
            this.ColSellID,
            this.ColPeoID,
            this.ColProID});
            this.jm_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jm_dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.jm_dgv.Location = new System.Drawing.Point(0, 38);
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
            this.jm_dgv.Size = new System.Drawing.Size(1010, 400);
            this.jm_dgv.SxColumnsIndex = null;
            this.jm_dgv.SxColumnsIndexLen = null;
            this.jm_dgv.TabIndex = 1;
            this.jm_dgv.Zxmlname = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.jmButton3);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.label_sum);
            this.panel1.Controls.Add(this.jmDateTime2);
            this.panel1.Controls.Add(this.jmDateTime1);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 38);
            this.panel1.TabIndex = 4;
            // 
            // jmButton3
            // 
            this.jmButton3.Font = new System.Drawing.Font("宋体", 9F);
            this.jmButton3.ForeColor = System.Drawing.Color.White;
            this.jmButton3.JMBaseColor = System.Drawing.Color.Maroon;
            this.jmButton3.JMBaseColorTwo = System.Drawing.Color.Maroon;
            this.jmButton3.JMRadius = 1;
            this.jmButton3.Location = new System.Drawing.Point(194, 8);
            this.jmButton3.Name = "jmButton3";
            this.jmButton3.Size = new System.Drawing.Size(60, 21);
            this.jmButton3.TabIndex = 25;
            this.jmButton3.Text = "读卡";
            this.jmButton3.UseVisualStyleBackColor = true;
            this.jmButton3.Click += new System.EventHandler(this.jmButton3_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.IsXYK = false;
            this.txtPhone.Location = new System.Drawing.Point(65, 8);
            this.txtPhone.MaxLen = 20;
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(129, 21);
            this.txtPhone.TabIndex = 24;
            this.txtPhone.ZBlackColor = System.Drawing.Color.White;
            this.txtPhone.ZBorderColor = System.Drawing.Color.Silver;
            this.txtPhone.ZEmptyTextTip = "";
            this.txtPhone.ZFormat = "yyyy-MM-dd";
            // 
            // label_sum
            // 
            this.label_sum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_sum.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_sum.ForeColor = System.Drawing.Color.Green;
            this.label_sum.Location = new System.Drawing.Point(879, 9);
            this.label_sum.Name = "label_sum";
            this.label_sum.Size = new System.Drawing.Size(120, 18);
            this.label_sum.TabIndex = 11;
            this.label_sum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // jmDateTime2
            // 
            this.jmDateTime2.BackColor = System.Drawing.Color.White;
            this.jmDateTime2.BorderColor = System.Drawing.Color.Silver;
            this.jmDateTime2.Location = new System.Drawing.Point(497, 8);
            this.jmDateTime2.MonthBorderColor = System.Drawing.Color.Silver;
            this.jmDateTime2.Name = "jmDateTime2";
            this.jmDateTime2.Size = new System.Drawing.Size(140, 21);
            this.jmDateTime2.TabIndex = 10;
            // 
            // jmDateTime1
            // 
            this.jmDateTime1.BackColor = System.Drawing.Color.White;
            this.jmDateTime1.BorderColor = System.Drawing.Color.Silver;
            this.jmDateTime1.Location = new System.Drawing.Point(330, 8);
            this.jmDateTime1.MonthBorderColor = System.Drawing.Color.Silver;
            this.jmDateTime1.Name = "jmDateTime1";
            this.jmDateTime1.Size = new System.Drawing.Size(140, 21);
            this.jmDateTime1.TabIndex = 9;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.JMBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            this.btn_search.JMBaseColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            this.btn_search.JMRadius = 25;
            this.btn_search.Location = new System.Drawing.Point(666, 6);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(60, 25);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "查 询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "至";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "消费日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手机号：";
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
            // ColPeoName
            // 
            this.ColPeoName.HeaderText = "会员姓名";
            this.ColPeoName.Name = "ColPeoName";
            // 
            // ColPeoPhone
            // 
            this.ColPeoPhone.HeaderText = "手机号";
            this.ColPeoPhone.Name = "ColPeoPhone";
            this.ColPeoPhone.Width = 120;
            // 
            // ColSellDate
            // 
            this.ColSellDate.HeaderText = "消费日期";
            this.ColSellDate.Name = "ColSellDate";
            this.ColSellDate.Width = 150;
            // 
            // ColProName
            // 
            this.ColProName.HeaderText = "产品名称";
            this.ColProName.Name = "ColProName";
            this.ColProName.Width = 150;
            // 
            // ColProPrice
            // 
            this.ColProPrice.HeaderText = "产品单价";
            this.ColProPrice.Name = "ColProPrice";
            // 
            // ColSaleNum
            // 
            this.ColSaleNum.HeaderText = "折扣";
            this.ColSaleNum.Name = "ColSaleNum";
            this.ColSaleNum.Width = 80;
            // 
            // ColSellCount
            // 
            this.ColSellCount.HeaderText = "数量";
            this.ColSellCount.Name = "ColSellCount";
            this.ColSellCount.Width = 80;
            // 
            // ColSellMoney2
            // 
            this.ColSellMoney2.HeaderText = "总金额";
            this.ColSellMoney2.Name = "ColSellMoney2";
            // 
            // ColSellMoney
            // 
            this.ColSellMoney.HeaderText = "消费金额";
            this.ColSellMoney.Name = "ColSellMoney";
            // 
            // ColID
            // 
            this.ColID.HeaderText = "编号";
            this.ColID.Name = "ColID";
            this.ColID.Visible = false;
            // 
            // ColSellID
            // 
            this.ColSellID.HeaderText = "消费主表编号";
            this.ColSellID.Name = "ColSellID";
            this.ColSellID.Visible = false;
            // 
            // ColPeoID
            // 
            this.ColPeoID.HeaderText = "会员编号";
            this.ColPeoID.Name = "ColPeoID";
            this.ColPeoID.Visible = false;
            this.ColPeoID.Width = 70;
            // 
            // ColProID
            // 
            this.ColProID.HeaderText = "产品编号";
            this.ColProID.Name = "ColProID";
            this.ColProID.Visible = false;
            // 
            // Uc_Sell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.jm_dgv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pager1);
            this.Name = "Uc_Sell";
            this.Size = new System.Drawing.Size(1010, 468);
            this.Load += new System.EventHandler(this.Uc_Sale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jm_dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JMControlsEx.JMDataGridView jm_dgv;
        private Pager pager1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private JMControlsEx.JMButton btn_search;
        private JMControlsEx.JMDateTime jmDateTime2;
        private JMControlsEx.JMDateTime jmDateTime1;
        private System.Windows.Forms.Label label_sum;
        private JMControlsEx.JMButton jmButton3;
        private JMControlsEx.JMTextBoxEx txtPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPeoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPeoPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSellDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaleNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSellCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSellMoney2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSellMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSellID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPeoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProID;
    }
}
