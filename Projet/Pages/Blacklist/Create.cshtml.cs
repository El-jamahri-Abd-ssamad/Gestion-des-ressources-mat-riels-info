using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projet.Domain;
using Projet.Services;
using System;
using System.Linq;

namespace Projet.Pages.Blacklist
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public BlacklistEntry Entry { get; set; }

        public SelectList Suppliers { get; set; }

        IBlacklistService blacklistService = new BlacklistService();
        ISupplierService supplierService = new SupplierService();

        public void OnGet()
        {
            var suppliers = supplierService.GetAllOffers();
            Suppliers = new SelectList(suppliers, "Id", "Name");
        }

        public IActionResult OnPost()
        {
            Entry.Date = DateTime.Now;
            Entry.CreatedBy = 1;

            blacklistService.AddToBlacklist(Entry);
            return RedirectToPage("Index");
        }
    }
}
