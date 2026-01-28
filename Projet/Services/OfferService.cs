using Projet.Data;
using Projet.Domain;
using Projet.Domain.Enums;
using Projet.Models;
using System.Collections.Generic;

namespace Projet.Services
{
    public class OfferService : IOfferService
    {
        OfferDaoDB dao = new OfferDaoDB();

        public void CreateOffer(int Idsupplier, OfferDto dto)
        {
            Offer o = new Offer
            {
                IdTender = dto.TenderId,
                IdSupplier = Idsupplier,
                TotalPrice = dto.TotalPrice,
                WarrantyMonths = dto.WarrantyMonths,   
                Status = OfferStatus.Submitted,
                SubmissionDate = DateTime.Now     
            };

            dao.Insert(o);
        }


        public List<OfferDto> GetOffersBySupplier(int supplierId)
        {
            List<Offer> offers = dao.GetBySupplierId(supplierId);
            List<OfferDto> result = new List<OfferDto>();

            foreach (Offer o in offers)
            {
                result.Add(new OfferDto
                {
                    Id = o.Id,
                    TenderId = o.IdTender,
                    TotalPrice = o.TotalPrice,
                    Status = o.Status.ToString()
                });
            }

            return result;
        }
    }
}
