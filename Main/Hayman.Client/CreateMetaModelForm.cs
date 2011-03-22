using System;
using DevExpress.XtraEditors;
using Hayman.Commands;
using System.ServiceModel;
using Ncqrs.CommandService.Contracts;
using Ncqrs.CommandService;

namespace Hayman.Client
{
    public partial class CreateMetaModelForm : XtraForm
    {
        private static ChannelFactory<ICommandWebServiceClient> channelFactory;
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

        static CreateMetaModelForm()
        {
            channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");
        }

        public CreateMetaModelForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var command = new CreateMetaModel(Guid.Parse(MetaModelIdTextEdit.Text), MetaModelNameTextEdit.Text);

            try
            {
                ChannelHelper.Use(channelFactory.CreateChannel(), (client) => client.Execute(new ExecuteRequest(command)));
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            
            Close();
        }

        private void CreateMetaModelForm_Load(object sender, EventArgs e)
        {
            MetaModelIdTextEdit.Text = Guid.NewGuid().ToString();
        }
    }
}