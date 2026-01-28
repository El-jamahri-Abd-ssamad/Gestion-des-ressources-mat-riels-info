using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Projet.Entities;

namespace Projet.Data
{
    public class InterventionDaoDB
    {
        public int Insert(Intervention it)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Intervention (IdFault, TechnicianId, DateTaken, IsReparable, Outcome, Notes)
                  OUTPUT INSERTED.Id
                  VALUES (@f,@t,@d,@r,@o,@n)", cn))
            {
                cmd.Parameters.AddWithValue("@f", it.IdFault);
                cmd.Parameters.AddWithValue("@t", it.TechnicianId);
                cmd.Parameters.AddWithValue("@d", it.DateTaken);
                cmd.Parameters.AddWithValue("@r", (object)it.IsReparable ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@o", (object)it.Outcome ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@n", (object)it.Notes ?? DBNull.Value);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public Intervention GetById(int id)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdFault, TechnicianId, DateTaken, IsReparable, Outcome, Notes FROM Intervention WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Intervention
                        {
                            Id = (int)rd["Id"],
                            IdFault = (int)rd["IdFault"],
                            TechnicianId = (int)rd["TechnicianId"],
                            DateTaken = (DateTime)rd["DateTaken"],
                            IsReparable = rd["IsReparable"] == DBNull.Value ? null : (bool?)rd["IsReparable"],
                            Outcome = rd["Outcome"] == DBNull.Value ? "" : rd["Outcome"].ToString(),
                            Notes = rd["Notes"] == DBNull.Value ? "" : rd["Notes"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public List<Intervention> GetByFaultId(int faultId)
        {
            var list = new List<Intervention>();
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdFault, TechnicianId, DateTaken, IsReparable, Outcome, Notes FROM Intervention WHERE IdFault=@fid", cn))
            {
                cmd.Parameters.AddWithValue("@fid", faultId);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Intervention
                        {
                            Id = (int)rd["Id"],
                            IdFault = (int)rd["IdFault"],
                            TechnicianId = (int)rd["TechnicianId"],
                            DateTaken = (DateTime)rd["DateTaken"],
                            IsReparable = rd["IsReparable"] == DBNull.Value ? null : (bool?)rd["IsReparable"],
                            Outcome = rd["Outcome"] == DBNull.Value ? "" : rd["Outcome"].ToString(),
                            Notes = rd["Notes"] == DBNull.Value ? "" : rd["Notes"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}