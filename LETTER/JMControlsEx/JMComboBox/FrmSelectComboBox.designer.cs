namespace JMControlsEx
{
    partial class FrmSelectComboBox
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.jScrollbar1 = new JMControlsEx.JScrollbar();
            this.jm_btn_Cancel = new JMControlsEx.JMButton();
            this.jm_btn_Add = new JMControlsEx.JMButton();
            this.jContextMenuStrip1 = new JMControlsEx.JContextMenuStrip();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.jContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.jScrollbar1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1);
            this.panel3.Size = new System.Drawing.Size(366, 278);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 226);
            this.panel2.TabIndex = 5;
            this.panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel2_Scroll);
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.panel1.Controls.Add(this.jm_btn_Cancel);
            this.panel1.Controls.Add(this.jm_btn_Add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 50);
            this.panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // jScrollbar1
            // 
            this.jScrollbar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jScrollbar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.jScrollbar1.BaseColor = System.Drawing.Color.White;
            this.jScrollbar1.LargeChange = 10;
            this.jScrollbar1.Location = new System.Drawing.Point(348, 1);
            this.jScrollbar1.Maximum = 100;
            this.jScrollbar1.Minimum = 0;
            this.jScrollbar1.MinimumSize = new System.Drawing.Size(17, 60);
            this.jScrollbar1.Name = "jScrollbar1";
            this.jScrollbar1.Round = 10;
            this.jScrollbar1.Roundtum = 10;
            this.jScrollbar1.SelectColor = System.Drawing.Color.Empty;
            this.jScrollbar1.Size = new System.Drawing.Size(17, 226);
            this.jScrollbar1.SmallChange = 1;
            this.jScrollbar1.TabIndex = 6;
            this.jScrollbar1.TumbHeight = 40;
            this.jScrollbar1.Value = 0;
            this.jScrollbar1.Visible = false;
            this.jScrollbar1.Scroll += new System.EventHandler(this.jScrollbar1_Scroll);
            // 
            // jm_btn_Cancel
            // 
            this.jm_btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.jm_btn_Cancel.JMBaseColor = System.Drawing.Color.LightGray;
            this.jm_btn_Cancel.JMBaseColorTwo = System.Drawing.Color.White;
            this.jm_btn_Cancel.Location = new System.Drawing.Point(281, 7);
            this.jm_btn_Cancel.Name = "jm_btn_Cancel";
            this.jm_btn_Cancel.Size = new System.Drawing.Size(75, 37);
            this.jm_btn_Cancel.TabIndex = 1;
            this.jm_btn_Cancel.Text = "取消";
            this.jm_btn_Cancel.UseVisualStyleBackColor = true;
            this.jm_btn_Cancel.Click += new System.EventHandler(this.jm_btn_Cancel_Click);
            // 
            // jm_btn_Add
            // 
            this.jm_btn_Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.jm_btn_Add.Image = global::JMControlsEx.Properties.Resources.add;
            this.jm_btn_Add.JMBaseColor = System.Drawing.Color.LightGray;
            this.jm_btn_Add.JMBaseColorTwo = System.Drawing.Color.White;
            this.jm_btn_Add.Location = new System.Drawing.Point(187, 7);
            this.jm_btn_Add.Name = "jm_btn_Add";
            this.jm_btn_Add.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.jm_btn_Add.Size = new System.Drawing.Size(75, 37);
            this.jm_btn_Add.TabIndex = 0;
            this.jm_btn_Add.Text = "新增  ";
            this.jm_btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.jm_btn_Add.UseVisualStyleBackColor = true;
            this.jm_btn_Add.Click += new System.EventHandler(this.jm_btn_Add_Click);
            // 
            // jContextMenuStrip1
            // 
            this.jContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.jContextMenuStrip1.Name = "jContextMenuStrip1";
            this.jContextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            this.jContextMenuStrip1.ZBaseColor = System.Drawing.Color.White;
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加ToolStripMenuItem.Text = "新增";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // FrmSelectComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 280);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSelectComboBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmTypeSelect";
            this.Deactivate += new System.EventHandler(this.FrmTypeSelect_Deactivate);
            this.Load += new System.EventHandler(this.FrmTypeSelect_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.jContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JContextMenuStrip jContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private JMButton jm_btn_Cancel;
        private JScrollbar jScrollbar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel panel2;
        private System.Windows.Forms.Panel panel1;
        private JMButton jm_btn_Add;
        private System.Windows.Forms.TextBox textBox1;
    }
}