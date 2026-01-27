using System;
using System.Collections.Generic;
using Projet.Domain.Enums;

namespace Projet.Domain
{
    public class Tender
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TenderStatus Status { get; set; }
        public int CreatedBy { get; set; }
        public List<TenderItem> Items { get; set; } = new List<TenderItem>();
    }
}
