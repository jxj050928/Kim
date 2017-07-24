using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JMControlsEx
{
    public class JPageControl : UserControl
    {
        #region 页码变化触发事件
        public event EventHandler currentPageChanged;
        #endregion

        #region 构造函数
        public JPageControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.jPageButton1 = new JMControlsEx.JPageButton();
            this.jPageButton2 = new JMControlsEx.JPageButton();
            this.jPageButton3 = new JMControlsEx.JPageButton();
            this.jPageButton4 = new JMControlsEx.JPageButton();
            this.jPageButton5 = new JMControlsEx.JPageButton();
            this.jPageButton6 = new JMControlsEx.JPageButton();
            this.jPageButton7 = new JMControlsEx.JPageButton();
            this.jPageButton8 = new JMControlsEx.JPageButton();
            this.jPageButton9 = new JMControlsEx.JPageButton();
            this.jPageButton10 = new JMControlsEx.JPageButton();
            this.jPageButton11 = new JMControlsEx.JPageButton();
            this.jPageButton12 = new JMControlsEx.JPageButton();
            this.jPageButton13 = new JMControlsEx.JPageButton();
            this.jPageButton14 = new JMControlsEx.JPageButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.jPageButton1);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton2);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton3);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton4);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton5);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton6);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton7);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton8);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton9);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton10);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton11);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton12);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton13);
            this.flowLayoutPanel1.Controls.Add(this.jPageButton14);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(482, 31);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(482, 31);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(482, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // jPageButton1
            // 
            this.jPageButton1.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton1.ButtonType = JMControlsEx.PageButtonType.First;
            this.jPageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton1.IsFoucs = false;
            this.jPageButton1.Location = new System.Drawing.Point(3, 0);
            this.jPageButton1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton1.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton1.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton1.Name = "jPageButton1";
            this.jPageButton1.Pageindex = "1";
            this.jPageButton1.Size = new System.Drawing.Size(31, 31);
            this.jPageButton1.TabIndex = 0;
            this.jPageButton1.Click += new System.EventHandler(this.jPageButton1_Click);
            // 
            // jPageButton2
            // 
            this.jPageButton2.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton2.ButtonType = JMControlsEx.PageButtonType.Befor;
            this.jPageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton2.IsFoucs = false;
            this.jPageButton2.Location = new System.Drawing.Point(37, 0);
            this.jPageButton2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton2.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton2.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton2.Name = "jPageButton2";
            this.jPageButton2.Pageindex = "1";
            this.jPageButton2.Size = new System.Drawing.Size(31, 31);
            this.jPageButton2.TabIndex = 1;
            this.jPageButton2.Click += new System.EventHandler(this.jPageButton2_Click);
            // 
            // jPageButton3
            // 
            this.jPageButton3.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton3.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton3.IsFoucs = true;
            this.jPageButton3.Location = new System.Drawing.Point(71, 0);
            this.jPageButton3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton3.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton3.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton3.Name = "jPageButton3";
            this.jPageButton3.Pageindex = "1";
            this.jPageButton3.Size = new System.Drawing.Size(31, 31);
            this.jPageButton3.TabIndex = 1;
            this.jPageButton3.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton4
            // 
            this.jPageButton4.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton4.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton4.IsFoucs = false;
            this.jPageButton4.Location = new System.Drawing.Point(105, 0);
            this.jPageButton4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton4.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton4.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton4.Name = "jPageButton4";
            this.jPageButton4.Pageindex = "2";
            this.jPageButton4.Size = new System.Drawing.Size(31, 31);
            this.jPageButton4.TabIndex = 2;
            this.jPageButton4.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton5
            // 
            this.jPageButton5.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton5.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton5.IsFoucs = false;
            this.jPageButton5.Location = new System.Drawing.Point(139, 0);
            this.jPageButton5.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton5.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton5.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton5.Name = "jPageButton5";
            this.jPageButton5.Pageindex = "3";
            this.jPageButton5.Size = new System.Drawing.Size(31, 31);
            this.jPageButton5.TabIndex = 3;
            this.jPageButton5.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton6
            // 
            this.jPageButton6.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton6.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton6.IsFoucs = false;
            this.jPageButton6.Location = new System.Drawing.Point(173, 0);
            this.jPageButton6.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton6.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton6.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton6.Name = "jPageButton6";
            this.jPageButton6.Pageindex = "4";
            this.jPageButton6.Size = new System.Drawing.Size(31, 31);
            this.jPageButton6.TabIndex = 4;
            this.jPageButton6.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton7
            // 
            this.jPageButton7.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton7.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton7.IsFoucs = false;
            this.jPageButton7.Location = new System.Drawing.Point(207, 0);
            this.jPageButton7.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton7.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton7.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton7.Name = "jPageButton7";
            this.jPageButton7.Pageindex = "5";
            this.jPageButton7.Size = new System.Drawing.Size(31, 31);
            this.jPageButton7.TabIndex = 5;
            this.jPageButton7.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton8
            // 
            this.jPageButton8.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton8.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton8.IsFoucs = false;
            this.jPageButton8.Location = new System.Drawing.Point(241, 0);
            this.jPageButton8.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton8.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton8.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton8.Name = "jPageButton8";
            this.jPageButton8.Pageindex = "6";
            this.jPageButton8.Size = new System.Drawing.Size(31, 31);
            this.jPageButton8.TabIndex = 6;
            this.jPageButton8.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton9
            // 
            this.jPageButton9.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton9.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton9.IsFoucs = false;
            this.jPageButton9.Location = new System.Drawing.Point(275, 0);
            this.jPageButton9.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton9.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton9.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton9.Name = "jPageButton9";
            this.jPageButton9.Pageindex = "7";
            this.jPageButton9.Size = new System.Drawing.Size(31, 31);
            this.jPageButton9.TabIndex = 7;
            this.jPageButton9.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton10
            // 
            this.jPageButton10.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton10.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton10.IsFoucs = false;
            this.jPageButton10.Location = new System.Drawing.Point(309, 0);
            this.jPageButton10.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton10.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton10.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton10.Name = "jPageButton10";
            this.jPageButton10.Pageindex = "8";
            this.jPageButton10.Size = new System.Drawing.Size(31, 31);
            this.jPageButton10.TabIndex = 8;
            this.jPageButton10.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton11
            // 
            this.jPageButton11.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton11.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton11.IsFoucs = false;
            this.jPageButton11.Location = new System.Drawing.Point(343, 0);
            this.jPageButton11.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton11.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton11.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton11.Name = "jPageButton11";
            this.jPageButton11.Pageindex = "9";
            this.jPageButton11.Size = new System.Drawing.Size(31, 31);
            this.jPageButton11.TabIndex = 9;
            this.jPageButton11.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton12
            // 
            this.jPageButton12.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton12.ButtonType = JMControlsEx.PageButtonType.None;
            this.jPageButton12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton12.IsFoucs = false;
            this.jPageButton12.Location = new System.Drawing.Point(377, 0);
            this.jPageButton12.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton12.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton12.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton12.Name = "jPageButton12";
            this.jPageButton12.Pageindex = "10";
            this.jPageButton12.Size = new System.Drawing.Size(31, 31);
            this.jPageButton12.TabIndex = 10;
            this.jPageButton12.Click += new System.EventHandler(this.jPageButton3_Click);
            // 
            // jPageButton13
            // 
            this.jPageButton13.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton13.ButtonType = JMControlsEx.PageButtonType.Next;
            this.jPageButton13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton13.IsFoucs = false;
            this.jPageButton13.Location = new System.Drawing.Point(411, 0);
            this.jPageButton13.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton13.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton13.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton13.Name = "jPageButton13";
            this.jPageButton13.Pageindex = "1";
            this.jPageButton13.Size = new System.Drawing.Size(31, 31);
            this.jPageButton13.TabIndex = 11;
            this.jPageButton13.Click += new System.EventHandler(this.jPageButton13_Click);
            // 
            // jPageButton14
            // 
            this.jPageButton14.BackColor = System.Drawing.Color.Transparent;
            this.jPageButton14.ButtonType = JMControlsEx.PageButtonType.End;
            this.jPageButton14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jPageButton14.IsFoucs = false;
            this.jPageButton14.Location = new System.Drawing.Point(445, 0);
            this.jPageButton14.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.jPageButton14.MaximumSize = new System.Drawing.Size(31, 31);
            this.jPageButton14.MinimumSize = new System.Drawing.Size(31, 31);
            this.jPageButton14.Name = "jPageButton14";
            this.jPageButton14.Pageindex = "1";
            this.jPageButton14.Size = new System.Drawing.Size(31, 31);
            this.jPageButton14.TabIndex = 12;
            this.jPageButton14.Click += new System.EventHandler(this.jPageButton14_Click);
            // 
            // JPageControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "JPageControl";
            this.Size = new System.Drawing.Size(482, 31);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region 分页字段和属性

        private int recordsPerpageCount = 10;

        /// <summary>
        /// 一次显示多少页
        /// </summary>
        public int RecordsPerPageCount
        {
            get { return recordsPerpageCount; }
            //set
            //{
            //    recordsPerpageCount = value;
            //    this.Width = (recordsPerpageCount + 4) * 34;
            //}
        }

        private int currentPage = 1;
        /// <summary>
        /// 当前页面
        /// </summary>
        public virtual int CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;

                int pg = currentPage % recordsPerpageCount == 0 ? currentPage / recordsPerpageCount - 1 : currentPage / recordsPerpageCount;
                jPageButton3.Pageindex = (pg * recordsPerpageCount + 1).ToString();
                jPageButton4.Pageindex = (pg * recordsPerpageCount + 2).ToString();
                jPageButton5.Pageindex = (pg * recordsPerpageCount + 3).ToString();
                jPageButton6.Pageindex = (pg * recordsPerpageCount + 4).ToString();
                jPageButton7.Pageindex = (pg * recordsPerpageCount + 5).ToString();
                jPageButton8.Pageindex = (pg * recordsPerpageCount + 6).ToString();
                jPageButton9.Pageindex = (pg * recordsPerpageCount + 7).ToString();
                jPageButton10.Pageindex = (pg * recordsPerpageCount + 8).ToString();
                jPageButton11.Pageindex = (pg * recordsPerpageCount + 9).ToString();
                jPageButton12.Pageindex = (pg * recordsPerpageCount + 10).ToString();

                foreach (JPageButton item in this.flowLayoutPanel1.Controls)
                {
                    if (item.ButtonType==PageButtonType.None)
                    {
                        if (item.Pageindex == currentPage.ToString())
                        {
                            item.IsFoucs = true;
                        }
                        else
                        {
                            item.IsFoucs = false;
                        }
                    }
                }
            }
        }

        private int recordsPerPage = 15;
        /// <summary>
        /// 每页记录数
        /// </summary>
        public virtual int RecordsPerPage
        {
            get { return recordsPerPage; }
            set { recordsPerPage = value; DrawControl(); }
        }

        private FlowLayoutPanel flowLayoutPanel1;
        private JPageButton jPageButton1;
        private JPageButton jPageButton2;
        private JPageButton jPageButton3;
        private JPageButton jPageButton4;
        private JPageButton jPageButton5;
        private JPageButton jPageButton6;
        private JPageButton jPageButton7;
        private JPageButton jPageButton8;
        private JPageButton jPageButton9;
        private JPageButton jPageButton10;
        private JPageButton jPageButton11;
        private JPageButton jPageButton12;
        private JPageButton jPageButton13;
        private JPageButton jPageButton14;

        private int totalCount = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public virtual int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; DrawControl(); }
        }

        private int pageCount = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (recordsPerPage != 0)
                {
                    pageCount = GetPageCount();
                }
                return pageCount;
            }
        }
        #endregion

        #region 分页及相关事件功能实现

        /// <summary>
        /// 计算总页数
        /// </summary>
        /// <returns></returns>
        private int GetPageCount()
        {
            if (RecordsPerPage == 0)
            {
                return 0;
                //throw new DivideByZeroException("每页记录数为0");
            }
            int pageCount = TotalCount / RecordsPerPage;
            if (TotalCount % RecordsPerPage == 0)
            {
                pageCount = TotalCount / RecordsPerPage;
            }
            else
            {
                pageCount = TotalCount / RecordsPerPage + 1;
            }
            return pageCount;
        }

        /// <summary>
        /// 页面控件呈现
        /// </summary>
        private void DrawControl()
        {

            jPageButton1.Visible = true;
            jPageButton2.Visible = true;
            jPageButton3.Visible = true;
            jPageButton4.Visible = true;
            jPageButton5.Visible = true;
            jPageButton6.Visible = true;
            jPageButton7.Visible = true;
            jPageButton8.Visible = true;
            jPageButton9.Visible = true;
            jPageButton10.Visible = true;
            jPageButton11.Visible = true;
            jPageButton12.Visible = true;
            jPageButton13.Visible = true;
            jPageButton14.Visible = true;
            jPageButton1.Enabled = true;
            jPageButton14.Enabled = true;

            if (PageCount == 1)//有且仅有一页
            {
                jPageButton1.Visible = false;
                jPageButton2.Visible = false;
                jPageButton3.Visible = false;
                jPageButton4.Visible = false;
                jPageButton5.Visible = false;
                jPageButton6.Visible = false;
                jPageButton7.Visible = false;
                jPageButton8.Visible = false;
                jPageButton9.Visible = false;
                jPageButton10.Visible = false;
                jPageButton11.Visible = false;
                jPageButton12.Visible = false;
                jPageButton13.Visible = false;
                jPageButton14.Visible = false;
            }
            else if (CurrentPage == 1)//第一页
            {
                jPageButton1.Enabled = false;
                jPageButton2.Visible = false;
                if (pageCount > recordsPerpageCount)
                {
                    jPageButton13.Visible = true;
                }
                else
                {
                    jPageButton13.Visible = false;
                    for (int i = PageCount % recordsPerpageCount + 1; i <= recordsPerpageCount; i++)
                    {
                        this.flowLayoutPanel1.Controls.Find("jPageButton" + (i + 2).ToString(), false)[0].Visible = false;
                    }
                }
            }
            else if (CurrentPage == this.PageCount)//最后一页
            {
                jPageButton14.Enabled = false;
                jPageButton13.Visible = false;
                if (pageCount > recordsPerpageCount)
                {
                    jPageButton2.Visible = true;
                }
                else
                {
                    jPageButton2.Visible = false;
                }
                for (int i = PageCount % recordsPerpageCount + 1; i <= recordsPerpageCount; i++)
                {
                    this.flowLayoutPanel1.Controls.Find("jPageButton" + (i + 2).ToString(), false)[0].Visible = false;
                }
            }
            else
            {
                if (CurrentPage <= recordsPerpageCount)
                {
                    jPageButton2.Visible = false;
                    if (pageCount > recordsPerpageCount)
                    {
                        jPageButton13.Visible = true;
                    }
                    else
                    {
                        jPageButton13.Visible = false;
                        for (int i = PageCount % recordsPerpageCount + 1; i <= recordsPerpageCount; i++)
                        {
                            this.flowLayoutPanel1.Controls.Find("jPageButton" + (i + 2).ToString(), false)[0].Visible = false;
                        }
                    }
                }
                else if ((currentPage % recordsPerpageCount == 0 ? currentPage / recordsPerpageCount - 1 : currentPage / recordsPerpageCount) == (pageCount % recordsPerpageCount == 0 ? pageCount / recordsPerpageCount - 1 : pageCount / recordsPerpageCount))
                {
                    jPageButton13.Visible = false;
                    if (pageCount > recordsPerpageCount)
                    {
                        jPageButton2.Visible = true;
                    }
                    else
                    {
                        jPageButton2.Visible = false;
                    }
                    for (int i = PageCount % recordsPerpageCount + 1; i <= recordsPerpageCount; i++)
                    {
                        this.flowLayoutPanel1.Controls.Find("jPageButton" + (i + 2).ToString(), false)[0].Visible = false;
                    }
                }
                else
                {
                    if (pageCount > recordsPerpageCount)
                    {
                        jPageButton13.Visible = true;
                        jPageButton2.Visible = true;
                    }
                    else
                    {
                        jPageButton13.Visible = false;
                        jPageButton2.Visible = false;
                    }
                }
            }


            if (currentPageChanged != null)
            {
                currentPageChanged(this, null);//当前分页数字改变时，触发委托事件
            }
        }
        #endregion

        private void jPageButton1_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            DrawControl();
        }

        private void jPageButton14_Click(object sender, EventArgs e)
        {
            CurrentPage = pageCount;
            DrawControl();
        }

        private void jPageButton2_Click(object sender, EventArgs e)
        {
            CurrentPage = currentPage - recordsPerpageCount;
            DrawControl();
        }

        private void jPageButton13_Click(object sender, EventArgs e)
        {
            CurrentPage = currentPage + recordsPerpageCount > pageCount ? pageCount : currentPage + recordsPerpageCount;
            DrawControl();
        }

        private void jPageButton3_Click(object sender, EventArgs e)
        {
            CurrentPage = int.Parse((sender as JPageButton).Pageindex);
            DrawControl();
        }

    }
}
