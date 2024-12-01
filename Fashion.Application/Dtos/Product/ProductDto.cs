using Fashion.Application.Dtos.Category;

namespace Fashion.Application.Dtos.Product;

public class ProductDto
{
    public string Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string URLImage { get; set; } = string.Empty;

    public CategoryDto Category { get; set; }

    public List<SizeDto> Sizes { get; set; }
}
