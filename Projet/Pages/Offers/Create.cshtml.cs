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
            Offer = new OfferDto
            {
                TenderId = tenderId
            };
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("ON POST CREATE OFFER");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("MODEL STATE INVALID");
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
