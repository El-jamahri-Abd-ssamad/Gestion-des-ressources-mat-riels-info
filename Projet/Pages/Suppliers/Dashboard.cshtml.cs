using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using System.Collections.Generic;

namespace Projet.Pages.Suppliers
{
    public class DashboardModel : PageModel
    {
        public List<OfferDto> Offers { get; set; }

        IOfferService service = new OfferService();

        public void OnGet()
        {
            int supplierId = 1;
            Offers = service.GetOffersBySupplier(supplierId);
        }
    }
}
