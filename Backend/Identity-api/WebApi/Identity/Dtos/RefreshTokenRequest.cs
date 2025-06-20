namespace Identity_api.WebApi.Identity.Dtos;

public class RefreshTokenRequest
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string GrantType { get; set; }
    public string RefreshToken { get; set; }
}