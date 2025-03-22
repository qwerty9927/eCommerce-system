using System.Text;
using System.Text.Json;
using Ecom.Domain.Constants;
using Microsoft.Extensions.Logging;

namespace Ecom.Infrastructure.Helper;

public class RestHttpClientHelper
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<RestHttpClientHelper> _logger;

    public RestHttpClientHelper(HttpClient httpClient, ILogger<RestHttpClientHelper> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public HttpClient GetHttpClientInstance()
    {
        return _httpClient;
    }

    public async Task<TResponse> GetAsync<TResponse>(Uri uri)
    {
        Func<Task<HttpResponseMessage>> action = () => _httpClient.GetAsync(uri);

        return await ResponseHandlerAsync<TResponse>(action);
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request,
        string type = MediaType.Json)
    {
        var payload = Serialize(request, type);
        Func<Task<HttpResponseMessage>> action = () => _httpClient.PostAsync(uri, payload);

        return await ResponseHandlerAsync<TResponse>(action);
    }

    public async Task<bool> PutAsync<TRequest>(Uri uri, TRequest request, string type = MediaType.Json)
    {
        var payload = Serialize(request, type);
        Func<Task<HttpResponseMessage>> action = () => _httpClient.PutAsync(uri, payload);

        return await ResponseHandlerAsync<bool>(action);
    }

    public async Task<bool> DeleteAsync(Uri uri)
    {
        Func<Task<HttpResponseMessage>> action = () => _httpClient.DeleteAsync(uri);

        return await ResponseHandlerAsync<bool>(action);
    }

    public void AddRequestHeaders(string headerParameterName, string headerParameterValue)
    {
        if (string.IsNullOrEmpty(headerParameterName))
        {
            throw new ArgumentNullException(nameof(headerParameterName));
        }

        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(headerParameterName, headerParameterValue);
    }

    private static HttpContent Serialize<T>(T obj, string type)
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
                    .ToDictionary(p => p.Name, p => p.GetValue(obj)?.ToString());

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
                throw new HttpRequestException($"{nameof(RestHttpClientHelper)} -- Request unsuccessful.");
            }

            string content = await response.Content.ReadAsStringAsync();
            if (content.Trim().StartsWith("<"))
            {
                return content;
            }

            return JsonSerializer.Deserialize<TResponse>(content) ?? throw new NullReferenceException();
        }
        catch (HttpRequestException ex)
        {
            // Network errors or non-success status codes
            _logger.LogError($"{nameof(RestHttpClientHelper)} -- Request failed: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            // JSON deserialization error
            _logger.LogError($"{nameof(RestHttpClientHelper)} -- Failed to parse JSON: {ex.Message}");
            throw;
        }
        catch (TaskCanceledException)
        {
            // Timeout or cancellation
            _logger.LogError($"{nameof(RestHttpClientHelper)} -- Request timed out or was canceled.");
            throw;
        }
        catch (Exception ex)
        {
            // General error
            _logger.LogError($"{nameof(RestHttpClientHelper)} -- Unexpected error: {ex.Message}");
            throw;
        }
    }
}
