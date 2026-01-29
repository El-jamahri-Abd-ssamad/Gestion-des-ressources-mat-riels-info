using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class DepartementDto
    {
        public int Id { get; set; }   // utile pour affichage / update

        [Required(ErrorMessage = "Le nom du département est obligatoire")]
        [StringLength(100)]
        public string Nom { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Budget invalide")]
        public decimal Budget { get; set; }

        // affichage uniquement (pas modifié par formulaire)
        public string ChefName { get; set; }

        public DepartementDto()  
        {
            Nom = "????";
            Budget = 0;
            ChefName = "????";
        }
    }
}
