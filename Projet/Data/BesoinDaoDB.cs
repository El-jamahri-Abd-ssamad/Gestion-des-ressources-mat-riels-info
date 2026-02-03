using Microsoft.Data.SqlClient;
using Projet.Domain.enums;

using Projet.Domain;
using System;
using System.Collections.Generic;

namespace Projet.Data
{
    public class BesoinDaoDB : IBesoinDao
    {
        // =========================
        // GET BESOINS ENVOYÉS
        // =========================
        public List<Besoin> GetBesoinsEnvoyes()
        {
            var list = new List<Besoin>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Code, DepartementId, TypeRessource, Quantite, Statut
                  FROM Besoin 
                  WHERE Statut = @Statut", cn))
            {
                cmd.Parameters.AddWithValue("@Statut", (int)StatutBesoin.Envoye);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapBesoin(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // UPDATE STATUT
        // =========================
        public void UpdateStatut(int besoinCode, StatutBesoin statut)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Besoin 
                  SET Statut = @Statut
                  WHERE Code = @Code", cn))
            {
                cmd.Parameters.AddWithValue("@Code", besoinCode);
                cmd.Parameters.AddWithValue("@Statut", (int)statut);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

      

        // =========================
        // MAPPING CENTRALISÉ
        // =========================
        private Besoin MapBesoin(SqlDataReader rd)
        {
            return new Besoin
            {
                Code = (int)rd["Code"],
                DepartementId = (int)rd["DepartementId"],
                TypeRessource = rd["TypeRessource"].ToString(),
                Quantite = (int)rd["Quantite"],
                Statut = (StatutBesoin)(int)rd["Statut"]
            };
        }
    }
}