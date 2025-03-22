using Identity_api.Common;
using Identity_api.Constants;
using Identity_api.Dtos;
using Identity_api.Interfaces.Service;
using Identity_api.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity_api.Services;

public class AuthService(UserManager<UserModel> userManager) : BaseService, IAuthService
{
    public async Task<BaseResponse<bool>> RegisterAsync(RegisterRequest request)
    {
        var foundUser = await userManager.FindByNameAsync(request.Username);
        if (foundUser != null)
        {
            throw new BaseException("Account was existed", StatusCodes.Status409Conflict);
        }

        UserModel user = new UserModel
        {
            Email = request.Email,
            UserName = request.Username,
            FullName = request.FullName,
            UrlImage = request.UrlImage
        };

        await EnsureModifyActionSuccess(async () => await userManager.AddToRoleAsync(user, RoleConstant.User),
            nameof(userManager.AddToRoleAsync));
        await EnsureModifyActionSuccess(async () => await userManager.CreateAsync(user, request.Password),
            nameof(userManager.CreateAsync));

        return new SuccessResponse<bool>(true);
    }

    public async Task<BaseResponse<bool>> DeleteAsync(string id)
    {
        var foundUser = await userManager.FindByIdAsync(id);
        if (foundUser != null)
        {
            throw new BaseException("Account was existed", StatusCodes.Status409Conflict);
        }

        await EnsureModifyActionSuccess(async () => await userManager.DeleteAsync(foundUser),
            nameof(userManager.DeleteAsync));

        return new SuccessResponse<bool>(true);
    }
}