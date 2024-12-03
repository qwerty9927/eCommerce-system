namespace Fashion.Application.Dtos.Cart;

public class AddItemRequest
{
    public string ProductId { get; set; }
    public string SizeId { get; set; }
    public int Quantity { get; set; }
}
