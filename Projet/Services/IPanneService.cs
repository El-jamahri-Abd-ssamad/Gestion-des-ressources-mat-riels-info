using System.Collections.Generic;
using System.Threading.Tasks;
using Projet.Models;

namespace Projet.Services
{
    public interface IPanneService
    {
        Task<Panne> CreatePanneAsync(Panne p);
        Task<Panne> GetPanneByIdAsync(int id);
        Task<IEnumerable<Panne>> GetPannesAsync(string statusFilter = null);
        Task UpdateStatusAsync(int panneId, PanneStatus status);
    }
}