using System;
using System.Collections.Generic;
using Hayman.Client.Presentation.Widgets.ViewModels;
using System.Windows.Input;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.Presentation.Windows.ViewModels
{
    public class NavigationNode : Hayman.Client.Presentation.Widgets.ViewModels.INavigationNode
    {
        private ICommand navigateToCommand;

        public Action Action { get; set; }
        public string Name { get; set; }
        public IList<INavigationNode> Nodes { get; private set; }

        public NavigationNode(string name, Action action)
        {
            Name = name;
            Action = action;
            Nodes = new List<INavigationNode>();
        }

        #region Commands

      
        /// <summary>
        /// Gets the navigation command
        /// </summary>
        public ICommand NavigateToCommand
        {
            get
            {
                if (navigateToCommand == null)
                {
                    navigateToCommand = new DelegateCommand
                    (
                        () => NavigateTo(),
                        () => CanNavigate()
                    );
                }

                return navigateToCommand;
            }
        }

        #endregion
                       
        #region Command Actions

        /// <summary>
        /// Returns a value indcating whether the navigation command can be executed
        /// </summary>
        /// <returns></returns>
        private bool CanNavigate()
        {
            return Nodes.Count == 0;
        }

        /// <summary>
        /// Handles the navigation command
        /// </summary>
        public void NavigateTo()
        {
            Action.Invoke();
        }

        #endregion
    }
}