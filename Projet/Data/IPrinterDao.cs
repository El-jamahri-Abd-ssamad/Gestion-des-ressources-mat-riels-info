
using Projet.Domain;

namespace Projet.Data
{
    public interface IPrinterDao
    {
        void AddPrinter(Printer printer);
        Printer GetPrinter(string inventoryNumber);
        List<Printer> GetPrinters();
        List<Printer> GetPrintersByDepartment(int departmentId);
        void UpdatePrinter(string inventoryNumber, Printer newPrinter);
        void DeletePrinter(string inventoryNumber);
    }
}
