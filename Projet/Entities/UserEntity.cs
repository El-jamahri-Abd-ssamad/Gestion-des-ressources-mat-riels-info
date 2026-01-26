namespace Projet.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
        public int IdAccount { get; set; } //clé étrangère
        public UserEntity()
        {
            Id = 0;
            Name = Email = Phone = "";
            DateBirth = DateTime.Parse("1/1/2000");
            IdAccount = 0;
        }

        public UserEntity(int id, string name, string email, string phone, DateTime dateBirth, int idAccount)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            DateBirth = dateBirth;
            IdAccount = idAccount;
        }



        public override string ToString()
        {
            return $@"Id {Id} Name {Name} Date of birth:{DateBirth} Phone: {Phone} Email:{Email}
                      Id Account: {IdAccount}";
        }
    }
}
