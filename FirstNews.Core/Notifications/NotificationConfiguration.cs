using FirstNews.Core.Collections;

namespace FirstNews.Core.Notifications
{
    internal class NotificationConfiguration : INotificationConfiguration
    {
        public ITypeList<NotificationProvider> Providers { get; private set; }

        public NotificationConfiguration()
        {
            Providers = new TypeList<NotificationProvider>();
        }
    }
}