using System;
using Microsoft.Data.SqlClient;
using Projet.Domain;

namespace Projet.Data
{
    public class SupplierDaoDB
    {
        public int Register(Supplier s)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Supplier (IdUser, CompanyName, IsBlacklisted, BlacklistReason)
                  OUTPUT INSERTED.Id
                  VALUES (@u,@c,@b,@r)", cn))
            {
                cmd.Parameters.AddWithValue("@u", s.IdUser);
                cmd.Parameters.AddWithValue("@c", s.CompanyName);
                cmd.Parameters.AddWithValue("@b", s.IsBlacklisted);
                cmd.Parameters.AddWithValue("@r", (object)s.BlacklistReason ?? DBNull.Value);

                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public Supplier GetByUserId(int userId)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdUser, CompanyName, IsBlacklisted, BlacklistReason
                  FROM Supplier
                  WHERE IdUser=@u", cn))
            {
                cmd.Parameters.AddWithValue("@u", userId);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Supplier
                        {
                            Id = (int)rd["Id"],
                            IdUser = (int)rd["IdUser"],
                            CompanyName = rd["CompanyName"].ToString(),
                            IsBlacklisted = (bool)rd["IsBlacklisted"],
                            BlacklistReason = rd["BlacklistReason"] == DBNull.Value
                                                ? null
                                                : rd["BlacklistReason"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public Supplier GetById(int id)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdUser, CompanyName, IsBlacklisted, BlacklistReason
                  FROM Supplier
                  WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Supplier
                        {
                            Id = (int)rd["Id"],
                            IdUser = (int)rd["IdUser"],
                            CompanyName = rd["CompanyName"].ToString(),
                            IsBlacklisted = (bool)rd["IsBlacklisted"],
                            BlacklistReason = rd["BlacklistReason"] == DBNull.Value
                                                ? null
                                                : rd["BlacklistReason"].ToString()
                        };
                    }
                }
            }

            return null;
        }
    }
}
