using Projet.Models;

namespace Projet.Services
{
    public interface IUserService
    {
        bool RegisterUser(UserDto user);
        UserDto GetUser(string username);
        bool DeleteUser(string username);
        List<UserDto> GetUsers();
        bool UpdateUser(UserDto olduser, UserDto newUser);
    }
}
