using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Projet.Domain;
using Projet.Domain.Enums;

namespace Projet.Data
{
    public class TenderDaoDB
    {
        public List<Tender> GetAll()
        {
            var list = new List<Tender>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Id, Title, Description, StartDate, EndDate, Status, CreatedBy FROM Tender", cn))
            {
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Tender
                        {
                            Id = (int)rd["Id"],
                            Title = rd["Title"].ToString(),
                            Description = rd["Description"] as string,
                            StartDate = (DateTime)rd["StartDate"],
                            EndDate = (DateTime)rd["EndDate"],
                            Status = Enum.TryParse(rd["Status"].ToString(), out TenderStatus s)
                                        ? s
                                        : TenderStatus.Open,
                            CreatedBy = (int)rd["CreatedBy"]
                        });
                    }
                }
            }

            return list;
        }

        public Tender GetById(int id)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Id, Title, Description, StartDate, EndDate, Status, CreatedBy FROM Tender WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Tender
                        {
                            Id = (int)rd["Id"],
                            Title = rd["Title"].ToString(),
                            Description = rd["Description"] as string,
                            StartDate = (DateTime)rd["StartDate"],
                            EndDate = (DateTime)rd["EndDate"],
                            Status = Enum.TryParse(rd["Status"].ToString(), out TenderStatus s)
                                        ? s
                                        : TenderStatus.Open,
                            CreatedBy = (int)rd["CreatedBy"]
                        };
                    }
                }
            }

            return null;
        }

        public int Insert(Tender t)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Tender (Title, Description, StartDate, EndDate, Status, CreatedBy)
                  OUTPUT INSERTED.Id
                  VALUES (@title,@desc,@sd,@ed,@status,@createdBy)", cn))
            {
                cmd.Parameters.AddWithValue("@title", t.Title);
                cmd.Parameters.AddWithValue("@desc", (object)t.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@sd", t.StartDate);
                cmd.Parameters.AddWithValue("@ed", t.EndDate);
                cmd.Parameters.AddWithValue("@status", t.Status.ToString());
                cmd.Parameters.AddWithValue("@createdBy", t.CreatedBy);

                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public List<TenderItem> GetItemsByTenderId(int tenderId)
        {
            var list = new List<TenderItem>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Id, IdTender, Label, Quantity FROM TenderItem WHERE IdTender=@tid", cn))
            {
                cmd.Parameters.AddWithValue("@tid", tenderId);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new TenderItem
                        {
                            Id = (int)rd["Id"],
                            IdTender = (int)rd["IdTender"],
                            Label = rd["Label"].ToString(),
                            Quantity = (int)rd["Quantity"]
                        });
                    }
                }
            }

            return list;
        }
    }
}
