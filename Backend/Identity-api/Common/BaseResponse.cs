using System.Text.Json.Serialization;

namespace Identity_api.Common;

public class BaseResponse
{
    public string Message { get; set; } = string.Empty;

    [JsonIgnore]
    public int Code { get; set; }

    public bool Status { get; set; }

    public object? Data { get; set; }

    public object? Error { get; set; }
}

public class BaseResponse<T> : BaseResponse
{
    public BaseResponse() { }

    public BaseResponse(T? data, string message)
    {
        Message = message;
        Status = true;
        Data = data;
    }
}

public class SuccessResponse<T>(
    T? data,
    string message = "Success") :
    BaseResponse<T>(data, message) { }