using Projet.Domain;

namespace Projet.Data
{
    public interface IPrinterDao
    {
        int Insert(Printer printer);
        Printer GetById(int id);
        Printer GetByInventoryNumber(string inventoryNumber);
        List<Printer> GetAll();
        List<Printer> GetByDepartment(int departmentId);
        void Update(Printer printer);
        void Delete(string inventoryNumber);
    }
}