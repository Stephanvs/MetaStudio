using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Hayman.Client.Presentation.Windows.ExtensionMethods;
using Hayman.Client.Infrastructure.Core;
using System.Collections.Generic;
using Hayman.Client.Infrastructure.Helpers;

namespace Hayman.Client.Presentation.Windows.Controls
{
	public class Desktop : Canvas, IDesktop
	{
		static Desktop()
		{
			FocusManager.IsFocusScopeProperty.OverrideMetadata(
				   typeof(Desktop), new FrameworkPropertyMetadata(true));

			KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(
				typeof(Desktop), new FrameworkPropertyMetadata(KeyboardNavigationMode.Cycle));
		}

		public Desktop()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }

		/// <summary>
		/// Adds the new desktop element.
		/// </summary>
		/// <param name="newElement">The new desktop element.</param>
		/// <param name="position">The position.</param>
		public void AddElement(IDesktopElement newElement, Point position)
		{
            UIElement newUIElement = newElement as UIElement;

            newUIElement.Move(Math.Max(0, position.X), Math.Max(0, position.Y));
            newUIElement.SetZIndex(0);

			AddElement(newElement);
		}

		/// <summary>
		/// Adds the new desktop element.
		/// </summary>
		/// <param name="newElement">The new desktop element.</param>
		public void AddElement(IDesktopElement newElement)
		{
            Children.Add(newElement as UIElement);
		}

		/// <summary>
		/// Removes the given element from the desktop.
		/// </summary>
		/// <param name="element">The element.</param>
		public void RemoveElement(IDesktopElement element)
		{
			Children.Remove(element as UIElement);
		}

		/// <summary>
		/// Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.MouseDown"/> attached event 
		/// reaches an element in its route that is derived from this class. 
		/// Implement this method to add class handling for this event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> 
		/// that contains the event data. This event data reports details about the mouse button that was pressed and the handled state.
		/// </param>
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			if (Object.ReferenceEquals(e.Source, this))
			{
				// Deactivate all Desktop elements
				DeactivateAll();

				FocusHelper.Focus(this);

				e.Handled = true;
			}

			base.OnMouseDown(e);
		}

		/// <summary>
		/// Called when a <see cref="DesktopElement"/> gets activated.
		/// </summary>
		/// <param name="id">The id.</param>
		internal void OnActivatedElement(Guid id)
		{
			Children
				.OfType<IDesktopElement>()
				.Where(e => e.Id != id)
				.ToList()
				.ForEach(element => element.Deactivate());
		}

		private void DeactivateAll()
		{
			Children
				.OfType<IActiveAware>()
				.ToList()
				.ForEach(element => element.Deactivate());
		}

        public List<IDesktopElement> DesktopElements
        {
            get 
            { 
                return Children
                .OfType<IDesktopElement>()
                .ToList(); 
            }
        }
    }
}