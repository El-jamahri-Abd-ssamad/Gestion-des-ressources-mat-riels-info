using Microsoft.Data.SqlClient;
using Projet.Domain;
using Projet.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Projet.Data
{
    public class OfferDaoDB
    {
        // =========================
        // INSERT
        // =========================
        public int Insert(Offer o)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Offer 
                  (IdTender, IdSupplier, TotalPrice, WarrantyMonths, Status, SubmissionDate)
                  OUTPUT INSERTED.Id
                  VALUES (@t,@s,@p,@w,@st,@d)", cn))
            {
                cmd.Parameters.AddWithValue("@t", o.IdTender);
                cmd.Parameters.AddWithValue("@s", o.IdSupplier);
                cmd.Parameters.AddWithValue("@p", o.TotalPrice);
                cmd.Parameters.AddWithValue("@w", o.WarrantyMonths);
                cmd.Parameters.AddWithValue("@st", o.Status.ToString());
                cmd.Parameters.AddWithValue("@d", o.SubmissionDate);

                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // =========================
        // GET ALL
        // =========================
        public List<Offer> GetAll()
        {
            var list = new List<Offer>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdTender, IdSupplier, TotalPrice, WarrantyMonths, Status, SubmissionDate
                  FROM Offer", cn))
            {
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapOffer(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // GET BY SUPPLIER
        // =========================
        public List<Offer> GetBySupplierId(int supplierId)
        {
            var list = new List<Offer>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdTender, IdSupplier, TotalPrice, WarrantyMonths, Status, SubmissionDate
                  FROM Offer
                  WHERE IdSupplier=@s", cn))
            {
                cmd.Parameters.AddWithValue("@s", supplierId);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapOffer(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // GET BY TENDER
        // =========================
        public List<Offer> GetByTender(int tenderId)
        {
            var list = new List<Offer>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdTender, IdSupplier, TotalPrice, WarrantyMonths, Status, SubmissionDate
                  FROM Offer
                  WHERE IdTender=@t", cn))
            {
                cmd.Parameters.AddWithValue("@t", tenderId);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapOffer(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // MAPPING CENTRALISÉ
        // =========================
        private Offer MapOffer(SqlDataReader rd)
        {
            return new Offer
            {
                Id = (int)rd["Id"],
                IdTender = (int)rd["IdTender"],
                IdSupplier = (int)rd["IdSupplier"],
                TotalPrice = Convert.ToDecimal(rd["TotalPrice"]),
                WarrantyMonths = (int)rd["WarrantyMonths"],
                Status = Enum.TryParse(rd["Status"].ToString(), out OfferStatus s)
                            ? s
                            : OfferStatus.Submitted,
                SubmissionDate = (DateTime)rd["SubmissionDate"]
            };
        }

        public List<Offer> GetByTenderId(int tenderId)
        {
            var list = new List<Offer>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Offer WHERE IdTender=@t", cn))
            {
                cmd.Parameters.AddWithValue("@t", tenderId);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(MapOffer(rd));
                }
            }
            return list;
        }

        public void UpdateStatus(int offerId, OfferStatus status)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Offer SET Status=@s WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@s", status.ToString());
                cmd.Parameters.AddWithValue("@id", offerId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
