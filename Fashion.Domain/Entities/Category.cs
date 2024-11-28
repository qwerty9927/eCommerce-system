namespace Fashion.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = string.Empty;

        public string CategoryDescription { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public List<Product> Products { get; set; }
    }
}
