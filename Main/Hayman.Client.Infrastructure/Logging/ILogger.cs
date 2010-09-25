using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Logging;
using Hayman.Client.Infrastructure.Events;

namespace Hayman.Client.Infrastructure.Logging
{
	public interface ILogger
	{
		void Log(string message, Category category, Priority priority);
		ICollection<MessageLoggedEventPayload> Events { get; }
	}
}
