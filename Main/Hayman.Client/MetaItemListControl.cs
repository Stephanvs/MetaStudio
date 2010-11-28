using System;
using Hayman.Client.HaymanReadModelServiceReference;

namespace Hayman.Client
{
    public struct DialogResult
    {
        static DialogResult()
        {
            
        }
    }
    public partial class MetaItemListControl : DevExpress.XtraEditors.XtraUserControl
    {
        private Object datasource;

        public Object DataSource
        {
            get
            {
                return datasource;
            }
            set
            {
                datasource = value;
                metaItemBindingSource.DataSource = datasource;
                metaItemBindingSource.DataMember = "MetaItems";
                UpdateButtons();
            }
        }

        public MetaItemListControl()
        {
            InitializeComponent();
        }

        private void addMetaItemButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new AddMetaItemForm())
            {
                MetaItem metaItem = (MetaItem)metaItemBindingSource.AddNew();
                metaItem.MetaModelId = ((MetaModel)datasource).MetaModelId;
                form.DataSource = metaItem;

                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    metaItemBindingSource.CancelEdit();
                }
            }
        }

        private void renameMetaItemButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new RenameMetaItemForm())
            {
                form.DataSource = metaItemBindingSource.Current;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    metaItemBindingSource.CancelEdit();
                }
            }
        }

        private void removeMetaItemButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            metaItemBindingSource.RemoveCurrent();
        }

        private void UpdateButtons()
        {
            var enabled = metaItemBindingSource.Current != null;
            renameMetaItemButton.Enabled = enabled;
            removeMetaItemButton.Enabled = enabled;
        }

        private void metaItemBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }
    }
}
