using Identity_api.Dtos;

namespace Identity_api.Interfaces.WebApi;

public interface IIdentityApi
{
    Task<TokenDto> GetTokenByGrantPasswordAsync(string username, string password);
    Task<TokenDto> RefreshTokenAsync(string refreshToken);
    Task<bool> RevokeTokenAsync(string token);
}