using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Security;
using Projet.Domain.enums;
using Projet.Services;
using Projet.Models;
using AppContext = Projet.Security.AppContext;
using Projet.Data;

namespace Projet.Pages.ChefDepartement
{
    public class ModifierBesoinModel : PageModel
    {
        private readonly ChefDepartementService _service;

        [BindProperty]
        public BesoinChefDto Besoin { get; set; } = new BesoinChefDto();

        public string Message { get; set; } = "";

        public ModifierBesoinModel()
        {
            _service = new ChefDepartementService(new BesoinDB(), new DepartementDB());
        }

        public IActionResult OnGet(int id)
        {
            if (!AppContext.IsAuthenticated || AppContext.Role != Role.ChefDepartement)
                return RedirectToPage("/SignIn");

            Besoin = _service.GetBesoinById(id);

            if (Besoin == null)
            {
                Message = "Le besoin demandé n'existe pas.";
                return Page();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Message = "Veuillez remplir correctement tous les champs.";
                return Page();
            }

            try
            {
                _service.UpdateBesoin(Besoin);
                return RedirectToPage("/ChefDepartement/Index");
            }
            catch
            {
                Message = "Une erreur est survenue lors de la modification.";
                return Page();
            }
        }
    }
}
