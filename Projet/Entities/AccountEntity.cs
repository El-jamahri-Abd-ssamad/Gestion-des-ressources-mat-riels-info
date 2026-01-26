using Projet.Domain;

namespace Projet.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public AccountEntity()
        {
            Username = "???????";
            Password = "";
            Id = 0;
            Role = Role.Enseignant;
        }

        public AccountEntity(int id, string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Id = id;
            Role = role;
        }

        public override string ToString()
        {
            return $"Id {Id} Username {Username} Password {Password}";
        }
    }
}
