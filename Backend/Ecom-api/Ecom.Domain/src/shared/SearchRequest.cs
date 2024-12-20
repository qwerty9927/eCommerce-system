namespace Ecom.Domain.Shared;

public class SearchRequest
{
    private int _pageSize;
    private int _pageIndex;
    public string? KeyWord { get; set; }
    public int PageSize
    {
        get => _pageSize < 0 ? 10 : _pageSize;
        set => _pageSize = value;
    }
    public int PageIndex
    {
        get => _pageIndex < 0 ? 0 : _pageIndex;
        set => _pageIndex = value;
    }
    public string? SortOrder { get; set; }
}
