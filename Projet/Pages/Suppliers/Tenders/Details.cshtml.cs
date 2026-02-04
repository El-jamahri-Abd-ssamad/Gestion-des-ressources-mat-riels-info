using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;

namespace Projet.Pages.Suppliers.Tenders
{
    public class DetailsModel : PageModel
    {
        public TenderDto Tender { get; set; }
        public List<OfferDto> Offers { get; set; }

        public bool IsSupplier => true; // temporaire
        public bool IsAdmin => true;
        public bool CanSubmitOffer { get; set; }

        ITenderService tenderService = new TenderService();
        IOfferService offerService = new OfferService();
        IBlacklistService blacklistService = new BlacklistService();

        public void OnGet(int id)
        {
            Tender = tenderService.GetTenderById(id);
            Offers = offerService.GetOffersByTender(id);

            int supplierId = 1;
            CanSubmitOffer = Tender.Status.Equals("Open")
                             && !blacklistService.IsBlacklisted(supplierId);
        }

        public IActionResult OnPost(int id)
        {
            offerService.SelectLowestOffer(id);
            return RedirectToPage("Index");
        }
    }
}
