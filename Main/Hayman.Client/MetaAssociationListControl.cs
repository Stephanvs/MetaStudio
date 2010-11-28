using System;
using Hayman.Client.HaymanReadModelServiceReference;

namespace Hayman.Client
{
    public partial class MetaAssociationListControl : DevExpress.XtraEditors.XtraUserControl
    {
        public MetaAssociationListControl()
        {
            InitializeComponent();
            var entities = new HaymanReadModelServiceReference.HaymanReadModelEntities(new Uri("http://localhost:20813/HaymanReadModelService.svc/"));
            metaItemBindingSource.DataSource = entities.MetaItems;
            metaModelBindingSource.DataSource = entities.MetaModels;
            UpdateButtons();
        }

        private void createMetaAssociationButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new CreateMetaAssociationForm())
            {
                form.DataSource = metaAssociationBindingSource.AddNew();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    metaAssociationBindingSource.CancelEdit();
                }
            }
        }

        private void UpdateButtons()
        {
            var enabled = metaAssociationBindingSource.Current != null;
            deleteMetaAssociationButton.Enabled = enabled;
        }

        private void deleteMetaAssociationButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MetaAssociation metaAssociation = (MetaAssociation)metaAssociationBindingSource.Current;
            metaAssociation.Deleted = true;
        }

        private void metaAssociationBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }
    }
}
