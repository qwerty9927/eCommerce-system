using System.Net;

namespace Ecom.Domain.Shared;

public class BaseResponse
{
    public string Message { get; set; } = string.Empty;

    public bool Status { get; set; } = true;

    public int Code { get; set; }

    public object Data { get; set; }
}

public class BaseResponse<T> : BaseResponse
{
    public BaseResponse() { }

    public BaseResponse(T? data, string message, bool status, int code)
    {
        Message = message;
        Status = status;
        Code = code;
        Data = data;
    }
}

public class SuccessResponse<T>(
    T? data,
    string message = nameof(HttpStatusCode.OK),
    bool status = true,
    HttpStatusCode code = HttpStatusCode.OK) :
    BaseResponse<T>(data, message, status, (int)code) { }

public class ErrorResponse(
    string message = nameof(HttpStatusCode.BadRequest),
    HttpStatusCode code = HttpStatusCode.BadRequest) : BaseException(message, (int)code) { }
