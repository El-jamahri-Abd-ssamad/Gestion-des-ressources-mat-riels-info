using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using System.Collections.Generic;

namespace Projet.Pages.Resources
{
    public class ManagePrintersModel : PageModel
    {
        private readonly IPrinterService _printerService;

        public ManagePrintersModel(IPrinterService printerService)
        {
            _printerService = printerService;
        }

        public List<PrinterDto> Printers { get; set; }

        public void OnGet()
        {
            Printers = _printerService.GetAllPrinters();
        }

        public IActionResult OnPostDelete(string inventoryNumber)
        {
            if (string.IsNullOrWhiteSpace(inventoryNumber))
            {
                return Page();
            }

            bool result = _printerService.DeletePrinter(inventoryNumber);
            return RedirectToPage();
        }
    }
}