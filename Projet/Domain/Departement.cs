namespace Projet.Domain
{
    public class Departement
    {
        public Departement(int id, string nom, decimal budget, string chefUsername, ICollection<Besoin> besoins)
        {
            Id = id;
            Nom = nom;
            Budget = budget;
            ChefUsername = chefUsername;
            Besoins = besoins;
        }
        public Departement()
        {
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Budget { get; set; }

        public string ChefUsername { get; set; }
        //public ApplicationUser Chef { get; set; }

        public ICollection<Besoin> Besoins { get; set; }
    }
}
