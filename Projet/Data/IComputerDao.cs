using Projet.Domain;

namespace Projet.Data
{
    public interface IComputerDao
    {
        int Insert(Computer computer);
        Computer GetById(int id);
        Computer GetByInventoryNumber(string inventoryNumber);
        List<Computer> GetAll();
        List<Computer> GetByDepartment(int departmentId);
        void Update(Computer computer);
        void Delete(string inventoryNumber);
    }
}