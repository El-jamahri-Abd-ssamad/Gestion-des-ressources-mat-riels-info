using Projet.Domain.enums;

namespace Projet.Models
{
    public class BesoinChefDto
    {
        
        public BesoinChefDto() { }

        public BesoinChefDto(int code, string typeRessource, string description, int quantite, bool valide, DateTime dateSoumission, StatutBesoin statut)
        {
            Code = code;
            TypeRessource = typeRessource;
            Description = description;
            Quantite = quantite;
            Valide = valide;
            DateSoumission = dateSoumission;
            Statut = statut;
        }

        public int Code { get; set; }
        public string TypeRessource { get; set; }
        public string Description { get; set; }
        public int Quantite { get; set; }
        public bool Valide { get; set; }
        public DateTime DateSoumission { get; set; }
        public StatutBesoin Statut { get; set; }
       
    }
}
