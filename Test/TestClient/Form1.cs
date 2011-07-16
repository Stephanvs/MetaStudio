using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Hayman.Client.ReadModel.Blueprints.Meta;
using Hayman.Commands;
using System.ServiceModel;
using Ncqrs.CommandService.Contracts;
using Ncqrs.CommandService;

namespace TestClient
{
	public partial class Form1 : Form
	{
		private readonly Collection<Model> _models = new Collection<Model>();
		private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

		public Form1()
		{
			InitializeComponent();
		}

		static Form1()
		{
			_channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");
		}

		private void btnCreateNewMetaItem_Click(object sender, EventArgs e)
		{
			GetCurrentlyActiveModel().AddMetaItem(tbName.Text);
			tbName.Text = String.Empty;
			AssignDataSources();
			UpdateBindings();
		}

		private void btnAddMetaAssociation_Click(object sender, EventArgs e)
		{
			var source = (MetaItem)miSource.SelectedItem;
			var target = (MetaItem)miTarget.SelectedItem;

			GetCurrentlyActiveModel().AddMetaAssocation(source.Id, target.Id);

			listMetaAssociations.DataSource = GetCurrentlyActiveModel().MetaAssociations.ToList();
			listMetaAssociations.ResetBindings();
		}

		private void btnCreateItem_Click(object sender, EventArgs e)
		{
			var item = GetCurrentlyActiveModel().AddItem(tbNewItemName.Text);
			var mi = (MetaItem)cbMetaItems.SelectedItem;

			// Don't forget to add an association between the created Item and the existing MetaItem!
			GetCurrentlyActiveModel().AddInstanceAssocation(mi.Id, item.Id);

			tbNewItemName.Text = String.Empty;
		}

		private void AssignDataSources()
		{
			var model = GetCurrentlyActiveModel();

			listMetaItems.DataSource = model.MetaItems.ToList();
			miSource.DataSource = model.MetaItems.ToList();
			miTarget.DataSource = model.MetaItems.ToList();
			cbMetaItems.DataSource = model.MetaItems.ToList();
			listOfMetaItemsForItems.DataSource = model.MetaItems.ToList();
			ddlSourceMetaItem.DataSource = model.MetaItems.ToList();
			ddlTargetMetaItem.DataSource = model.MetaItems.ToList();
			listMetaItemsForView.DataSource = model.MetaItems.ToList();
		}

		private void UpdateBindings()
		{
			listMetaItems.ResetBindings();
			miSource.ResetBindings();
			miTarget.ResetBindings();
			cbMetaItems.ResetBindings();
			listOfMetaItemsForItems.ResetBindings();
			ddlSourceMetaItem.ResetBindings();
			ddlTargetMetaItem.ResetBindings();
			listMetaItemsForView.ResetBindings();
		}

		private void listOfMetaItemsForItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			var mi = (MetaItem)listOfMetaItemsForItems.SelectedItem;

			listOfItems.DataSource = mi.Items.ToList();
			listOfItems.ResetBindings();
		}

		private Model GetCurrentlyActiveModel()
		{
			return (Model)cbModels.SelectedItem;
		}

		private void btnCreateNewModel_Click(object sender, EventArgs e)
		{
			_models.Add(new Model(tbNewModelName.Text));
			cbModels.DataSource = _models;
			cbModels.ResetBindings();

			tbNewModelName.Text = String.Empty;
		}

		private void cbModels_SelectedIndexChanged(object sender, EventArgs e)
		{
			AssignDataSources();
			UpdateBindings();

            listMetaAssociations.DataSource = GetCurrentlyActiveModel().Associations.OfType<MetaAssociation>().ToList();
            listMetaAssociations.ResetBindings();
		}

		private void ddlSourceMetaItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			ddlSourceItem.DataSource = ((MetaItem)ddlSourceMetaItem.SelectedItem).Items.ToList();
			ddlSourceItem.ResetBindings();
		}

		private void ddlTargetMetaItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			ddlTargetItem.DataSource = ((MetaItem)ddlTargetMetaItem.SelectedItem).Items.ToList();
			ddlTargetItem.ResetBindings();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//var w = new ExportForm(_models);
			//w.Show(this);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//var dlg = new OpenFileDialog() { CheckFileExists = true, DefaultExt = "xml" };

			//if (DialogResult.OK == dlg.ShowDialog(this))
			//{
			//    using (var x = new StreamReader(dlg.FileName))
			//    {
			//        var xmlReader = new XmlTextReader(x);
			//        var ser = new DataContractSerializer(typeof(Model), "Model", "http://schemas.hayman.com/metastudio/2011/v1", new[] 
			//        {
			//            typeof(MetaAssociation), 
			//            typeof(Association),
			//            typeof(InstanceAssociation),
			//            typeof(HaymanGraph),
			//            typeof(MetaItem),
			//            typeof(Item),
			//            typeof(Word),
			//            typeof(Collection<HaymanGraph>)
			//        });
			//        var result = ser.ReadObject(xmlReader, false);

			//        _models = (Collection<Model>) result;
			//    }

			//    cbModels.DataSource = _models;
			//    cbModels.ResetBindings();

			//    AssignDataSources();
			//    UpdateBindings();
			//    ResetBindings();

			//    listMetaAssociations.DataSource = GetCurrentlyActiveModel().Associations.OfType<MetaAssociation>().ToList();
			//    listMetaAssociations.ResetBindings();

			//    listAssociations.DataSource = GetCurrentlyActiveModel().Associations.OfType<Association>().ToList();
			//    listAssociations.ResetBindings();
			//}
		}

        private void btnCreateView_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
			//var view = new Model(string.Format("[View] {0}", tbViewName.Text));

			//foreach (var metaitem in listMetaItemsForView.SelectedItems.Cast<MetaItem>())
			//{
			//    var clone = new MetaItem(view, string.Format("[Clone] {0}", metaitem.DefaultWord.Value)); // Todo: create possibility to clone metaitems
			//}

			//_models.Add(view);
			//cbModels.DataSource = _models;
			//cbModels.ResetBindings();
        }

		private void btnCreateItemAssociation_Click(object sender, EventArgs e)
		{
			var sourceItem = (Item) ddlSourceItem.SelectedItem;
			var targetItem = (Item) ddlTargetItem.SelectedItem;
			var model = GetCurrentlyActiveModel();

			model.AddAssociation(sourceItem.Id, targetItem.Id);

			// Update listbox with associations
			listAssociations.DataSource = model.Associations.ToList();
			listAssociations.ResetBindings();
		}

		private void btnNewModelCommand_Click(object sender, EventArgs e)
		{
			var command = new CreateModel(Guid.NewGuid(), tbNewModelName.Text);

			ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
							  client.Execute(new ExecuteRequest(command)));
		}
	}
}