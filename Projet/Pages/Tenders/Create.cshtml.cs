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

        public void OnGet()
        {
            Console.WriteLine("ON GET CREATE TENDER");
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("ON POST CREATE TENDER");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("MODEL STATE INVALID");
                return Page();
            }

            // ⚠️ TEST LOG
            Console.WriteLine("TITLE = " + Tender.Title);

            service.CreateTender(Tender, 1); // 1 = CreatedBy (temporaire)

            Console.WriteLine("INSERT DONE");

            return RedirectToPage("Index");
        }
    }
}
