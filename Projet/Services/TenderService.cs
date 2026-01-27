using System.Collections.Generic;
using Projet.Data;
using Projet.Domain;
using Projet.Domain.Enums;
using Projet.Models;

namespace Projet.Services
{
    public class TenderService : ITenderService
    {
        TenderDaoDB dao = new TenderDaoDB();

        public List<TenderDto> GetAllTenders()
        {
            var result = new List<TenderDto>();
            var tenders = dao.GetAll();

            foreach (var t in tenders)
            {
                result.Add(new TenderDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate
                });
            }
            return result;
        }

        public TenderDto GetTenderById(int id)
        {
            var t = dao.GetById(id);
            if (t == null) return null;

            return new TenderDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                StartDate = t.StartDate,
                EndDate = t.EndDate
            };
        }

       

        public void CreateTender(TenderDto dto, int createdBy)
        {
            Tender t = new Tender
            {
                Title = dto.Title,
                Description = dto.Description,
                StartDate = dto.StartDate.Value,
                EndDate = dto.EndDate.Value,
                Status = TenderStatus.Open,
                CreatedBy = createdBy
            };

            dao.Insert(t);
        }
    }
}
