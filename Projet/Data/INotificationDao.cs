using Projet.Domain;
using Projet.Domain.enums;
using Projet.Domain.Enums;
using System.Collections.Generic;

namespace Projet.Data
{
    public interface INotificationDao
    {
        List<Notification> GetNotifications(Role role);
        void Insert(Notification notification);
    }
}