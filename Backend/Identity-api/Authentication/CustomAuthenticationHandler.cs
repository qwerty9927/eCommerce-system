using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Identity_api.Authentication;

public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationOptions>
{
    private readonly ILogger _logger;

    /// <summary>
    /// The IdentityUrl.
    /// </summary>
    public static string IdentityUrl { get; set; }

    /// <summary>
    /// The Secret.
    /// </summary>
    public static string Secret { get; set; }

    /// <summary>
    /// The EnableIdentityUrl.
    /// </summary>
    public static bool EnableIdentityUrl { get; set; }

    /// <summary>
    /// The Memorycache.
    /// </summary>
    private readonly IMemoryCache _cache;


    /// <summary>
    /// The cacheKey.
    /// </summary>
    private const string CacheKey = "SigningKeys";

    /// <summary>
    /// The CustomAuthenticationHandler constructor.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="encoder">The encoder.</param>
    /// <param name="clock">The clock.</param>
    /// <param name="cache">The cache.</param>
    public CustomAuthenticationHandler(
        IOptionsMonitor<CustomAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IMemoryCache cache
    ) : base(options, logger, encoder, clock)
    {
        _cache = cache;
        _logger = logger.CreateLogger<CustomAuthenticationHandler>();
    }

    /// <summary>
    /// Handle Authenticate Async.
    /// </summary>
    /// <returns>Task{AuthenticateResult}</returns>
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));
        }

        var authorizationHeader = Request.Headers["Authorization"].ToString();

        if (string.IsNullOrWhiteSpace(authorizationHeader))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        if (!authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));
        }

        var token = authorizationHeader.Substring("Bearer ".Length).Trim();

        if (string.IsNullOrEmpty(token))
        {
            return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));
        }

        try
        {
            var authResult = ValidateToken(token);
            return Task.FromResult(authResult);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Token validation failed.");
            return Task.FromResult(AuthenticateResult.Fail("Token validation failed."));
        }

    }

    private AuthenticateResult ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return AuthenticateResult.Fail("Unauthorized");
        }

        ClaimsIdentity identity = GetIdentityFromToken(token);
        identity.AddClaim(new Claim("AccessToken", token));

        GenericPrincipal principal = new GenericPrincipal(identity, null);
        AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }

    private ClaimsIdentity GetIdentityFromToken(string token, bool isRetry = false)
    {
        try
        {
            var validationParameters = new TokenValidationParameters()
            {
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = false,
                RequireExpirationTime = false,
                RequireSignedTokens = false,
            };

            if (EnableIdentityUrl)
            {
                var signingKeysFromCache = GetKeys();

                if (signingKeysFromCache == null)
                {
                    string id4MetaData = $"{IdentityUrl}/.well-known/openid-configuration";
                    var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                        id4MetaData, new OpenIdConnectConfigurationRetriever());
                    var openIdConfig = configurationManager.GetConfigurationAsync(CancellationToken.None).Result;

                    signingKeysFromCache = openIdConfig.SigningKeys;
                    SetKeys(openIdConfig.SigningKeys);
                }

                validationParameters.ValidateLifetime = true;
                validationParameters.ValidateIssuerSigningKey = true;
                validationParameters.ValidateTokenReplay = true;
                validationParameters.IssuerSigningKeys = signingKeysFromCache;
            }
            else
            {
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
                validationParameters.IssuerSigningKey = securityKey;
            }

            var tokenDecoder = new JwtSecurityTokenHandler();
            var jwtSecurityToken = (JwtSecurityToken)tokenDecoder.ReadToken(token);
            string tokenRaw = EnableIdentityUrl ? token : jwtSecurityToken.RawData;

            ClaimsPrincipal principal = tokenDecoder.ValidateToken(tokenRaw, validationParameters, out _);

            return principal.Identities.FirstOrDefault();
        }
        catch (SecurityTokenExpiredException ex)
        {
            _logger.LogError(ex,
                $"Call to {nameof(GetIdentityFromToken)} failed with {nameof(SecurityTokenExpiredException)}");
            if (!isRetry && EnableIdentityUrl)
            {
                RemoveKeys();
                return GetIdentityFromToken(token, true);
            }

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Call to {nameof(GetIdentityFromToken)} failed with message: {ex.Message}");
            throw;
        }
    }
    
    public IEnumerable<SecurityKey> GetKeys()
    {
        if (_cache.TryGetValue(CacheKey, out IEnumerable<SecurityKey> keys))
        {
            return keys;
        }

        // If the keys are not in the cache, return null or an empty list, depending on your requirements
        return null;
    }
    
    public void RemoveKeys()
    {
        _cache.Remove(CacheKey);
    }
    
    public void SetKeys(IEnumerable<SecurityKey> keys)
    {
        _cache.Set(CacheKey, keys, TimeSpan.FromDays(1)); // Adjust cache expiration time as needed
    }
}