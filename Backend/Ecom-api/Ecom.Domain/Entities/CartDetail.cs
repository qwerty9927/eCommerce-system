namespace Ecom.Domain.Entities
{
    public class CartDetail : BaseEntity
    {
        public int Quantity { get; set; }
        
        public string OptionHash {get;set;}
        
        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
