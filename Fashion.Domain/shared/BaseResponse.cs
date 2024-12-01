namespace Fashion.Domain.Shared;

public class BaseResponse<T>
{
    public string Message { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    public int Code { get; set; }
    public T Data { get; set; }

    public BaseResponse(T data, string message, bool status, int code)
    {
        Message = message;
        Status = status;
        Code = code;
        Data = data;
    }
}

public class SuccessResponse<T>(T? data, string message = "Success", bool status = true, int code = 200) :
                BaseResponse<T>(data, message, status, code)
{ }

public class BadResponse<T>(T? data, string message = "Bad request", bool status = false, int code = 400) :
                BaseResponse<T>(data, message, status, code)
{ }
