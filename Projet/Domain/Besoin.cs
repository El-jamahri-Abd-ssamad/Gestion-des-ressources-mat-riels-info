using Projet.Domain.enums;

namespace Projet.Domain
{
    public class Besoin
    {
        
        public Besoin()
        {
        }

        public Besoin(int code, int departementId, DateTime dateSoumission, string typeRessource, string description, int quantite, bool valideParChef, StatutBesoin statut)
        {
            Code = code;
            DepartementId = departementId;
            DateSoumission = dateSoumission;
            TypeRessource = typeRessource;
            Description = description;
            Quantite = quantite;
            ValideParChef = valideParChef;
            Statut = statut;
        }

        public int Code { get; set; }

        public int DepartementId { get; set; }
        public DateTime DateSoumission { get; set; }
        public string TypeRessource { get; set; } // Ordinateur / Imprimante
        public string Description { get; set; }
        public int Quantite { get; set; }

        public bool ValideParChef { get; set; }
        public StatutBesoin Statut { get; set; }
        public int? AppelOffreId { get; set; }
    }
}
