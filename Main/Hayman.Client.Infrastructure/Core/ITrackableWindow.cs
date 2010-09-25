using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Hayman.Client.Infrastructure.Core
{
	public interface ITrackableWindow
	{
		/// <summary>
		/// Gets the Id
		/// </summary>
		Guid Id { get; }

        /// <summary>
        /// Gets or sets the window thumbnail.
        /// </summary>
        /// <value>The thumbnail.</value>
        Visual Thumbnail
        {
            get;
            set;
        }

        DelegateCommand RestoreCommand
        {
            get;
        }

		/// <summary>
		/// Gets or sets the display name
		/// </summary>
		string DisplayName { get; set; }
	}
}
