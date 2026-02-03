using Projet.Data;
using Projet.Domain;
using Projet.Domain.enums;
using Projet.Models;

namespace Projet.Services
{
    public class ChefDepartementService : IChefDepartementService
    {
        private readonly IBesoinDao besoinDao;
        private readonly IDepartementDao departementDao;
        //private readonly NotificationDB notificationDb;

        public ChefDepartementService(IBesoinDao besoinDao, IDepartementDao departementDao)
        {
            this.besoinDao = besoinDao;
            this.departementDao = departementDao;
        }

        public Departement GetDepartementChef(string username)
        {
            return departementDao.GetDepartementByChefUsername(username);
        }

        public List<BesoinChefDto> GetBesoins(int departementId)
        {
            var besoins = besoinDao.GetBesoinsByDepartement(departementId);
            var list = new List<BesoinChefDto>();

            foreach (var b in besoins)
            {
                list.Add(new BesoinChefDto
                {
                    Code = b.Code,
                    TypeRessource = b.TypeRessource,
                    Description = b.Description,
                    Quantite = b.Quantite,
                    Valide = b.ValideParChef,
                    DateSoumission = b.DateSoumission,
                    Statut = b.Statut
                });
            }

            return list;
        }
        public void ValiderBesoin(int besoinId)
        {
            besoinDao.ValidateBesoin(besoinId);
        }

        public void RejeterBesoin(int besoinId)
        {
            besoinDao.RejectBesoin(besoinId);
        }
        public void UpdateBesoin(BesoinChefDto b)
        {
            besoinDao.UpdateBesoin(new Projet.Domain.Besoin
            {
                Code = b.Code,
                TypeRessource = b.TypeRessource,
                Description = b.Description,
                Quantite = b.Quantite,
                ValideParChef = false, // le chef ne peut pas valider ici
                Statut= b.Statut
            });
        }

        public void DeleteBesoin(int id)
        {
            besoinDao.DeleteBesoin(id);
        }

        public BesoinChefDto GetBesoinById(int besoinId)
        {
            var b = besoinDao.GetBesoinById(besoinId); // méthode à créer dans BesoinDB
            if (b == null) return null;

            return new BesoinChefDto
            {
                Code = b.Code,
                TypeRessource = b.TypeRessource,
                Description = b.Description,
                Quantite = b.Quantite,
                Valide = b.ValideParChef,
                DateSoumission = b.DateSoumission,
                Statut = b.Statut
            };
        }
        public void EnvoyerBesoinsAuResponsable(int departementId, string nomDepartement)
        {
            besoinDao.EnvoyerBesoinsValides(departementId);
            //notificationDb.Ajouter(new Notification
            //{
            //    Message = $"Nouveaux besoins envoyés par le département {nomDepartement}",
            //    DateCreation = DateTime.Now,
            //    RoleCible = Role.ResponsableRessources
            //});
        }

    }
}
