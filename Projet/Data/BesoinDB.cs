using Microsoft.Data.SqlClient;
using Projet.Domain;
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
                  (DepartementId, DateSoumission, TypeRessource, Description, Quantite, ValideParChef)
                  VALUES (@DepId,@Date,@Type,@Desc,@Qte,@Valide)";

            command.Parameters.AddWithValue("@DepId", besoin.DepartementId);
            command.Parameters.AddWithValue("@Date", besoin.DateSoumission);
            command.Parameters.AddWithValue("@Type", besoin.TypeRessource);
            command.Parameters.AddWithValue("@Desc", besoin.Description);
            command.Parameters.AddWithValue("@Qte", besoin.Quantite);
            command.Parameters.AddWithValue("@Valide", besoin.ValideParChef);

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
                    ValideParChef = Convert.ToBoolean(rd["ValideParChef"])
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
                    Code = Convert.ToInt32(rd["Id"]),
                    DepartementId = departementId,
                    TypeRessource = rd["TypeRessource"].ToString(),
                    Description = rd["Description"].ToString(),
                    Quantite = Convert.ToInt32(rd["Quantite"]),
                    ValideParChef = true
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
                "UPDATE Besoin SET ValideParChef=1 WHERE Code=@Code";
            command.Parameters.AddWithValue("@Code", besoinId);
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
            command.CommandText = "UPDATE Besoin SET ValideParChef=0 WHERE Code=@Code";
            command.Parameters.AddWithValue("@Code", besoinId);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public void UpdateBesoin(Besoin besoin)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText =
                @"UPDATE Besoin 
                  SET TypeRessource=@Type, Description=@Desc, Quantite=@Qte
                  WHERE Id=@Id";

            command.Parameters.AddWithValue("@Type", besoin.TypeRessource);
            command.Parameters.AddWithValue("@Desc", besoin.Description);
            command.Parameters.AddWithValue("@Qte", besoin.Quantite);
            command.Parameters.AddWithValue("@Id", besoin.Code);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public Besoin GetBesoinById(int id)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Besoin WHERE Code=@Code";
            command.Parameters.AddWithValue("@Id", id);

            var rd = command.ExecuteReader();
            Besoin besoin = null;

            if (rd.Read())
            {
                besoin = new Besoin
                {
                    Code = Convert.ToInt32(rd["Code"]),
                    DepartementId = Convert.ToInt32(rd["DepartementId"]),
                    TypeRessource = rd["TypeRessource"].ToString(),
                    Description = rd["Description"].ToString(),
                    Quantite = Convert.ToInt32(rd["Quantite"]),
                    ValideParChef = Convert.ToBoolean(rd["ValideParChef"]),
                    DateSoumission = Convert.ToDateTime(rd["DateSoumission"])
                };
            }

            rd.Close();
            connection.Close();
            return besoin;
        }


    }
}
