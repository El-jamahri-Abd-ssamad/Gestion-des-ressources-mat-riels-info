using Microsoft.Data.SqlClient;

using Microsoft.Data.SqlClient;

namespace Projet.Data
{
    public class DbFactory
    {
        private static readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\dernier ve\Gestion-des-ressources-mat-riels-info\Projet\Data\db1.mdf"";Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
