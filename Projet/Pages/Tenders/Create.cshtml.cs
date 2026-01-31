using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;

namespace Projet.Pages.Tenders
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public TenderDto Tender { get; set; }

        ITenderService service = new TenderService();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            service.CreateTender(Tender, 1); // admin temporaire
            return RedirectToPage("Index");
        }
    }
}
