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
    public class BesoinDetailsModel : PageModel
    {
        private readonly ChefDepartementService service;

        public BesoinChefDto Besoin { get; set; }

        public BesoinDetailsModel()
        {
            service = new ChefDepartementService(
                new BesoinDB(),
                new DepartementDB()
            );
        }

        public IActionResult OnGet(int id)
        {
            if (!AppContext.IsAuthenticated || AppContext.Role != Role.ChefDepartement)
                return RedirectToPage("/SignIn");

            Besoin = service.GetBesoinById(id);

            if (Besoin == null)
                return RedirectToPage("/ChefDepartement/Index");

            return Page();
        }
    }
}
