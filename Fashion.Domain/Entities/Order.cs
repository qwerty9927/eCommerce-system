namespace Fashion.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string? CouponId { get; set; }

        public Coupon? Coupon { get; set; }

        public decimal Total { get; set; }

        public string Status { get; set; }

        public string UserId { get; set; }

        public DeliveryInformation DeliveryInformation { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
