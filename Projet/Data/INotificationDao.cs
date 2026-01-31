using Projet.Domain;
using Projet.Domain.enums;

namespace Projet.Data
{
    public interface INotificationDao
    {
        public void Ajouter(Notification n);
        public List<Notification> GetNotifications(Role role);
    }
}
