namespace Identity_api.Common;

public class BaseResponse
{
    public string Message { get; set; } = string.Empty;

    public int Code { get; set; }

    public object Data { get; set; }
}

public class BaseResponse<T> : BaseResponse
{
    public BaseResponse() { }

    public BaseResponse(T? data, string message, int code)
    {
        Message = message;
        Code = code;
        Data = data;
    }
}

public class SuccessResponse<T>(
    T? data,
    string message = "Success",
    int code = StatusCodes.Status200OK) :
    BaseResponse<T>(data, message, code) { }