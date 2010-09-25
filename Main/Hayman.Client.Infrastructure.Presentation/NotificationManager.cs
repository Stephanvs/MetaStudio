using Hayman.Client.Infrastructure.ViewModels;
using Hayman.Client.Presentation.Windows.ViewModels;
using System;
using Hayman.Client.Presentation.Windows.Controls;
using Hayman.Client.Infrastructure.Core;
using Microsoft.Practices.ServiceLocation;
using System.Windows;

namespace Hayman.Client.Presentation.Windows
{
	public class NotificationManager : INotificationManager
	{
		public void ShowNotification(string title, string message)
		{
			var model = new NotificationViewModel(title, message);
			ShowNotification(model);
		}

		public void ShowNotification(string title, string message, Action action)
		{
			throw new NotImplementedException();
		}

		public void ShowNotification(INotificationViewModel model)
		{
			var window = new SimpleNotificationWindow() { DataContext = model };
            IDesktopManager dm = ServiceLocator.Current.GetInstance<IDesktopManager>();

            var position = new Point()
            {
                X = dm.ActiveDesktop.ActualWidth - window.Width - window.BorderThickness.Right - window.Padding.Right,
                Y = dm.ActiveDesktop.ActualHeight - window.Height - window.BorderThickness.Bottom - window.Padding.Bottom
            };

            window.WindowStartupLocation = WindowElementStartupLocation.Manual;

            dm.Show(window as UIElement, position);
		}
	}
}
