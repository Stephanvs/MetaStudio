using System;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Composite.Logging;

namespace Hayman.Client.Infrastructure.Logging
{
	public static class Logger
	{
		private static ILogger logger = ServiceLocator.Current.GetInstance<ILogger>();

		public static void Log(string message, Category category = Category.Info, Priority priority = Priority.None)
		{
			logger.Log(message, category, priority);
		}
	}
}
