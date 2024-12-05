using Fashion.Application.Dtos.DeliveryInformation;
using Fashion.Domain.Entities;

namespace Fashion.Application.Dtos.Order;

public class OrderDto
{
    public string Id { get; set; }

    public string? CouponId { get; set; }

    public Coupon? Coupon { get; set; }

    public double Total { get; set; }

    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DeliveryInformationDto DeliveryInformation { get; set; }

    public List<OrderDetailDto> OrderDetails { get; set; }
}
