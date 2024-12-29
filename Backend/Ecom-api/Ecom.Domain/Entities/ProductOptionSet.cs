namespace Ecom.Domain.Entities
{
    public class ProductOptionSet : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Guid OptionSetId { get; set; }
        
        public OptionSet OptionSet { get; set; }
    }
}
