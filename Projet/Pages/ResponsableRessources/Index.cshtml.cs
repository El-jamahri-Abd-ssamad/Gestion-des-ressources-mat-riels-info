using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Data;
using Projet.Domain;
using Projet.Domain.enums;
using Projet.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Projet.Pages.ResponsableRessources
{
    public class IndexModel : PageModel
    {
        private readonly IBesoinDao _besoinDao;
        private readonly INotificationDao _notificationDao;

        // Liste des besoins envoyés
        public List<BesoinViewModel> BesoinsEnvoyes { get; set; } = new List<BesoinViewModel>();

        // Notifications pour le responsable
        public List<Notification> Notifications { get; set; } = new List<Notification>();

        // =========================
        // Constructeur
        // =========================
        public IndexModel()
        {
            _besoinDao = new BesoinDB();           // DAO Besoin
            _notificationDao = new NotificationDaoDB(); // DAO Notification
        }

        // =========================
        // OnGet : récupérer besoins et notifications
        // =========================
        public void OnGet()
        {
            // Récupérer les notifications
            Notifications = _notificationDao.GetNotifications(Role.ResponsableRessources)
                             ?? new List<Notification>();

            // Récupérer les besoins envoyés
            var besoins = _besoinDao.GetBesoinsEnvoyes() ?? new List<Besoin>();

            // Mapper vers la view model
            BesoinsEnvoyes = besoins.Select(b => new BesoinViewModel
            {
                Code = b.Code,
                DepartementId = b.DepartementId,
                TypeRessource = b.TypeRessource ?? "",
                Quantite = b.Quantite,
                Statut = b.Statut,
                AppelOffreId = b.AppelOffreId,
                NomDepartement = "Inconnu" // plus tard on pourra récupérer via DepartementDao
            }).ToList();
        }
    }

    // =========================
    // ViewModel pour l'affichage
    // =========================
    public class BesoinViewModel
    {
        public int Code { get; set; }
        public int DepartementId { get; set; }
        public string NomDepartement { get; set; } = string.Empty;
        public string TypeRessource { get; set; } = string.Empty;
        public int Quantite { get; set; }
        public StatutBesoin Statut { get; set; }
        public int? AppelOffreId { get; set; }
    }
}
