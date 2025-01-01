namespace Ecom.Domain.Entities
{
    public class CartDetail : BaseEntity
    {
        public int Quantity { get; set; }

        public string OptionHash { get; set; }

        public string CartId { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
