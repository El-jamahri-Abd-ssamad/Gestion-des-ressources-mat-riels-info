using System.Threading.Tasks;
using Projet.Models;

namespace Projet.Services
{
    public interface IConstatService
    {
        Task<ConstatTechnique> CreateConstatAsync(ConstatTechnique c);
    }
}