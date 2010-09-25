using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using Hayman.Client.Infrastructure.Presentation.ViewModels;
using Hayman.Client.Infrastructure.Presentation.Windows.Controls;
using Hayman.Client.Infrastructure.Presentation.ExtensionMethods;
using System.Collections.ObjectModel;
using System.Windows;
using Hayman.Client.Infrastructure.Messaging;
using Hayman.Client.Infrastructure.Events;
using Hayman.Client.Infrastructure.Presentation.Core;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Hayman.Client.Infrastructure.Presentation
{
	public sealed class DesktopManager : DispatcherObject, IDesktopManager
	{
		public DesktopManager()
		{
			Channel<DesktopElementChangedEvent, DesktopElementChangedEventPayload>
				.Subscribe(ep =>
			{
				if (ep.Action == DesktopElementAction.Closed)
					Close(ep.Id);
			});
		}

		/// <summary>
		/// Identifies the IsDesktopCanvas dependency property.
		/// </summary>
		public static readonly DependencyProperty IsDesktopProperty =
			DependencyProperty.RegisterAttached("IsDesktop", typeof(bool), typeof(DesktopManager),
				new FrameworkPropertyMetadata((bool)false, OnIsDesktop));

		/// <summary>
		/// Gets the value of the IsDesktopCanvas attached property
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public static bool GetIsDesktop(DependencyObject d)
		{
			return (bool)d.GetValue(IsDesktopProperty);
		}

		/// <summary>
		/// Sets the value of the IsDesktopCanvas attached property
		/// </summary>
		/// <param name="d"></param>
		/// <param name="value"></param>
		public static void SetIsDesktop(DependencyObject d, bool value)
		{
			d.SetValue(IsDesktopProperty, value);
		}

		private static void OnIsDesktop(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d != null)
			{
				IDesktopManager service = ServiceLocator.Current.GetInstance<IDesktopManager>();
				if (service != null)
					service.RegisterDesktop(d);
			}
		}

		public void RegisterDesktop(DependencyObject d)
		{
			Debug.Assert(d != null, "d");
			Debug.Assert(d is Desktop, "d is not an instance of Desktop");

			Desktop desktop = d as Desktop;

			if (desktop != null)
			{
				ActiveDesktop = desktop;
			}
			else
			{
				Debug.WriteLine("d is not a valid Desktop instance");
			}
		}

		private ReadOnlyObservableCollection<ITrackableWindow> activeWindowsWrapper;
		private ObservableCollection<ITrackableWindow> activeWindows;
		private bool hasBeenActivated;

		public Guid Id
		{
			get
			{
				if (ActiveDesktop != null)
				{
					return ActiveDesktop.Id;
				}

				return Guid.Empty;
			}
		}

		public ReadOnlyObservableCollection<ITrackableWindow> ActiveWindows
		{
			get
			{
				if (activeWindowsWrapper == null)
				{
					activeWindowsWrapper = new ReadOnlyObservableCollection<ITrackableWindow>(this.Windows);
				}

				return activeWindowsWrapper;
			}
		}

		public ObservableCollection<ITrackableWindow> Windows
		{
			get
			{
				if (activeWindows == null)
				{
					activeWindows = new ObservableCollection<ITrackableWindow>();
				}

				return activeWindows;
			}
		}

		public Desktop ActiveDesktop { get; private set; }

		/// <summary>
		/// Activates the desktop instance
		/// </summary>
		public void Activate()
		{
			this.InvokeAsynchronouslyInBackground(() =>
			{
				if (!hasBeenActivated)
				{
					//this.Load();
					hasBeenActivated = true;
				}

				ActiveDesktop.Visibility = Visibility.Visible;

				Channel<ActiveDesktopChangedEvent, ActiveDesktopChangedEventPayload>
					.Publish(new ActiveDesktopChangedEventPayload(ActiveDesktop, ActiveDesktopChangedEventAction.Activated));
			});
		}

		/// <summary>
		/// Deactivates the desktop instance
		/// </summary>
		public void Deactivate()
		{
			this.Invoke(() =>
			{
				ActiveDesktop.Visibility = Visibility.Hidden;

				Channel<ActiveDesktopChangedEvent, ActiveDesktopChangedEventPayload>
					.Publish(new ActiveDesktopChangedEventPayload(ActiveDesktop, ActiveDesktopChangedEventAction.Deactivated));
			});
		}

		/// <summary>
		/// Shows the given window instance
		/// </summary>
		/// <param name="element">A <see cref="WindowElement"/> instance</param>
		public void Show(UIElement element)
		{
			Debug.Assert(element is WindowElement);

			WindowElement window = element as WindowElement;

			this.InvokeAsynchronouslyInBackground(() =>
			{
				ActiveDesktop.AddElement(window);
				window.Parent = ActiveDesktop;
				window.Show();

				//// Add the window to the ActiveWindows collection
				//if (!window.IsModal &&
				//	window.DataContext is ITrackableWindow)
				//{
				//	this.InvokeAsynchronouslyInBackground(
				//		delegate
				//		{
				//			ITrackableWindow vm = window.DataContext as ITrackableWindow;
				//			vm.Thumbnail = window.CaptureScreen();

				//			this.Windows.Add(vm);
				//		});
				//}
			});
		}

		/// <summary>
		/// Restores the window with the given Id
		/// </summary>
		/// <param name="id"></param>
		public void Restore(Guid id)
		{
			this.InvokeAsynchronouslyInBackground(() =>
			{
				WindowElement window = ActiveDesktop
					.Children
					.OfType<WindowElement>()
					.Where(wc => wc.Id == id)
					.SingleOrDefault();

				if (window != null)
				{
					window.WindowState = WindowState.Normal;
					window.Activate();
				}
			});
		}

		#region Shortcut Methods

		/// <summary>
		/// Creates a new shortcut with the given display name and target
		/// </summary>
		/// <param name="displayName"></param>
		/// <param name="target"></param>
		public void CreateShortcut(string displayName, string target)
		{
			InternalShortcutViewModel vm = new InternalShortcutViewModel
			{
				DisplayName = displayName,
				Target      = target
			};
			
			Show(vm);
		}

		public void CreateShortcut(string displayName, Action action)
		{
			CustomShortcutViewModel vm = new CustomShortcutViewModel
			{
				Action = action,
				DisplayName = displayName
			};

			Show(vm);
		}

		/// <summary>
		/// Shows the specified shortcut.
		/// </summary>
		/// <param name="shortcut">The shortcut.</param>
		public void Show(ShortcutViewModelBase shortcut)
		{
			Show(shortcut, new Point());
		}

		/// <summary>
		/// Shows the specified shortcut.
		/// </summary>
		/// <param name="shortcut">The shortcut.</param>
		/// <param name="position">The position.</param>
		public void Show(ShortcutViewModelBase shortcut, Point position)
		{
			this.InvokeAsynchronouslyInBackground(() =>
			{
				ActiveDesktop.AddElement(CreateDesktopElement<ShortcutElement>(shortcut), position);
			});
		}

		#endregion

		#region Closing

		/// <summary>
		/// Closes the given element with the given Id
		/// </summary>
		/// <param name="id">The id.</param>
		public void Close(ClosableViewModel vm)
		{
			Close(vm.Id);
		}
		
		/// <summary>
		/// Closes the given element with the given Id
		/// </summary>
		/// <param name="id">The id.</param>
		public void Close(Guid id)
		{
			DesktopElement element = ActiveDesktop
				.Children
				.OfType<DesktopElement>()
				.Where(x => x.Id == id)
				.FirstOrDefault();

			if (element != null)
			{
				Close(element);
			}
		}

		/// <summary>
		/// Closes the given element
		/// </summary>
		/// <param name="element">The desktop element</param>
		public void Close(DesktopElement element)
		{
			Debug.Assert(element != null, "element");

			this.Invoke(() =>
				{
					if (element is WindowElement)
					{
						WindowElement window = element as WindowElement;

						if (window.DataContext is ITrackableWindow)
						{
							Windows.Remove(Windows.Where(wnd => wnd.Id == window.Id).SingleOrDefault());
						}
					}

					ActiveDesktop.RemoveElement(element);

					element.Close();
					element = null;
				});
		}

		/// <summary>
		/// Closes all
		/// </summary>
		public void CloseAll()
		{
			this.Invoke(() =>
				{
					List<DesktopElement> elements = ActiveDesktop.Children.OfType<DesktopElement>().ToList();

					if (elements != null)
					{
						foreach (DesktopElement element in elements)
						{
							Close(element);
						}

						elements.Clear();
						elements = null;

						hasBeenActivated = false;
					}
				});
		}

		#endregion

		private T CreateDesktopElement<T>(ClosableViewModel vm) where T : DesktopElement, new()
		{
			return new T { DataContext = vm, Content = vm };
		}
	}
}
