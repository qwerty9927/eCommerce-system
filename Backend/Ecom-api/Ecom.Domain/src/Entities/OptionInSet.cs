namespace Ecom.Domain.Entities
{
    public class OptionInSet : BaseEntity
    {
        public string OptionSetId { get; set; }

        public string OptionId { get; set; }

        public string OptionHash { get; set; }

        public int DisplayOrder { get; set; }
    }
}
