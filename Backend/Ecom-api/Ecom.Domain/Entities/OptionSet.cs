namespace Ecom.Domain.Entities
{
    public class OptionSet : BaseEntity
    {
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public string DisplayType { get; set; }

        public List<OptionInSet> OptionInSets { get; set; }
    }
}
