using Fashion.Application.Dtos.Product;

namespace Fashion.Application.Dtos.Order;

public class OrderDetailDto
{
    public double ProductPrice { get; set; }

    public double Quantity { get; set; }

    public string ProductId { get; set; }

    public ProductDto Product { get; set; }

}
