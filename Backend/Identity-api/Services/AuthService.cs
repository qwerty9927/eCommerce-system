using Identity_api.Common;
using Identity_api.Dtos;
using Identity_api.Interfaces.Service;
using Identity_api.Interfaces.WebApi;
using Identity_api.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Identity_api.Services;

public class AuthService(
    UserManager<UserModel> userManager,
    IIdentityApi identityApi
) : BaseService, IAuthService
{
    public async Task<BaseResponse<TokenDto>> LoginAsync(LoginRequest request)
    {
        TokenDto tokenDto = await identityApi.GetTokenByGrantPasswordAsync(request.Username, request.Password);

        return new SuccessResponse<TokenDto>(tokenDto);
    }
    
    public async Task<BaseResponse<bool>> RegisterAsync(RegisterRequest request)
    {
        var foundUser = await userManager.FindByNameAsync(request.Username);
        if (foundUser != null)
        {
            throw new ConflictException("Account was existed");
        }

        UserModel user = new UserModel
        {
            UserName = request.Username,
            FullName = request.FullName,
            UrlImage = request.UrlImage
        };

        await EnsureModifyActionSuccess(async () => await userManager.CreateAsync(user, request.Password),
            nameof(userManager.CreateAsync));

        return new SuccessResponse<bool>(true);
    }

    public async Task<BaseResponse<TokenDto>> RefreshTokenAsync(string refreshToken)
    {
        var result = await identityApi.RefreshTokenAsync(refreshToken);
        
        return new SuccessResponse<TokenDto>(result);
    }

    public async Task<BaseResponse<bool>> RevokeTokenAsync(string token)
    {
        var result = await identityApi.RevokeTokenAsync(token);

        return new SuccessResponse<bool>(result);
    }

    public async Task<BaseResponse<UserInfoDto>> GetUserInfoByEmailAsync(string email)
    {
        var foundUser = await userManager.FindByEmailAsync(email);

        if (foundUser == null)
        {
            throw new NotFoundException("User not found");
        }

        var result = foundUser.Adapt<UserInfoDto>();

        return new SuccessResponse<UserInfoDto>(result);
    }

    public async Task<BaseResponse<bool>> DeleteAsync(string id)
    {
        var foundUser = await userManager.FindByIdAsync(id);

        if (foundUser != null)
        {
            await EnsureModifyActionSuccess(async () => await userManager.DeleteAsync(foundUser),
                nameof(userManager.DeleteAsync));
        }

        return new SuccessResponse<bool>(true);
    }
}