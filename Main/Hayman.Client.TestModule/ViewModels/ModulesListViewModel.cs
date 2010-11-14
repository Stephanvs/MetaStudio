using System;
using System.Collections.Generic;
using Microsoft.Practices.Composite.Modularity;
using Hayman.Client.Presentation.Windows.ViewModels;

namespace Hayman.Client.DebugModule.ViewModels
{
    public class ModulesListViewModel : WorkspaceWindowViewModel
	{
		IModuleCatalog moduleCatalog;

		public ModulesListViewModel(IModuleCatalog moduleCatalog) : base("Modules")
		{
			this.moduleCatalog = moduleCatalog;
		}

		public IEnumerable<ModuleInfo> Modules
		{
			get
			{
				return moduleCatalog.Modules;
			}
		}
	}
}
