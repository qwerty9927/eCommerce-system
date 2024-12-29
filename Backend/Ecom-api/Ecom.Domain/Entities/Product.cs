namespace Ecom.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;

        public string URLImage { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public decimal Price { get; set; }

        public List<ProductOptionSet> ProductOptionSets { get; set; }
    }
}
