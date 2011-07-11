using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections.ObjectModel;
using Hayman.Client.ReadModel.Blueprints.Graph;
using Hayman.Client.ReadModel.Blueprints.Meta;

namespace TestClient
{
	public partial class ExportForm : Form
	{
		Collection<Model> _models;

        public ExportForm(Collection<Model> models)
		{
			InitializeComponent();
			_models = models;

			Export();
		}

		private void Export()
		{
			var sw = new StringWriter();
			var ser = new DataContractSerializer(typeof(HaymanGraph), "Model", "http://schemas.hayman.com/metastudio/2011/v1", new[] 
            {
                typeof(MetaAssociation), 
                typeof(Association),
                typeof(InstanceAssociation),
                typeof(HaymanGraph),
                typeof(MetaItem),
                typeof(Item),
                typeof(Word),
                typeof(Collection<HaymanGraph>)
            });
			ser.WriteObject(new XmlTextWriter(sw), _models);

			textBox1.Text = sw.ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog()
			{
				AddExtension = true,
				Filter = "MetaModel (*.xml)|*.xml",
				DefaultExt = "xml"
			};

			if (DialogResult.OK == dlg.ShowDialog(this))
			{
				using (var sw = File.CreateText(dlg.FileName))
				{
					sw.Write(textBox1.Text);
				}
			}
		}
	}
}
