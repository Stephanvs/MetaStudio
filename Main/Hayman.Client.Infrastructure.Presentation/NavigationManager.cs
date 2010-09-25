using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hayman.Client.Infrastructure.Core;
using Hayman.Client.Presentation.Widgets.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Hayman.Client.Presentation.Windows.ViewModels;

namespace Hayman.Client.Presentation.Windows
{
    public class NavigationManager : INavigationManager
    {
        private NavigatorWidgetViewModel viewModel;

        public NavigationManager()
        {
            viewModel = new NavigatorWidgetViewModel();
            ServiceLocator.Current.GetInstance<IDesktopManager>().Show(viewModel);   
        }

        public void AddNavigation(INavigationNode node)
        {
            var existingNode = viewModel.Nodes.Where(n => n.Name == node.Name).FirstOrDefault();

            if (existingNode != null)
            {
                AddNavigationTo(node, existingNode);
            }
            else
            {
                viewModel.Nodes.Add(node);
            }
        }

        public void AddNavigationTo(INavigationNode node, INavigationNode to)
        {
            var existingNode = to.Nodes.Where(n => n.Name == node.Name).FirstOrDefault();

            if (existingNode != null)
            {
                AddNavigationTo(node, existingNode);
            }
            else
            {
                to.Nodes.Add(node);
            }
        }
    }
}
