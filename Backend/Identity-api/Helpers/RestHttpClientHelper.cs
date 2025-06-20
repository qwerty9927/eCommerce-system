using System.Text;
using System.Text.Json;
using Identity_api.Common;
using Identity_api.Constants;

namespace Identity_api.Helpers;

public class RestHttpClientHelper
{
    private readonly HttpClient _httpClient;
    private readonly string _providerName;
    private readonly ILogger<RestHttpClientHelper> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RestHttpClientHelper(
        HttpClient httpClient,
        ILogger<RestHttpClientHelper> logger,
        IHttpContextAccessor httpContextAccessor,
        string providerName)
    {
        _httpClient = httpClient;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _providerName = providerName;
    }

    public HttpClient GetHttpClientInstance()
    {
        return _httpClient;
    }

    public async Task<TResponse> GetAsync<TResponse>(Uri uri)
    {
        Task<HttpResponseMessage> Action() => _httpClient.GetAsync(uri);

        return await ResponseHandlerAsync<TResponse>(Action);
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request, string type = MediaType.Json,
        bool isForSnakeCase = false)
    {
        var content = SerializeBody(request, type, isForSnakeCase);
        Task<HttpResponseMessage> Action() => _httpClient.PostAsync(uri, content);

        return await ResponseHandlerAsync<TResponse>(Action);
    }

    public async Task<bool> PutAsync<TRequest>(Uri uri, TRequest request, string type = MediaType.Json,
        bool isForSnakeCase = false)
    {
        var content = SerializeBody(request, type, isForSnakeCase);
        Task<HttpResponseMessage> Action() => _httpClient.PutAsync(uri, content);

        return await ResponseHandlerAsync<bool>(Action);
    }

    public async Task<bool> DeleteAsync(Uri uri)
    {
        Task<HttpResponseMessage> Action() => _httpClient.DeleteAsync(uri);

        return await ResponseHandlerAsync<bool>(Action);
    }

    protected void AddRequestHeaders(string headerParameterName, string headerParameterValue)
    {
        if (string.IsNullOrEmpty(headerParameterName))
        {
            throw new ArgumentNullException(nameof(headerParameterName));
        }

        _httpClient.DefaultRequestHeaders.Remove(headerParameterName);
        _httpClient.DefaultRequestHeaders.Add(headerParameterName, headerParameterValue);
    }

    protected string StrategyAuthorization(string authorizationMethod,
        object value)
    {
        string token = authorizationMethod switch
        {
            AuthorizationMethod.Basic => ConvertToBasicToken(value),
            _ => ConvertToBearerToken(value)
        };

        return token;
    }

    private static string ConvertToBasicToken(object value)
    {
        var properties = value.GetType().GetProperties();
        var values = properties.Select(p => p.GetValue(value)?.ToString() ?? string.Empty).ToArray();
        var combined = $"{values[0]}:{values[1]}"; // username:password
        var bytes = Encoding.UTF8.GetBytes(combined);

        return $"{AuthorizationMethod.Basic} {Convert.ToBase64String(bytes)}";
    }

    private static string ConvertToBearerToken(object value)
    {
        return value is not string result ? string.Empty : $"{AuthorizationMethod.Bearer} {result}";
    }

    private static HttpContent SerializeBody<T>(T obj, string type, bool isForSnakeCase)
    {
        switch (type)
        {
            case MediaType.Json:
                string jsonContent = JsonSerializer.Serialize(obj);
                return new StringContent(jsonContent, Encoding.UTF8, MediaType.Json);

            case MediaType.FormUrlEncoded:
                if (obj is Dictionary<string, string> dictionary)
                {
                    return new FormUrlEncodedContent(dictionary);
                }

                // Convert other objects to dictionary (optional)
                var properties = obj.GetType()
                    .GetProperties()
                    .Where(p => p.GetValue(obj) != null)
                    .ToDictionary(p => isForSnakeCase ? JsonNamingPolicy.SnakeCaseLower.ConvertName(p.Name) : p.Name,
                        p => p.GetValue(obj)?.ToString());

                return new FormUrlEncodedContent(properties);

            default:
                throw new ArgumentException("Unsupported media type.");
        }
    }

    private async Task<dynamic> ResponseHandlerAsync<TResponse>(Func<Task<HttpResponseMessage>> action)
    {
        try
        {
            HttpResponseMessage response = await action();
            if (!response.IsSuccessStatusCode)
            {
                throw new BaseException($"{_providerName} -- Request unsuccessful: {response.ReasonPhrase}", (int) response.StatusCode, null);
            }

            string content = await response.Content.ReadAsStringAsync();
            if (content.Trim().StartsWith("<"))
            {
                return content;
            }

            return !string.IsNullOrEmpty(content) ? JsonSerializer.Deserialize<TResponse>(content) : content;
        }
        catch (JsonException ex)
        {
            // JSON deserialization error
            _logger.LogError($"{_providerName} -- Failed to parse JSON: {ex.Message}");
            throw;
        }
        catch (TaskCanceledException)
        {
            // Timeout or cancellation
            _logger.LogError($"{_providerName} -- Request timed out or was canceled.");
            throw;
        }
        catch (Exception ex)
        {
            // General error
            _logger.LogError($"{_providerName} -- Unexpected error: {ex.Message}");
            throw;
        }
    }
}