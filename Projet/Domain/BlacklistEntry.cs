using System;

namespace Projet.Domain
{
    public class BlacklistEntry
    {
        public int Id { get; set; }
        public int IdSupplier { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public int CreatedBy { get; set; }
    }
}
