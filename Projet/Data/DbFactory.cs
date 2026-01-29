/* using Microsoft.Data.SqlClient;

namespace Projet.Data
{
   public class DbFactory
   {
       private static readonly string connectionString =
           @"Server=(localdb)\MSSQLLocalDB;Database=dbb;Trusted_Connection=True;";

       public static SqlConnection GetConnection()
       {
           return new SqlConnection(connectionString);
       }
   }
}
*/
using Microsoft.Data.SqlClient;
using System;

namespace Projet.Data
{
    public class DbFactory
    {
        private static readonly string connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = dbbb;
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