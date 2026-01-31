using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using System.Collections.Generic;

namespace Projet.Pages.Tenders
{
    public class IndexModel : PageModel
    {
        public List<TenderDto> Tenders { get; set; }
        public bool IsAdmin => true; // temporaire

        ITenderService service = new TenderService();

        public void OnGet()
        {
            Tenders = service.GetAllTenders();
        }
    }
}
