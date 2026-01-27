using System.Collections.Generic;

namespace Projet.Models
{
    public class OfferDto
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public int SupplierId { get; set; }

        public decimal TotalPrice { get; set; }
        public int WarrantyMonths { get; set; }
        public string Status { get; set; }

        // utilisé plus tard si tu veux détailler l’offre
        public List<OfferItemDto> Items { get; set; } = new List<OfferItemDto>();
    }
}
