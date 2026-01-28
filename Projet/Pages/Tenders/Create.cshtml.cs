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

                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"ERROR {entry.Key} : {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            // ✅ ICI LA CRÉATION (IL MANQUAIT CETTE PARTIE)
            Console.WriteLine("CREATING TENDER...");
            service.CreateTender(Tender, 1); // userId = 1 (temp)

            Console.WriteLine("INSERT DONE");

            return RedirectToPage("Index");
        }
    }
}
