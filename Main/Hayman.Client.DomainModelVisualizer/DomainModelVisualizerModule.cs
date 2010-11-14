using System;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Logging;
using Hayman.Client.DomainModelVisualizerModule.Views;
using Hayman.Client.Infrastructure.Logging;
using Hayman.Client.Infrastructure.Core;
using System.Windows;

namespace Hayman.Client.DomainModelVisualizerModule
{
	[Module(ModuleName = "DomainModelVisualizer")]
	public class DomainModelVisualizerModule : IModule
	{
		private readonly IDesktopManager desktopManager;

		public DomainModelVisualizerModule()
		{
			desktopManager = ServiceLocator.Current.GetInstance<IDesktopManager>();
		}

		public void Initialize()
		{
			Logger.Log(String.Format(@"Module '{0}' initializing...", GetType().Name), Category.Info, Priority.Low);

			CreateDesktopShortcuts();

			Logger.Log(String.Format(@"Module '{0}' initialized.", GetType().Name), Category.Info, Priority.Low);
		}

		private void CreateDesktopShortcuts()
		{
			desktopManager.CreateShortcut("Metamodel", () =>
			{
                var window = ServiceLocator.Current.GetInstance<DomainVisualizerView>();
				desktopManager.Show(window, new Point(500, 500));
			});
		}
	}
}
