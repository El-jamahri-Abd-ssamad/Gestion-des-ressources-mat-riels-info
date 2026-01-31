using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using System.Collections.Generic;

namespace Projet.Pages.Suppliers
{
    public class TendersModel : PageModel
    {
        public List<TenderDto> Tenders { get; set; }

        ITenderService service = new TenderService();

        public void OnGet()
        {
            // uniquement les appels d’offres ouverts
            Tenders = service.GetAllTenders();
        }
    }
}
