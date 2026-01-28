using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Entities;
using Projet.Services;

namespace Projet.Pages.Maintenance
{
    public class CreateReportModel : PageModel
    {
        private readonly IFaultService _faultService;

        public CreateReportModel(IFaultService faultService)
        {
            _faultService = faultService;
            Report = new TechnicalReport();
        }

        [BindProperty]
        public TechnicalReport Report { get; set; }

        public void OnGet(int interventionId)
        {
            Report.IdIntervention = interventionId;
            Report.DateOccurred = System.DateTime.Now;
        }

        public IActionResult OnPost()
        {
            if (Report == null || Report.IdIntervention == 0 || string.IsNullOrWhiteSpace(Report.DetailedDescription))
            {
                ModelState.AddModelError("", "Remplissez le constat.");
                return Page();
            }

            int id = _faultService.AddTechnicalReport(Report);

            // mettre à jour le status de la panne sur 'SentToSupplier' pour suivi
            // Récupération simple : récupérer l'intervention pour obtenir FaultId
            var intervention = _faultService.GetInterventionById(Report.IdIntervention);
            if (intervention != null)
            {
                _faultService.UpdateFaultStatus(intervention.IdFault, "SentToSupplier");
            }

            return RedirectToPage("./ViewReports");
        }
    }
}