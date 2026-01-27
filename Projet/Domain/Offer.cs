using System;
using Projet.Domain.Enums;

namespace Projet.Domain
{
    public class Offer
    {
        public int Id { get; set; }
        public int IdTender { get; set; }
        public int IdSupplier { get; set; }
        public decimal TotalPrice { get; set; }
        public int WarrantyMonths { get; set; }
        public OfferStatus Status { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
