namespace Ecom.Domain.Entities
{
    public class OptionSet : BaseEntity
    {
        public string Name { get; set; }

        public string? ParentId { get; set; }

        public string DisplayType { get; set; }

        public List<OptionInSet> OptionInSets { get; set; }
    }
}
