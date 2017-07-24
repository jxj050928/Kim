using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.ComponentModel;

namespace JMControlsEx
{
    public class JMComboTree : Panel
    {
        //显示效果文本
        Label jmlb;

        //显示标题文本
        Label jmlbOne;

        //显示具体值文本
        Label jmlbTwo;

        //隐藏控件用户 获取焦点
        TextBox tebo;

        FrmComboTree frm = new FrmComboTree();

        [Browsable(true)]
        public event EventHandler JMLeave;

        private bool _JMFocused = false;

        public bool JMFocused
        {
            get { return _JMFocused; }
            set
            {
                _JMFocused = value;
                if (value)
                {
                    //tebo.Focus();
                    tebo.Select();
                    tebo.Focus();
                }
            }
        }

        #region 属性
        /// <summary>
        /// 显示效果文本
        /// </summary>
        private string _JMEffectText;

        [Description("显示效果文本"), DefaultValue(typeof(Font), "")]
        public string JMEffectText
        {
            get { return _JMEffectText; }
            set { _JMEffectText = value; jmlb.Text = value; }
        }

        /// <summary>
        /// 显示效果颜色
        /// </summary>
        private Color _JMEffectColor;

        [Description("显示效果颜色"), DefaultValue(typeof(Color), "Black")]
        public Color JMEffectColor
        {
            get { return _JMEffectColor; }
            set { _JMEffectColor = value; jmlb.ForeColor = value; jmlbOne.ForeColor = value; jmlbTwo.ForeColor = value; }
        }

        [Description("绑定数据集")]
        public DataTable JMDT
        {
            get { return frm.JMDT; }
            set { frm.JMDT = value; }
        }

        /// <summary>
        /// 编号
        /// </summary>
        private string _JMTypeID;

        [Description("获取或设置当前编号值"), DefaultValue(typeof(string), "")]
        public string JMTypeID
        {
            get { return _JMTypeID; }
            set
            {
                _JMTypeID = value;
                if (!string.IsNullOrEmpty(value))
                {
                    jmlb.Visible = false;
                    jmlbOne.Visible = true;
                    jmlbTwo.Visible = true;
                    string _Names = JMDT.Select(JMBHLie + "='" + _JMTypeID + "'")[0].ItemArray[1].ToString();
                    jmlbTwo.Text = _Names;
                }
                else
                {
                    jmlb.Visible = true;
                    jmlbOne.Visible = false;
                    jmlbTwo.Visible = false;
                    jmlbTwo.Text = "";
                }
            }
        }

        [Description("编号列(数据库字段)")]
        public string JMBHLie
        {
            get { return frm.JMBHLie; }
            set { frm.JMBHLie = value; }
        }

        [Description("名称列(数据库字段)")]
        public string JMNameLie
        {
            get { return frm.JMNameLie; }
            set { frm.JMNameLie = value; }
        }

        /// <summary>
        /// 选择前的显示值
        /// </summary>
        private string _JMXZQZ;

        [Description("名称列文本"), DefaultValue(typeof(string), "")]
        public string JMXZQZ
        {
            get { return _JMXZQZ; }
            set
            {
                _JMXZQZ = value;
                jmlbOne.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    jmlbTwo.Location = new Point(jmlbOne.Location.X + jmlbOne.Width + 6, (this.Height - jmlbTwo.Height) / 2);
                }
            }
        }

        [Description("是否显示增加按钮、右键菜单")]
        public bool JMVisibleADDandYJ
        {
            get { return frm.JMVisibleADDandYJ; }
            set { frm.JMVisibleADDandYJ = value; }
        }

        /// <summary>
        /// 选中以后是否赋值
        /// </summary>
        private bool _isSetSelected;

        [Description("选中以后是否赋值")]
        public bool IsSetSelected
        {
            get { return _isSetSelected; }
            set { _isSetSelected = value; }
        }

        /// <summary>
        /// 单击时是否获取焦点
        /// </summary>
        private bool _JMClickFous;

        [Description("单击时是否获取焦点")]
        public bool JMClickFous
        {
            get { return _JMClickFous; }
            set { _JMClickFous = value; }
        }
        #endregion

        #region 事件
        public event JMDelegate.IEventHandle JMAddAndUpdateClick;

        public event JMDelegate.IEventHandle JMDeleteClick;

        public event JMDelegate.ClickDeleteHandel AfterSelect;
        #endregion

