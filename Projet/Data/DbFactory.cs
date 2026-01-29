using Microsoft.Data.SqlClient;

namespace Projet.Data
{
    public class DbFactory
    {
        private static readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog = PRJT;
            Integrated Security = True;
            Connect Timeout = 30;
            Encrypt=True;
            TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
