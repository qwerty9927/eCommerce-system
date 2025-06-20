namespace Identity_api.WebApi.Identity.Dtos;

public class RevokeTokenRequest
{
    public string Token { get; set; }
    public string TokenTypeHint { get; set; }
}