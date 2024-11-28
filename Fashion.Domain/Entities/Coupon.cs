namespace Fashion.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public string CouponCode { get; set; } = string.Empty;

        public string CouponName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public int Discount { get; set; }

        public double MinRequire { get; set; }

        public double MaxTotalDiscount { get; set; }

        public DateTime DateExpire { get; set; }

        public DateTime DateStart { get; set; }
    }
}
