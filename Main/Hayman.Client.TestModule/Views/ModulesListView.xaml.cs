using System;
using Hayman.Client.DebugModule.ViewModels;
using Hayman.Client.Presentation.Windows.Controls;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.DebugModule.Views
{
	/// <summary>
	/// Interaction logic for ModulesListView.xaml
	/// </summary>
    public partial class ModulesListView : WindowElement
	{
		public ModulesListView(ModulesListViewModel vm)
		{
			InitializeComponent();
			DataContext = vm;
		}
	}
}
