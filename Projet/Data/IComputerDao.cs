using Microsoft.Data.SqlClient;
using Projet.Data;
using WebApplication1.Domain;

namespace WebApplication1.Data
{
    public interface IComputerDao
    {
        void AddComputer(Computer computer);
        Computer GetComputer(string inventoryNumber);
        List<Computer> GetComputers();
        List<Computer> GetComputersByDepartment(int departmentId);
        void UpdateComputer(string inventoryNumber, Computer newComputer);
        void DeleteComputer(string inventoryNumber);
    }
}