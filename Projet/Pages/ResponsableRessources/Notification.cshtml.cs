using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Services;
using Projet.Models;
using Projet.Domain.Enums;
using System.Collections.Generic;

namespace Projet.Pages
{
    public class NotificationsModel : PageModel
    {
        private readonly INotificationService _notificationService;

        public NotificationsModel(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public void OnGet() =>
            // Exemple : afficher uniquement les notifications du rôle Responsable
            Notifications = _notificationService.GetAllNotifications(Role.ResponsableRessources);
    }
}
