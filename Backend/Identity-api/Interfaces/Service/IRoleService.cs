using Identity_api.Common;

namespace Identity_api.Interfaces.Service;

public interface IRoleService
{
    Task<BaseResponse<bool>> CreateRoleAsync(string roleName);
}