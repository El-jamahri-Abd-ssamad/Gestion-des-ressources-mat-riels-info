using System;

namespace Projet.Models
{
    public class DecisionResponsable
    {
        public int Id { get; set; }
        public int ConstatId { get; set; }
        public string ResponsableId { get; set; }
        public DateTime DateDecision { get; set; }
        public DecisionType DecisionType { get; set; }
        public string Reason { get; set; }
        public bool WarrantyValid { get; set; }
    }
}