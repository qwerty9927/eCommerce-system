namespace Ecom.Domain.Entities
{
    public class ProductOptionSet : BaseEntity
    {
        public string ProductId { get; set; }

        public string OptionSetId { get; set; }

        public OptionSet OptionSet { get; set; }
    }
}
