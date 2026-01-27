using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    // DTO de base pour les ressources
    public abstract class ResourceDto
    {
        [Required(ErrorMessage = "Le numéro d'inventaire est obligatoire")]
        [StringLength(50, ErrorMessage = "Le numéro d'inventaire ne peut pas dépasser 50 caractères")]
        public string InventoryNumber { get; set; }

        [Required(ErrorMessage = "La marque est obligatoire")]
        [StringLength(100, ErrorMessage = "La marque ne peut pas dépasser 100 caractères")]
        public string Brand { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeliveryDate { get; set; }

        public int? SupplierId { get; set; }

        [Required(ErrorMessage = "L'affectation est obligatoire")]
        public string AssignedTo { get; set; }

        [Required(ErrorMessage = "Le type d'affectation est obligatoire")]
        public string AssignmentType { get; set; } // "Teacher" ou "Department"

        public int? DepartmentId { get; set; }

        protected ResourceDto()
        {
            InventoryNumber = string.Empty;
            Brand = string.Empty;
            AssignedTo = string.Empty;
            AssignmentType = "Department";
        }

        public abstract string GetResourceType();
    
    }
}