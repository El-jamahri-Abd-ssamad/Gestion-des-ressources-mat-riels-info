using Projet.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class TenderDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "La date de début est obligatoire")]
        public DateTime? StartDate { get; set; }   // ✅ nullable

        [Required(ErrorMessage = "La date de fin est obligatoire")]
        public DateTime? EndDate { get; set; }     // ✅ nullable

        public TenderStatus Status { get; set; }
        

        public TenderDto()
        {
            Title = "?????";
            Description = null;
            StartDate = null;
            EndDate = null;
            Status = TenderStatus.Open;
        }
        public TenderDto(int Id, string Title, string? Description, DateTime? StartDate, DateTime? EndDate,
            TenderStatus Status)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Status = Status;

        }

        public override string ToString()
        {
            return $@"Id: {Id} Title: {Title} Description: {Description}
                    StartDate: {StartDate} EndDate: {EndDate} Status: {Status}";
        }
    }
}

