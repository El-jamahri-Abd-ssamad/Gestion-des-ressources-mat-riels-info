using System.Collections.Generic;
using Projet.Data;
using Projet.Models;

namespace Projet.Services
{
    public class SupplierService : ISupplierService
    {
        OfferDaoDB offerDao = new OfferDaoDB();

        public List<OfferDto> GetAllOffers()
        {
            var result = new List<OfferDto>();
            var offers = offerDao.GetAll();

            foreach (var o in offers)
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
    }
}
