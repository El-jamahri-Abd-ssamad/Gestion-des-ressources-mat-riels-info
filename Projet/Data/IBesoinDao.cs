using Projet.Domain;

namespace Projet.Data
{
    public interface IBesoinDao
    {
        void AddBesoin(Besoin besoin);
        List<Besoin> GetBesoinsByDepartement(int departementId);
        List<Besoin> GetBesoinsValidesByDepartement(int departementId);
        void ValidateBesoin(int besoinId);
        void DeleteBesoin(int besoinId);
        public void RejectBesoin(int besoinId);
        public bool UpdateBesoin(Besoin besoin);
        public Besoin GetBesoinById(int id);
    }
}
