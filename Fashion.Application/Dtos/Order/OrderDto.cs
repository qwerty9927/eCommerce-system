using Fashion.Domain.Entities;

namespace Fashion.Application.Dtos.Order;

public class OrderDto
{
    public string? CouponId { get; set; }

    public Coupon? Coupon { get; set; }

    public double Total { get; set; }

    public bool Status { get; set; }

    public DeliveryInformationDto DeliveryInformation { get; set; }

    public List<OrderDetailDto> OrderDetails { get; set; }
}
