namespace Fashion.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;

        public float Price { get; set; }

        public int Quantity { get; set; }

        public string URLImage { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public string BrandId { get; set; }

        public Brand Brand { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
