using Projet.Models;
using Projet.Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet.Services
{
    public class NotificationService : INotificationService
    {
        private static List<Notification> _notifications = new List<Notification>();

        // Récupérer toutes les notifications filtrées par rôle
        public List<Notification> GetAllNotifications(Role role)
        {
            return _notifications
                    .Where(n => n.DestinataireRole == role)
                    .ToList();
        }

        // Ajouter une notification pour un rôle spécifique
        public void AddNotification(string title, string message, Role destinataireRole)
        {
            _notifications.Add(new Notification
            {
                Title = title,
                Message = message,
                Date = DateTime.Now,
                DestinataireRole = destinataireRole
            });
        }

        public void AddNotification(string message, Role destinataireRole)
        {
            throw new NotImplementedException();
        }
    }
}
