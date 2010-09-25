using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Hayman.Client.Infrastructure.Logging;
using Hayman.Client.Presentation.Windows.ExtensionMethods;
using Microsoft.Practices.ServiceLocation;
using Hayman.Client.Infrastructure.Core;
using Hayman.Client.Infrastructure.Helpers;

namespace Hayman.Client.Presentation.Windows.Controls
{
    /// <summary>
	/// Base class for <see cref="Desktop"/> elements (shortcuts, widgets,...)
	/// </summary>
	[TemplatePart(Name = DesktopElement.PART_ContentPresenter, Type = typeof(ContentPresenter))]
	[TemplatePart(Name = DesktopElement.PART_Dragger, Type = typeof(UIElement))]
    public abstract class DesktopElement : ContentControl, IActiveAware, IDesktopElement
	{
		#region Constants

		/// <summary>
		/// Name of the <see cref="DesktopElement"/> ContentPresenter Template Part
		/// </summary>
		protected const string PART_ContentPresenter = "PART_ContentPresenter";
		/// <summary>
		/// Name of the <see cref="DesktopElement"/> Dragger Template Part
		/// </summary>
		protected const string PART_Dragger = "PART_Dragger";

		#endregion

		#region Dependency Properties

		/// <summary>
		/// Identifies the Id dependency property.
		/// </summary>
		public static readonly DependencyProperty IdProperty =
			DependencyProperty.Register("Id", typeof(Guid), typeof(DesktopElement), new FrameworkPropertyMetadata(Guid.NewGuid()));

		/// <summary>
		/// Identifies the CanResize dependency property.
		/// </summary>
		public static readonly DependencyProperty CanResizeProperty =
			DependencyProperty.Register("CanResize", typeof(bool), typeof(DesktopElement),
				new FrameworkPropertyMetadata(true));

		/// <summary>
		/// Identifies the CanDrag dependency property.
		/// </summary>
		public static readonly DependencyProperty CanDragProperty =
			DependencyProperty.Register("CanDrag", typeof(bool), typeof(DesktopElement),
				new FrameworkPropertyMetadata(true));

		/// <summary>
		/// Identifies the ConstraintToParent dependency property.
		/// </summary>
		public static readonly DependencyProperty ConstraintToParentProperty =
			DependencyProperty.Register("ConstraintToParent", typeof(bool), typeof(DesktopElement),
				new FrameworkPropertyMetadata(false));

		/// <summary>
		/// Identifies the ParentId dependency property
		/// </summary>
		public static readonly DependencyProperty ParentIdProperty =
			DependencyProperty.Register("ParentId", typeof(Guid), typeof(DesktopElement));

		/// <summary>
		/// Identifies the IsActive dependency property
		/// </summary>
		public static readonly DependencyProperty IsActiveProperty =
		  DependencyProperty.Register("IsActive", typeof(bool), typeof(DesktopElement), new FrameworkPropertyMetadata(false));

		#endregion

		#region Static Constructor

		/// <summary>
		/// Initializes the <see cref="DesktopElement"/> class.
		/// </summary>
		static DesktopElement()
		{
			// set the key to reference the style for this control
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
				typeof(DesktopElement), new FrameworkPropertyMetadata(typeof(DesktopElement)));
		}

		#endregion

		#region Static Routed Events

