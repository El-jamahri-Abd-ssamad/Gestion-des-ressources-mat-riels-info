using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Projet.Data;
using Projet.Models;

namespace Projet.Services
{
    public class DecisionService : IDecisionService
    {
        private readonly DbFactory _dbFactory;
        public DecisionService(DbFactory dbFactory) => _dbFactory = dbFactory;

        public async Task<DecisionResponsable> CreateDecisionAsync(DecisionResponsable d)
        {
            const string sql = @"
INSERT INTO Decisions (ConstatId, ResponsableId, DateDecision, DecisionType, Reason, WarrantyValid)
VALUES (@ConstatId, @ResponsableId, @DateDecision, @DecisionType, @Reason, @WarrantyValid);
SELECT SCOPE_IDENTITY();";

            using var conn = _dbFactory.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ConstatId", d.ConstatId);
            cmd.Parameters.AddWithValue("@ResponsableId", (object)d.ResponsableId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DateDecision", d.DateDecision);
            cmd.Parameters.AddWithValue("@DecisionType", (int)d.DecisionType);
            cmd.Parameters.AddWithValue("@Reason", d.Reason ?? string.Empty);
            cmd.Parameters.AddWithValue("@WarrantyValid", d.WarrantyValid);

            var idObj = await cmd.ExecuteScalarAsync();
            d.Id = Convert.ToInt32(idObj);
            return d;
        }
    }
}