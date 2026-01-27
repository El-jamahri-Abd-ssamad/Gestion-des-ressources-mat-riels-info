using System;

namespace Projet.Models
{
    public class Intervention
    {
        public int Id { get; set; }
        public int PanneId { get; set; }                   // FK -> Pannes
        public string TechnicianId { get; set; }           // FK -> AspNetUsers.Id
        public DateTime DateIntervention { get; set; }
        public string ActionsTaken { get; set; }
        public bool? IsRepairable { get; set; }
        public string ResultSummary { get; set; }
    }
}