using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;

namespace JMControlsEx
{
    internal class JMDropDownCollectionEditor : CollectionEditor
    {
        #region FieldsPrivate

        private CollectionForm m_collectionForm;

        #endregion

        #region MethodsPublic

        public JMDropDownCollectionEditor(Type type)
            : base(type)
        {
        }

        #endregion

        #region MethodsProtected

        protected override CollectionForm CreateCollectionForm()
        {
            this.m_collectionForm = base.CreateCollectionForm();
            return this.m_collectionForm;
        }

        protected override Object CreateInstance(Type ItemType)
        {
            JMComboBoxButton xpanderPanel = (JMComboBoxButton)base.CreateInstance(ItemType);
            if (this.Context.Instance != null)
            {
                //xpanderPanel.Expand = true;
            }
            return xpanderPanel;
        }

        #endregion
    }
}
