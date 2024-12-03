namespace Fashion.Application.Dtos.Category;

public class CreateCategoryDto
{
    public string CategoryName { get; set; } = string.Empty;

    public string CategoryDescription { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}