		/// <summary>
		/// Occurs when a desktop element is activated
		/// </summary>
		public static readonly RoutedEvent ActivatedEvent = EventManager.
			RegisterRoutedEvent("Activated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DesktopElement));

		/// <summary>
		/// Occurs when a desktop element is deactivated
		/// </summary>
		public static readonly RoutedEvent DeactivatedEvent = EventManager.
			RegisterRoutedEvent("Deactivated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DesktopElement));

		#endregion

		#region Events

		/// <summary>
		/// Occurs when the element becomes activated
		/// </summary>
		public event RoutedEventHandler Activated
		{
			add { base.AddHandler(DesktopElement.ActivatedEvent, value); }
			remove { base.RemoveHandler(DesktopElement.ActivatedEvent, value); }
		}

		/// <summary>
		/// Occurs when the element becomes deactivated
		/// </summary>
		public event RoutedEventHandler Deactivated
		{
			add { base.AddHandler(DesktopElement.DeactivatedEvent, value); }
			remove { base.RemoveHandler(DesktopElement.DeactivatedEvent, value); }
		}

		#endregion

		#region Fields

		private UIElement draggerElement;
		private DragOrResizeStatus previewDragOrResizeStatus;
		private DragOrResizeStatus dragOrResizeStatus;
		private Point startMousePosition;
		private Point previousMousePosition;
		private Point oldPosition;
		private double oldWidth;
		private double oldHeight;
		private bool oldCanResize;
		protected ILogger logger = ServiceLocator.Current.GetInstance<ILogger>();

		#endregion

		#region Properties
		
		/// <summary>
		/// Gets or sets the element id.
		/// </summary>
		/// <value>The id.</value>
		public Guid Id
		{
			get { return (Guid)base.GetValue(IdProperty); }
			set { base.SetValue(IdProperty, value); }
		}

		/// <summary>
		/// Gets or sets the parent element id.
		/// </summary>
		/// <value>The parent id.</value>
		public Guid ParentId
		{
			get { return (Guid)base.GetValue(ParentIdProperty); }
			set { base.SetValue(ParentIdProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the element can be resized
		/// </summary>
		public bool CanResize
		{
			get { return (bool)base.GetValue(CanResizeProperty); }
			set { base.SetValue(CanResizeProperty, value); }
		}

		/// <summary>
		/// Gets a value indicating whether the element can be dragged.
		/// </summary>
		/// <value><c>true</c> if this instance can drag; otherwise, <c>false</c>.</value>
		public virtual bool CanDrag
		{
			get { return (bool)base.GetValue(CanDragProperty); }
			set { base.SetValue(CanDragProperty, value); }
		}

		/// <summary>
		/// Gets a value indicating whether the element should be constrained to parent.
		/// </summary>
		/// <value><c>true</c> if this instance can drag; otherwise, <c>false</c>.</value>
		public virtual bool ConstraintToParent
		{
			get { return (bool)base.GetValue(ConstraintToParentProperty); }
			set { base.SetValue(ConstraintToParentProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the element is active.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is active; otherwise, <c>false</c>.
		/// </value>
		public virtual bool IsActive
		{
			get { return (bool)base.GetValue(IsActiveProperty); }
		}

		#endregion

		#region Protected Properties

		/// <summary>
		/// Gets the current drag or resize status
		/// </summary>
		protected DragOrResizeStatus DragOrResizeStatus
		{
			get { return this.dragOrResizeStatus; }
		}

		/// <summary>
		/// Gets or sets the old element position.
		/// </summary>
		protected Point OldPosition
		{
			get { return this.oldPosition; }
			set { this.oldPosition = value; }
		}

		/// <summary>
		/// Gets or sets the previous value of he <see cref="E:UIElement.Width"/> property
		/// </summary>
		protected double OldWidth
		{
			get { return this.oldWidth; }
			set { this.oldWidth = value; }
		}

		/// <summary>
		/// Gets or sets the previous value of he <see cref="E:UIElement.Height"/> property
		/// </summary>
		protected double OldHeight
		{
			get { return this.oldHeight; }
			set { this.oldHeight = value; }
		}

		/// <summary>
		/// Gets or sets the previous value of he <see cref="DesktopElement.CanResize"/> property
		/// </summary>
		protected bool OldCanResize
		{
			get { return this.oldCanResize; }
			set { this.oldCanResize = value; }
		}

		/// <summary>
		/// Gets the parent <see cref="Desktop"/>.
		/// </summary>
		/// <value>The parent desktop.</value>
		protected Desktop ParentDesktop
		{
			get { return this.GetParent<Desktop>(); }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="DesktopElement"/> class.
		/// </summary>
		protected DesktopElement()
		{
			this.dragOrResizeStatus = DragOrResizeStatus.None;
			this.startMousePosition = new Point();
			this.oldWidth = this.Width;
			this.oldHeight = this.Height;
			this.oldCanResize = this.CanResize;
		}

		#endregion

		#region Methods
		
		/// <summary>
		/// When overridden in a derived class, is invoked whenever application code 
		/// or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
		/// </summary>
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			draggerElement = GetTemplateChild(DesktopElement.PART_Dragger) as UIElement;
		}

		/// <summary>
		/// Attempts to bring the element to the foreground and activates it.
		/// </summary>
		public void Activate()
		{
			OnActivated();
		}

		/// <summary>
		/// Deactivates the element
		/// </summary>
		public void Deactivate()
		{
			OnDeactivated();
		}

		/// <summary>
		/// Closes the desktop element
		/// </summary>
		public virtual void Close()
		{
			// Clean up
			this.Id = Guid.Empty;
			this.Visibility = Visibility.Collapsed;
			this.dragOrResizeStatus = DragOrResizeStatus.None;
			this.oldWidth = 0;
			this.oldHeight = 0;
			this.oldCanResize = false;
			this.draggerElement = null;
			this.DataContext = null;
			this.Content = null;
		}

		#endregion

		#region Protected Methods

		/// <summary>
		/// Raises the <see cref="DesktopElement.Activated"/> event.
		/// </summary>
		protected virtual void OnActivated()
		{
			if (!(bool)GetValue(DesktopElement.IsActiveProperty))
			{
				ParentDesktop.OnActivatedElement(this.Id);
				ParentDesktop.BringToFront(this);

				FocusHelper.Focus(this);

				base.SetValue(DesktopElement.IsActiveProperty, true);

				RoutedEventArgs e = new RoutedEventArgs(DesktopElement.ActivatedEvent, this);
				base.RaiseEvent(e);
			}
		}

		/// <summary>
		/// Raises the <see cref="DesktopElement.Deactivated"/> event.
		/// </summary>
		protected virtual void OnDeactivated()
		{
			if (IsActive)
			{
				base.SetValue(DesktopElement.IsActiveProperty, false);

				RoutedEventArgs e = new RoutedEventArgs(DesktopElement.DeactivatedEvent, this);
				base.RaiseEvent(e);
			}
		}

		#endregion

		#region Mouse Handling Methods

		/// <summary>
		/// Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.PreviewMouseDown"/> attached routed event 
		/// reaches an element in its route that is derived from this class. 
		/// Implement this method to add class handling for this event.
		/// </summary>
		/// <param name="e">
		/// The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> that contains the event data. 
		/// The event data reports that one or more mouse buttons were pressed.
		/// </param>
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			if (!IsActive)
			{
				OnActivated();
			}

			base.OnPreviewMouseDown(e);
		}
		
		/// <summary>
		/// Invoked when an unhandled <see cref="E:System.Windows.UIElement.PreviewMouseLeftButtonDown"/> routed event 
		/// reaches an element in its route that is derived from this class. 
		/// Implement this method to add class handling for this event.
		/// </summary>
		/// <param name="e">
		/// The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> that contains the event data. 
		/// The event data reports that the left mouse button was pressed.
		/// </param>
		protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			if (!e.Handled && e.ClickCount == 1) 
			{
				if (this.dragOrResizeStatus == DragOrResizeStatus.None &&
					this.previewDragOrResizeStatus != DragOrResizeStatus.None)
				{
					e.Handled = true;

					this.dragOrResizeStatus = this.previewDragOrResizeStatus;
					this.startMousePosition = this.previousMousePosition = e.GetPosition(this);

					Debug.WriteLine("Capturing Mouse");

					this.CaptureMouse();
				}
			}

			base.OnPreviewMouseLeftButtonDown(e);
		}

		/// <summary>
		/// Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.PreviewMouseMove"/> attached event 
		/// reaches an element in its route that is derived from this class. 
		/// Implement this method to add class handling for this event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Windows.Input.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnPreviewMouseMove(MouseEventArgs e)
		{
			if (dragOrResizeStatus == DragOrResizeStatus.None)
			{
				// http://www.switchonthecode.com/tutorials/wpf-snippet-reliably-getting-the-mouse-position
				Point point = e.GetPosition(this);

				previewDragOrResizeStatus = this.GetDragOrResizeMode(point);

				if (!CanResize
					&& previewDragOrResizeStatus != DragOrResizeStatus.Drag
					&& previewDragOrResizeStatus != DragOrResizeStatus.None)
				{
					previewDragOrResizeStatus = DragOrResizeStatus.None;
				}

				SetResizeCursor(previewDragOrResizeStatus);
			}
			else
			{
				if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
				{
					// http://www.switchonthecode.com/tutorials/wpf-snippet-reliably-getting-the-mouse-position
					Point point = e.GetPosition(this);

					if (Math.Abs(point.X - previousMousePosition.X) > SystemParameters.MinimumHorizontalDragDistance ||
						Math.Abs(point.Y - previousMousePosition.Y) > SystemParameters.MinimumVerticalDragDistance)
					{
						Debug.WriteLine("Moving element");

						e.Handled = true;

						AdjustBounds(point);
						previousMousePosition = point;
					}
				}
				else
				{
					CancelDragOrResize();
				}
			}

			base.OnPreviewMouseMove(e);
		}

		/// <summary>
		/// Invoked when an unhandled <see cref="E:System.Windows.UIElement.MouseLeftButtonUp"/> routed event reaches an element 
		/// in its route that is derived from this class. Implement this method to add class handling for this event.
		/// </summary>
		/// <param name="e">
		/// The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> that contains the event data. The event data reports 
		/// that the left mouse button was released.
		/// </param>
		protected override void OnPreviewMouseLeftButtonUp(System.Windows.Input.MouseButtonEventArgs e)
		{
			if (IsMouseCaptured && dragOrResizeStatus != DragOrResizeStatus.None)
			{
				e.Handled = true;
				CancelDragOrResize();
			}

			base.OnPreviewMouseLeftButtonUp(e);
		}

		#endregion

		#region Drag and Resize Methods

		private DragOrResizeStatus GetDragOrResizeMode(Point position)
		{
			int resizeSideThichness = 5;
			int resizeCornerSize    = 5;

			DragOrResizeStatus status = DragOrResizeStatus.None;

			if (CanResize || CanDrag)
			{
				if (position.X <= resizeSideThichness) // left
				{
					status = GetLeftDragStatus(position, resizeCornerSize);
				}
				else if (ActualWidth - position.X <= resizeSideThichness) // right
				{
					status = GetRightDragStatus(position, resizeCornerSize);
				}
				else if (position.Y <= resizeSideThichness) // top
				{
					status = GetTopDragStatus(position, resizeCornerSize);
				}
				else if (ActualHeight - position.Y <= resizeSideThichness) // bottom
				{
					status = GetBottomDragStatus(position, resizeCornerSize);
				}
				else if (CanDrag &&
						 draggerElement != null &&
						 draggerElement.IsMouseOver)
				{
					status = DragOrResizeStatus.Drag;
				}
				else
				{
					status = DragOrResizeStatus.None;
				}
			}
			else
			{
				status = DragOrResizeStatus.None;
			}

			return status;
		}

		private DragOrResizeStatus GetBottomDragStatus(Point position, int resizeCornerSize)
		{
			DragOrResizeStatus status;

			if (position.X <= resizeCornerSize)
			{
				status = DragOrResizeStatus.BottomLeft;
			}
			else if (ActualWidth - position.X <= resizeCornerSize)
			{
				status = DragOrResizeStatus.BottomRight;
			}
			else
			{
				status = DragOrResizeStatus.BottomCenter;
			}

			return status;
		}

		private DragOrResizeStatus GetTopDragStatus(Point position, int resizeCornerSize)
		{
			DragOrResizeStatus status;

			if (position.X <= resizeCornerSize)
			{
				status = DragOrResizeStatus.TopLeft;
			}
			else if (ActualWidth - position.X <= resizeCornerSize)
			{
				status = DragOrResizeStatus.TopRight;
			}
			else
			{
				status = DragOrResizeStatus.TopCenter;
			}

			return status;
		}

		private DragOrResizeStatus GetRightDragStatus(Point position, int resizeCornerSize)
		{
			DragOrResizeStatus status;

			if (position.Y <= resizeCornerSize)
			{
				status = DragOrResizeStatus.TopRight;
			}
			else if (ActualHeight - position.Y <= resizeCornerSize)
			{
				status = DragOrResizeStatus.BottomRight;
			}
			else
			{
				status = DragOrResizeStatus.MiddleRight;
			}

			return status;
		}

		private DragOrResizeStatus GetLeftDragStatus(Point position, int resizeCornerSize)
		{
			DragOrResizeStatus status;

			if (position.Y <= resizeCornerSize)
			{
				status = DragOrResizeStatus.TopLeft;
			}
			else if (ActualHeight - position.Y <= resizeCornerSize)
			{
				status = DragOrResizeStatus.BottomLeft;
			}
			else
			{
				status = DragOrResizeStatus.MiddleLeft;
			}

			return status;
		}

		private void CancelDragOrResize()
		{
			Debug.WriteLine("CancelDragOrResize");

			Cursor             = null;
			dragOrResizeStatus = DragOrResizeStatus.None;
			ReleaseMouseCapture();
		}

		private void SetResizeCursor(DragOrResizeStatus resizeStatus)
		{
			if (CanResize || CanDrag)
			{
				if (resizeStatus.IsOnTopLeftOrBottomRight)
				{
					Cursor = Cursors.SizeNWSE;
				}
				else if (resizeStatus.IsOnTopRightOrBottomLeft)
				{
					Cursor = Cursors.SizeNESW;
				}
				else if (resizeStatus.IsOnTopRightOrBottomLeft)
				{
					Cursor = Cursors.SizeNESW;
				}
				else if (resizeStatus.IsOnTopCenterOrBottomCenter)
				{
					Cursor = Cursors.SizeNS;
				}
				else if (resizeStatus.IsOnMiddleLeftOrMiddleRight)
				{
					Cursor = Cursors.SizeWE;
				}
				else if (Cursor != null)
				{
					Cursor = null;
				}
			}
			else if (Cursor != null)
			{
				Cursor = null;
			}
		}

		private void AdjustBounds(Point actualPosition)
		{
			Point position = this.GetCanvasLeftPosition();

			if (Parent != null)
			{
				Vector changeFromStart = Point.Subtract(actualPosition, startMousePosition);

				if (dragOrResizeStatus == DragOrResizeStatus.Drag)
				{
					if (CanDrag)
					{
						double x = position.X + changeFromStart.X;
						double y = position.Y + changeFromStart.Y;

						if (ConstraintToParent)
						{
							if (x < 0)
							{
								x = 0;
							}
							if (y < 0)
							{
								y = 0;
							}
							if (y + ActualHeight > ParentDesktop.ActualHeight)
							{
								y = ParentDesktop.ActualHeight- ActualHeight;
							}
							if (x + ActualWidth > ParentDesktop.ActualWidth)
							{
								x = ParentDesktop.ActualWidth - ActualWidth;
							}
						}

						if (x != position.X || y != position.Y)
						{
							this.Move(x, y);
						}
					}
				}
				else
				{
					Size    size                = RenderSize;
					Vector  changeFromPrevious  = Point.Subtract(actualPosition, previousMousePosition);

					if (this.dragOrResizeStatus.IsOnRight)
					{
						if (size.Width + changeFromPrevious.X > MinWidth)
						{
							size.Width += changeFromPrevious.X;
						}
					}
					else if (dragOrResizeStatus.IsOnLeft)
					{
						if (size.Width - changeFromStart.X > MinWidth)
						{
							this.MoveLeft(position.X + changeFromStart.X);
							size.Width -= changeFromStart.X;
						}
					}

					if (dragOrResizeStatus.IsOnBottom)
					{
						if (size.Height + changeFromPrevious.Y > this.MinHeight)
						{
							size.Height += changeFromPrevious.Y;
						}
					}
					else if (dragOrResizeStatus.IsOnTop)
					{
						if (size.Height - changeFromStart.Y > MinHeight)
						{
							this.MoveTop(position.Y + changeFromStart.Y);
							size.Height -= changeFromStart.Y;
						}
					}

					Width  = size.Width;
					Height = size.Height;
				}
			}
		}

		#endregion
	}
}
