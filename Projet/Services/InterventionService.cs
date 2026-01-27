using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Projet.Data;
using Projet.Models;

namespace Projet.Services
{
    public class InterventionService : IInterventionService
    {
        private readonly DbFactory _dbFactory;
        public InterventionService(DbFactory dbFactory) => _dbFactory = dbFactory;

        public async Task<Intervention> CreateInterventionAsync(Intervention i)
        {
            const string sql = @"
INSERT INTO Interventions (PanneId, TechnicianId, DateIntervention, ActionsTaken, IsRepairable, ResultSummary)
VALUES (@PanneId, @TechnicianId, @DateIntervention, @ActionsTaken, @IsRepairable, @ResultSummary);
SELECT SCOPE_IDENTITY();";

            using var conn = _dbFactory.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PanneId", i.PanneId);
            cmd.Parameters.AddWithValue("@TechnicianId", (object)i.TechnicianId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DateIntervention", i.DateIntervention);
            cmd.Parameters.AddWithValue("@ActionsTaken", i.ActionsTaken ?? string.Empty);
            cmd.Parameters.AddWithValue("@IsRepairable", (object)i.IsRepairable ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ResultSummary", i.ResultSummary ?? string.Empty);

            var idObj = await cmd.ExecuteScalarAsync();
            i.Id = System.Convert.ToInt32(idObj);
            return i;
        }

        public async Task<IEnumerable<Intervention>> GetInterventionsByPanneAsync(int panneId)
        {
            const string sql = @"SELECT Id, PanneId, TechnicianId, DateIntervention, ActionsTaken, IsRepairable, ResultSummary FROM Interventions WHERE PanneId = @PanneId";
            var list = new List<Intervention>();
            using var conn = _dbFactory.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PanneId", panneId);
            using var rdr = await cmd.ExecuteReaderAsync();
            while (await rdr.ReadAsync())
            {
                list.Add(new Intervention
                {
                    Id = rdr.GetInt32(0),
                    PanneId = rdr.GetInt32(1),
                    TechnicianId = rdr.IsDBNull(2) ? null : rdr.GetString(2),
                    DateIntervention = rdr.GetDateTime(3),
                    ActionsTaken = rdr.IsDBNull(4) ? null : rdr.GetString(4),
                    IsRepairable = rdr.IsDBNull(5) ? (bool?)null : rdr.GetBoolean(5),
                    ResultSummary = rdr.IsDBNull(6) ? null : rdr.GetString(6)
                });
            }
            return list;
        }
    }
}