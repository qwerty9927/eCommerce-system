using Fashion.Application.Dtos.Product;

namespace Fashion.Application.Dtos.Cart;

public class CartDetailDto
{
    public string Id { get; set; }

    public string ProductId { get; set; }

    public ProductDto Product { get; set; }

    public int Quantity { get; set; }

    public SizeDto Size { get; set; }
}
