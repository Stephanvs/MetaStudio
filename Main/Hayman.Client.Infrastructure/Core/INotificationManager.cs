using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hayman.Client.Infrastructure.ViewModels;

namespace Hayman.Client.Infrastructure.Core
{
	public interface INotificationManager
	{
		void ShowNotification(string title, string message);
		void ShowNotification(string title, string message, Action action);
		void ShowNotification(INotificationViewModel model);
	}
}
