using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastelariaSMN.Infra
{
	public class NotificationList
	{
		public List<Notification> Notifications { get; }
		public bool HasNotifications => Notifications.Any();

        public NotificationList()
        {
            Notifications = new List<Notification>();

        }

        public void AddNotification(string key, string message)
		{
			Notifications.Add(new Notification(key, message));
		}
	}
}