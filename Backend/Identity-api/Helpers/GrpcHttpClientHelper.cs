using System.Net;

namespace Identity_api.Helpers;

public class GrpcHttpClientHelper
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<GrpcHttpClientHelper> _logger;

    public GrpcHttpClientHelper(HttpClient httpClient, ILogger<GrpcHttpClientHelper> logger)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestVersion = HttpVersion.Version20;
        _httpClient.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
        _logger = logger;
    }
    
    public HttpClient GetHttpClientInstance()
    {
        return _httpClient;
    }
}