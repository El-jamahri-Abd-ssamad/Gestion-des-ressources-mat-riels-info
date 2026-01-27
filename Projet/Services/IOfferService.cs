using Projet.Models;
using System.Collections.Generic;

namespace Projet.Services
{
    public interface IOfferService
    {
        void CreateOffer(int supplierId, OfferDto dto);
        List<OfferDto> GetOffersBySupplier(int supplierId);
    }
}
