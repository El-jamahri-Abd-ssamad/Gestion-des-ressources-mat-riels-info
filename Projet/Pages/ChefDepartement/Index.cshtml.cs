using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Security;
using Projet.Domain.Enums;
using Projet.Services;
using Projet.Models;
using System.Collections.Generic;
using AppContext = Projet.Security.AppContext;
using Projet.Data;

namespace Projet.Pages.ChefDepartement
{
    public class IndexModel : PageModel
    {
        private readonly ChefDepartementService _service;

        public List<BesoinChefDto> Besoins { get; set; } = new List<BesoinChefDto>();
        public string Message { get; set; } = "";

        public IndexModel()
        {
            _service = new ChefDepartementService(new BesoinDB(), new DepartementDB());
        }

        public IActionResult OnGet()
        {
            if (!AppContext.IsAuthenticated || AppContext.Role != Role.ChefDepartement)
                return RedirectToPage("/SignIn");

            var departement = _service.GetDepartementChef(AppContext.Username);

            if (departement == null)
            {
                Message = "Aucun département associé à ce compte.";
                return Page();
            }

            Besoins = _service.GetBesoins(departement.Id);

            if (Besoins.Count == 0)
                Message = "Aucun besoin pour ce département.";

            return Page();
        }

        // Valider un besoin
        public IActionResult OnPostValider(int besoinId)
        {
            _service.ValiderBesoin(besoinId);
            return RedirectToPage();
        }

        // Rejeter un besoin
        public IActionResult OnPostRejeter(int besoinId)
        {
            _service.RejeterBesoin(besoinId);
            return RedirectToPage();
        }

        // Supprimer un besoin
        public IActionResult OnPostSupprimer(int besoinId)
        {
            _service.DeleteBesoin(besoinId);
            return RedirectToPage();
        }

        // Modifier un besoin
        public IActionResult OnPostModifier(int besoinId)
        {
            return RedirectToPage("/ChefDepartement/ModifierBesoin", new { id = besoinId });
        }
    }
}
