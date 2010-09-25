using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using Hayman.Client.Presentation.Windows.ViewModels;
using Hayman.Client.Presentation.Windows.Controls;
using Hayman.Client.Presentation.Windows.ExtensionMethods;
using System.Collections.ObjectModel;
using System.Windows;
using Hayman.Client.Infrastructure.Messaging;
using Hayman.Client.Infrastructure.Events;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics;
using Hayman.Client.Infrastructure.Core;
using Hayman.Client.Infrastructure.ViewModels;
using System.Windows.Controls;

namespace Hayman.Client.Presentation.Windows
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
                if (ep.Action == DesktopElementAction.Restored)
                    Restore(ep.Id);
			});
		}

		/// <summary>
		/// Identifies the IsDesktopCanvas dependency property.
		/// </summary>
        public static readonly DependencyProperty IsDesktopProperty =
            DependencyProperty.RegisterAttached("IsDesktop", typeof(bool), typeof(DesktopManager),
                new FrameworkPropertyMetadata((bool)false, OnIsDesktop));

        /// <summary>
        /// Identifies the IsModalContainer dependency property.
        /// </summary>
        public static readonly DependencyProperty IsIsModalContainerProperty =
            DependencyProperty.RegisterAttached("IsModalContainer", typeof(bool), typeof(DesktopManager),
                new FrameworkPropertyMetadata((bool)false,  OnIsModalContainer));

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
			Debug.Assert(d is IDesktop, "d is not an instance of IDesktop");

			IDesktop desktop = d as IDesktop;

			if (desktop != null)
			{
				ActiveDesktop = desktop;
			}
			else
			{
                Debug.WriteLine("d is not a valid IDesktop instance");
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
					activeWindowsWrapper = new ReadOnlyObservableCollection<ITrackableWindow>(Windows);
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

		public IDesktop ActiveDesktop { get; private set; }

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
					.Publish(new ActiveDesktopChangedEventPayload(ActiveDesktop as IDesktop, ActiveDesktopChangedEventAction.Activated));
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
                    .Publish(new ActiveDesktopChangedEventPayload(ActiveDesktop as IDesktop, ActiveDesktopChangedEventAction.Deactivated));
			});
		}

        public void Show(UIElement element)
        {
            Show(element, new Point());
        }

		/// <summary>
		/// Shows the given window instance
		/// </summary>
		/// <param name="element">A <see cref="WindowElement"/> instance</param>
		public void Show(UIElement element, Point position)
		{
			Debug.Assert(element is WindowElement);

			WindowElement window = element as WindowElement;

			this.InvokeAsynchronouslyInBackground(() =>
			{
                ActiveDesktop.AddElement(window, position);

				window.Parent = ActiveDesktop as Desktop;
				window.Show();

                // Add the window to the ActiveWindows collection
                if (!window.IsModal &&
                    window.DataContext is ITrackableWindow)
                {
                    this.InvokeAsynchronouslyInBackground(() =>
                    {
                        ITrackableWindow vm = window.DataContext as ITrackableWindow;
                        vm.Thumbnail = window; //window.CaptureScreen();
                        Windows.Add(vm);
                    });
                }
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
					.DesktopElements
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

        public void RegisterModalContainer(DependencyObject d)
        {
            Canvas container = d as Canvas;

            if (container != null)
            {
                WindowElement.ModalContainerPanel = container;
            }
            else
            {
                Debug.WriteLine("d is not a valid Canvas instance");
            }
        }
        
        private static void OnIsModalContainer(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d != null)
            {
                IDesktopManager service = ServiceLocator.Current.GetInstance<IDesktopManager>();

                if (service != null)
                {
                    service.RegisterModalContainer(d);
                }
            }
        }

        /// <summary>
        /// Gets the value of the IsModalContainer attached property
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool GetIsModalContainer(DependencyObject d)
        {
            return (bool)d.GetValue(IsIsModalContainerProperty);
        }

        /// <summary>
        /// Sets the value of the IsModalContainer attached property
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        public static void SetIsModalContainer(DependencyObject d, bool value)
        {
            d.SetValue(IsIsModalContainerProperty, value);
        }

        #region Widget Methods

        /// <summary>
        /// Shows the specified widget.
        /// </summary>
        /// <param name="widget">The widget.</param>
        public void Show(IWidgetViewModel widget)
        {
            Show(widget, new Point());
        }

        /// <summary>
        /// Shows the specified widget.
        /// </summary>
        /// <param name="widget">The widget.</param>
        /// <param name="position">The position.</param>
        public void Show(IWidgetViewModel widget, Point position)
        {
            this.InvokeAsynchronously(() =>
            {
                ActiveDesktop.AddElement(CreateDesktopElement<WidgetElement>(widget), position);
            });
        }

        #endregion

		#region Shortcut Methods

		/// <summary>
		/// Creates a new shortcut with the given display name and target
		/// </summary>
		/// <param name="displayName"></param>
		/// <param name="target"></param>
		public void CreateShortcut(string displayName, string target)
		{
			InternalShortcutViewModel vm = new InternalShortcutViewModel(displayName)
			{
				Target = target
			};
			
			Show(vm);
		}

		public void CreateShortcut(string displayName, Action action)
		{
			CustomShortcutViewModel vm = new CustomShortcutViewModel(displayName)
			{
				Action = action
			};

			Show(vm);
		}

		/// <summary>
		/// Shows the specified shortcut.
		/// </summary>
		/// <param name="shortcut">The shortcut.</param>
		public void Show(IShortcutViewModel shortcut)
		{
			Show(shortcut, new Point());
		}

		/// <summary>
		/// Shows the specified shortcut.
		/// </summary>
		/// <param name="shortcut">The shortcut.</param>
		/// <param name="position">The position.</param>
		public void Show(IShortcutViewModel shortcut, Point position)
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
		public void Close(IClosableViewModel vm)
		{
			Close(vm.Id);
		}
		
		/// <summary>
		/// Closes the given element with the given Id
		/// </summary>
		/// <param name="id">The id.</param>
		public void Close(Guid id)
		{
			IDesktopElement element = ActiveDesktop
				.DesktopElements
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
		public void Close(IDesktopElement element)
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
					List<IDesktopElement> elements = ActiveDesktop.DesktopElements;

					if (elements != null)
					{
                        foreach (IDesktopElement element in ActiveDesktop.DesktopElements)
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

		private static T CreateDesktopElement<T>(IClosableViewModel vm) where T : IDesktopElement, new()
		{
			return new T { DataContext = vm, Content = vm };
		}
	}
}
