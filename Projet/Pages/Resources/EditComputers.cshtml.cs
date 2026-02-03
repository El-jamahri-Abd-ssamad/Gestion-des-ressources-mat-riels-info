using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;

namespace Projet.Pages.Resources
{
    public class EditComputerModel : PageModel
    {
        private readonly IComputerService _computerService;

        public EditComputerModel(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [BindProperty]
        public ComputerDto Computer { get; set; } = new ComputerDto();  // ← AJOUT

        public string ErrorMessage { get; set; } = "";  // ← AJOUT

        public IActionResult OnGet(string inventoryNumber)
        {
            if (string.IsNullOrWhiteSpace(inventoryNumber))
            {
                return RedirectToPage("./ManageComputers");
            }

            Computer = _computerService.GetComputerByInventoryNumber(inventoryNumber);

            if (Computer == null)
            {
                return RedirectToPage("./ManageComputers");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Computer == null ||
                string.IsNullOrWhiteSpace(Computer.InventoryNumber) ||
                string.IsNullOrWhiteSpace(Computer.Brand))
            {
                ErrorMessage = "Remplissez tous les champs obligatoires.";
                return Page();
            }

            bool result = _computerService.UpdateComputer(Computer);

            if (result)
            {
                return RedirectToPage("./ManageComputers");
            }

            ErrorMessage = "Erreur lors de la modification.";
            return Page();
        }
    }
}