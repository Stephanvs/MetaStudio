using System;
using Microsoft.Practices.Composite.Presentation.Events;

namespace Hayman.Client.Infrastructure.Events
{
	public class DesktopElementChangedEvent : CompositePresentationEvent<DesktopElementChangedEventPayload>
	{
	}

	public class DesktopElementChangedEventPayload
	{
		public DesktopElementChangedEventPayload(Guid id, DesktopElementAction action)
		{
			Id = id;
			Action = action;
		}

		public Guid Id { get; set; }
		public DesktopElementAction Action { get; set; }
	}

	[Serializable]
	public enum DesktopElementAction
	{
		Added,
        Restored,
		Closed
	}
}
