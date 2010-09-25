using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hayman.Client.Infrastructure.Presentation.Core
{
	public interface ITrackableWindow
	{
		/// <summary>
		/// Gets the Id
		/// </summary>
		Guid Id { get; }

		/// <summary>
		/// Gets or sets the display name
		/// </summary>
		string DisplayName { get; set; }
	}
}
