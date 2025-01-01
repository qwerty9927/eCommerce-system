namespace Ecom.Application.Dtos.Product;

public class ProductDto
{
    public Guid Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string UrlImage { get; set; } = string.Empty;
}
