using Hayman.Client.Infrastructure.ViewModels;
using System;
using System.Windows.Input;
using Hayman.Client.Infrastructure.Core;

namespace Hayman.Client.Presentation.Windows.ViewModels
{
	public class NotificationViewModel : ClosableViewModel, INotificationViewModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClosableViewModel"/> class.
		/// </summary>
		/// <param name="displayName"></param>
		protected NotificationViewModel(string displayName)
			: base(displayName)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClosableViewModel"/> class.
		/// </summary>
		/// <param name="displayName"></param>
		public NotificationViewModel(string displayName, string message)
			: this(displayName)
		{
			Message = message;
		}

		public string Title 
		{
			get { return DisplayName; }
			set { DisplayName = value; }
		}

		public string Message { get; set; }
	}
}
