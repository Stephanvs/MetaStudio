using System;
using System.Windows.Markup;
using System.Collections.Generic;
using System.Windows;

namespace Hayman.Client.Infrastructure.Core
{
    public interface IDesktop : IAddChild
    {
        Guid Id { get; }
        List<IDesktopElement> DesktopElements { get; }

        double ActualWidth { get; }
        double ActualHeight { get; }
        Visibility Visibility { get; set; }

        void AddElement(IDesktopElement element);
        void AddElement(IDesktopElement element, Point position);
        void RemoveElement(IDesktopElement element);
        
    }
}
