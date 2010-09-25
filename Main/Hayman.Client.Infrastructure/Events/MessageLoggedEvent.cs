using System;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Logging;

namespace Hayman.Client.Infrastructure.Events
{
	public class MessageLoggedEvent : CompositePresentationEvent<MessageLoggedEventPayload>
	{
	}

	public class MessageLoggedEventPayload
	{
		public MessageLoggedEventPayload(string message, Category categroy = Category.Debug, Priority priority = Priority.None)
		{
			Message = message;
			OccuredAt = DateTime.Now;
			Category = categroy;
			Priority = priority;
		}

		public string Message { get; set; }
		public DateTime OccuredAt { get; set; }
		public Category Category { get; set; }
		public Priority Priority { get; set; }
	}
}
