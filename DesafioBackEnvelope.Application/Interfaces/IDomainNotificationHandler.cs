
namespace DesafioBackEnvelope.Application.Interfaces
{
    public interface IDomainNotificationHandler
    {
        bool HasNotifications();
        //List<NotificationDTO> GetNotifications();
        void NewNotification(string message);
    }
}
