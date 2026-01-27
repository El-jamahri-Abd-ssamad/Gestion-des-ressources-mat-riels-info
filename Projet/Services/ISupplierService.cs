using System.Collections.Generic;
using Projet.Models;

namespace Projet.Services
{
    public interface ISupplierService
    {
        List<OfferDto> GetAllOffers();
    }
}
