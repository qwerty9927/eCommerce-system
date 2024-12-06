namespace Fashion.Application.Dtos.Cart;

public class RemoveItemRequest
{
    public string CartDetailId { get; set; }
    public int Quantity { get; set; }
}

