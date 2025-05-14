using Identity_api.Authentication;
using Identity_api.Configurations;

namespace Identity_api.Extensions
{
    public static class SetupJWTServices
    {
        public static void AddJWTServices(this IServiceCollection services, OpenIDConnectSettings openIdConnectSettings)
        {
            bool enableIdentityUrl = openIdConnectSettings.EnableIdentityUrl;
            CustomAuthenticationHandler.EnableIdentityUrl = enableIdentityUrl;

            if (enableIdentityUrl)
            {
                CustomAuthenticationHandler.IdentityUrl = openIdConnectSettings.Authority;
            }
            else
            {
                string key = openIdConnectSettings.Key; // this should be same which is used while creating token
                CustomAuthenticationHandler.Secret = key;
            }

            services.AddAuthentication(options =>
                {
                    // Set the default scheme to Bearer
                    options.DefaultAuthenticateScheme = "Bearer";
                    options.DefaultChallengeScheme = "Bearer";
                })
                .AddScheme<CustomAuthenticationOptions, CustomAuthenticationHandler>("Bearer", options => { });

            services.AddAuthorization();
        }
    }
}
