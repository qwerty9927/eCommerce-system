namespace Fashion.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public string PaymentId { get; set; }
        public string Status { get; set; }
    }
}
