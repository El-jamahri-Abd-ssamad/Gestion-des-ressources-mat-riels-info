namespace Projet.Models
{
    public class BesoinChefDto
    {
        public BesoinChefDto(int id, string typeRessource, string description, int quantite, bool valide, DateTime dateSoumission)
        {
            Code = id;
            TypeRessource = typeRessource;
            Description = description;
            Quantite = quantite;
            Valide = valide;
            DateSoumission = dateSoumission;
        }
        public BesoinChefDto() { }

        public int Code { get; set; }
        public string TypeRessource { get; set; }
        public string Description { get; set; }
        public int Quantite { get; set; }
        public bool Valide { get; set; }
        public DateTime DateSoumission { get; set; }
    }
}
