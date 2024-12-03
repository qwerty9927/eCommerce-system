namespace Fashion.Presentation.Models;

public class CartModel
{
    public string UserId { get; set; }
    public List<CartDetailModel> CartDetails { get; set; } = [];
}

public class CartDetailModel
{
    public string Id { get; set; }

    public string ProductId { get; set; }

    public ProductModel Product { get; set; }

    public int Quantity { get; set; }

    public SizeModel Size { get; set; }
}
