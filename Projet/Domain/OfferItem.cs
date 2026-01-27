namespace Projet.Domain
{
    public class OfferItem
    {
        public int Id { get; set; }
        public int IdOffer { get; set; }
        public int IdTenderItem { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
