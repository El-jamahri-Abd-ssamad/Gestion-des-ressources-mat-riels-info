using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Data;
using Projet.Domain;
using Projet.Domain.enums;
using Projet.Models;
using Projet.Security;
using Projet.Services;
using AppContext = Projet.Security.AppContext;

namespace Projet.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public UserDto Input { get; set; }
        public string ErrorMessage { get; set; }

        IUserService service = new UserService();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            User user = service.Login(Input.Username, Input.Password);
            if (user == null)
            {
                ErrorMessage = "Nom d'utilisateur ou mot de passe incorrect.";
                return Page();
            }

            AppContext.Username = user.Account.Username;
            AppContext.Role = (Role)user.Account.Role;

            // récupérer l'ID
            AppContext.UserId = service.GetUserIdByUsername(user.Account.Username);
            Console.WriteLine($"LOGIN => UserId = {AppContext.UserId}, Username = {AppContext.Username}");

            return AppContext.Role switch
            {
                Role.Admin => RedirectToPage("/Admin/Dashboard"),
                Role.ChefDepartement => RedirectToPage("/ChefDepartement/Index"),
                Role.Enseignant => RedirectToPage("/Enseignant/Dashboard"),
                Role.Fournisseur => RedirectToPage("/Suppliers/Dashboard"),
                Role.Technicien => RedirectToPage("/Maintenance/CreateReport"),
                _ => RedirectToPage("/Index")
            };
        }
    }
}
