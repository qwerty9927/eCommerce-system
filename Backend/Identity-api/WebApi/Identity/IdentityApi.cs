using System.Net.Http.Headers;
using Duende.IdentityServer.Models;
using Identity_api.Common;
using Identity_api.Configurations;
using Identity_api.Constants;
using Identity_api.Dtos;
using Identity_api.Helpers;
using Identity_api.Interfaces.WebApi;
using Identity_api.WebApi.Identity.Dtos;
using Microsoft.Extensions.Options;

namespace Identity_api.WebApi.Identity;

public class IdentityApi(
    HttpClient httpClient,
    ILogger<RestHttpClientHelper> logger,
    IOptions<OpenIDConnectSettings> openidConnectSettings,
    IHttpContextAccessor httpContextAccessor)
    : RestHttpClientHelper(httpClient, logger, httpContextAccessor, nameof(IdentityApi)), IIdentityApi
{
    private HttpClient _httpClient = httpClient;
    private OpenIDConnectSettings _openidConnectSettings = openidConnectSettings.Value;

    public async Task<TokenDto> GetTokenByGrantPasswordAsync(string username, string password)
    {
        FluentUriBuilder uri = new FluentUriBuilder($"{_openidConnectSettings.Authority}/connect/token");
        PasswordTokenRequest request = new()
        {
            ClientId = _openidConnectSettings.Password.ClientId,
            ClientSecret = _openidConnectSettings.Password.ClientSecret,
            GrantType = GrantType.ResourceOwnerPassword,
            Username = username,
            Password = password,
            Scope = AuthScope.OfflineAccess
        };

        TokenDto result = await PostAsync<object, TokenDto>(uri.Build(), request, MediaType.FormUrlEncoded, true);

        return result;
    }
    
    
    public async Task<TokenDto> RefreshTokenAsync(string refreshToken)
    {
        FluentUriBuilder uri = new FluentUriBuilder($"{_openidConnectSettings.Authority}/connect/token");
        RefreshTokenRequest request = new()
        {
            ClientId = _openidConnectSettings.Password.ClientId,
            ClientSecret = _openidConnectSettings.Password.ClientSecret,
            GrantType = "refresh_token",
            RefreshToken = refreshToken,
        };

        TokenDto result = await PostAsync<object, TokenDto>(uri.Build(), request, MediaType.FormUrlEncoded, true);

        return result;
    }

    public async Task<bool> RevokeTokenAsync(string token)
    {
        FluentUriBuilder uri = new FluentUriBuilder($"{_openidConnectSettings.Authority}/connect/revocation");
        RevokeTokenRequest request = new()
        {
            Token = token,
            TokenTypeHint = "refresh_token"
        };

        string authenticationToken = StrategyAuthorization(AuthorizationMethod.Basic,
            new { _openidConnectSettings.Password.ClientId, _openidConnectSettings.Password.ClientSecret });
        AddRequestHeaders("Authorization", authenticationToken);
        await PostAsync<object, string>(uri.Build(), request, MediaType.FormUrlEncoded, true);

        return true;
    }
}