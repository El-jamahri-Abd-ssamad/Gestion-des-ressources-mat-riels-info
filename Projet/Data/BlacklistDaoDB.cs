using Microsoft.Data.SqlClient;
using Projet.Domain;
using System.Collections.Generic;

namespace Projet.Data
{
    public class BlacklistDaoDB
    {
        public void Insert(BlacklistEntry entry)
        {
            using SqlConnection cn = DbFactory.GetConnection();
            using SqlCommand cmd = new SqlCommand(
                @"INSERT INTO BlacklistEntry (IdSupplier, Reason, Date, CreatedBy)
                    VALUES (@s,@r,GETDATE(),@u)", cn);

            cmd.Parameters.AddWithValue("@s", entry.IdSupplier);
            cmd.Parameters.AddWithValue("@r", entry.Reason);
            cmd.Parameters.AddWithValue("@d", entry.Date);
            cmd.Parameters.AddWithValue("@u", entry.CreatedBy);

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public bool IsBlacklisted(int supplierId)
        {
            using SqlConnection cn = DbFactory.GetConnection();
            using SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*) FROM BlacklistEntry WHERE IdSupplier=@s", cn);

            cmd.Parameters.AddWithValue("@s", supplierId);
            cn.Open();

            return (int)cmd.ExecuteScalar() > 0;
        }

        public List<BlacklistEntry> GetAll()
        {
            var list = new List<BlacklistEntry>();

            using SqlConnection cn = DbFactory.GetConnection();
            using SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdSupplier, Reason, Date, CreatedBy
                  FROM BlacklistEntry", cn);

            cn.Open();
            using var rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new BlacklistEntry
                {
                    Id = (int)rd["Id"],
                    IdSupplier = (int)rd["IdSupplier"],
                    Reason = rd["Reason"].ToString(),
                    Date = (DateTime)rd["Date"],
                    CreatedBy = (int)rd["CreatedBy"]
                });
            }

            return list;
        }
    }
}
