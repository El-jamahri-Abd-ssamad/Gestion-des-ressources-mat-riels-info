using Projet.Domain.enums;
using Projet.Domain.Enums; // pour l'enum Role
using System;

namespace Projet.Domain
{
    public class Notification
    {
        public int Id { get; set; }                       // correspond à la colonne Id
        public string Message { get; set; } = "";         // correspond à la colonne Message
        public Role DestinataireRole { get; set; }        // correspond à DestinataireRole
        public DateTime DateCreation { get; set; }        // correspond à DateCreation
        public bool EstLue { get; set; } = false;        // correspond à EstLue
    }
}
