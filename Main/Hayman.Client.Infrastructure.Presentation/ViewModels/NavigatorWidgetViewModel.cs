using System;
using Hayman.Client.Presentation.Windows.ViewModels;
using System.Windows.Input;
using Hayman.Client.Infrastructure.Core;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using Hayman.Client.Presentation.Widgets.ViewModels;

namespace Hayman.Client.Presentation.Windows.ViewModels
{
    /// <summary>
    /// Navigator Widget ViewModel
    /// </summary>
    /// <remarks>
    /// http://www.codeproject.com/KB/WPF/TreeViewWithViewModel.aspx
    /// </remarks>
    public sealed class NavigatorWidgetViewModel : WidgetViewModel
    {
        //private ICommand createWidgetCommand;
        //private ICommand navigateToCommand;

        public NavigatorWidgetViewModel() : base("Navigator")
        {
            Nodes = new List<INavigationNode>();
        }

        public IList<INavigationNode> Nodes { get; private set; }

        /// <summary>
        /// Gets the widget description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description
        {
            get { return "Navigate and search application options"; }
            set { }
        }

        //#region Commands

        ///// <summary>
        ///// Gets the create widget command.
        ///// </summary>
        ///// <value>The create widget command.</value>
        //public ICommand CreateWidgetCommand
        //{
        //    get
        //    {
        //        if (createWidgetCommand == null)
        //        {
        //            createWidgetCommand = new DelegateCommand(() => OnCreateWidget());
        //        }

        //        return createWidgetCommand;
        //    }
        //}

        ///// <summary>
        ///// Gets the navigation command
        ///// </summary>
        //public ICommand NavigateToCommand
        //{
        //    get
        //    {
        //        if (navigateToCommand == null)
        //        {
        //            navigateToCommand = new DelegateCommand
        //            (
        //                () => OnNavigateTo(),
        //                () => CanNavigate()
        //            );
        //        }

        //        return navigateToCommand;
        //    }
        //}

        //#endregion
                       
        //#region Command Actions

        ///// <summary>
        ///// Handles the create widget command
        ///// </summary>
        //private static void OnCreateWidget()
        //{
        //    ServiceLocator.Current.GetInstance<IDesktopManager>().Show(new NavigatorWidgetViewModel());
        //}

        ///// <summary>
        ///// Returns a value indcating whether the navigation command can be executed
        ///// </summary>
        ///// <returns></returns>
        //private static bool CanNavigate()
        //{
        //    return true;
        //    //return this.matchingOptions != null && this.matchingOptions.Count == 1;
        //}

        ///// <summary>
        ///// Handles the navigation command
        ///// </summary>
        //private static void OnNavigateTo()
        //{
            
        //}

        //#endregion
    }
}
