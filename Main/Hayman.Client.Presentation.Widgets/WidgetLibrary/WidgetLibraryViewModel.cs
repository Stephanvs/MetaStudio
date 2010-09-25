using Hayman.Client.Presentation.Windows.ViewModels;

namespace Hayman.Client.Presentation.Widgets
{
    /// <summary>
    /// Widget library ViewModel
    /// </summary>
    public sealed class WidgetLibraryViewModel : WidgetViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetLibraryViewModel"/> class.
        /// </summary>
        public WidgetLibraryViewModel() : base("Widget Library")
        {
            Description = "Browse the list of available widgets";
        }
    }
}
