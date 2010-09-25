using System;
using Hayman.Client.DebugModule.Views;
using Hayman.Client.Infrastructure.Logging;
using Microsoft.Practices.Composite.Logging;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.ServiceLocation;
using Hayman.Client.Presentation.Windows.Controls;
using Hayman.Client.Infrastructure.Core;
using System.Text.RegularExpressions;
using Hayman.Client.Presentation.Windows.ViewModels;

namespace Hayman.Client.DebugModule
{
	[Module(ModuleName = "DebugModule")]
	public class DebugModule : IModule
	{
		private readonly IDesktopManager desktopManager;
        private readonly INavigationManager navigationManager;

		public DebugModule()
		{
			desktopManager = ServiceLocator.Current.GetInstance<IDesktopManager>();
            navigationManager = ServiceLocator.Current.GetInstance<INavigationManager>();
		}

		public void Initialize()
		{
			Logger.Log(String.Format(@"Module '{0}' initializing...", GetType().Name), priority: Priority.Low);

			//CreateDesktopElements();
			CreateSampleNotificationWindow();
            CreateNavigationNodes();

			Logger.Log(String.Format(@"Module '{0}' initialized.", GetType().Name), priority: Priority.Low);
		}

		private void CreateDesktopElements()
		{
			CreateShowModulesShortcut();
			CreateEventLogShortcut();
		}

        private void CreateNavigationNodes()
        {
            var administrationNode = new NavigationNode("Administration", () => {});
            var debuggingNode = new NavigationNode("Debugging", () => {});
            var logNode = new NavigationNode("Log", () => 
                {
                    var window = ServiceLocator.Current.GetInstance<LogView>();
                    desktopManager.Show(window);
			    });

            administrationNode.Nodes.Add(debuggingNode);
            debuggingNode.Nodes.Add(logNode);

            navigationManager.AddNavigation(administrationNode);
        }

		private void CreateShowModulesShortcut()
		{
			desktopManager.CreateShortcut("Show loaded modules", () =>
			{
                var window = ServiceLocator.Current.GetInstance<ModulesListView>();
				desktopManager.Show(window);
			});
		}

		private void CreateEventLogShortcut()
		{
			desktopManager.CreateShortcut("Event log", () =>
			{
                var window = ServiceLocator.Current.GetInstance<LogView>();
                desktopManager.Show(window);
			});
		}

		private void CreateSampleNotificationWindow()
		{
			INotificationManager nm = ServiceLocator.Current.GetInstance<INotificationManager>();
			IDesktopManager dm = ServiceLocator.Current.GetInstance<IDesktopManager>();

			dm.CreateShortcut("Show Notification", () =>
			{
				nm.ShowNotification("Hello World :)", "Hello world, this is a test notification window ;-), probably also multiline because this is quite the long piece of text...");
			});

			
		}
	}
}
