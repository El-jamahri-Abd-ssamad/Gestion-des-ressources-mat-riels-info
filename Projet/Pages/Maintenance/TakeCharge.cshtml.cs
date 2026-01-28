using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Entities;
using Projet.Services;

namespace Projet.Pages.Maintenance
{
    public class TakeChargeModel : PageModel
    {
        private readonly IFaultService _faultService;

        public TakeChargeModel(IFaultService faultService)
        {
            _faultService = faultService;
            Intervention = new Intervention();
        }

        public Fault Fault { get; set; }

        [BindProperty]
        public Intervention Intervention { get; set; }

        [BindProperty]
        public bool? IsReparable { get; set; }

        public void OnGet(int id)
        {
            Fault = _faultService.GetFaultById(id);
            if (Fault != null)
            {
                Intervention.IdFault = Fault.Id;
            }
        }

        public IActionResult OnPost()
        {
            if (Intervention == null || Intervention.IdFault == 0 || Intervention.TechnicianId == 0)
            {
                ModelState.AddModelError("", "Intervention invalide. Vérifiez TechnicianId et la panne.");
                Fault = _faultService.GetFaultById(Intervention.IdFault);
                return Page();
            }

            Intervention.IsReparable = IsReparable;
            Intervention.DateTaken = System.DateTime.Now;
            int id = _faultService.CreateIntervention(Intervention);

            if (IsReparable == false)
            {
                // rediriger pour créer un constat technique
                return RedirectToPage("./CreateReport", new { interventionId = id });
            }

            // réparable => marquer Réparée
            _faultService.UpdateFaultStatus(Intervention.IdFault, "Repaired");
            return RedirectToPage("./ListFaults");
        }
    }
}