using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Projet.Data;
using Projet.Models;

namespace Projet.Services
{
    public class PanneService : IPanneService
    {
        private readonly DbFactory _dbFactory;

        public PanneService(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<Panne> CreatePanneAsync(Panne p)
        {
            const string sql = @"
INSERT INTO Pannes (ResourceId, DeclaredByUserId, DateDeclared, DescriptionCourte, Status, CreatedAt)
VALUES (@ResourceId, @DeclaredByUserId, @DateDeclared, @DescriptionCourte, @Status, @CreatedAt);
SELECT SCOPE_IDENTITY();";

            using var conn = _dbFactory.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ResourceId", p.ResourceId);
            cmd.Parameters.AddWithValue("@DeclaredByUserId", (object)p.DeclaredByUserId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DateDeclared", p.DateDeclared);
            cmd.Parameters.AddWithValue("@DescriptionCourte", p.DescriptionCourte ?? string.Empty);
            cmd.Parameters.AddWithValue("@Status", (int)p.Status);
            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);

            var idObj = await cmd.ExecuteScalarAsync();
            p.Id = Convert.ToInt32(idObj);
            p.CreatedAt = DateTime.UtcNow;
            return p;
        }

        public async Task<Panne> GetPanneByIdAsync(int id)
        {
            const string sql = @"
SELECT Id, ResourceId, DeclaredByUserId, DateDeclared, DescriptionCourte, Status, CreatedAt, UpdatedAt
FROM Pannes WHERE Id = @Id";

            using var conn = _dbFactory.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var rdr = await cmd.ExecuteReaderAsync();
            if (!await rdr.ReadAsync()) return null;

            return new Panne
            {
                Id = rdr.GetInt32(0),
                ResourceId = rdr.GetInt32(1),
                DeclaredByUserId = rdr.IsDBNull(2) ? null : rdr.GetString(2),
                DateDeclared = rdr.GetDateTime(3),
                DescriptionCourte = rdr.IsDBNull(4) ? null : rdr.GetString(4),
                Status = (PanneStatus)rdr.GetInt32(5),
                CreatedAt = rdr.GetDateTime(6),
                UpdatedAt = rdr.IsDBNull(7) ? null : rdr.GetDateTime(7)
            };
        }

        public async Task<IEnumerable<Panne>> GetPannesAsync(string statusFilter = null)
        {
            // Minimal implementation : retourne toutes les pannes. Ajouter filtres selon besoin.
            const string sql = @"SELECT Id, ResourceId, DeclaredByUserId, DateDeclared, DescriptionCourte, Status, CreatedAt, UpdatedAt FROM Pannes";
            var list = new List<Panne>();
            using var conn = _dbFactory.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            using var rdr = await cmd.ExecuteReaderAsync();
            while (await rdr.ReadAsync())
            {
                list.Add(new Panne
                {
                    Id = rdr.GetInt32(0),
                    ResourceId = rdr.GetInt32(1),
                    DeclaredByUserId = rdr.IsDBNull(2) ? null : rdr.GetString(2),
                    DateDeclared = rdr.GetDateTime(3),
                    DescriptionCourte = rdr.IsDBNull(4) ? null : rdr.GetString(4),
                    Status = (PanneStatus)rdr.GetInt32(5),
                    CreatedAt = rdr.GetDateTime(6),
                    UpdatedAt = rdr.IsDBNull(7) ? null : rdr.GetDateTime(7)
                });
            }
            return list;
        }

        public async Task UpdateStatusAsync(int panneId, PanneStatus status)
        {
            const string sql = @"UPDATE Pannes SET Status = @Status, UpdatedAt = @UpdatedAt WHERE Id = @Id";
            using var conn = _dbFactory.CreateConnection();
            await conn.OpenAsync();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Status", (int)status);
            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@Id", panneId);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}