using System;
using Hayman.Client.DebugModule.ViewModels;
using Hayman.Client.Presentation.Windows.Controls;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.DebugModule.Views
{
	/// <summary>
	/// Interaction logic for LogView.xaml
	/// </summary>
    public partial class LogView : WindowElement
	{
		public LogView(LogViewModel model)
		{
			InitializeComponent();
			DataContext = model;
		}
    }
}
