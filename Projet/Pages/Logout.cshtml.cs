using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Security;
using AppContext = Projet.Security.AppContext;

namespace Projet.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            AppContext.Logout();

            return RedirectToPage("/SignIn");
        }
    }
}
