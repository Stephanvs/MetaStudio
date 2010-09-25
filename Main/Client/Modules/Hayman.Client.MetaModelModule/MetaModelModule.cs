using System;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Logging;
using Hayman.Client.Infrastructure.Logging;
using Hayman.Client.Infrastructure.Core;
using System.Windows;
using Hayman.Client.MetaModelModule.Views;

namespace Hayman.Client.MetaModelModule
{
	[Module(ModuleName = "MetaModel")]
	public class MetaModelModule : IModule
	{
		private readonly IDesktopManager desktopManager;

        public MetaModelModule()
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
                var window = ServiceLocator.Current.GetInstance<MetaModelView>();
                desktopManager.Show(window, new Point(500, 500));
			});
		}
	}
}
