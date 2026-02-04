using Projet.Domain.enums;
using Projet.Domain.Enums; // pour Role
using System;

namespace Projet.Models
{
    public class Notification
    {
        public int Id { get; set; } // Id pour la base
        public string Title { get; set; } = ""; // titre de la notification
        public string Message { get; set; } = "";
        public Role DestinataireRole { get; set; } // destinataire
        public DateTime DateCreation { get; set; } = DateTime.Now; // date
        public bool EstLue { get; set; } = false; // lue ou non
        public DateTime Date { get; internal set; }
    }
}
