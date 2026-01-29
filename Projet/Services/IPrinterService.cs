using Projet.Models;
using System.Collections.Generic;

namespace Projet.Services
{
    public interface IPrinterService
    {
        bool AddPrinter(PrinterDto printer);
        PrinterDto GetPrinterByInventoryNumber(string inventoryNumber);
        List<PrinterDto> GetAllPrinters();
        List<PrinterDto> GetPrintersByDepartment(int departmentId);
        bool UpdatePrinter(PrinterDto printer);
        bool DeletePrinter(string inventoryNumber);
    }
}