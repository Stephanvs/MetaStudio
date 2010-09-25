using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.UnityExtensions;
using Microsoft.Practices.Unity;
using System;
using System.Windows;
using Hayman.Shell.ViewModels;
using Hayman.Shell.Views;
using Microsoft.Practices.Composite.Presentation.Regions;
using Hayman.Shell.Logging;
using Hayman.Client.Infrastructure.Logging;
using Hayman.Client.Presentation.Windows;
using Hayman.Client.Infrastructure.RegionAdapters;
using Hayman.Client.Presentation.Windows.Controls;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Shell
{
	public class Bootstrapper : UnityBootstrapper
	{
		protected override DependencyObject CreateShell()
		{
			ShellViewModel vm = Container.Resolve<ShellViewModel>();
            
			IShellView view = vm.View as IShellView;
			view.ShowView();

            return view as DependencyObject;
		}

        protected override IModuleCatalog CreateModuleCatalog()
		{
			return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();

			Container.RegisterType<ILogger, CompositeTextLogger>(new ContainerControlledLifetimeManager());
			Container.RegisterType<IDesktopManager, DesktopManager>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INavigationManager, NavigationManager>(new ContainerControlledLifetimeManager());
			Container.RegisterType<INotificationManager, NotificationManager>(new ContainerControlledLifetimeManager());
			Container.RegisterType<IShellView, ShellView>(new ContainerControlledLifetimeManager());
		}

		protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
		{
			RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(Desktop), Container.Resolve<DesktopRegionAdapter>());
			return mappings;
		}
	}
}
