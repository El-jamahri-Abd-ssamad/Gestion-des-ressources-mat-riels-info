using Projet.Domain.enums;

namespace Projet.Domain
{
    public class Besoin
    {
        public int Code { get; set; }
        public int DepartementId { get; set; }
        public string TypeRessource { get; set; }
        public int Quantite { get; set; }
        public StatutBesoin Statut { get; set; }
        public int? AppelOffreId { get; set; } // Nullable pour plus tard
        public DateTime DateCreation { get; set; }
    }
}