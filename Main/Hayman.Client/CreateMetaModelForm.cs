using System;
using DevExpress.XtraEditors;
using Hayman.Commands;

namespace Hayman.Client
{
    public partial class CreateMetaModelForm : XtraForm
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
                metaModelBindingSource.DataSource = datasource;
            }
        }

        public CreateMetaModelForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            using (var service = new HaymanCommandServiceReference.HaymanCommandServiceClient())
            {
                service.ExecuteCommand(new CreateMetaModel(Guid.Parse(MetaModelIdTextEdit.Text), MetaModelNameTextEdit.Text));
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CreateMetaModelForm_Load(object sender, EventArgs e)
        {
            MetaModelIdTextEdit.Text = Guid.NewGuid().ToString();
        }
    }
}