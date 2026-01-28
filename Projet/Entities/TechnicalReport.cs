using System;

namespace Projet.Entities
{
    public class TechnicalReport
    {
        public int Id { get; set; }
        public int IdIntervention { get; set; }
        public string DetailedDescription { get; set; }
        public DateTime DateOccurred { get; set; }
        public string Frequency { get; set; } // Rare, Frequent, Permanent
        public string Nature { get; set; } // Software, Hardware
        public bool SentToResponsible { get; set; }

        public TechnicalReport()
        {
            Id = 0;
            IdIntervention = 0;
            DetailedDescription = "";
            DateOccurred = DateTime.Now;
            Frequency = "Rare";
            Nature = "Hardware";
            SentToResponsible = true;
        }

        public override string ToString()
        {
            return $@"Id {Id} Intervention {IdIntervention} Date {DateOccurred} Frequency {Frequency} Nature {Nature}";
        }
    }
}