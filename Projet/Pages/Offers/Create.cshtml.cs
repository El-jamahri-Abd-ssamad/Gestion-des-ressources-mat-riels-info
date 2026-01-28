using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;

namespace Projet.Pages.Offers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public OfferDto Offer { get; set; }

        IOfferService service = new OfferService();

        public int TenderId { get; set; }

        public void OnGet(int tenderId)
        {
            TenderId = tenderId;
            // Valeur par défaut pour éviter l'erreur "The Status field is required"
            Offer = new OfferDto
            {
                Status = "Pending"
            };
        }

        public IActionResult OnPost(int tenderId)
        {
            Console.WriteLine("ON POST CREATE OFFER");

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

            int supplierId = 1; // temporaire
            Offer.TenderId = tenderId;

            Offer.WarrantyMonths = 0;

            service.CreateOffer(supplierId, Offer);

            Console.WriteLine("OFFER INSERT DONE");

            return RedirectToPage("/Suppliers/Dashboard");
        }
    }
}
