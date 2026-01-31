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

        

        BlacklistDaoDB blacklistDao = new BlacklistDaoDB();

        public void CreateOffer(int supplierId, OfferDto dto)
        {
            if (blacklistDao.IsBlacklisted(supplierId))
                throw new Exception("Fournisseur blacklisté");

            Offer o = new Offer
            {
                IdTender = dto.TenderId,
                IdSupplier = supplierId,
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

        public List<OfferDto> GetOffersByTender(int tenderId)
        {
            List<Offer> offers = dao.GetByTender(tenderId);
            List<OfferDto> result = new List<OfferDto>();

            foreach (Offer o in offers)
            {
                result.Add(new OfferDto
                {
                    Id = o.Id,
                    TenderId = o.IdTender,
                    SupplierId = o.IdSupplier,
                    TotalPrice = o.TotalPrice,
                    WarrantyMonths = o.WarrantyMonths,
                    Status = o.Status.ToString()
                });
            }

            return result;
        }


        public void SelectLowestOffer(int tenderId)
        {
            var offers = dao.GetByTenderId(tenderId);

            if (offers.Count == 0)
                return;

            // 1️⃣ trouver le moins disant
            Offer lowest = offers[0];
            foreach (var o in offers)
                if (o.TotalPrice < lowest.TotalPrice)
                    lowest = o;

            // 2️⃣ mettre à jour les statuts
            foreach (var o in offers)
            {
                if (o.Id == lowest.Id)
                    dao.UpdateStatus(o.Id, OfferStatus.Accepted);
                else
                    dao.UpdateStatus(o.Id, OfferStatus.Rejected);
            }

            // 3️⃣ fermer l'appel d’offre
            TenderDaoDB tenderDao = new TenderDaoDB();
            tenderDao.UpdateStatus(tenderId, TenderStatus.Closed);
        }

    }
}
