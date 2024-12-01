namespace Fashion.Application.Dtos.Product;

public class UpdateProduct
{
    public string Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string URLImage { get; set; } = string.Empty;

    public string CategoryId { get; set; }

    public bool IsActive { get; set; }

    public List<SizeDto> Sizes { get; set; }
}
