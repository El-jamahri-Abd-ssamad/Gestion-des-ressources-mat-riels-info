using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Domain;
using Projet.Services;
using System.Collections.Generic;

namespace Projet.Pages.Blacklist
{
    public class IndexModel : PageModel
    {
        public List<BlacklistEntry> Blacklist { get; set; }

        IBlacklistService service = new BlacklistService();

        public void OnGet()
        {
            Blacklist = service.GetAll();
        }
    }
}
