﻿namespace LETTER
{
    partial class FrmProductList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_ok = new JMControlsEx.JMButton();
            this.btn_cancel = new JMControlsEx.JMButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.jm_dgv = new JMControlsEx.JMDataGridView();
            this.ColCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jmComboBox1 = new JMControlsEx.JMComboBox();
            this.jmTextBoxEx2 = new JMControlsEx.JMTextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jm_dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.JMBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            this.btn_ok.JMBaseColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(194)))));
            this.btn_ok.JMRadius = 23;
            this.btn_ok.Location = new System.Drawing.Point(292, 48);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(66, 25);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "确 定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.jm_btn_Login_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_cancel.JMBaseColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.JMBaseColorTwo = System.Drawing.SystemColors.Control;
            this.btn_cancel.JMRadius = 23;
            this.btn_cancel.Location = new System.Drawing.Point(215, 48);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(66, 25);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "取 消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.jmButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 303);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.jm_dgv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(393, 213);
            this.panel3.TabIndex = 10;
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
            this.ColCheck,
            this.ColID,
            this.ColName,
            this.ColProPrice});
            this.jm_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jm_dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.jm_dgv.Location = new System.Drawing.Point(0, 0);
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
            this.jm_dgv.Size = new System.Drawing.Size(393, 213);
            this.jm_dgv.SxColumnsIndex = null;
            this.jm_dgv.SxColumnsIndexLen = null;
            this.jm_dgv.TabIndex = 0;
            this.jm_dgv.Zxmlname = null;
            this.jm_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jm_dgv_CellClick);
            // 
            // ColCheck
            // 
            this.ColCheck.HeaderText = "选择";
            this.ColCheck.Name = "ColCheck";
            this.ColCheck.Width = 50;
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
            // ColProPrice
            // 
            this.ColProPrice.HeaderText = "单价";
            this.ColProPrice.Name = "ColProPrice";
            this.ColProPrice.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.jmComboBox1);
            this.panel2.Controls.Add(this.btn_ok);
            this.panel2.Controls.Add(this.jmTextBoxEx2);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 88);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品折扣";
            // 
            // jmComboBox1
            // 
            this.jmComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jmComboBox1.FormattingEnabled = true;
            this.jmComboBox1.Location = new System.Drawing.Point(71, 14);
            this.jmComboBox1.Name = "jmComboBox1";
            this.jmComboBox1.Size = new System.Drawing.Size(85, 20);
            this.jmComboBox1.TabIndex = 1;
            this.jmComboBox1.ZArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.jmComboBox1.ZBaseColor = System.Drawing.Color.Silver;
            this.jmComboBox1.ZBorderColor = System.Drawing.Color.Silver;
            this.jmComboBox1.ZEmptyTextTip = null;
            // 
            // jmTextBoxEx2
            // 
            this.jmTextBoxEx2.BackColor = System.Drawing.Color.White;
            this.jmTextBoxEx2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jmTextBoxEx2.ForeColor = System.Drawing.Color.Black;
            this.jmTextBoxEx2.IsXYK = false;
            this.jmTextBoxEx2.Location = new System.Drawing.Point(269, 13);
            this.jmTextBoxEx2.MaxLen = 10;
            this.jmTextBoxEx2.MaxLength = 20;
            this.jmTextBoxEx2.Name = "jmTextBoxEx2";
            this.jmTextBoxEx2.Size = new System.Drawing.Size(85, 21);
            this.jmTextBoxEx2.TabIndex = 4;
            this.jmTextBoxEx2.Text = "0";
            this.jmTextBoxEx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.jmTextBoxEx2.ZBlackColor = System.Drawing.Color.White;
            this.jmTextBoxEx2.ZBorderColor = System.Drawing.Color.Silver;
            this.jmTextBoxEx2.ZDtype = JMControlsEx.JMDataType.JMDECIMAL;
            this.jmTextBoxEx2.ZFormat = "yyyy-MM-dd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(206, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "购买数量";
            // 
            // FrmProductList
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(395, 303);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择产品";
            this.Load += new System.EventHandler(this.FrmProductList_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jm_dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JMControlsEx.JMButton btn_ok;
        private JMControlsEx.JMButton btn_cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private JMControlsEx.JMTextBoxEx jmTextBoxEx2;
        private System.Windows.Forms.Label label2;
        private JMControlsEx.JMComboBox jmComboBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private JMControlsEx.JMDataGridView jm_dgv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProPrice;
    }
}