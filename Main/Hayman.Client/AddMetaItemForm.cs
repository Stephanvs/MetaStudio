using System;

namespace Hayman.Client
{
    public partial class AddMetaItemForm : DevExpress.XtraEditors.XtraForm
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

        public AddMetaItemForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void AddMetaItemForm_Load(object sender, EventArgs e)
        {
            MetaItemIdTextEdit.Text = Guid.NewGuid().ToString();
        }
    }
}