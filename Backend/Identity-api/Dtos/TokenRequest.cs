using System.Text.Json.Serialization;

namespace Identity_api.Dtos;

public class TokenRequest
{
    [JsonPropertyName("client_id")] 
    public string ClientId { get; set; }

    [JsonPropertyName("client_secret")] 
    public string ClientSecret { get; set; }

    [JsonPropertyName("grant_type")] 
    public string GrantType { get; set; }

    [JsonPropertyName("code")] 
    public string Code { get; set; }

    [JsonPropertyName("redirect_uri")] 
    public string RedirectUri { get; set; }

    [JsonPropertyName("code_verifier")] 
    public string CodeVerifier { get; set; }
}