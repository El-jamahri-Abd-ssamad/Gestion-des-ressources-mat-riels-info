using Projet.Domain;
using Projet.Models;

namespace Projet.Services
{
    public interface IChefDepartementService
    {
        public Departement GetDepartementChef(string username);
        public List<BesoinChefDto> GetBesoins(int departementId);
        public void ValiderBesoin(int besoinId);
        public void RejeterBesoin(int besoinId);
        public void UpdateBesoin(BesoinChefDto b);
        public void DeleteBesoin(int id);

    }
}
