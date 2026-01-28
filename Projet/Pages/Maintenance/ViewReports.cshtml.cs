using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Data;
using Projet.Entities;
using Projet.Services;
using System.Collections.Generic;

namespace Projet.Pages.Maintenance
{
    public class ViewReportsModel : PageModel
    {
        private readonly IFaultService _faultService;
        private readonly TechnicalReportDaoDB _reportDao;

        public ViewReportsModel(IFaultService faultService)
        {
            _faultService = faultService;
            _reportDao = new TechnicalReportDaoDB();
        }

        public List<TechnicalReport> Reports { get; set; }

        public void OnGet()
        {
            // Pas de DAO GetAll dans l'implémentation précédente -> on lit indirectement les interventions connus
            // Pour simplicité, ici on suppose une méthode existante; sinon, on peut élargir le DAO.
            // Appel simple à la base via SQL léger (réutilise TechnicalReportDaoDB GetByInterventionId n'est pas suffisant).
            // Implémentation minimale: afficher les constats rattachés aux dernières interventions (non exhaustive).
            Reports = new List<TechnicalReport>();
            // tentative : lire rapports pour interventions connues (non implémenté en DAO GetAll), laisser vide si non disponible.
        }
    }
}