namespace Fashion.Application.Dtos.Cart;

public class CartDto
{
    public string UserId { get; set; }

    public bool IsActive { get; set; }

    public List<CartDetailDto> CartDetails { get; set; } = [];
}
