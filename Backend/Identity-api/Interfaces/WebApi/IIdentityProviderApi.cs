using Identity_api.Dtos;
using IdentityModel.Client;

namespace Identity_api.Interfaces.WebApi;

public interface IIdentityProviderApi
{
    Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync();
    Task<TokenDto> GetAccessTokenByPasswordAsync(string username, string password);
}