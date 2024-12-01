namespace Fashion.Application.Dtos.Product;

public class CreateProduct
{
    public string ProductName { get; set; } = string.Empty;

    public string URLImage { get; set; } = string.Empty;

    public string CategoryId { get; set; }

    public bool IsActive { get; set; }

    public List<CreateSize> Sizes { get; set; }
}
