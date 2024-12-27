namespace Ecom.Domain.Shared;

public class BaseException : Exception
{
    public BaseResponse<object> Response { get; set; }

    public BaseException(string message, int code)
        : base(message)
    {
        Response = new()
        {
            Message = message,
            Code = code
        };
    }
}
