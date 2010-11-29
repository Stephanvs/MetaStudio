using System;
using Hayman.Client.HaymanReadModelServiceReference;
using System.Windows.Forms;
using Hayman.Commands;

namespace Hayman.Client
{
    public partial class MetaModelListControl : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void MetaModelChangedEventHandler(MetaModel metaModel);

        public MetaModelListControl()
        {
            InitializeComponent();
            Load += MetaModelListControl_Load;
            metaModelBindingSource.CurrentChanged += metaModelBindingSource_CurrentChanged;
        }

        void MetaModelListControl_Load(object sender, EventArgs e)
        {
            var entities = new HaymanReadModelServiceReference.HaymanReadModelEntities(new Uri("http://localhost:20813/HaymanReadModelService.svc/"));
            metaModelBindingSource.DataSource = entities.MetaModels
                                                .Expand("MetaItems/IncomingMetaAssociations")
                                                .Expand("MetaItems/OutgoingMetaAssociations");

            if (MetaModelChanged != null)
            {
                MetaModelChanged((MetaModel)metaModelBindingSource.Current);
            }

            UpdateButtons();
        }

        void metaModelBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            OnMetaModelChanged((MetaModel)metaModelBindingSource.Current);
            UpdateButtons();
        }

        public void OnMetaModelChanged(MetaModel metaModel)
        {
            if (MetaModelChanged != null)
            {
                MetaModelChanged(metaModel);
            }
        }

        public event MetaModelChangedEventHandler MetaModelChanged;

        private void createMetaModelButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new CreateMetaModelForm())
            {
                form.DataSource = metaModelBindingSource.AddNew();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    metaModelBindingSource.CancelEdit();
                }
            }
        }

        private void renameMetaModelButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new RenameMetaModelForm())
            {
                form.DataSource = metaModelBindingSource.Current;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    metaModelBindingSource.CancelEdit();
                }
            }
        }

        private void UpdateButtons()
        {
            var enabled = metaModelBindingSource.Current != null;
            renameMetaModelButton.Enabled = enabled;
            deleteMetaModelButton.Enabled = enabled;
        }

        private void deleteMetaModelButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var service = new HaymanCommandServiceReference.HaymanCommandServiceClient())
            {
                service.ExecuteCommand(new DeleteMetaModel(((MetaModel)metaModelBindingSource.Current).MetaModelId));
            }

            MetaModel metaModel = (MetaModel)metaModelBindingSource.Current;
            metaModel.Deleted = true;
        }
    }
}
