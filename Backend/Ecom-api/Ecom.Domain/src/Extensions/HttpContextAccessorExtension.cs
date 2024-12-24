using System.Reflection;
using Ecom.Domain.Constants;
using Ecom.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Ecom.Domain.Extensions
{
    public static class HttpContextAccessorExtension
    {
        public static UserSession GetUserSession(this IHttpContextAccessor httpContextAccessor)
        {
            var headers = httpContextAccessor?.HttpContext?.Request?.Headers;
            if (headers != null)
            {
                UserSession userSession = new();
                PropertyInfo[] userSessionProperties = userSession.GetType().GetProperties();
                foreach (var property in userSessionProperties)
                {
                    property.SetValue(userSession, headers[typeof(HeaderConstants).GetField(property.Name)?.GetValue(null)?.ToString()]);
                }
            }

            return new UserSession();
        }

        public static string GetHeaderByKeyName(this IHttpContextAccessor httpContextAccessor, string keyName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(httpContextAccessor?.HttpContext?.Request?.Headers[keyName]))
                {
                    return httpContextAccessor!.HttpContext.Request.Headers[keyName];
                }

                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
