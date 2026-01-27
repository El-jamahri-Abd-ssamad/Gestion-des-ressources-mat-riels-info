using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;

namespace Projet.Pages.Tenders
{
    public class DetailsModel : PageModel
    {
        public TenderDto Tender { get; set; }

        ITenderService service = new TenderService();

        public void OnGet(int id)
        {
            Tender = service.GetTenderById(id);
        }
    }
}
