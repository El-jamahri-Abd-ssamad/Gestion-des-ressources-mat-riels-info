using Projet.Domain.Enums;

namespace Projet.Models
{
    public class AccountDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public AccountDto()
        {
            Username = "???????";
            Password = "";
            Role = Role.Enseignant;
        }

        public AccountDto(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            return $"Username {Username} Password {Password} Role {Role}";
        }
    }
}
