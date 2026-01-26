using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Projet.Data
{
    public class DbFactory
    {
        private readonly string _connectionString;

        public DbFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' introuvable dans la configuration.");
        }

        // Retourne une nouvelle connexion non ouverte ; l'appelant doit Open/Close
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
