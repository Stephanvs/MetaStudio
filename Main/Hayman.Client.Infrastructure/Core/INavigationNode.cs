using System;
using System.Collections.Generic;

namespace Hayman.Client.Presentation.Widgets.ViewModels
{
    public interface INavigationNode
    {
        Action Action { get; set; }
        string Name { get; set; }
        void NavigateTo();
        IList<INavigationNode> Nodes { get; }
    }
}
