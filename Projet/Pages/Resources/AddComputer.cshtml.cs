using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projet.Models;
using Projet.Services;
using Projet.Domain.enums; // pour le Role
using System;

namespace Projet.Pages.Resources
{
    public class AddComputerModel : PageModel
    {
        private readonly IComputerService _computerService;
        private readonly INotificationService _notificationService; // 🔹 Ajouter le service

        public AddComputerModel(IComputerService computerService,
                                INotificationService notificationService) // 🔹 Injecter le service
        {
            _computerService = computerService;
            _notificationService = notificationService;
        }

        [BindProperty]
        public ComputerDto Computer { get; set; } = new ComputerDto();

        public string ErrorMessage { get; set; } = "";

        public void OnGet()
        {
            // Valeurs par défaut pour un nouvel ordinateur
            Computer.DeliveryDate = DateTime.Now;
            Computer.AssignmentType = "Department";
        }

        public IActionResult OnPost()
        {
            // Vérification des champs obligatoires
            if (Computer == null ||
                string.IsNullOrWhiteSpace(Computer.InventoryNumber) ||
                string.IsNullOrWhiteSpace(Computer.Brand) ||
                string.IsNullOrWhiteSpace(Computer.CPU) ||
                string.IsNullOrWhiteSpace(Computer.RAM) ||
                string.IsNullOrWhiteSpace(Computer.HardDrive) ||
                string.IsNullOrWhiteSpace(Computer.Screen))
            {
                ErrorMessage = "Veuillez remplir tous les champs obligatoires.";
                return Page();
            }

            // Vérifier si le numéro d'inventaire existe déjà
            var existing = _computerService.GetComputerByInventoryNumber(Computer.InventoryNumber);
            if (existing != null)
            {
                ErrorMessage = $"Un ordinateur avec le numéro d'inventaire {Computer.InventoryNumber} existe déjà.";
                return Page();
            }

            // Ajouter l'ordinateur
            bool result = _computerService.AddComputer(Computer);
            if (result)
            {
                // 🔹 AJOUTER LA NOTIFICATION
                _notificationService.AddNotification(
                    title: "Nouvel ordinateur ajouté",
                    message: $"L'ordinateur {Computer.InventoryNumber} ({Computer.Brand}) a été ajouté avec succès.",
                    destinataireRole: Role.ResponsableRessources // affichage côté Responsable
                );

                return RedirectToPage("./ManageComputers");
            }

            // En cas d'erreur non prévue
            ErrorMessage = "Erreur lors de l'ajout de l'ordinateur.";
            return Page();
        }
    }
}
