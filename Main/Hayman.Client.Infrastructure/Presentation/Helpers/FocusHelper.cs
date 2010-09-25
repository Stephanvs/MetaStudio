using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Diagnostics;

namespace Hayman.Client.Infrastructure.Presentation.Helpers
{
	public static class FocusHelper
	{
		/// <summary>
		/// Set focus to UIElement
		/// </summary>
		/// <param name="element">The element to set focus on</param>
		public static void Focus(UIElement element)
		{
			//Focus in a callback to run on another thread, ensuring the main 
			//UI thread is initialized by the time focus is set
			ThreadPool.QueueUserWorkItem(theElement =>
			{
				UIElement elem = (UIElement)theElement;
				elem.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
																		{
																			elem.Focus();
																			Keyboard.Focus(elem);
																		}));
			}, element);
		}

		public static void MoveFocus(UIElement element, FocusNavigationDirection direction)
		{
			//Focus in a callback to run on another thread, ensuring the main 
			//UI thread is initialized by the time focus is set
			ThreadPool.QueueUserWorkItem(theElement =>
			{
				UIElement elem = (UIElement)theElement;
				elem.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
																	  {
																		  elem.Focus();
																		  Keyboard.Focus(elem);
																		  elem.MoveFocus(new TraversalRequest(direction));
																	  }));
			}, element);
		}

	}
}
