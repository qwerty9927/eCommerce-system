namespace Fashion.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public double ProductPrice { get; set; }

        public int Quantity { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public string OrderId { get; set; }
    }
}
