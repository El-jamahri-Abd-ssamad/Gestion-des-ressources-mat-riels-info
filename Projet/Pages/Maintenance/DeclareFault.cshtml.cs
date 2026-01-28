using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Entities;
using Projet.Data;
using Projet.Services;
using System.Collections.Generic;

namespace Projet.Pages.Maintenance
{
    public class DeclareFaultModel : PageModel
    {
        private readonly IFaultService _faultService;
        private readonly ResourceDaoDB _resourceDao;

        public DeclareFaultModel(IFaultService faultService)
        {
            _faultService = faultService;
            _resourceDao = new ResourceDaoDB();
            Fault = new Fault();
        }

        [BindProperty]
        public Fault Fault { get; set; }

        public IEnumerable<SelectListItem> ResourceSelect { get; set; }

        public string Message { get; set; }

        public void OnGet(int? userId)
        {
            Fault.DeclaredBy = userId ?? 0;
            var resources = _resourceDao.GetByAssignedTo(Fault.DeclaredBy);
            var list = new List<SelectListItem>();
            foreach (var r in resources)
            {
                list.Add(new SelectListItem { Value = r.Id.ToString(), Text = $"{r.Label} ({r.Type})" });
            }
            ResourceSelect = list;
        }

        public IActionResult OnPost()
        {
            if (Fault == null || Fault.IdResource == 0 || Fault.DeclaredBy == 0 || string.IsNullOrWhiteSpace(Fault.Description))
            {
                Message = "Tous les champs requis doivent être remplis.";
                return Page();
            }

            int id = _faultService.DeclareFault(Fault);
            Message = $"Panne déclarée (Id={id}).";
            return Page();
        }
    }
}