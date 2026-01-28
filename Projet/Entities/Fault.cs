using System;

namespace Projet.Entities
{
    public class Fault
    {
        public int Id { get; set; }
        public int IdResource { get; set; }
        public int DeclaredBy { get; set; }
        public DateTime DateDeclared { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Declared, InProgress, SentToSupplier, Repaired, Replaced

        public Fault()
        {
            Id = 0;
            IdResource = 0;
            DeclaredBy = 0;
            DateDeclared = DateTime.Now;
            Description = "";
            Status = "Declared";
        }

        public Fault(int id, int idResource, int declaredBy, DateTime dateDeclared, string description, string status)
        {
            Id = id;
            IdResource = idResource;
            DeclaredBy = declaredBy;
            DateDeclared = dateDeclared;
            Description = description;
            Status = status;
        }

        public override string ToString()
        {
            return $@"Id {Id} Resource {IdResource} DeclaredBy {DeclaredBy} Date {DateDeclared} Status {Status} Description: {Description}";
        }
    }
}