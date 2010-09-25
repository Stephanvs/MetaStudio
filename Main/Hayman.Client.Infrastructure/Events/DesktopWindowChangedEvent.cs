using System;
using Microsoft.Practices.Composite.Presentation.Events;

namespace Hayman.Client.Infrastructure.Events
{
	public class DesktopWindowChangedEvent : CompositePresentationEvent<DesktopWindowChangedEventPayload>
	{

	}

	public class DesktopWindowChangedEventPayload
	{
		public DesktopWindowChangedEventPayload(DesktopWindowState windowState)
		{
			WindowState = windowState;
		}

		public DesktopWindowState WindowState { get; private set; }
	}

	public enum DesktopWindowState
	{
		Maximized,
		Minimized,
		Closed,
		Opened
	}
}