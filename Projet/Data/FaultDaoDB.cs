using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Projet.Entities;

namespace Projet.Data
{
    public class FaultDaoDB
    {
        public int Insert(Fault f)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Fault (IdResource, DeclaredBy, DateDeclared, Description, Status)
                  OUTPUT INSERTED.Id
                  VALUES (@res,@decl,@date,@desc,@status)", cn))
            {
                cmd.Parameters.AddWithValue("@res", f.IdResource);
                cmd.Parameters.AddWithValue("@decl", f.DeclaredBy);
                cmd.Parameters.AddWithValue("@date", f.DateDeclared);
                cmd.Parameters.AddWithValue("@desc", f.Description);
                cmd.Parameters.AddWithValue("@status", f.Status);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public Fault GetById(int id)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdResource, DeclaredBy, DateDeclared, Description, Status
                  FROM Fault WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Fault
                        {
                            Id = (int)rd["Id"],
                            IdResource = (int)rd["IdResource"],
                            DeclaredBy = (int)rd["DeclaredBy"],
                            DateDeclared = (DateTime)rd["DateDeclared"],
                            Description = rd["Description"].ToString(),
                            Status = rd["Status"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public List<Fault> GetByResourceId(int resourceId)
        {
            var list = new List<Fault>();
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdResource, DeclaredBy, DateDeclared, Description, Status
                  FROM Fault WHERE IdResource=@rid ORDER BY DateDeclared DESC", cn))
            {
                cmd.Parameters.AddWithValue("@rid", resourceId);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Fault
                        {
                            Id = (int)rd["Id"],
                            IdResource = (int)rd["IdResource"],
                            DeclaredBy = (int)rd["DeclaredBy"],
                            DateDeclared = (DateTime)rd["DateDeclared"],
                            Description = rd["Description"].ToString(),
                            Status = rd["Status"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<Fault> GetAll()
        {
            var list = new List<Fault>();
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdResource, DeclaredBy, DateDeclared, Description, Status FROM Fault ORDER BY DateDeclared DESC", cn))
            {
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Fault
                        {
                            Id = (int)rd["Id"],
                            IdResource = (int)rd["IdResource"],
                            DeclaredBy = (int)rd["DeclaredBy"],
                            DateDeclared = (DateTime)rd["DateDeclared"],
                            Description = rd["Description"].ToString(),
                            Status = rd["Status"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void UpdateStatus(int id, string status)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Fault SET Status=@status WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}