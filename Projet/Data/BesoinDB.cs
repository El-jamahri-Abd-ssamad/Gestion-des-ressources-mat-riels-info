using Microsoft.Data.SqlClient;
using Projet.Domain;
using Projet.Domain.enums;
using System;
using System.Collections.Generic;

namespace Projet.Data
{
    public class BesoinDB : IBesoinDao
    {
        SqlConnection connection = DbFactory.GetConnection();
        SqlCommand command = new SqlCommand();

        public void AddBesoin(Besoin besoin)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText =
                @"INSERT INTO Besoin
                  (DepartementId, DateSoumission, TypeRessource, Description, Quantite, ValideParChef, Statut)
                  VALUES (@DepId,@Date,@Type,@Desc,@Qte,@Valide, @Statut)";

            command.Parameters.AddWithValue("@DepId", besoin.DepartementId);
            command.Parameters.AddWithValue("@Date", besoin.DateSoumission);
            command.Parameters.AddWithValue("@Type", besoin.TypeRessource);
            command.Parameters.AddWithValue("@Desc", besoin.Description);
            command.Parameters.AddWithValue("@Qte", besoin.Quantite);
            command.Parameters.AddWithValue("@Valide", besoin.ValideParChef);
            command.Parameters.AddWithValue("@Statut", besoin.Statut);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public List<Besoin> GetBesoinsByDepartement(int departementId)
        {
            List<Besoin> list = new List<Besoin>();
            connection.Open();
            command.Connection = connection;
            command.CommandText =
                "SELECT * FROM Besoin WHERE DepartementId=@DepId";
            command.Parameters.AddWithValue("@DepId", departementId);

            SqlDataReader rd = command.ExecuteReader();
            command.Parameters.Clear();

            while (rd.Read())
            {
                list.Add(new Besoin
                {
                    Code = Convert.ToInt32(rd["Code"]),
                    DepartementId = Convert.ToInt32(rd["DepartementId"]),
                    DateSoumission = Convert.ToDateTime(rd["DateSoumission"]),
                    TypeRessource = rd["TypeRessource"].ToString(),
                    Description = rd["Description"].ToString(),
                    Quantite = Convert.ToInt32(rd["Quantite"]),
                    ValideParChef = Convert.ToBoolean(rd["ValideParChef"]),
                    Statut = (StatutBesoin)Convert.ToInt32(rd["Statut"])
                });
            }

            rd.Close();
            connection.Close();
            return list;
        }

        public List<Besoin> GetBesoinsValidesByDepartement(int departementId)
        {
            List<Besoin> list = new List<Besoin>();
            connection.Open();
            command.Connection = connection;
            command.CommandText =
                @"SELECT * FROM Besoin 
                  WHERE DepartementId=@DepId AND ValideParChef=1";
            command.Parameters.AddWithValue("@DepId", departementId);

            SqlDataReader rd = command.ExecuteReader();
            command.Parameters.Clear();

            while (rd.Read())
            {
                list.Add(new Besoin
                {
                    Code = Convert.ToInt32(rd["Code"]),
                    DepartementId = departementId,
                    TypeRessource = rd["TypeRessource"].ToString(),
                    Description = rd["Description"].ToString(),
                    Quantite = Convert.ToInt32(rd["Quantite"]),
                    ValideParChef = true,
                    Statut = (StatutBesoin)Convert.ToInt32(rd["Statut"])
                });
            }

            rd.Close();
            connection.Close();
            return list;
        }

        public void ValidateBesoin(int besoinId)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText =
                "UPDATE Besoin SET ValideParChef=1, Statut=@Statut WHERE Code=@Code";
            command.Parameters.AddWithValue("@Code", besoinId);
            command.Parameters.AddWithValue("@Statut", (int)StatutBesoin.Valide);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public void DeleteBesoin(int besoinId)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText =
                "DELETE FROM Besoin WHERE Code=@Code";
            command.Parameters.AddWithValue("@Code", besoinId);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }
        public void RejectBesoin(int besoinId)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "UPDATE Besoin SET ValideParChef=0, Statut=@Statut WHERE Code=@Code";
            command.Parameters.AddWithValue("@Code", besoinId);
            command.Parameters.AddWithValue("@Statut", (int)StatutBesoin.Rejete);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public bool UpdateBesoin(Besoin besoin)
        {
            using var connection = DbFactory.GetConnection();
            connection.Open();

            string sql = @"
        UPDATE Besoin
        SET
            TypeRessource = @TypeRessource,
            Description = @Description,
            Quantite = @Quantite
        WHERE Code = @Code AND Statut = 0";

            using var command = new SqlCommand(sql, connection);

            // 🔥 TOUS les paramètres doivent exister
            command.Parameters.AddWithValue("@TypeRessource", besoin.TypeRessource);
            command.Parameters.AddWithValue("@Description", besoin.Description);
            command.Parameters.AddWithValue("@Quantite", besoin.Quantite);
            command.Parameters.AddWithValue("@Code", besoin.Code);
            command.Parameters.AddWithValue("@Statut", besoin.Statut);

            int rows = command.ExecuteNonQuery();

            return rows > 0;
        }

        public Besoin GetBesoinById(int id)
        {
            using var connection = DbFactory.GetConnection();
            connection.Open();

            string sql = "SELECT * FROM Besoin WHERE Code = @Code";
            using var command = new SqlCommand(sql, connection);

            // 🔥 PARAMÈTRE OBLIGATOIRE
            command.Parameters.AddWithValue("@Code", id);

            using var rd = command.ExecuteReader();

            if (rd.Read())
            {
                return new Besoin
                {
                    Code = Convert.ToInt32(rd["Code"]),
                    DepartementId = Convert.ToInt32(rd["DepartementId"]),
                    DateSoumission = Convert.ToDateTime(rd["DateSoumission"]),
                    TypeRessource = rd["TypeRessource"].ToString(),
                    Description = rd["Description"].ToString(),
                    Quantite = Convert.ToInt32(rd["Quantite"]),
                    ValideParChef = Convert.ToBoolean(rd["ValideParChef"]),
                    Statut = (StatutBesoin)Convert.ToInt32(rd["Statut"])
                };
            }

            return null;
        }

        public void EnvoyerBesoinsValides(int departementId)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = @"
        UPDATE Besoin
        SET Statut = @Statut
        WHERE DepartementId = @DepId AND Statut = @Valide
    ";

            command.Parameters.AddWithValue("@Statut", (int)StatutBesoin.Envoye);
            command.Parameters.AddWithValue("@Valide", (int)StatutBesoin.Valide);
            command.Parameters.AddWithValue("@DepId", departementId);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }


    }
}
