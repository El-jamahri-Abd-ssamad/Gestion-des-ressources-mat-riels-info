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

using Microsoft.Data.SqlClient;

namespace Projet.Data
{
    public class DbFactory
    {
        private static readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=D:\NET\GESTION-DES-RESSOURCES-MAT-RIELS-INFO\PROJET\DATA\DB1.mdf;
              Integrated Security=True;
              Connect Timeout=30;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
