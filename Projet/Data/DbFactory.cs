using Microsoft.Data.SqlClient;

namespace Projet.Data
{
    public class DbFactory
    {
        static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pc\Documents\NET\Projet\Projet\Data\db.mdf;Integrated Security=True");

        public DbFactory() { }
        public static SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
