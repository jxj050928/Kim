using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;
using System.Data;

namespace JMControlsEx
{
    //[ToolboxBitmap(typeof(JMDataGridView), "JMDataGridView.bmp")] //定义在工具箱里显示图标,可以去掉
    public class JMDataGridView : DataGridView
    {
        private const int WM_PASTE = 0x0302;//粘貼消息 

        #region 委托事件
        public delegate void DataGridViewButton(object sender, int rowindex, int columnindex);
        /// <summary>
        /// DataGridView按钮列单击时
        /// </summary>
        public event DataGridViewButton DataGridViewButtonClike;
        #endregion

        #region Static Fields
        //从user32.dll中引入MessageBeep函数
        [DllImport("user32.dll")]
        private static extern bool MessageBeep(uint uType);
        #endregion

        #region 私有变量
        private Color _ColumnHeaderColor1;
        private Color _ColumnHeaderColor2;
        private Color _SelectedRowColor1;
        private Color _SelectedRowColor2;
        private Color _PrimaryRowColor1;
        private Color _PrimaryRowColor2;
        private Color _SecondaryRowColor1;
        private Color _SecondaryRowColor2;
        private int _SecondaryLength = 2;
        int aaa = 0;
        int j = 0;//小数点后几位
        bool abc = false;
        int lie = -1;//所编辑的单元格索引
        int ind = -1;//启用规则，则返回该索引号
        private TextBox tb;//获取所编辑单元格文本框
        bool te = false;
        private int[] cd;
        //都哪个列启用该规则
        private int[] sx;

        private bool _showCaiDan;

        #endregion

        #region 构造函数
        public JMDataGridView()
        {
            this.AllowUserToOrderColumns = true;
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            style1.BackColor = Color.Transparent;
            style1.SelectionBackColor = Color.Transparent;
            this.RowsDefaultCellStyle = style1;
            this.RowTemplate.DefaultCellStyle.BackColor = Color.Transparent;
            this.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            this.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.EditMode = DataGridViewEditMode.EditOnEnter;
            this.RowHeadersVisible = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackgroundColor = Color.White;
            _ColumnHeaderColor1 = Color.White;
            _ColumnHeaderColor2 = ColorClass.GetBColor();
            _SelectedRowColor1 = Color.White;
            _SelectedRowColor2 = Color.FromArgb(171, 217, 254);
            _PrimaryRowColor1 = Color.White;
            _PrimaryRowColor2 = Color.FromArgb(255, 249, 232);
            _SecondaryRowColor1 = Color.White;
            _SecondaryRowColor2 = Color.White;
            _showCaiDan = true;
        }
        #endregion

        #region 公共属性
        [DefaultValue(true)]
        [Description("是否显示菜单")]
        public bool ZShowCaiDan
        {
            get { return _showCaiDan; }
            set { _showCaiDan = value; }
        }

        [DefaultValue(-1)]
        [Description("都哪个列启用小数点规则")]
        public int[] SxColumnsIndex
        {
            get { return sx; }
            set { sx = value; }
        }

        //和sx属性对应 小数点长度
        
        [DefaultValue(-1)]
        [Description("小数点长度*注*必须与sx属性相匹配")]
        public int[] SxColumnsIndexLen
        {
            get { return cd; }
            set { cd = value; }
        }


        [Description("表头起始颜色")]
        public Color ColumnHeaderColorBegin //表头起始颜色
        {
            get { return _ColumnHeaderColor1; }
            set
            {
                _ColumnHeaderColor1 = value;
                this.Invalidate();
            }
        }

        [Description("表头终止颜色")]
        public Color ColumnHeaderColorEnd //表头终止颜色
        {
            get { return _ColumnHeaderColor2; }
            set
            {
                _ColumnHeaderColor2 = value;
                this.Invalidate();
            }
        }

        [Description("奇行起始颜色")]
        public Color PrimaryRowcolorBegin //奇行起始颜色
        {
            get { return _PrimaryRowColor1; }
            set
            {
                if (value.IsEmpty || value == Color.Transparent)
                    _PrimaryRowColor1 = Color.White;
                else
                    _PrimaryRowColor1 = value;
            }
        }

