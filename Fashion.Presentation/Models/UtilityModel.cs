namespace Fashion.Presentation.Models;

public class PagingResponseModel<T>
{
    public List<T> Records { get; set; } = [];
    public int TotalRecord { get; set; }
}
