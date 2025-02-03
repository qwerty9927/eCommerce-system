namespace Ecom.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public string UserId { get; set; }

        public List<CartDetail> CartDetails { get; set; }
    }
}
