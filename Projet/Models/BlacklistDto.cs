using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class BlacklistDto
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Le motif est obligatoire")]
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
