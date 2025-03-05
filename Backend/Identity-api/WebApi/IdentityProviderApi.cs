using Grpc.Core;
using Identity_api.Common;
using Identity_api.Configurations;
using Identity_api.Constants;
using Identity_api.Dtos;
using Identity_api.Helpers;
using Identity_api.Interfaces.WebApi;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Identity_api.WebApi;

public class IdentityProviderApi : IIdentityProviderApi
{
    private readonly OpenIDConnectSettings _openIdConnectSettings;
    private readonly HttpClient _httpClient;
    private readonly RestHttpClientHelper _clientHelper;

    public IdentityProviderApi(IOptions<OpenIDConnectSettings> options, RestHttpClientHelper clientHelper)
    {
        _openIdConnectSettings = options.Value;
        _clientHelper = clientHelper;
        _httpClient = clientHelper.GetHttpClientInstance();
    }

    public async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync()
    {
        var discovery = await _httpClient.GetDiscoveryDocumentAsync(_openIdConnectSettings.Authority);
        if (discovery.IsError)
        {
            throw new BaseException(
                $"{_openIdConnectSettings.Name}: {nameof(GetDiscoveryDocumentAsync)} failed",
                (int)StatusCode.NotFound);
        }

        return discovery;
    }

    public async Task<TokenDto> GetAccessTokenByPasswordAsync(string username, string password)
    {
        FluentUriBuilder uri = new(_openIdConnectSettings.Authority);
        uri.AppendPathParam("connect/token");

        var formUrlEncoded = new Dictionary<string, string>
        {
            { "client_id", _openIdConnectSettings.Password.ClientId },
            { "client_secret", _openIdConnectSettings.Password.ClientSecret },
            { "grant_type", "password" },
            { "username", username },
            { "password", password },
            { "scope", "openid profile" }
        };

        return await _clientHelper.PostAsync<Dictionary<string, string>, TokenDto>(uri.Build(), formUrlEncoded,
            MediaType.FormUrlEncoded);
    }
}