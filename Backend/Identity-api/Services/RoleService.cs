using Identity_api.Common;
using Identity_api.Interfaces.Service;
using Microsoft.AspNetCore.Identity;

namespace Identity_api.Services;

public class RoleService(
    RoleManager<IdentityRole> roleManager) : BaseService, IRoleService
{
    public async Task<BaseResponse<bool>> CreateRoleAsync(string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await EnsureModifyActionSuccess(async () =>
                await roleManager.CreateAsync(new IdentityRole(roleName)), nameof(roleManager.CreateAsync));
        }

        return new SuccessResponse<bool>(true);
    }
}