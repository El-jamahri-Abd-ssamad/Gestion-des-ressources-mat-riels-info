using Microsoft.Data.SqlClient;

namespace Projet.Data
{
    public class DbFactory
    {
        private static readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=C:\USERS\HP\ONEDRIVE\DOCUMENTS\ESISA\4EME_ANNEE\S7\ENG_LOGICIEL\PROJET\PROJET\DATA\PRJT.MDF;
              Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
