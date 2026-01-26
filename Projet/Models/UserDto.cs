using Projet.Domain;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class UserDto
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        [RegularExpression(@"\d{10}", ErrorMessage = "Phone must be 10 digits!")]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public Role Role { get; set; }
        public UserDto()
        {
            Name = Phone = Email = Username = "?????";
            Password = "";
            DateBirth = DateTime.Parse("1/1/2000");
        }

        public UserDto(string name, DateTime dateBirth, string phone, string email,
            string username, string password, Role role)
        {
            Name = name;
            DateBirth = dateBirth;
            Phone = phone;
            Email = email;
            Username = username;
            Password = password;
            Role = role;
        }
        public override string ToString()
        {
            return $@"Name {Name} Date of birth:{DateBirth} Phone: {Phone} Email:{Email}
                    Username: {Username} Password:{Password} Role {Role}";
        }
    }
}
