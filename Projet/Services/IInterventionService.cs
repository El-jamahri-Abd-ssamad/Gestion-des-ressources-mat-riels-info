using System.Collections.Generic;
using System.Threading.Tasks;
using Projet.Models;

namespace Projet.Services
{
    public interface IInterventionService
    {
        Task<Intervention> CreateInterventionAsync(Intervention i);
        Task<IEnumerable<Intervention>> GetInterventionsByPanneAsync(int panneId);
    }
}