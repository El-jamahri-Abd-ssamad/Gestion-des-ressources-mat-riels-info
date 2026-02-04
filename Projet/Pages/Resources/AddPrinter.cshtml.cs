using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using Projet.Domain.enums; // Pour Role
using System;

namespace Projet.Pages.Resources
{
    public class AddPrinterModel : PageModel
    {
        private readonly IPrinterService _printerService;
        private readonly INotificationService _notificationService; // 🔹 Inject notification

        public AddPrinterModel(IPrinterService printerService, INotificationService notificationService)
        {
            _printerService = printerService;
            _notificationService = notificationService; // 🔹 Init notification
        }

        [BindProperty]
        public PrinterDto Printer { get; set; } = new PrinterDto();

        public string ErrorMessage { get; set; } = "";

        public void OnGet()
        {
            Printer.DeliveryDate = DateTime.Now;
            Printer.AssignmentType = "Department";
        }

        public IActionResult OnPost()
        {
            if (Printer == null || string.IsNullOrWhiteSpace(Printer.InventoryNumber))
            {
                ErrorMessage = "Remplissez tous les champs obligatoires.";
                return Page();
            }

            // Ajouter l'imprimante
            bool result = _printerService.AddPrinter(Printer);
            if (result)
            {
                // 🔹 Ajouter une notification pour le responsable des ressources
                string title = "Nouvelle imprimante ajoutée";
                string message = $"Imprimante {Printer.Brand} ({Printer.InventoryNumber}) ajoutée avec succès.";
                _notificationService.AddNotification(title, message, Role.ResponsableRessources);

                return RedirectToPage("./ManagePrinters");
            }

            ErrorMessage = "Erreur lors de l'ajout.";
            return Page();
        }
    }
}
