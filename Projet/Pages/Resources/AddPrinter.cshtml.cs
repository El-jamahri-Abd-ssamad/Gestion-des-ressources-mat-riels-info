using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using System;

namespace Projet.Pages.Resources
{
    public class AddPrinterModel : PageModel
    {
        private readonly IPrinterService _printerService;

        public AddPrinterModel(IPrinterService printerService)
        {
            _printerService = printerService;
            Printer = new PrinterDto();
        }

        [BindProperty]
        public PrinterDto Printer { get; set; }

        public void OnGet()
        {
            Printer.DeliveryDate = DateTime.Now;
            Printer.AssignmentType = "Department";
        }

        public IActionResult OnPost()
        {
            if (Printer == null ||
                string.IsNullOrWhiteSpace(Printer.InventoryNumber) ||
                string.IsNullOrWhiteSpace(Printer.Brand))
            {
                ModelState.AddModelError("", "Remplissez tous les champs obligatoires.");
                return Page();
            }

            bool result = _printerService.AddPrinter(Printer);

            if (result)
            {
                return RedirectToPage("./ManagePrinters");
            }

            ModelState.AddModelError("", "Erreur lors de l'ajout de l'imprimante.");
            return Page();
        }
    }
}