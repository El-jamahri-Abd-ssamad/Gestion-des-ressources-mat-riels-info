using Projet.Domain;
using Projet.Domain.enums;

using Microsoft.Data.SqlClient;
namespace Projet.Data
{
    public class NotificationDB : INotificationDao
    {
        SqlConnection connection = DbFactory.GetConnection();
        SqlCommand command = new SqlCommand();

        public void Ajouter(Notification n)
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = @"
            INSERT INTO Notification (Message, DateCreation, EstLue, RoleCible)
            VALUES (@Msg, @Date, 0, @Role)
        ";

            command.Parameters.AddWithValue("@Msg", n.Message);
            command.Parameters.AddWithValue("@Date", n.DateCreation);
            command.Parameters.AddWithValue("@Role", (int)n.RoleCible);

            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }

        public List<Notification> GetNotifications(Role role)
        {
            var list = new List<Notification>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Notification WHERE RoleCible=@Role ORDER BY DateCreation DESC";
            command.Parameters.AddWithValue("@Role", (int)role);

            var rd = command.ExecuteReader();
            command.Parameters.Clear();

            while (rd.Read())
            {
                list.Add(new Notification
                {
                    Id = (int)rd["Id"],
                    Message = rd["Message"].ToString(),
                    DateCreation = (DateTime)rd["DateCreation"],
                    EstLue = (bool)rd["EstLue"]
                });
            }

            rd.Close();
            connection.Close();
            return list;
        }
    }
}