        [Description("奇行终止颜色")]
        public Color PrimaryRowcolorEnd//奇行终止颜色
        {
            get { return _PrimaryRowColor2; }
            set
            {
                if (value.IsEmpty || value == Color.Transparent)
                    _PrimaryRowColor2 = Color.White;
                else
                    _PrimaryRowColor2 = value;
            }
        }

        [Description("偶行起始颜色")]
        public Color SecondaryRowColorBegin//偶行起始颜色
        {
            get { return _SecondaryRowColor1; }
            set
            {
                if (value.IsEmpty || value == Color.Transparent)
                    _SecondaryRowColor1 = Color.White;
                else
                    _SecondaryRowColor1 = value;
            }
        }

        [Description("偶行终止颜色")]
        public Color SecondaryRowColorEnd//偶行终止颜色
        {
            get { return _SecondaryRowColor2; }
            set
            {
                if (value.IsEmpty || value == Color.Transparent)
                    _SecondaryRowColor2 = Color.White;
                else
                    _SecondaryRowColor2 = value;
            }
        }

        [Description("隔多少个行出现一个偶行")]
        public int SecondaryLength //这个长度现在是指导隔多少个行出现一个偶行
        {
            get { return _SecondaryLength; }
            set { _SecondaryLength = value; }
        }

        [Description("选中行起始颜色")]
        public Color SelectedRowColor1 //选中行起始颜色
        {
            get { return _SelectedRowColor1; }

            set { _SelectedRowColor1 = value; }
        }

        [Description("选中行终止颜色")]
        public Color SelectedRowColor2 //选中行终止颜色
        {
            get { return _SelectedRowColor2; }

            set { _SelectedRowColor2 = value; }
        }
        #endregion

        #region 重写
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.RowPrePaint += new DataGridViewRowPrePaintEventHandler(JMDataGridView_RowPrePaint);

            this.CellClick += new DataGridViewCellEventHandler(JMDataGridView_CellClick);

            this.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(JMDataGridView_EditingControlShowing);

            this.CellEnter += new DataGridViewCellEventHandler(JMDataGridView_CellEnter);
            this.CellEndEdit += new DataGridViewCellEventHandler(JMDataGridView_CellEndEdit);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (keyData == Keys.Enter)
                {
                    System.Windows.Forms.SendKeys.Send("{tab}");
                }
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion

        #region TextBox事件
        private void tb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tb.Select(0, tb.Text.Split('.')[0].ToString().Length);
            aaa = 0;
            abc = false;
            j = 0;
        }

