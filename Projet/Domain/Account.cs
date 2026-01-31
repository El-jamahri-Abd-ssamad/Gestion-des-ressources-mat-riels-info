using System;
using Projet.Domain.enums;

namespace Projet.Domain
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Account()
        {
            Username = "???????";
            Password = "";
            Role = Role.Enseignant;
        }

        public Account(string username, string password, Role role)
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
