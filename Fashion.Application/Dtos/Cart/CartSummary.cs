namespace Fashion.Application.Dtos.Cart;

public class CartSummary
{
    public List<CartDetailDto> CartDetails { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
}