        private void tb_MouseClick(object sender, MouseEventArgs e)
        {
            tb.Select(0, tb.Text.Split('.')[0].ToString().Length);
            aaa = 0;
            abc = false;
            j = 0;
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            ind = checkcolumns(lie);
            if (ind >= 0)
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.' || e.KeyChar == 8)
                {
                    #region 擦除键
                    if (e.KeyChar == 8)
                    {
                        //全选则把小数点前的改为0
                        if (tb.SelectedText == tb.Text)
                        {
                            e.Handled = true;
                            tb.Select(0, tb.Text.Split('.')[0].ToString().Length);
                            tb.SelectedText = "0";
                            tb.Select(0, tb.Text.Split('.')[0].ToString().Length);
                            abc = false;
                            j = 0;
                            return;
                        }
                        //小数点前剩下一位则 把该字符改为0
                        if (tb.SelectionStart < tb.Text.Split('.')[0].ToString().Length + 1)
                        {
                            if (tb.SelectionStart == 1 || tb.SelectionStart == 0 && tb.Text.Split('.')[0].ToString().Length == 1)
                            {
                                tb.Select(0, 1);
                                tb.SelectedText = "0";
                                tb.Select(0, 1);
                                e.Handled = true;
                            }
                            return;
                        }
                        e.Handled = true;
                        if (tb.SelectionStart == 0)
                            return;
                        else
                        {
                            if (j != 0)
                                j--;

                            tb.Select(tb.SelectionStart - 1, 1);

                            if (tb.SelectedText == ".")
                            {
                                tb.Select(tb.SelectionStart - 1, 1);
                                j = 0;
                                abc = false;
                                return;
                            }
                            else if (tb.SelectionStart >= tb.Text.Split('.')[0].ToString().Length + 1)
                            {
                                tb.SelectedText = "0";
                                tb.Select(tb.SelectionStart - 1, 1);
                            }
                            else
                            {
                                e.Handled = false;
                            }
                        }
                        return;
                    }
                    #endregion

                    #region 小数点
                    if (e.KeyChar == '.' && !abc)
                    {
                        abc = true;
                        j = 0;
                        e.Handled = true;
                        tb.Select(tb.Text.Split('.')[0].ToString().Length + 1, 1);
                    }
                    #endregion

                    #region 数字 小数点前
                    else if (!abc)
                    {
                        if (tb.SelectedText == tb.Text)
                        {
                            e.Handled = true;
                            tb.Select(0, tb.Text.Split('.')[0].ToString().Length);
                            tb.SelectedText = e.KeyChar.ToString();
                            abc = false;
                            j = 0;
                            return;
                        }
                    }
                    #endregion
                    #region 数字
                    else if (abc)
                    {
                        if (tb.SelectedText == tb.Text)
                        {
                            e.Handled = true;
                            tb.Select(0, tb.Text.Split('.')[0].ToString().Length);
                            tb.SelectedText = e.KeyChar.ToString();
                            abc = false;
                            j = 0;
                            return;
                        }
                        if (e.KeyChar == '.')
                        {
                            e.Handled = true;
                            return;
                        }
                        j++;
                        if (j > cd[ind])
                        {
                            e.Handled = true;
                            j--;
                            return;
                        }
                        e.Handled = false;
                        tb.Select(tb.SelectionStart, 1);
                    }
                    #endregion
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            ind = checkcolumns(lie);
            if (ind >= 0)
            {
                if (aaa == 0)
                {
                    tb.Select(0, 1);
                    aaa++;
                }
                #region 上，左
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
                {

                    if (tb.SelectionStart == 0)
                        return;
                    else
                    {
                        if (j != 0)
                            j--;
                        tb.Select(tb.SelectionStart - 1, 1);

                        if (tb.SelectedText == ".")
                        {
                            tb.Select(tb.SelectionStart - 1, 1);
                            j = 0;
                            abc = false;
                        }
                    }
                    e.Handled = true;
                    return;
                }
                #endregion

                #region 下，右
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                    if (tb.SelectionStart >= tb.Text.Length)
                        return;
                    else
                    {
                        tb.Select(tb.SelectionStart, 1);
                        if (tb.SelectedText == ".")
                        {
                            tb.Select(tb.SelectionStart + 1, 1);
                            j = 0;
                            abc = true;
                            return ;
                        }
                        tb.Select(tb.SelectionStart + 1, 1);
                        if (tb.SelectedText == ".")
                        {
                            tb.Select(tb.SelectionStart + 1, 1);
                            j = 0;
                            abc = true;
                        }
                        else if (tb.SelectionStart > tb.Text.Split('.')[0].ToString().Length + 1)
                        {
                            j++;
                            tb.Select(tb.SelectionStart, 1);
                        }
                        else
                        {
                            tb.Select(tb.SelectionStart, 1);
                        }
                    }
                    return ;
                }
                #endregion

                #region delete
                else if (e.KeyCode == Keys.Delete)
                {
                    tb.Select(tb.SelectionStart, 1);

                    //光标下一位是 小数点  则 跳到下一个位子
                    if (tb.SelectedText == ".")
                    {
                        tb.Select(tb.SelectionStart + 1, 1);
                        e.Handled = true;
                        j = 0;
                        abc = true;
                        return;
                    }

                    //小数位数后面 一律不删除 都改为0
                    if (tb.SelectionStart >= tb.Text.Split('.')[0].ToString().Length + 1)
                    {
                        j++;
                        if (j > cd[ind])
                        {
                            e.Handled = true;
                            j--;
                        }
                        else
                        {
                            tb.SelectedText = "0";
                            tb.Select(tb.SelectionStart, 1);
                            e.Handled = true;
                        }
                        return;
                    }

                    //小数点前 剩下一位 则 不删除 改为 0
                    if (tb.Text.Split('.')[0].ToString().Length == 1 && tb.SelectionStart <= tb.Text.Split('.')[0].ToString().Length)
                    {
                        if (tb.Text.Split('.')[0].ToString().Length == tb.SelectionStart)
                        {
                            tb.Select(tb.SelectionStart + 1, 1);
                            j = 0;
                            abc = true;
                        }
                        else
                        {
                            tb.SelectedText = "0";
                            tb.Select(tb.SelectionStart + 1, 1);
                            j = 0;
                            abc = true;
                        }
                        e.Handled = true;
                        return;
                    }
                }
                #endregion
                #region end
                else if (e.KeyCode == Keys.End)
                {
                    j = cd[ind];
                    abc = true;
                }
                #endregion
                #region Home

                else if (e.KeyCode == Keys.Home)
                {
                    j = 0;
                    abc = false;
                }
                #endregion
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }
        #endregion

        #region 方法
        private int checkcolumns(int col)
        {
            if (sx == null)
                return -1;
            for (int l = 0; l < sx.Length; l++)
            {
                if (col == sx[l])
                {
                    return l;
                }
            }
            return -1;
        }

        private static void DrawLinearGradient(Rectangle Rec, Graphics Grp, Color Color1, Color Color2)
        {
            if (Color1 == Color2)
            {
                Brush backbrush = new SolidBrush(Color1);
                Grp.FillRectangle(backbrush, Rec);
            }
            else
            {
                using (Brush backbrush =
                    new LinearGradientBrush(Rec, Color1, Color2,
                                            LinearGradientMode.
                                                Vertical))
                {
                    Grp.FillRectangle(backbrush, Rec);
                }
            }
        }

        private static void DrawLine(Rectangle Rec, Graphics Grp, Color Color1)
        {
            Grp.DrawLine(new Pen(new SolidBrush(Color1)), new Point(Rec.X + Rec.Width - 1, Rec.Y + 2), new Point(Rec.X + Rec.Width - 1, Rec.Y + Rec.Height - 2));
        }
        #endregion

        #region DataGridView事件
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            if (e.RowIndex == -1)
            {
                if (!(_ColumnHeaderColor1 == Color.Transparent) && !(_ColumnHeaderColor2 == Color.Transparent) &&
                    !_ColumnHeaderColor1.IsEmpty && !_ColumnHeaderColor2.IsEmpty)
                {
                    DrawLinearGradient(e.CellBounds, e.Graphics, _ColumnHeaderColor1, _ColumnHeaderColor2);
                    DrawLine(e.CellBounds, e.Graphics, Color.Silver);
                    try
                    {
                        e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background));
                    }
                    catch { }
                    e.Handled = true;
                }
            }
        }

        private void JMDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Rectangle rowBounds = new Rectangle(0, e.RowBounds.Top, this.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - this.HorizontalScrollingOffset + 1,e.RowBounds.Height);
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                if (this.RowTemplate.DefaultCellStyle.SelectionBackColor == Color.Transparent)
                    DrawLinearGradient(rowBounds, e.Graphics, _SelectedRowColor1, _SelectedRowColor2);
            }
            else
            {
                if (this.RowTemplate.DefaultCellStyle.BackColor == Color.Transparent)
                {
                    if (e.RowIndex % _SecondaryLength == 1)
                    {
                        DrawLinearGradient(rowBounds, e.Graphics, _PrimaryRowColor1, _PrimaryRowColor2);
                    }
                    else
                    {
                        DrawLinearGradient(rowBounds, e.Graphics, _SecondaryRowColor1, _SecondaryRowColor2);
                    }
                }
            }
        }

        private void JMDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (sx == null)
                return;
            lie = e.ColumnIndex;
            ind = checkcolumns(lie);
            if (ind >= 0)
            {
                aaa = 0;
                abc = false;
                j = 0;
            }
        }

        private void JMDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() == typeof(System.Windows.Forms.DataGridViewTextBoxEditingControl))
            {
                tb = e.Control as TextBox;

                tb.KeyDown += new KeyEventHandler(tb_KeyDown);
                tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                tb.MouseClick += new MouseEventHandler(tb_MouseClick);
                tb.MouseDoubleClick += new MouseEventHandler(tb_MouseDoubleClick);
                te = true;
            }
        }

        private void JMDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (te)
            {
                tb.KeyDown -= new KeyEventHandler(tb_KeyDown);
                tb.KeyPress -= new KeyPressEventHandler(tb_KeyPress);
                tb.MouseClick -= new MouseEventHandler(tb_MouseClick);
                tb.MouseDoubleClick -= new MouseEventHandler(tb_MouseDoubleClick);
                aaa = 0;
                abc = false;
                j = 0;
                te = false;
            }
        }

        private void JMDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (this.Columns[e.ColumnIndex].GetType().ToString() == "System.Windows.Forms.DataGridViewButtonColumn")
                {
                    if (DataGridViewButtonClike != null)
                        DataGridViewButtonClike(sender, e.RowIndex, e.ColumnIndex);
                }
            }
            lie = e.ColumnIndex;
            ind = checkcolumns(lie);
            if (ind >= 0)
            {
                aaa = 0;
                abc = false;
                j = 0;
            }
        }
        #endregion

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            //检测是被表示的控件还是DataGridViewTextBoxEditingControl
            if (e.Control is DataGridViewTextBoxEditingControl)
            { //取得被表示的控件
                DataGridViewTextBoxEditingControl tb =
                (DataGridViewTextBoxEditingControl)e.Control;

                ContextMenuStrip cms = new ContextMenuStrip();
                tb.ContextMenuStrip = cms;
            }
            base.OnEditingControlShowing(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Y <= this.ColumnHeadersHeight)
            {
                if (!string.IsNullOrEmpty(_zxmlname))
                {
                    string path = Application.StartupPath + "\\" + _zxmlname;
                    foreach (DataGridViewColumn column in this.Columns)
                    {
                        XmlHelperEx.Update(path, "DataGridViewColumns/Column[@cname='" + column.Name + "']/DisplayIndex", "", column.DisplayIndex.ToString());
                    }
                }
            }
        }
        
        #region 单击表头弹出菜单
        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            //base.OnColumnHeaderMouseClick(e);
            //MessageBoxJ.Show(e.X.ToString() + "," + e.Y.ToString());
            if (e.Button == MouseButtons.Right)
            {
                if (e.X < this.Columns[e.ColumnIndex].Width && e.X > this.Columns[e.ColumnIndex].Width - 20)
                {
                    if (ZShowCaiDan)
                    {
                        List<columninfo> strlist = new List<columninfo>();
                        foreach (DataGridViewColumn var in this.Columns)
                        {
                            if (var.Tag == null)
                            {
                                columninfo cin = new columninfo();
                                cin.Cvisble = var.Visible;
                                cin.Cname = var.Name;
                                cin.Ctext = var.HeaderText;
                                strlist.Add(cin);
                            }
                        }
                        DataTable colvalue = new DataTable();
                        string cname = this.Columns[e.ColumnIndex].Name;
                        colvalue.Columns.Add("vs", typeof(bool));
                        colvalue.Columns.Add(cname, typeof(string));
                        foreach (DataGridViewRow var in this.Rows)
                        {
                            DataRow dr = colvalue.NewRow();
                            dr["vs"] = var.Visible;
                            dr[cname] = var.Cells[cname].Value;
                            colvalue.Rows.Add(dr);
                        }
                        JMDGVMENU ContextMenu = new JMDGVMENU(strlist, cname, GetDistinctTable(colvalue, cname));
                        ContextMenu.Stype = JMControlsEx.ShowType.Top;//从左到右
                        ContextMenu.ColumnVisbleChange += new JMDGVMENU.ColumnVisbleHandel(ContextMenu_ColumnVisbleChange);
                        ContextMenu.ColumnOrderChange += new JMDGVMENU.ColumnOrderHandel(ContextMenu_ColumnOrderChange);
                        ContextMenu.ColumnValueChange += new JMDGVMENU.ColumnValueHandel(ContextMenu_ColumnValueChange);
                        Screen cre = Screen.PrimaryScreen;//当前屏幕
                        //是否超出屏幕
                        if (ContextMenu.Height + MousePosition.Y > cre.WorkingArea.Height)
                            ContextMenu.Location = new Point(MousePosition.X + 5, cre.WorkingArea.Height - ContextMenu.Height);
                        else
                            ContextMenu.Location = new Point(MousePosition.X + 5, MousePosition.Y);
                        ContextMenu.Show();
                    }
                    else
                        base.OnColumnHeaderMouseClick(e);
                }
                else
                    base.OnColumnHeaderMouseClick(e);
            }
            else
                base.OnColumnHeaderMouseClick(e);
        }

        void ContextMenu_ColumnValueChange(List<string> values, string _cname)
        {
            foreach (DataGridViewRow var in this.Rows)
            {
                string va = "";
                if (var.Cells[_cname].Value != null)
                    va = var.Cells[_cname].Value.ToString();
                bool bl = true;
                foreach (string str in values)
                {
                    if (va == str)
                    {
                        bl = false;
                        break;
                    }
                }

                if (this.DataSource != null)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[this.DataSource];
                    cm.SuspendBinding(); //挂起数据绑定
                    var.Visible = bl;
                    cm.ResumeBinding(); //恢复数据绑定
                }
                else
                {
                    var.Visible = bl;
                }
            }
        }

        void ContextMenu_ColumnOrderChange(ListSortDirection cstate, string _cname)
        {
            this.Sort(this.Columns[_cname], cstate);
        }

        void ContextMenu_ColumnVisbleChange(bool cstate, string _cname)
        {
            this.Columns[_cname].Visible = cstate;
            if (!string.IsNullOrEmpty(_zxmlname))
            {
                string path = Application.StartupPath + "\\" + _zxmlname;
                XmlHelperEx.Update(path, "DataGridViewColumns/Column[@cname='" + _cname + "']/Visble", "", cstate.ToString());
            }
        }

        /// <summary>
        /// 获取对固定列不重复的新DataTable
        /// </summary>
        /// <param name="dt">含有重复数据的DataTable</param>
        /// <param name="colName">需要验证重复的列名</param>
        /// <returns>新的DataTable，colName列不重复，表格式保持不变</returns>
        private DataTable GetDistinctTable(DataTable dt, string colName)
        {
            DataView dv = dt.DefaultView;
            DataTable dtCardNo = dv.ToTable(true, colName);
            DataTable Pointdt = new DataTable();
            Pointdt = dv.ToTable();
            Pointdt.Clear();
            for (int i = 0; i < dtCardNo.Rows.Count; i++)
            {
                string value = "";
                if (dtCardNo.Rows[i][0] != null)
                    value = dtCardNo.Rows[i][0].ToString();
                if (dt.Select(colName + "='" + value + "'").Length > 0)
                {
                    DataRow dr = dt.Select(colName + "='" + value + "'")[0];
                    Pointdt.Rows.Add(dr.ItemArray);
                }
            }
            return Pointdt;
        }
        #endregion

        private string _zxmlname;

        public string Zxmlname
        {
            get { return _zxmlname; }
            set { _zxmlname = value; }
        }

        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            if (!string.IsNullOrEmpty(_zxmlname))
            {
                string path = Application.StartupPath + "\\" + _zxmlname;
                XmlHelperEx.Update(path, "DataGridViewColumns/Column[@cname='" + e.Column.Name + "']", "Width", e.Column.Width.ToString());
            }
        }

        #region 添加列 加载xml文件
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
        }
        #endregion

    }
}
