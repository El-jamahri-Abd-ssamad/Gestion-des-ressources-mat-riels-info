using Projet.Models;
using Projet.Domain.enums;
using System.Collections.Generic;

namespace Projet.Services
{
    public interface INotificationService
    {
        List<Notification> GetAllNotifications(Role role);
        void AddNotification(string title, string message, Role destinataireRole);
    }
}
