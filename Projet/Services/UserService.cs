using Projet.Data;
using Projet.Domain;
using Projet.Models;

namespace Projet.Services
{
    public class UserService : IUserService
    {
        IUserDao userDao = new UserDaoDB();// new UserDao();
        public bool DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(string username)
        {
            User u = userDao.GetUser(username);
            Console.WriteLine("User found:" + u);
            if (u == null)
            {
                return null; //l'utilisateur n'existe pas
            }
            UserDto u2 = new UserDto
            {
                Name = u.Name,
                Email = u.Email,
                DateBirth = u.DateBirth,
                Phone = u.Phone,
                Username = u.Account.Username,
                Password = u.Account.Password,
                Role = u.Account.Role
            };
            return u2;
        }

        public List<UserDto> GetUsers()
        {
            List<User> liste = userDao.GetUsers();
            List<UserDto> liste2 = new List<UserDto>();
            foreach (var item in liste)
            {
                UserDto u = new UserDto
                {
                    Name = item.Name,
                    Email = item.Email,
                    Phone = item.Phone,
                    DateBirth = item.DateBirth,
                    Username = item.Account.Username,
                    Password = item.Account.Password,
                    Role = item.Account.Role,
                };
                liste2.Add(u);
            }
            return liste2;
        }

        public bool RegisterUser(UserDto user)
        {
            //règle métier: verifier si l'utilisateur existe deja avec le même username
            UserDto u = GetUser(user.Username);

            if (u != null)
            {
                //l'utilisateur existe deja
                return false;
            }
            else //u=null
            {
                //mapper UserDto to User:
                User u2 = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    DateBirth = user.DateBirth,
                    Account = new Account { Username = user.Username, Password = user.Password, Role = user.Role }
                };

                userDao.AddUser(u2); //appel au DAO pour ajouter l'utilisateur

                return true;
            }
        }

        public bool UpdateUser(UserDto olduser, UserDto newUser)
        {
            throw new NotImplementedException();
        }
        public User Login(string username, string password)
        {
            User user = userDao.GetUser(username);

            if (user == null)
                return null;

            if (user.Account.Password != password)
                return null;

            return user;
        }
    }
}
