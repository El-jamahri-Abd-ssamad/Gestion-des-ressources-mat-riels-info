using Projet.Domain.enums;

namespace Projet.Domain
{
    public class Notification
    {
        public Notification(int id, string message, DateTime dateCreation, bool estLue, Role roleCible)
        {
            Id = id;
            Message = message;
            DateCreation = dateCreation;
            EstLue = estLue;
            RoleCible = roleCible;
        }

        public Notification() { }

        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreation { get; set; }
        public bool EstLue { get; set; }
        public Role RoleCible { get; set; }
    }
}
