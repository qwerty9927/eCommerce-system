using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Identity_api.Common;
using Identity_api.Configurations;
using Identity_api.Constants;
using Identity_api.Dtos;
using Identity_api.Helpers;
using Identity_api.Interfaces.WebApi;
using Identity_api.Models;
using Identity_api.Protos;
using Identity_api.Protos.Dtos.Auth;
using Identity_api.Protos.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Identity_api.Services;

public class AuthService(
    UserManager<UserModel> userManager,
    SignInManager<UserModel> signInManager,
    RoleManager<IdentityRole> roleManager,
    IIdentityProviderApi identityProviderApi,
    IOptions<OpenIDConnectSettings> openIDConnectSettings) : AuthGrpc.AuthGrpcBase
{
    public override async Task<GrpcResponse> LoginAsync(LoginRequest request, ServerCallContext context)
    {
        TokenDto result = await identityProviderApi.GetAccessTokenByPasswordAsync(request.Username, request.Password);

        UserModel? foundUser = await userManager.FindByNameAsync(request.Username);

        if (!string.IsNullOrEmpty(result.AccessToken))
        {
            await EnsureModifyActionSuccess(async () =>
                await userManager.SetAuthenticationTokenAsync(foundUser, "JWT", nameof(TokenDto.AccessToken),
                    result.AccessToken));
        }

        return GrpcHelper.ConvertingStrategy<SuccessResponse<TokenDto>, GrpcResponse, TokenResponse>(
            new SuccessResponse<TokenDto>(result));
    }

    public override async Task<GrpcResponse> RegisterAsync(RegisterRequest request, ServerCallContext context)
    {
        var foundUser = await userManager.FindByNameAsync(request.Username);
        if (foundUser != null)
        {
            throw new BaseException("Account was existed", (int)StatusCode.Aborted);
        }

        UserModel user = new UserModel
        {
            Email = request.Email,
            UserName = request.Username,
            FullName = request.FullName,
            UrlImage = request.UrlImage
        };

        await EnsureModifyActionSuccess(async () => await userManager.CreateAsync(user, request.Password));
        await EnsureModifyActionSuccess(async () => await userManager.AddToRoleAsync(user, RoleConstant.User));

        return GrpcHelper.ConvertingStrategy<SuccessResponse<bool>, GrpcResponse, BoolValue>(
            new SuccessResponse<bool>(true));
    }

    public override async Task<GrpcResponse> CreateRoleAsync(CreateRoleRequest request, ServerCallContext context)
    {
        if (!await roleManager.RoleExistsAsync(request.RoleName))
        {
            await EnsureModifyActionSuccess(async () =>
                await roleManager.CreateAsync(new IdentityRole(request.RoleName)));
        }

        return GrpcHelper.ConvertingStrategy<SuccessResponse<bool>, GrpcResponse, BoolValue>(
            new SuccessResponse<bool>(true));
    }

    public override async Task<GrpcResponse> DeleteAsync(IdGrpcRequest request, ServerCallContext context)
    {
        var foundUser = await userManager.FindByIdAsync(request.Id);
        if (foundUser != null)
        {
            throw new BaseException("Account was existed", (int)StatusCode.Aborted);
        }

        await EnsureModifyActionSuccess(async () => await userManager.DeleteAsync(foundUser));
        
        return GrpcHelper.ConvertingStrategy<SuccessResponse<bool>, GrpcResponse, BoolValue>(
            new SuccessResponse<bool>(true));
    }

    private static async Task EnsureModifyActionSuccess(Func<Task<IdentityResult>> action)
    {
        try
        {
            var result = await action();
            if (result is { Succeeded: false })
            {
                throw new Exception("Internal server error");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}