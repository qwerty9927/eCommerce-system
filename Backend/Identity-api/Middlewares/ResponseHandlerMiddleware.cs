using System.Text.Json;
using Identity_api.Common;

namespace Identity_api.Middlewares;

public class ResponseHandlerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (BaseException ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, object exception)
    {
        var response = new BaseResponse
        {
            Data = null,
            Status = false,
            Message = "Internal server error",
            Code = StatusCodes.Status500InternalServerError,
            Error = null
        };

        if (exception is BaseException baseException)
        {
            response.Message = baseException.Response.Message;
            response.Code = baseException.Response.Code;
            response.Error = baseException.Response.Error ?? (object[])[];
        }

        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        
        var jsonResponse = JsonSerializer.Serialize(response, jsonOptions);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.Code;

        return context.Response.WriteAsync(jsonResponse);
    }
}