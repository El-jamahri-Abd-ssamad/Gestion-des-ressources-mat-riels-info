namespace Projet.Domain
{
    public class User
    {
        public User()
        {
            Name = Email = Phone = "";
            DateBirth = DateTime.Parse("1/1/2000");
        }

        public User(string name, string email, string phone, DateTime dateBirth, Account account)
        {
            Name = name;
            Email = email;
            Phone = phone;
            DateBirth = dateBirth;
            Account = account;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
        public Account Account { get; set; } //agrégation

        public override string ToString()
        {
            return $@"Name {Name} Date of birth:{DateBirth} Phone: {Phone} Email:{Email}
                      Account: {Account}";
        }
    }

}
