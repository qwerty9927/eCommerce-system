using System.Net;
using System.Text.Json;
using Ecom.Domain.Shared;

namespace Ecom.API.Middlewares
{
    public class ResponseHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, object exception)
        {
            var response = new BaseResponse<object>
            {
                Data = default,
                Status = false,
                Message = "Internal server error",
                Code = (int)HttpStatusCode.InternalServerError,
            };

            if (exception is BaseException baseException)
            {
                response.Message = baseException.Response.Message;
                response.Code = baseException.Response.Code;
            }

            var jsonResponse = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = response.Code;

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
