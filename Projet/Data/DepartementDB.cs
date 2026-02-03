using Microsoft.Data.SqlClient;
using Projet.Domain;
using System;
using System.Collections.Generic;

namespace Projet.Data
{
    public class DepartementDB : IDepartementDao
    {
        SqlConnection connection = DbFactory.GetConnection();
        SqlCommand command = new SqlCommand();

        // Récupérer un département par username du chef
        public Departement GetDepartementByChefUsername(string username)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Departement WHERE ChefUsername = @ChefUsername";
            command.Parameters.AddWithValue("@ChefUsername", username);

            SqlDataReader rd = command.ExecuteReader();
            command.Parameters.Clear();

            if (rd.Read())
            {
                var dep = new Departement
                {
                    Id = Convert.ToInt32(rd["Id"]),
                    Nom = rd["Nom"].ToString(),
                    Budget = Convert.ToDecimal(rd["Budget"]),
                    ChefUsername = rd["ChefUsername"].ToString()
                };

                rd.Close();
                connection.Close();
                return dep;
            }

            rd.Close();
            connection.Close();
            return null;
        }

        // Récupérer un département par Id
        public Departement GetDepartementById(int id)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Departement WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader rd = command.ExecuteReader();
            command.Parameters.Clear();

            if (rd.Read())
            {
                var dep = new Departement
                {
                    Id = Convert.ToInt32(rd["Id"]),
                    Nom = rd["Nom"].ToString(),
                    Budget = Convert.ToDecimal(rd["Budget"]),
                    ChefUsername = rd["ChefUsername"].ToString()
                };

                rd.Close();
                connection.Close();
                return dep;
            }

            rd.Close();
            connection.Close();
            return null;
        }

        // Récupérer tous les départements
        public List<Departement> GetDepartements()
        {
            List<Departement> list = new List<Departement>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Departement";

            SqlDataReader rd = command.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new Departement
                {
                    Id = Convert.ToInt32(rd["Id"]),
                    Nom = rd["Nom"].ToString(),
                    Budget = Convert.ToDecimal(rd["Budget"]),
                    ChefUsername = rd["ChefUsername"].ToString()
                });
            }

            rd.Close();
            connection.Close();
            return list;
        }

        // Mettre à jour le budget
        public void UpdateBudget(int departementId, decimal newBudget)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "UPDATE Departement SET Budget = @Budget WHERE Id = @Id";
            command.Parameters.AddWithValue("@Budget", newBudget);
            command.Parameters.AddWithValue("@Id", departementId);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }
    }
}
