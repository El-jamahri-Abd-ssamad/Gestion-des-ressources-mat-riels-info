using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Entities;
using Projet.Services;

namespace Projet.Pages.Maintenance
{
    public class DecisionModel : PageModel
    {
        private readonly IFaultService _faultService;
        private readonly TechnicalReportDaoDB _reportDao;
        private readonly InterventionDaoDB _interventionDao;

        public DecisionModel(IFaultService faultService)
        {
            _faultService = faultService;
            _reportDao = new TechnicalReportDaoDB();
            _interventionDao = new InterventionDaoDB();
        }

        [BindProperty]
        public TechnicalReport Report { get; set; }

        [BindProperty]
        public string Decision { get; set; }

        [BindProperty]
        public string Comments { get; set; }

        public void OnGet(int reportId)
        {
            Report = _reportDao.GetByInterventionId(reportId);
        }

        public IActionResult OnPost()
        {
            if (Report == null)
            {
                ModelState.AddModelError("", "Constat introuvable.");
                return Page();
            }

            // récupérer intervention pour obtenir FaultId
            var intervention = _interventionDao.GetById(Report.IdIntervention);
            if (intervention == null)
            {
                ModelState.AddModelError("", "Intervention introuvable.");
                return Page();
            }

            // Cast intervention en type Intervention pour accéder à IdFault
            if (Decision == "RepairAtSupplier")
            {
                _faultService.UpdateFaultStatus(((Intervention)intervention).IdFault, "SentToSupplier");
            }
            else if (Decision == "Replace")
            {
                _faultService.UpdateFaultStatus(((Intervention)intervention).IdFault, "Replaced");
            }

            return RedirectToPage("./ViewReports");
        }
    }
}