using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;

namespace Projet.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public UserDto Input { get; set; }
        public string ErrorMessage { get; set; }
        IUserService service = new UserService(); //service métier
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                Console.WriteLine("Invalid data");
                ErrorMessage = "Invalid data. Please correct the errors and try again.";
            }
            else
            {

                bool result = service.RegisterUser(Input);
                if (result == false)
                {
                    Console.WriteLine("Invalid username!!!");
                    ErrorMessage = "Username already exists. Please choose a different username.";
                }
                else
                {
                    Console.WriteLine("registration success :" + Input);
                    //redirection vers la page de succès
                    return RedirectToPage("Index");
                }
            }
            return Page(); //on revient sur la meme page
        }
    }
}
