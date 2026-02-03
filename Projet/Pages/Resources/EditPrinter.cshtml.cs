using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;

namespace Projet.Pages.Resources
{
    public class EditPrinterModel : PageModel
    {
        private readonly IPrinterService _printerService;

        public EditPrinterModel(IPrinterService printerService)
        {
            _printerService = printerService;
        }

        [BindProperty]
        public PrinterDto Printer { get; set; } = new PrinterDto();

        public string ErrorMessage { get; set; } = "";

        public IActionResult OnGet(string inventoryNumber)
        {
            if (string.IsNullOrWhiteSpace(inventoryNumber))
                return RedirectToPage("./ManagePrinters");

            Printer = _printerService.GetPrinterByInventoryNumber(inventoryNumber);
            if (Printer == null) return RedirectToPage("./ManagePrinters");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Printer == null) return Page();

            bool result = _printerService.UpdatePrinter(Printer);
            if (result) return RedirectToPage("./ManagePrinters");

            ErrorMessage = "Erreur lors de la modification.";
            return Page();
        }
    }
}