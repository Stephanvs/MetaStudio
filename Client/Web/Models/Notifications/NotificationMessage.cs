using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hayman.Client.Web.Models.Notifications
{
	public class NotificationMessage
	{
		public NotificationMessage(NotificationType type)
		{
			Id = Guid.NewGuid();
			CreatedDate = DateTime.Now;
		}

		public NotificationType Type { get; set; }
		public Guid Id { get; private set; }
		public DateTime CreatedDate { get; private set; }
		public string Sender { get; set; }
		public string Body { get; set; }
	}
}