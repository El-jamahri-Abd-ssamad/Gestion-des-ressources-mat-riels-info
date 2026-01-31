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
        public int TenderId { get; set; }

        IOfferService service = new OfferService();

        public void OnGet(int tenderId)
        {
            TenderId = tenderId;
        }

        public IActionResult OnPost(int tenderId)
        {
            if (!ModelState.IsValid)
                return Page();

            Offer.TenderId = tenderId;
            service.CreateOffer(1, Offer); // supplier temporaire

            return RedirectToPage("/Suppliers/Dashboard");
        }
    }
}
