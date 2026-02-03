using Microsoft.Data.SqlClient;
using Projet.Domain;
using Projet.Domain.enums;
using Projet.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Projet.Data
{
    public class NotificationDaoDB : INotificationDao
    {
        // =========================
        // GET NOTIFICATIONS PAR ROLE
        // =========================
        public List<Notification> GetNotifications(Role role)
        {
            var list = new List<Notification>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, Message, DestinataireRole, DateCreation, EstLue
                  FROM Notification 
                  WHERE DestinataireRole = @Role 
                  ORDER BY DateCreation DESC", cn))
            {
                cmd.Parameters.AddWithValue("@Role", (int)role);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapNotification(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // INSERT NOTIFICATION
        // =========================
        public void Insert(Notification notification)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Notification (Message, DestinataireRole, DateCreation, EstLue)
                  VALUES (@Message, @Role, @DateCreation, @EstLue)", cn))
            {
                cmd.Parameters.AddWithValue("@Message", notification.Message);
                cmd.Parameters.AddWithValue("@Role", (int)notification.DestinataireRole);
                cmd.Parameters.AddWithValue("@DateCreation", notification.DateCreation);
                cmd.Parameters.AddWithValue("@EstLue", notification.EstLue);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =========================
        // MAPPING CENTRALISÉ
        // =========================
        private Notification MapNotification(SqlDataReader rd)
        {
            return new Notification
            {
                Id = (int)rd["Id"],
                Message = rd["Message"].ToString(),
                DestinataireRole = (Role)(int)rd["DestinataireRole"],
                DateCreation = (DateTime)rd["DateCreation"],
                EstLue = (bool)rd["EstLue"]
            };
        }
    }
}