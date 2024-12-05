namespace Fashion.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string? CouponId { get; set; }

        public Coupon? Coupon { get; set; }

        public decimal Total { get; set; }

        public string Status { get; set; }

        public string UserId { get; set; }

        public string? DeliveryInformationId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DeliveryInformation DeliveryInformation { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
