using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace JMControlsEx
{
    public class LeftMenuItems : CollectionBase
    {
        private LeftMenu owner;

        #region 构造函数
        public LeftMenuItems(
               LeftMenu c
            )
            : base()
        {
            this.owner = c;
        }

        public LeftMenuItems()
            : base()
        {
        }
        #endregion

        public LeftMenuItem this[int idx]
        {
            get
            {
                return (LeftMenuItem)InnerList[idx];
            }
        }

        public LeftMenuItem Add(
               string sText
            )
        {
            LeftMenuItem aclb = new LeftMenuItem(owner);
            aclb.Text = sText;
            InnerList.Add(aclb);
            owner.CalculatesMenuSize();
            return aclb;
        }

        public LeftMenuItem Add(
               string sText,
               string sDescription
            )
        {
            LeftMenuItem aclb = new LeftMenuItem(owner);
            aclb.Text = sText;
            aclb.Description = sDescription;
            InnerList.Add(aclb);
            owner.CalculatesMenuSize();
            return aclb;
        }

        public LeftMenuItem Add(
            string sText,
            string sDescription,
            Image img
            )
        {
            LeftMenuItem btn = new LeftMenuItem(owner);
            btn.Text = sText;
            btn.Description = sDescription;
            btn.Image = img;
            InnerList.Add(btn);
            owner.CalculatesMenuSize();
            return btn;
        }

        public LeftMenuItem Add(
            string sText,
            Image img
            )
        {
            LeftMenuItem btn = new LeftMenuItem(owner);
            btn.Text = sText;
            btn.Image = img;

            InnerList.Add(btn);
            owner.CalculatesMenuSize();
            return btn;
        }

        public void Add(LeftMenuItem btn)
        {

            List.Add(btn);
            btn.Owner = this.owner;
            owner.CalculatesMenuSize();
        }

        public int IndexOf(object o)
        {
            return InnerList.IndexOf(o);
        }

        protected override void OnInsertComplete(int index, object value)
        {
            LeftMenuItem btn = (LeftMenuItem)value;
            btn.Owner = this.owner;
            owner.CalculatesMenuSize();
            base.OnInsertComplete(index, value);
        }

        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            LeftMenuItem btn = (LeftMenuItem)newValue;
            btn.Owner = this.owner;
            owner.CalculatesMenuSize();
            base.OnSetComplete(index, oldValue, newValue);
        }

        public LeftMenu Owner
        {
            get
            {
                return this.owner;
            }
        }

        protected override void OnClearComplete()
        {
            owner.CalculatesMenuSize();
            base.OnClearComplete();
        }
    }
}
