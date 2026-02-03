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
                AttachDbFilename=C:\Users\pc\Documents\GL\projet1\Gestion-des-ressources-mat-riels-info\Projet\Data\dbbb.mdf;
                Integrated Security=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}