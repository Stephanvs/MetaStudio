using System;

namespace Hayman.Client
{
    public partial class RenameMetaModelForm : DevExpress.XtraEditors.XtraForm
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

        public RenameMetaModelForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}