using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using AppContext = Projet.Security.AppContext;

namespace Projet.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public UserDto User { get; set; }

        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        private readonly UserService service;

        public ProfileModel()
        {
            service = new UserService();
        }

        public IActionResult OnGet()
        {
            if (!AppContext.IsAuthenticated)
                return RedirectToPage("/Signin");

            User = service.GetUser(AppContext.Username);

            if (User == null)
                return RedirectToPage("/Signin");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!AppContext.IsAuthenticated)
                return RedirectToPage("/Signin");

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Veuillez corriger les erreurs.";
                return Page();
            }

            UserDto oldUser = service.GetUser(AppContext.Username);

            if (oldUser == null)
            {
                ErrorMessage = "Utilisateur introuvable.";
                return Page();
            }

            bool updated = service.UpdateUser(oldUser, User);

            if (!updated)
            {
                ErrorMessage = "Échec de la mise à jour.";
                return Page();
            }

            Message = "Profil mis à jour avec succès ✔";
            return RedirectToPage();
        }
    }
}
