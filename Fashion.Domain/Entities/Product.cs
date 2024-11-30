namespace Fashion.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;

        public string URLImage { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Size> Sizes { get; set; }
    }
}
