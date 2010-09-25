using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Hayman.Client.Infrastructure.Presentation.Core;
using Hayman.Client.Infrastructure.Presentation.ExtensionMethods;
using Hayman.Client.Infrastructure.Presentation.Helpers;

namespace Hayman.Client.Infrastructure.Presentation.Windows.Controls
{
	/// <summary>
	/// Provides the ability to create, configure, show, and manage the lifetime of windows
	/// </summary>
	[TemplatePart(Name = WindowElement.PART_MinimizeButton, Type = typeof(ButtonBase))]
	[TemplatePart(Name = WindowElement.PART_MaximizeButton, Type = typeof(ButtonBase))]
	[TemplatePart(Name = WindowElement.PART_CloseButton, Type = typeof(ButtonBase))]
	public class WindowElement : DesktopElement
	{
		#region Constants

		private const string PART_MaximizeButton = "PART_MaximizeButton";
		private const string PART_MinimizeButton = "PART_MinimizeButton";
		private const string PART_CloseButton = "PART_CloseButton";
		private const int MaximizeMargin = 20;

		#endregion

		#region Dependency Properties

		/// <summary>
		/// Identifies the Title dependency property.
		/// </summary>
		public static readonly DependencyProperty TitleProperty =
			DependencyProperty.Register("Title", typeof(String), typeof(WindowElement),
				new FrameworkPropertyMetadata(String.Empty));

		/// <summary>
		/// Identifies the IsModal dependency property.
		/// </summary>
		public static readonly DependencyProperty IsModalProperty =
			DependencyProperty.Register("IsModal", typeof(bool), typeof(WindowElement),
				new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure));

		/// <summary>
		/// Identifies the WindowStartupLocation dependency property.
		/// </summary>
		public static readonly DependencyProperty WindowStartupLocationProperty =
			DependencyProperty.Register("WindowStartupLocation", typeof(WindowElementStartupLocation), typeof(WindowElement),
				new FrameworkPropertyMetadata(WindowElementStartupLocation.WindowsDefaultLocation, FrameworkPropertyMetadataOptions.AffectsArrange));

		/// <summary>
		/// Identifies the WindowState dependency property.
		/// </summary>
		public static readonly DependencyProperty WindowStateProperty =
			DependencyProperty.Register("WindowState", typeof(WindowState), typeof(WindowElement),
				new FrameworkPropertyMetadata(WindowState.Normal));

		/// <summary>
		/// Identifies the ShowCloseButton dependency property.
		/// </summary>
		public static readonly DependencyProperty ShowCloseButtonProperty =
			DependencyProperty.Register("ShowCloseButton", typeof(bool), typeof(WindowElement),
				new FrameworkPropertyMetadata(true));

		/// <summary>
		/// Identifies the ShowMaximizeButton dependency property.
		/// </summary>
		public static readonly DependencyProperty ShowMaximizeButtonProperty =
			DependencyProperty.Register("ShowMaximizeButton", typeof(bool), typeof(WindowElement),
				new FrameworkPropertyMetadata(true));

		/// <summary>
		/// Identifies the ShowMinimizeButton dependency property.
		/// </summary>
		public static readonly DependencyProperty ShowMinimizeButtonProperty =
			DependencyProperty.Register("ShowMinimizeButton", typeof(bool), typeof(WindowElement),
				new FrameworkPropertyMetadata(true));

		/// <summary>
		/// Identifies the DialogResult dependency property.
		/// </summary>
		public static readonly DependencyProperty DialogResultProperty =
			DependencyProperty.Register("DialogResult", typeof(DialogResult), typeof(WindowElement),
				new FrameworkPropertyMetadata(DialogResult.None));

		#endregion

		#region Routed Commands

		/// <summary>
		/// Close window command
		/// </summary>
		public static RoutedCommand CloseCommand;

		/// <summary>
		/// Maximize window command
		/// </summary>
		public static RoutedCommand MaximizeCommand;

