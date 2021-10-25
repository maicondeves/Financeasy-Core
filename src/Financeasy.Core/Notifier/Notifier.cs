using System.Collections.Generic;
using System.Linq;

namespace Financeasy.Core
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
            => _notifications;

        public bool HasNotifications()
            => _notifications.Any();

        public void Notify(Notification notification)
            => _notifications.Add(notification);

        public void Notify(string message)
            => Notify(new Notification(message));
    }
}