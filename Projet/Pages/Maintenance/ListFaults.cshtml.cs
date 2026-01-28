using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Entities;
using Projet.Services;
using System.Collections.Generic;

namespace Projet.Pages.Maintenance
{
    public class ListFaultsModel : PageModel
    {
        private readonly IFaultService _faultService;

        public ListFaultsModel(IFaultService faultService)
        {
            _faultService = faultService;
        }

        public List<Fault> Faults { get; set; }

        public void OnGet()
        {
            Faults = _faultService.GetAllFaults();
        }
    }
}