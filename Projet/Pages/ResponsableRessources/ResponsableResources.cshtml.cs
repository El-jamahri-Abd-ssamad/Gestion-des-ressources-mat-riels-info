using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Projet.Pages.ResponsableResources
{
    public class ResponsableResourcesModel : PageModel
    {
        // Informations utilisateur
        public string UserName { get; set; }

        // Statistiques
        public int TotalComputers { get; set; }
        public int TotalPrinters { get; set; }
        public int TotalDepartments { get; set; }
        public int PendingRequests { get; set; }

        // Activités récentes
        public List<Activity> RecentActivities { get; set; } = new List<Activity>();

        public void OnGet()
        {
            // TODO: Récupérer les données depuis la base de données
            // Pour l'exemple, voici des données de test

            // Nom d'utilisateur (à récupérer depuis l'authentification)
            UserName = "Responsable Ressources";

            // Statistiques
            TotalComputers = 8;
            TotalPrinters = 5;
            TotalDepartments = 6;
            PendingRequests = 3;

            // Activités récentes
            RecentActivities = new List<Activity>
            {
                new Activity
                {
                    Type = "add",
                    Icon = "fa-plus",
                    Description = "Ordinateur N°12 ajouté au département SALIMA",
                    TimeAgo = "Il y a 2 heures"
                },
                new Activity
                {
                    Type = "edit",
                    Icon = "fa-edit",
                    Description = "Ordinateur N°120 modifié - RAM mise à jour",
                    TimeAgo = "Il y a 5 heures"
                },
                new Activity
                {
                    Type = "add",
                    Icon = "fa-plus",
                    Description = "Imprimante HP LaserJet ajoutée au département IT",
                    TimeAgo = "Hier à 14:30"
                },
                new Activity
                {
                    Type = "delete",
                    Icon = "fa-trash",
                    Description = "Ordinateur N°45 supprimé - Fin de vie",
                    TimeAgo = "Hier à 10:15"
                },
                new Activity
                {
                    Type = "edit",
                    Icon = "fa-edit",
                    Description = "Ordinateur N°222 réaffecté au département Finance",
                    TimeAgo = "Il y a 2 jours"
                }
            };
        }
    }

    public class Activity
    {
        public string Type { get; set; }  // add, edit, delete
        public string Icon { get; set; }
        public string Description { get; set; }
        public string TimeAgo { get; set; }
    }
}
