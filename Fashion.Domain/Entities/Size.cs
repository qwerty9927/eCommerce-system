namespace Fashion.Domain.Entities
{
    public class Size : BaseEntity
    {
        public string SizeName { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public int Order { get; set; }

        public string ProductId { get; set; }
    }
}
