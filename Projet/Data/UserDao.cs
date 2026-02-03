using Projet.Domain;

namespace Projet.Data
{
    public class UserDao : IUserDao
    {
        static List<User> liste = new List<User>();
        public void AddUser(User user)
        {
            liste.Add(user);
        }

        public void DeleteUser(string username)
        {
            foreach (var item in liste)
            {
                if (item.Account.Username == username)
                {
                    liste.Remove(item);
                    break;
                }
            }
        }

        public int GetAccountIdByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            foreach (var item in liste)
            {
                if (item.Account.Username == username)
                    return item;
            }
            return null;
        }

        public int GetUserIdByUsername(string? name)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            return liste;
        }

        public void UpdateUser(User olduser, User newUser)
        {
            User user = GetUser(olduser.Account.Username);
            user.Name = newUser.Name;
            user.Email = newUser.Email;
            user.Phone = newUser.Phone;
            user.DateBirth = newUser.DateBirth;
            user.Account.Username = newUser.Account.Username;
            user.Account.Password = newUser.Account.Password;
        }
    }
}

