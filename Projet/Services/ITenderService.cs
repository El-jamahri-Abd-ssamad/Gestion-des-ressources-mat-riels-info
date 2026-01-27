using Projet.Models;
using System.Collections.Generic;

namespace Projet.Services
{
    public interface ITenderService
    {
        void CreateTender(TenderDto dto, int createdBy);
        List<TenderDto> GetAllTenders();
        TenderDto GetTenderById(int id);
    }
}
