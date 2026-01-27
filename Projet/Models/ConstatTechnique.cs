using System;

namespace Projet.Models
{
    public class ConstatTechnique
    {
        public int Id { get; set; }
        public int PanneId { get; set; }
        public string TechnicianId { get; set; }
        public DateTime DateConstat { get; set; }
        public string DescriptionDetaillee { get; set; }
        public DateTime DateApparition { get; set; }
        public Frequence Frequence { get; set; }
        public NaturePanne Nature { get; set; }
        public bool SentToResponsable { get; set; }
    }
}