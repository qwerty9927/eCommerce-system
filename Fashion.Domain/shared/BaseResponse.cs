public class BaseResponse
{
    public string Message { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    public string Code { get; set; }
}

public class BaseResponse<T> : BaseResponse
{
    public T Data { get; set; }
}
