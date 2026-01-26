using Microsoft.Data.SqlClient;
using Projet.Domain;

namespace Projet.Data
{
    public class UserDaoDB : IUserDao
    {
        SqlConnection connection = DbFactory.GetConnection();
        SqlCommand command = new SqlCommand();
        public void AddUser(User user)
        {

            connection.Open();
            command.Connection = connection;
            command.CommandText = "Insert into Account (Username,Password,Role) " +
                                 "VALUES (@Username,@Password,@Role)";
            command.Parameters.AddWithValue("@Username", user.Account.Username);
            command.Parameters.AddWithValue("@Password", user.Account.Password);
            command.Parameters.AddWithValue("@Role", user.Account.Role);
            command.ExecuteNonQuery();
            command.Parameters.Clear(); //effacer les paramètres précédents

            command.CommandText = "SELECT Id FROM Account WHERE Username=@Username";
            command.Parameters.AddWithValue("@Username", user.Account.Username);
            int idAccount = (int)command.ExecuteScalar();
            command.Parameters.Clear(); //effacer les paramètres précédents

            command.CommandText = "INSERT INTO [User] (Name,Email,Phone,DateBirth, IdAccount) " +
                                  "VALUES (@Name,@Email,@Phone,@DateBirth, @IdAccount)";
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@DateBirth", user.DateBirth);
            command.Parameters.AddWithValue("@IdAccount", idAccount);
            command.ExecuteNonQuery();
            command.Parameters.Clear(); //effacer les paramètres précédents
            connection.Close();
        }

        public void DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {

            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Account a, [User] u WHERE a.Username=@Username AND u.IdAccount=a.Id";
            command.Parameters.AddWithValue("@Username", username);
            SqlDataReader rd = command.ExecuteReader();
            command.Parameters.Clear();//effacer les paramètres précédents
            if (rd.Read())
            {
                User user = new User
                {
                    Name = rd["Name"].ToString(),
                    Email = rd["Email"].ToString(),
                    Phone = rd["Phone"].ToString(),
                    DateBirth = Convert.ToDateTime(rd["DateBirth"]),
                    Account = new Account
                    {
                        Username = rd["Username"].ToString(),
                        Password = rd["Password"].ToString()
                    }
                };

                rd.Close();
                connection.Close();
                return user;
            }
            else
            {

                connection.Close();
                return null;
            }
        }

        public List<User> GetUsers()
        {
            List<User> liste = new List<User>();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Account a, [User] u WHERE u.IdAccount=a.Id";

            SqlDataReader rd = command.ExecuteReader();

            while (rd.Read())
            {
                User user = new User
                {
                    Name = rd["Name"].ToString(),
                    Email = rd["Email"].ToString(),
                    Phone = rd["Phone"].ToString(),
                    DateBirth = Convert.ToDateTime(rd["DateBirth"]),
                    Account = new Account
                    {
                        Username = rd["Username"].ToString(),
                        Password = rd["Password"].ToString(),
                        Role = (Role)rd["Role"]
                    }
                };
                liste.Add(user);

            }
            rd.Close();
            connection.Close();
            return liste;
        }

        public void UpdateUser(User olduser, User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
