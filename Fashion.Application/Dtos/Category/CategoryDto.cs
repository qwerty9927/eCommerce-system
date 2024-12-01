using Fashion.Application.Dtos.Product;

namespace Fashion.Application.Dtos.Category;

public class CategoryDto
{
    public string Id { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string CategoryDescription { get; set; } = string.Empty;

    public List<ProductDto> Products { get; set; }
}
