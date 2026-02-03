using Projet.Data;
using Projet.Domain;

namespace Projet.Services
{
    public class BesoinService : IBesoinService
    {
        private readonly IBesoinDao _besoinDao;

        public BesoinService(IBesoinDao besoinDao)
        {
            _besoinDao = besoinDao;
        }

        public List<Besoin> GetBesoinsEnvoyes()
        {
            return _besoinDao.GetBesoinsEnvoyes();
        }
    }
}
