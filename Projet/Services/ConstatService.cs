using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Projet.Data;
using Projet.Models;

namespace Projet.Services
{
    public class ConstatService : IConstatService
    {
        private readonly DbFactory _dbFactory;
        public ConstatService(DbFactory dbFactory) => _dbFactory = dbFactory;

        public async Task<ConstatTechnique> CreateConstatAsync(ConstatTechnique c)
        {
            const string sql = @"
INSERT INTO Constats (PanneId, TechnicianId, DateConstat, DescriptionDetaillee, DateApparition, Frequence, Nature, SentToResponsable)
VALUES (@PanneId, @TechnicianId, @DateConstat, @DescriptionDetaillee, @DateApparition, @Frequence, @Nature, @SentToResponsable);
SELECT SCOPE_IDENTITY();";

            using var conn = _dbFactory.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PanneId", c.PanneId);
            cmd.Parameters.AddWithValue("@TechnicianId", (object)c.TechnicianId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DateConstat", c.DateConstat);
            cmd.Parameters.AddWithValue("@DescriptionDetaillee", c.DescriptionDetaillee ?? string.Empty);
            cmd.Parameters.AddWithValue("@DateApparition", c.DateApparition);
            cmd.Parameters.AddWithValue("@Frequence", (int)c.Frequence);
            cmd.Parameters.AddWithValue("@Nature", (int)c.Nature);
            cmd.Parameters.AddWithValue("@SentToResponsable", c.SentToResponsable);

            var idObj = await cmd.ExecuteScalarAsync();
            c.Id = Convert.ToInt32(idObj);
            return c;
        }
    }
}