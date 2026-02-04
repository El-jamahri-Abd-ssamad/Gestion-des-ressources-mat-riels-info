using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Domain;
using Projet.Services;
using System;

namespace Projet.Pages.Blacklist
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public BlacklistEntry Entry { get; set; }

        IBlacklistService service = new BlacklistService();

        public IActionResult OnPost()
        {
            Entry.Date = DateTime.Now;
            Entry.CreatedBy = 1; // admin temporaire

            service.AddToBlacklist(Entry);
            return RedirectToPage("Index");
        }
    }
}
