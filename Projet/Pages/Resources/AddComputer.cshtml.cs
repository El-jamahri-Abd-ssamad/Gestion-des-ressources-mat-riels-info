using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using System;

namespace Projet.Pages.Resources
{
    public class AddComputerModel : PageModel
    {
        private readonly IComputerService _computerService;

        public AddComputerModel(IComputerService computerService)
        {
            _computerService = computerService;
            Computer = new ComputerDto();
        }

        [BindProperty]
        public ComputerDto Computer { get; set; }

        public void OnGet()
        {
            Computer.DeliveryDate = DateTime.Now;
            Computer.AssignmentType = "Department";
        }

        public IActionResult OnPost()
        {
            if (Computer == null ||
                string.IsNullOrWhiteSpace(Computer.InventoryNumber) ||
                string.IsNullOrWhiteSpace(Computer.Brand))
            {
                ModelState.AddModelError("", "Remplissez tous les champs obligatoires.");
                return Page();
            }

            bool result = _computerService.AddComputer(Computer);

            if (result)
            {
                return RedirectToPage("./ManageComputers");
            }

            ModelState.AddModelError("", "Erreur lors de l'ajout de l'ordinateur.");
            return Page();
        }
    }
}