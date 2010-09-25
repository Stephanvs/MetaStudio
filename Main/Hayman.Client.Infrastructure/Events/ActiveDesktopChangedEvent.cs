using System;
using Microsoft.Practices.Composite.Presentation.Events;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.Infrastructure.Events
{
	public class ActiveDesktopChangedEvent : CompositePresentationEvent<ActiveDesktopChangedEventPayload>
	{
	}
    public class ActiveDesktopChangedEventPayload
	{
		public ActiveDesktopChangedEventPayload(IDesktop desktop, ActiveDesktopChangedEventAction action)
		{
			Desktop = desktop;
			Action = action;
		}

		public IDesktop Desktop { get; private set; }
		public ActiveDesktopChangedEventAction Action { get; private set; }
	}

	public enum ActiveDesktopChangedEventAction
	{
		Activated,
		Deactivated,
		Added,
		Removed
	}
}
