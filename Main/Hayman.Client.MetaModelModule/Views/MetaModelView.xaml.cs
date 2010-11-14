using System;
using Hayman.Client.MetaModelModule.ViewModels;
using Hayman.Client.Presentation.Windows.Controls;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.MetaModelModule.Views
{
	/// <summary>
	/// Interaction logic for LogView.xaml
	/// </summary>
    public partial class MetaModelView : WindowElement
	{
        public MetaModelView(MetaModelViewModel model)
		{
			DataContext = model;
		}
    }
}
