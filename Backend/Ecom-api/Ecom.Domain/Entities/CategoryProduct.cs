namespace Ecom.Domain.Entities
{
    public class CategoryProduct : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public Guid CategoryId { get; set; }
    }
}
