using Projet.Domain;

namespace Projet.Data
{
    public interface IDepartementDao
    {
        public Departement GetDepartementByChefUsername(string username);
        Departement GetDepartementById(int id);
        List<Departement> GetDepartements();
        void UpdateBudget(int departementId, decimal newBudget);
    }
}
