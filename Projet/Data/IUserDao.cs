using Projet.Domain;

namespace Projet.Data
{
    public interface IUserDao
    {
        void AddUser(User user);
        User GetUser(string username);
        void DeleteUser(string username);
        void UpdateUser(User olduser, User newUser);
        List<User> GetUsers();
        int GetUserIdByUsername(string? name);
        public int GetAccountIdByUsername(string username);
    }
}
