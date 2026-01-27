using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Projet.Data
{
    public class DbFactory
    {
        private static readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=C:\Users\HP\OneDrive\Documents\ESISA\4eme_annee\S7\Eng_logiciel\Projet\Projet\Data\PRJT.mdf;
              Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}