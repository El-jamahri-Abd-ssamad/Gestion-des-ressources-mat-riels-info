using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using System.Collections.Generic;

namespace Projet.Pages.Resources
{
    public class ManageComputersModel : PageModel
    {
        private readonly IComputerService _computerService;

        public ManageComputersModel(IComputerService computerService)
        {
            _computerService = computerService;
        }

        public List<ComputerDto> Computers { get; set; } = new List<ComputerDto>();  // ← AJOUT

        public void OnGet()
        {
            Computers = _computerService.GetAllComputers();
        }

        public IActionResult OnPostDelete(string inventoryNumber)
        {
            if (string.IsNullOrWhiteSpace(inventoryNumber))
            {
                return Page();
            }

            bool result = _computerService.DeleteComputer(inventoryNumber);
            return RedirectToPage();
        }
    }
}