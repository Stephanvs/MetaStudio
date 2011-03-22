using System;
using Hayman.Commands;
using Hayman.Client.HaymanReadModelServiceReference;
using System.ServiceModel;
using Ncqrs.CommandService.Contracts;
using Ncqrs.CommandService;

namespace Hayman.Client
{
    public partial class RenameMetaModelForm : DevExpress.XtraEditors.XtraForm
    {
        private Object datasource;
        private static ChannelFactory<ICommandWebServiceClient> channelFactory;

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

        static RenameMetaModelForm()
        {
            channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");
        }

        public RenameMetaModelForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //using (var service = new HaymanCommandServiceReference.HaymanCommandServiceClient())
            //{
            //    service.Execute(new [] { new RenameMetaModel(((MetaModel)datasource).MetaModelId, MetaModelNameTextEdit.Text) });
            //}

            var command = new RenameMetaModel(((MetaModel)datasource).MetaModelId, MetaModelNameTextEdit.Text);
            ChannelHelper.Use(channelFactory.CreateChannel(), (client) => client.Execute(new ExecuteRequest(command)));

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}