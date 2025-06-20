using System.Text.Json.Serialization;

namespace Identity_api.WebApi.Identity.Dtos;

public class PasswordTokenRequest
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string GrantType { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Scope { get; set; }
}