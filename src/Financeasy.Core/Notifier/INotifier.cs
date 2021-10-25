using System.Collections.Generic;

namespace Financeasy.Core
{
    public interface INotifier
    {
        bool HasNotifications();

        List<Notification> GetNotifications();

        void Notify(Notification notification);

        void Notify(string message);
    }
}