        public JMComboTree()
        {
            _JMEffectColor = Color.Black;
            _isSetSelected = true;
            _JMClickFous = false;

            this.Cursor = Cursors.Hand;
            this.MinimumSize = new Size(100, 22);
            this.Click += new EventHandler(JMDiayType_Click);

            frm.JMAddAndUpdateClick += new JMDelegate.IEventHandle(frm_JMAddAndUpdateClick);
            frm.JMDelClick += new JMDelegate.IEventHandle(frm_JMDelClick);
            frm.JMSelectClick += new JMDelegate.ClickDeleteHandel(frm_JMSelectClick);
            frm.ShwoAddCancel = false;

            jmlb = new Label();
            jmlb.Name = "label1";
            jmlb.AutoSize = true;
            jmlb.Cursor = Cursors.Hand;
            jmlb.Click += new EventHandler(JMDiayType_Click);
            this.Controls.Add(jmlb);

            jmlbOne = new Label();
            jmlbOne.Name = "label2";
            jmlbOne.AutoSize = true;
            jmlbOne.Cursor = Cursors.Hand;
            jmlbOne.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            jmlbOne.Visible = false;
            jmlbOne.Click += new EventHandler(JMDiayType_Click);
            this.Controls.Add(jmlbOne);

            jmlbTwo = new Label();
            jmlbTwo.Name = "label3";
            jmlbTwo.AutoSize = true;
            jmlbTwo.Cursor = Cursors.Hand;
            jmlbTwo.Visible = false;
            jmlbTwo.Click += new EventHandler(JMDiayType_Click);
            this.Controls.Add(jmlbTwo);

            //添加一个TextBox用于让控件获得焦点
            tebo = new TextBox();
            tebo.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Right));
            tebo.Name = "tebo1";
            tebo.Text = "";
            tebo.Visible = true;
            tebo.Size = new Size(50, 21);
            tebo.Leave += new EventHandler(tebo_Leave);
            this.Controls.Add(tebo);

            this.Size = new Size(120, 22);

            jmlb.Location = new Point(1, (this.Height - jmlb.Height) / 2);
            jmlbOne.Location = new Point(1, (this.Height - jmlbOne.Height) / 2);
            jmlbTwo.Location = new Point(jmlbOne.Location.X + jmlbOne.Width + 6, (this.Height - jmlbTwo.Height) / 2);
            tebo.Location = new Point(this.Width + 20, (this.Height - tebo.Height) / 2);
        }

        private void tebo_Leave(object sender, EventArgs e)
        {
            if (JMLeave != null)
            {
                JMFocused = false;
                JMLeave(sender, e);
            }
        }

        #region 添加/修改单击事件
        private void frm_JMAddAndUpdateClick(object sender, JEventargs e)
        {
            if (JMAddAndUpdateClick != null)
            {
                JMAddAndUpdateClick(sender, e);
                if (e.Cancel)
                {
                    if (!string.IsNullOrEmpty(e.Tag))
                    {
                        _JMTypeID = e.Tag.ToString();
                    }
                    jmlbTwo.Text = e.Text.Trim();
                    jmlb.Visible = false;
                    jmlbOne.Visible = true;
                    jmlbTwo.Visible = true;
                    JMFocused = true;
                }
            }
        }
        #endregion

        #region 删除事件
        private void frm_JMDelClick(object sender, JEventargs e)
        {
            if (JMDeleteClick != null)
            {
                JMDeleteClick(sender, e);
                if (e.Cancel)
                {
                    _JMTypeID = "";
                    jmlbTwo.Text = "";
                    jmlb.Visible = true;
                    jmlbOne.Visible = false;
                    jmlbTwo.Visible = false;
                }
                JMFocused = true;
            }
        }
        #endregion

        #region 选择事件
        private void frm_JMSelectClick(string _str, string _str1)
        {
            if (IsSetSelected)
            {
                _JMTypeID = _str;
                jmlbTwo.Text = _str1;
                jmlb.Visible = false;
                jmlbOne.Visible = true;
                jmlbTwo.Visible = true;
                JMFocused = true;
            }
            if (AfterSelect != null)
            {
                AfterSelect(_str, _str1);
            }
        }
        #endregion

        #region 单击事件(调用选择窗体)
        private void JMDiayType_Click(object sender, EventArgs e)
        {
            if (_JMClickFous)
            {
                JMFocused = true;
            }
            if (frm.Visible)
            {
                frm.Hide();
            }
            else
            {
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                Screen cre = Screen.PrimaryScreen;
                frm.Show();
                frm.Focus();
                if (CBRect.X + frm.Width > cre.WorkingArea.Width)
                {
                    frm.Location = new Point(CBRect.X - frm.Width + this.Width, CBRect.Y + this.Height);
                }
                else
                {
                    frm.Location = new Point(CBRect.X, CBRect.Y + this.Height);
                }
            }
        }
        #endregion
    }
}