using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class OfferDto
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public int SupplierId { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal TotalPrice { get; set; }
        public int WarrantyMonths { get; set; }
        public string Status { get; set; }

        // pour détailler l’offre
        //public List<OfferItemDto> Items { get; set; } = new List<OfferItemDto>();
    }
}
