using System;
using Hayman.Client.Infrastructure.ViewModels;

namespace Hayman.Client.Presentation.Windows.ViewModels
{
    /// <summary>
    /// Base class for widgets viewmodel implementations
    /// </summary>
    public abstract class WidgetViewModel : ClosableViewModel, IWidgetViewModel
    {
        private string description;

        /// <summary>
        /// Returns the user-friendly name of this object.
        /// Child classes can set this property to a new value,
        /// or override it to determine the value on-demand.
        /// </summary>
        public virtual string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    RaisePropertyChanged(() => Description);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetViewModel"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        protected WidgetViewModel(string displayName)
            : base(displayName)
        {
        }
    }
}
