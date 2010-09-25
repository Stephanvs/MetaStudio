using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hayman.Client.Presentation.Widgets.ViewModels;

namespace Hayman.Client.Infrastructure.Core
{
    public interface INavigationManager
    {
        void AddNavigation(INavigationNode node);
    }
}
