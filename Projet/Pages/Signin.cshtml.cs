using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Domain;
using Projet.Models;
using Projet.Services;

namespace Projet.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public UserDto Input { get; set; }   // Username et Password

        public string ErrorMessage { get; set; }   // message affiché en cas d'erreur

        IUserService service = new UserService();  // service métier

        public void OnGet()
        {
            // affichage initial
        }

        public IActionResult OnPost()
        {
            // Récupère l'utilisateur par username
            UserDto user = service.GetUser(Input.Username);

            if (user != null && user.Password == Input.Password)
            {
                Console.WriteLine("Authentification réussie !");

                // Redirection selon le rôle
                if (user.Username.ToLower() == "admin")
                    return RedirectToPage("ListUsers");
                else if (user.Username.ToLower() == "fournisseur")
                    return RedirectToPage("/Suppliers/Dashboard");
                else if (user.Username.ToLower() == "responsableressources")
                    return RedirectToPage("/Tenders/Index");
                return RedirectToPage("/Tenders/Index");
                

               

            }
            else
            {
                ErrorMessage = "Authentification échouée, nom d'utilisateur ou mot de passe incorrect.";
                Console.WriteLine("Authentification échouée !");
                return Page();
            }
        }
    }
}
