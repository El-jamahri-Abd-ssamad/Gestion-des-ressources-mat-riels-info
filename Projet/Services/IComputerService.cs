using Projet.Models;
using System.Collections.Generic;

namespace Projet.Services
{
    public interface IComputerService
    {
        bool AddComputer(ComputerDto computer);
        ComputerDto GetComputerByInventoryNumber(string inventoryNumber);
        List<ComputerDto> GetAllComputers();
        List<ComputerDto> GetComputersByDepartment(int departmentId);
        bool UpdateComputer(ComputerDto computer);
        bool DeleteComputer(string inventoryNumber);
    }
}