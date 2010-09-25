using System;
using System.Windows;

namespace Hayman.Client.Infrastructure.Core
{
    public interface IDesktopElement : IActiveAware
    {
        /// <summary>
        /// Occurs when the element becomes activated
        /// </summary>
        event RoutedEventHandler Activated;
        /// <summary>
        /// Occurs when the element becomes deactivated
        /// </summary>
        event RoutedEventHandler Deactivated;
        /// <summary>
        /// Gets or sets the element id.
        /// </summary>
        /// <value>The id.</value>
        Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the parent element id.
        /// </summary>
        /// <value>The parent id.</value>
        Guid ParentId { get; set; }
        /// <summary>
        /// Gets or sets the data context for an element when it participates in data binding.
        /// </summary>
        Object DataContext { get; set; }

        Object Content { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the element can be resized
        /// </summary>
        bool CanResize { get; set; }
        /// <summary>
        /// Gets a value indicating whether the element can be dragged.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can drag; otherwise, <c>false</c>.</value>
        bool CanDrag { get; set; }
        /// <summary>
        /// Gets a value indicating whether the element should be constrained to parent.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can drag; otherwise, <c>false</c>.</value>
        bool ConstraintToParent { get; set; }
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code 
        /// or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"></see>.
        /// </summary>
        void OnApplyTemplate();
        /// <summary>
        /// Closes the desktop element
        /// </summary>
        void Close();
    }
}
