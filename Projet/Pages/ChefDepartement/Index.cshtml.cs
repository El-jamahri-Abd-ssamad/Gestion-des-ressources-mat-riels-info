using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Data;
using Projet.Domain;
using Projet.Domain.enums;
using Projet.Models;
using Projet.Security;
using Projet.Services;
using AppContext = Projet.Security.AppContext;

namespace Projet.Pages.ChefDepartement
{
    public class IndexModel : PageModel
    {
        private readonly ChefDepartementService service;
        //private readonly NotificationDB notificationDb;
        public List<BesoinChefDto> Besoins { get; set; } = new();
        public string Message { get; set; } = "";

        public IndexModel()
        {
            service = new ChefDepartementService(new Projet.Data.BesoinDB(), new Projet.Data.DepartementDB());
            //notificationDb = new NotificationDB();
        }

        private void LoadBesoins()
        {
            var departement = service.GetDepartementChef(AppContext.Username);
            if (departement != null)
            {
                Besoins = service.GetBesoins(departement.Id);
            }
        }

        public IActionResult OnGet()
        {
            if (!AppContext.IsAuthenticated || AppContext.Role != Role.ChefDepartement)
                return RedirectToPage("/SignIn");

            LoadBesoins();

            if (Besoins.Count == 0)
                Message = "Aucun besoin pour ce département.";

            return Page();
        }

        public IActionResult OnPostValider(int besoinId)
        {
            var b = service.GetBesoinById(besoinId);
            if (b == null || b.Statut != StatutBesoin.EnAttente)
            {
                Message = "Action impossible : ce besoin ne peut pas être validé.";
            }
            else
            {
                service.ValiderBesoin(besoinId);
                Message = "Besoin validé avec succès.";
            }

            LoadBesoins();
            return RedirectToPage();
        }

        public IActionResult OnPostRejeter(int besoinId)
        {
            var b = service.GetBesoinById(besoinId);
            if (b == null || b.Statut != StatutBesoin.EnAttente)
            {
                Message = "Action impossible : ce besoin ne peut pas être rejeté.";
            }
            else
            {
                service.RejeterBesoin(besoinId);
                Message = "Besoin rejeté avec succès.";
            }

            LoadBesoins();
            return RedirectToPage();
        }

        public IActionResult OnPostSupprimer(int besoinId)
        {
            var b = service.GetBesoinById(besoinId);
            if (b == null || b.Statut != StatutBesoin.EnAttente)
            {
                Message = "Action impossible : ce besoin ne peut pas être supprimé.";
            }
            else
            {
                service.DeleteBesoin(besoinId);
                Message = "Besoin supprimé avec succès.";
            }

            LoadBesoins();
            return Page();
        }

        public IActionResult OnPostModifier(
    int besoinId,
    string TypeRessource,
    string Description,
    int Quantite,
    DateTime DateSoumission)
        {
            var b = service.GetBesoinById(besoinId);

            if (b == null || b.Statut != StatutBesoin.EnAttente)
            {
                Message = "Modification impossible.";
                LoadBesoins();
                return Page();
            }

            b.TypeRessource = TypeRessource;
            b.Description = Description;
            b.Quantite = Quantite;
            b.DateSoumission = DateSoumission;

            service.UpdateBesoin(b);

            Message = "Besoin modifié avec succès.";
            return RedirectToPage();
        }


        public IActionResult OnPostEnvoyer()
        {
            var departement = service.GetDepartementChef(AppContext.Username);

            if (departement == null)
                return Page();

            service.EnvoyerBesoinsAuResponsable(departement.Id, departement.Nom);

            Message = "Les besoins validés ont été envoyés au responsable des ressources.";
            LoadBesoins();
            

            // 🔔 Notification
            //notificationDb.Ajouter(new Notification
            //{
            //    Message = $"Nouveaux besoins envoyés par le département {departement.Nom}",
            //    DateCreation = DateTime.Now,
            //    RoleCible = Role.ResponsableRessources
            //});
            return Page();
        }
    }
}
