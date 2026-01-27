namespace Projet.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string CompanyName { get; set; }
        public bool IsBlacklisted { get; set; }
        public string BlacklistReason { get; set; }
    }
}