		/// <summary>
		/// Minimize window command
		/// </summary>
		public static RoutedCommand MinimizeCommand;

		#endregion

		#region Static Routed Events

		/// <summary>
		/// Occurs when the window as about to close.
		/// </summary>
		public static readonly RoutedEvent CreatedEvent;

		/// <summary>
		/// Occurs when the window as about to create.
		/// </summary>
		public static readonly RoutedEvent ClosedEvent;

		/// <summary>
		/// Occurs when the window's <see cref="WindowElement.WindowState"/> property changes.
		/// </summary>
		public static readonly RoutedEvent StateChangedEvent;

		#endregion

		#region Static members

		/// <summary>
		/// Container panel for modal windows
		/// </summary>
		public static Canvas ModalContainerPanel;

		#endregion

		#region Static Constructor

		/// <summary>
		/// Initializes the <see cref="WindowElement"/> class.
		/// </summary>
		static WindowElement()
		{
			WindowElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowElement),
				new FrameworkPropertyMetadata(typeof(WindowElement)));

			WindowElement.CloseCommand = new RoutedCommand("Close", typeof(WindowElement));
			WindowElement.MaximizeCommand = new RoutedCommand("Maximize", typeof(WindowElement));
			WindowElement.MinimizeCommand = new RoutedCommand("Minimize", typeof(WindowElement));

			WindowElement.CreatedEvent = EventManager.RegisterRoutedEvent("Created", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WindowElement));
			WindowElement.ClosedEvent = EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WindowElement));
			WindowElement.StateChangedEvent = EventManager.RegisterRoutedEvent("StateChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WindowElement));

			KeyGesture keyClose = new KeyGesture(Key.F4, ModifierKeys.Alt | ModifierKeys.Control);
			CloseCommand.InputGestures.Add(keyClose);

			FocusManager.IsFocusScopeProperty.OverrideMetadata(
				typeof(WindowElement), new FrameworkPropertyMetadata(true));

			KeyboardNavigation.IsTabStopProperty.OverrideMetadata(typeof(WindowElement),
				new FrameworkPropertyMetadata(false));

			KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(
				typeof(WindowElement), new FrameworkPropertyMetadata(KeyboardNavigationMode.Local));

			KeyboardNavigation.TabNavigationProperty.OverrideMetadata(
				typeof(WindowElement), new FrameworkPropertyMetadata(KeyboardNavigationMode.Cycle));

			KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(
				typeof(WindowElement), new FrameworkPropertyMetadata(KeyboardNavigationMode.Once));
		}

		#endregion

		#region Events

		/// <summary>
		/// Occurs when the window is about to create.
		/// </summary>
		public event RoutedEventHandler Created
		{
			add { base.AddHandler(WindowElement.CreatedEvent, value); }
			remove { base.RemoveHandler(WindowElement.CreatedEvent, value); }
		}

		/// <summary>
		/// Occurs when the window is about to close.
		/// </summary>
		public event RoutedEventHandler Closed
		{
			add { base.AddHandler(WindowElement.ClosedEvent, value); }
			remove { base.RemoveHandler(WindowElement.ClosedEvent, value); }
		}

		/// <summary>
		/// Occurs when the window's <see cref="WindowElement.WindowState"/> property changes.
		/// </summary>
		public event RoutedEventHandler StateChanged
		{
			add { base.AddHandler(WindowElement.StateChangedEvent, value); }
			remove { base.RemoveHandler(WindowElement.StateChangedEvent, value); }
		}

		#endregion

		#region Fields

		private Panel parent;
		private bool isInitialized;
		private bool isShowed;
		private DispatcherFrame dispatcherFrame;

		#endregion

		#region Properties

		/// <summary>
		/// Gets the window parent control
		/// </summary>
		public new Panel Parent
		{
			get { return this.parent; }
			set { this.parent = value; }
		}

		/// <summary>
		/// Gets or sets a window's title. This is a dependency property. 
		/// </summary>
		public String Title
		{
			get { return (String)base.GetValue(WindowElement.TitleProperty); }
			set { base.SetValue(WindowElement.TitleProperty, value); }
		}

		/// <summary>
		/// Gets a value that indicates whether the window is modal. This is a dependency property. 
		/// </summary>
		public bool IsModal
		{
			get { return (bool)base.GetValue(IsModalProperty); }
			set
			{
				base.SetValue(IsModalProperty, value);

				if (value)
				{
					LockKeyboardNavigation();
					LockMouseOutside();
				}
				else
				{
					LockMouseOutside(false);
				}
			}
		}

		/// <summary>
		/// Gets the dialog result
		/// </summary>
		public DialogResult DialogResult
		{
			get { return (DialogResult)base.GetValue(DialogResultProperty); }
			set { base.SetValue(DialogResultProperty, value); }
		}

		/// <summary>
		/// Gets or sets the position of the window when first shown.
		/// </summary>
		public WindowElementStartupLocation WindowStartupLocation
		{
			get { return (WindowElementStartupLocation)base.GetValue(WindowStartupLocationProperty); }
			set { base.SetValue(WindowStartupLocationProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value that indicates whether a window is restored, minimized, or maximized. 
		/// This is a dependency property.
		/// </summary>
		/// <value>A <see cref="WindowState"/> that determines whether a window is restored, minimized, or maximized. The default is Normal (restored).</value>
		public WindowState WindowState
		{
			get { return (WindowState)base.GetValue(WindowStateProperty); }
			set
			{
				if ((WindowState)this.GetValue(WindowStateProperty) != value)
				{
					SaveState(value);
					base.SetValue(WindowStateProperty, value);
					RaiseStateChangedEvent();
				}
			}
		}

		/// <summary>
		/// Gets a value that indicates whether the close button is visible. 
		/// This is a dependency property. 
		/// </summary>
		public bool ShowCloseButton
		{
			get { return (bool)base.GetValue(ShowCloseButtonProperty); }
			set { base.SetValue(ShowCloseButtonProperty, value); }
		}

		/// <summary>
		/// Gets a value that indicates whether the maximize button is visible. 
		/// This is a dependency property. 
		/// </summary>
		public bool ShowMaximizeButton
		{
			get { return (bool)base.GetValue(ShowMaximizeButtonProperty); }
			set { base.SetValue(ShowMaximizeButtonProperty, value); }
		}

		/// <summary>
		/// Gets a value that indicates whether the minimize button is visible. 
		/// This is a dependency property. 
		/// </summary>
		public bool ShowMinimizeButton
		{
			get { return (bool)base.GetValue(ShowMinimizeButtonProperty); }
			set { base.SetValue(ShowMinimizeButtonProperty, value); }
		}

		/// <summary>
		/// Gets a value indicating whether the element can be dragged.
		/// </summary>
		/// <value><c>true</c> if this instance can drag; otherwise, <c>false</c>.</value>
		public override bool CanDrag
		{
			get { return (bool)base.GetValue(CanDragProperty) && WindowState == WindowState.Normal; }
			set { base.SetValue(CanDragProperty, value); }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="WindowElement"/> class.
		/// </summary>
		public WindowElement()
			: base()
		{
			CommandBinding bindingClose = new CommandBinding(WindowElement.CloseCommand, new ExecutedRoutedEventHandler(OnCloseWindow));
			this.CommandBindings.Add(bindingClose);

			CommandBinding bindingMaximize = new CommandBinding(WindowElement.MaximizeCommand, new ExecutedRoutedEventHandler(OnMaximizeWindow));
			this.CommandBindings.Add(bindingMaximize);

			CommandBinding bindingMinimize = new CommandBinding(WindowElement.MinimizeCommand, new ExecutedRoutedEventHandler(OnMinimizeWindow));
			this.CommandBindings.Add(bindingMinimize);
		}

		#endregion

		#region Methods

		/// <summary>
		/// Shows the window
		/// </summary>
		public void Show()
		{
			if (!isShowed)
			{
				RaiseCreatedEvent();
				isShowed = true;
				FocusHelper.MoveFocus(this, FocusNavigationDirection.Next);
			}

			OnActivated();
		}

		/// <summary>
		/// Shows the window as a modal dialog
		/// </summary>
		public DialogResult ShowDialog()
		{
			WindowElement.ModalContainerPanel.Children.Add(this);
			Parent = WindowElement.ModalContainerPanel;

			IsModal = true;

			Show();

			// Set DialogResult default value
			DialogResult = DialogResult.None;

			try
			{
				// Push the current thread to a modal state
				ComponentDispatcher.PushModal();

				// Create a DispatcherFrame instance and use it to start a message loop
				dispatcherFrame = new DispatcherFrame();
				Dispatcher.PushFrame(dispatcherFrame);
			}
			finally
			{
				// Pop the current thread from modal state
				ComponentDispatcher.PopModal();
			}

			return DialogResult;
		}

		/// <summary>
		/// Manually closes a <see cref="WindowElement"/>.
		/// </summary>
		public override void Close()
		{
			if (Parent != null && IsModal)
			{
				WindowElement.ModalContainerPanel.Children.Remove(this);
			}

			LockMouseOutside(false);
			RaiseCloseEvent();

			// Clean up
			Parent = null;
			isInitialized = false;
			isShowed = false;
			dispatcherFrame = null;

			CommandBindings.Clear();

			base.Close();
		}

		/// <summary>
		/// Hides the Window
		/// </summary>
		public void Hide()
		{
			Visibility = Visibility.Collapsed;

			if (IsModal && dispatcherFrame != null)
			{
				dispatcherFrame.Continue = false;
				dispatcherFrame = null;
			}
		}

		#endregion

		#region Protected Methods

		/// <summary>
		/// Raises the <see cref="E:System.Windows.FrameworkElement.SizeChanged"/> event, using the specified information as part of the eventual event data.
		/// </summary>
		/// <param name="sizeInfo">Details of the old and new size involved in the change.</param>
		protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
		{
			base.OnRenderSizeChanged(sizeInfo);

			if (!isInitialized)
			{
				RefreshCalculatedVisualProperties();

				if (WindowState != WindowState.Normal)
				{
					SaveState(WindowState);
				}

				isInitialized = true;
			}
		}

		/// <summary>
		/// Invoked when an unhandled <see cref="E:System.Windows.Input.Keyboard.GotKeyboardFocus"/> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Windows.Input.KeyboardFocusChangedEventArgs"/> that contains the event data.</param>
		protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
		{
			base.OnGotKeyboardFocus(e);
			OnActivated();
		}

		#endregion

		#region Command Execution Methods

		protected virtual void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
		{
			if (IsModal)
			{
				Hide();
			}
			else
			{
				Close();
			}
		}

		protected virtual void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
		{
			if (WindowState != WindowState.Maximized)
			{
				WindowState = WindowState.Maximized;
			}
			else
			{
				WindowState = WindowState.Normal;
			}
		}

		protected virtual void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
		{
			if (WindowState != WindowState.Minimized)
			{
				WindowState = WindowState.Minimized;
			}
			else
			{
				WindowState = WindowState.Normal;
			}
		}

		#endregion

		#region Event Raising Methods

		private void RaiseCreatedEvent()
		{
			RoutedEventArgs e = new RoutedEventArgs(WindowElement.CreatedEvent, this);
			RaiseEvent(e);
		}

		private void RaiseCloseEvent()
		{
			RoutedEventArgs newEventArgs = new RoutedEventArgs(WindowElement.ClosedEvent, this);
			RaiseEvent(newEventArgs);
		}

		private void RaiseStateChangedEvent()
		{
			RoutedEventArgs newEventArgs = new RoutedEventArgs(WindowElement.StateChangedEvent, this);
			RaiseEvent(newEventArgs);
		}

		#endregion

		#region Private Methods

		private void RefreshCalculatedVisualProperties()
		{
			switch (WindowStartupLocation)
			{
				case WindowElementStartupLocation.CenterParent:
					if (Parent != null)
					{
						this.Move(
							(Parent.ActualWidth - ActualWidth) / 2,
							(Parent.ActualHeight - ActualHeight) / 2);
					}
					break;

				case WindowElementStartupLocation.Manual:
					break;

				case WindowElementStartupLocation.WindowsDefaultLocation:
					this.Move(5, 5);
					break;
			}
		}

		private void LockKeyboardNavigation()
		{
			KeyboardNavigation.SetTabNavigation(this, KeyboardNavigationMode.Cycle);
			KeyboardNavigation.SetDirectionalNavigation(this, KeyboardNavigationMode.None);
			KeyboardNavigation.SetControlTabNavigation(this, KeyboardNavigationMode.None);
		}

		private void LockMouseOutside()
		{
			LockMouseOutside(true);
		}

		private void LockMouseOutside(bool doLock)
		{
			if (doLock)
			{
				Debug.Assert(WindowElement.ModalContainerPanel != null);

				Binding wBinding = new Binding("ActualWidth");
				Binding hBinding = new Binding("ActualHeight");
				Canvas fence = new Canvas();

				wBinding.Source = WindowElement.ModalContainerPanel;
				hBinding.Source = WindowElement.ModalContainerPanel;

				fence.SetBinding(Canvas.WidthProperty, wBinding);
				fence.SetBinding(Canvas.HeightProperty, hBinding);

				fence.Background = new SolidColorBrush(Color.FromArgb(141, 162, 174, 255));
				fence.Opacity = 0.5;

				WindowElement.ModalContainerPanel.Children.Add(fence);
				WindowElement.ModalContainerPanel.BringToBottom(fence);
				WindowElement.ModalContainerPanel.Visibility = Visibility.Visible;
			}
			else
			{
				Debug.Assert(WindowElement.ModalContainerPanel != null);

				for (int i = 0; i < WindowElement.ModalContainerPanel.Children.Count; i++)
				{
					UIElement target = WindowElement.ModalContainerPanel.Children[i];

					if (target is Canvas)
					{
						WindowElement.ModalContainerPanel.Children.Remove(target);
						break;
					}
				}

				WindowElement.ModalContainerPanel.Visibility = Visibility.Hidden;
			}
		}

		private void SaveState(WindowState newWindowState)
		{
			if (newWindowState == WindowState.Maximized)
			{
				OldPosition = this.GetCanvasLeftPosition();
				OldWidth = Width;
				OldHeight = Height;
				OldCanResize = CanResize;
				CanResize = false;

				if (!ConstraintToParent)
				{
					this.Move(10, (-1) * (this.GetParent<Window>().ActualHeight - Parent.ActualHeight - 10));

					Width = this.GetParent<Window>().ActualWidth - MaximizeMargin;
					Height = this.GetParent<Window>().ActualHeight - MaximizeMargin;
				}
				else
				{
					this.Move(10, (-1) * (ParentDesktop.ActualHeight - Parent.ActualHeight - 10));

					Width = ParentDesktop.ActualWidth - MaximizeMargin;
					Height = ParentDesktop.ActualHeight - MaximizeMargin;
				}

				Parent.BringToFront(this);
			}
			else if (newWindowState == WindowState.Normal)
			{
				this.Move(OldPosition);

				Width = OldWidth;
				Height = OldHeight;
				CanResize = OldCanResize;
			}
			else if (newWindowState == WindowState.Minimized)
			{
				OldPosition = this.GetCanvasLeftPosition();
				OldWidth = Width;
				OldHeight = Height;
				OldCanResize = CanResize;

				OnDeactivated();
			}
		}

		#endregion
	}
}
