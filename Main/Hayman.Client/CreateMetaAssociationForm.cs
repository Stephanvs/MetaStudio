using System;

namespace Hayman.Client
{
    public partial class CreateMetaAssociationForm : DevExpress.XtraEditors.XtraForm
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
                metaAssociationBindingSource.DataSource = datasource;
            }
        }

        public CreateMetaAssociationForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CreateMetaAssociationForm_Load(object sender, EventArgs e)
        {
            MetaAssociationIdTextEdit.Text = Guid.NewGuid().ToString();

            var entities = new HaymanReadModelServiceReference.HaymanReadModelEntities(new Uri("http://localhost:20813/HaymanReadModelService.svc/"));
            metaItemBindingSource.DataSource = entities.MetaItems;
            metaModelBindingSource.DataSource = entities.MetaModels;
        }
    }
}