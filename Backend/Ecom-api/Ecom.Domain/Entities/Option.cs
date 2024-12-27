namespace Ecom.Domain.Entities
{
    public class Option : BaseEntity
    {
        public string Name { get; set; }

        public decimal PricePercentage { get; set; }
    }
}
