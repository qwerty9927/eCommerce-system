namespace Fashion.Domain.Entities
{
    public class CartDetail : BaseEntity
    {
        public string ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string CartId { get; set; }

        public string? SizeId { get; set; }

        public Size Size { get; set; }
    }
}
