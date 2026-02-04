using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;

namespace Projet.Pages.Offers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public OfferDto Offer { get; set; } = new OfferDto();

        IOfferService service = new OfferService();

        public void OnGet(int tenderId)
        {
            Offer.TenderId = tenderId;
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("ON POST CREATE OFFER");

            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"FIELD: {entry.Key} | ERROR: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            int supplierId = 1; // temporaire
            Offer.WarrantyMonths = 0;

            service.CreateOffer(supplierId, Offer);

            Console.WriteLine("OFFER INSERT DONE");

            return RedirectToPage("/Suppliers/Dashboard");
        }
    }

}
