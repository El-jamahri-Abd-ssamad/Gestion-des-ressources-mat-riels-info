using Projet.Domain;
using System.Collections.Generic;

namespace Projet.Services
{
    public interface IBlacklistService
    {
        void BlacklistSupplier(int supplierId, string reason, int adminId);
        bool IsBlacklisted(int supplierId);
        List<BlacklistEntry> GetAll();
        void AddToBlacklist(BlacklistEntry Entry);
    }
}
