namespace Ecom.Domain.Entities
{
    public class CategoryProduct : BaseEntity
    {
        public string ProductId { get; set; }

        public Product Product { get; set; }

        public string CategoryId { get; set; }
    }
}
