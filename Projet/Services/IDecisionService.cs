using System.Threading.Tasks;
using Projet.Models;

namespace Projet.Services
{
    public interface IDecisionService
    {
        Task<DecisionResponsable> CreateDecisionAsync(DecisionResponsable d);
    }
}