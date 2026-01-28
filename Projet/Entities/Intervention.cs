using System;

namespace Projet.Entities
{
    public class Intervention
    {
        public int Id { get; set; }
        public int IdFault { get; set; }
        public int TechnicianId { get; set; }
        public DateTime DateTaken { get; set; }
        public bool? IsReparable { get; set; }
        public string Outcome { get; set; }
        public string Notes { get; set; }

        public Intervention()
        {
            Id = 0;
            IdFault = 0;
            TechnicianId = 0;
            DateTaken = DateTime.Now;
            IsReparable = null;
            Outcome = Notes = "";
        }

        public override string ToString()
        {
            return $@"Id {Id} Fault {IdFault} Tech {TechnicianId} Date {DateTaken} Reparable {IsReparable} Outcome {Outcome} Notes:{Notes}";
        }
    }
}