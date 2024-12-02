namespace Fashion.Presentation.Models;

public class ProductModel
{
    public string Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string URLImage { get; set; } = string.Empty;

    public CategoryModel Category { get; set; }

    public List<SizeModel> Sizes { get; set; }
}

public class CategoryModel
{
    public string Id { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string CategoryDescription { get; set; } = string.Empty;

    public List<ProductModel> Products { get; set; }
}

public class SizeModel
{
    public string Id { get; set; }

    public string SizeName { get; set; }

    public float Price { get; set; }

    public int Quantity { get; set; }

    public int Order { get; set; }
}
