using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Projet.Models;
using Projet.Services;
using Projet.Security;
using Projet.Domain.Enums;
using AppContext = Projet.Security.AppContext;
using Projet.Domain;

namespace Projet.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public UserDto Input { get; set; }   // Username et Password

        public string ErrorMessage { get; set; }

        IUserService service = new UserService();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // récupérer l'utilisateur depuis la DB
            User user = service.Login(Input.Username, Input.Password);

            if (user == null)
            {
                ErrorMessage = "Nom d'utilisateur ou mot de passe incorrect.";
                return Page();
            }

            // ?? Stockage global (sans session)
            AppContext.Username = user.Account.Username;
            AppContext.Role = (Role)user.Account.Role;

            Console.WriteLine($"Utilisateur connecté : {AppContext.Username} | RôleId={(int)AppContext.Role} | RôleEnum={AppContext.Role}");
            // ?? Redirection selon le rôle
            return AppContext.Role switch
            {
                Role.Admin => RedirectToPage("/Admin/Dashboard"),
                Role.ChefDepartement => RedirectToPage("/ChefDepartement/Index"),
                Role.Enseignant => RedirectToPage("/Enseignant/Dashboard"),
                Role.Fournisseur => RedirectToPage("/Suppliers/Dashboard"),
                Role.Technicien => RedirectToPage("/Maintenance/CreateReport"),
                _ => RedirectToPage("/Welcome")
            };
        }
    }
}
