using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class BesoinDto
    {
        [Required]
        public string TypeRessource { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 100)]
        public int Quantite { get; set; }

        public BesoinDto() { }
        public BesoinDto(string typeRessource, string description, int quantite)
        {
            TypeRessource = typeRessource;
            Description = description;
            Quantite = quantite;
        }
    }
}
