using System;

namespace Hayman.Client
{
    public partial class RenameMetaItemForm : DevExpress.XtraEditors.XtraForm
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
            }
        }

        public RenameMetaItemForm()
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