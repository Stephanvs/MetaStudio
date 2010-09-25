using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hayman.Client.Infrastructure.Events;
using Hayman.Client.Infrastructure.Logging;
using Microsoft.Practices.Composite.Logging;
using Hayman.Client.Infrastructure.Messaging;

namespace Hayman.Shell.Logging
{
	public class CompositeTextLogger : ILogger, ILoggerFacade
	{
		private readonly ICollection<MessageLoggedEventPayload> events = new Collection<MessageLoggedEventPayload>();
		
		public void Log(string message, Category category, Priority priority)
		{
			var msg = new MessageLoggedEventPayload(message, category, priority);
			Events.Add(msg);

			Channel<MessageLoggedEvent, MessageLoggedEventPayload>.Publish(msg);
		}

		public ICollection<MessageLoggedEventPayload> Events
		{
			get { return events; }
		}
	}
}
