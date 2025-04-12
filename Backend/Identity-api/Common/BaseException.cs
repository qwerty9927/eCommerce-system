namespace Identity_api.Common;

public class BaseException : Exception
{
    public BaseResponse<object> Response { get; set; }

    public BaseException(string message, int code, object? error)
        : base(message)
    {
        Response = new()
        {
            Message = message,
            Code = code,
            Status = false,
            Error = error
        };
    }
}

public class UnprocessableException(string message = "Unprocessable content", object? error = null)
    : BaseException(message, StatusCodes.Status422UnprocessableEntity, error) { }

public class ConflictException(string message = "Conflict", object? error = null)
    : BaseException(message, StatusCodes.Status409Conflict, error) { }

public class BadRequestException(string message = "Bad Request", object? error = null)
    : BaseException(message, StatusCodes.Status400BadRequest, error) { }