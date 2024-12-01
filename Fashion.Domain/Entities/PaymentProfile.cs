namespace Fashion.Domain.Entities
{
    public class PaymentProfile : BaseEntity
    {
        public string CardId { get; set; }

        public string Last4 { get; set; }

        public string Brand { get; set; }

        public string UserId { get; set; }
    }
}
