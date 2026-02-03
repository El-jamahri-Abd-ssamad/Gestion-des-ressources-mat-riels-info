using Projet.Data;
using Projet.Domain;
using System.Collections.Generic;

namespace Projet.Services
{
    public class BlacklistService : IBlacklistService
    {
        BlacklistDaoDB dao = new BlacklistDaoDB();

        public void BlacklistSupplier(int supplierId, string reason, int adminId)
        {
            dao.Insert(new BlacklistEntry
            {
                IdSupplier = supplierId,
                Reason = reason,
                CreatedBy = adminId
            });
        }

        public bool IsBlacklisted(int supplierId)
        {
            return dao.IsBlacklisted(supplierId);
        }

        public List<BlacklistEntry> GetAll()
        {
            return dao.GetAll();
        }

        public void AddToBlacklist(BlacklistEntry Entry)
        {
            dao.Insert(new BlacklistEntry
            {
                IdSupplier = Entry.IdSupplier,
                Reason = Entry.Reason,
                Date = Entry.Date,
                CreatedBy = Entry.CreatedBy
            });

        }
    }
}
