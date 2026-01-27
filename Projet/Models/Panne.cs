using System;

namespace Projet.Models
{
    public class Panne
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }                // FK vers la table Resource existante
        public string DeclaredByUserId { get; set; }       // FK -> AspNetUsers.Id
        public DateTime DateDeclared { get; set; }
        public string DescriptionCourte { get; set; }
        public PanneStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}