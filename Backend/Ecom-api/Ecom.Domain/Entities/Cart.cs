namespace Ecom.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }

        public List<CartDetail> CartDetails { get; set; }
    }
}
