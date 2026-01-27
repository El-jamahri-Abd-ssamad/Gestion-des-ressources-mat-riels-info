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
            Offer = new OfferDto();
        }

        public IActionResult OnPost(int tenderId)
        {
            if (!ModelState.IsValid)
                return Page();

            int supplierId = 1; // temporaire
            Offer.TenderId = tenderId;

            service.CreateOffer(supplierId, Offer);
            return RedirectToPage("/Suppliers/Dashboard");
        }
    }
}
