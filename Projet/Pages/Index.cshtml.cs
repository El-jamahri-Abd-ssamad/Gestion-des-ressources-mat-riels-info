using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Domain.Enums;
using AppContext = Projet.Security.AppContext;

namespace Projet.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (!AppContext.IsAuthenticated)
                return RedirectToPage("/Signin");
            Console.WriteLine(AppContext.Username + " " + AppContext.Role);
            return AppContext.Role switch
            {
                Role.Fournisseur => RedirectToPage("/Suppliers/Dashboard"),
                Role.ChefDepartement => RedirectToPage("/ChefDepartement/Index"),
                Role.Technicien => RedirectToPage("/Maintenance/CreateReport"),
                Role.ResponsableRessources => RedirectToPage("/Resources/ManageComputers"),
                _ => Page()
            };
        }
    }
}
