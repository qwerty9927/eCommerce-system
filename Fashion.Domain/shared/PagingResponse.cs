namespace Fashion.Domain.Shared;

public class PagingResponse<T>
{
    public List<T> Records { get; set; } = [];
    public int TotalRecord { get; set; }
}
