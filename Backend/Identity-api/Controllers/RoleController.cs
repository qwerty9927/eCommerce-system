using Identity_api.Common;
using Identity_api.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity_api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RoleController(IRoleService roleService) : ControllerBase
{
    [HttpPost]
    public async Task<BaseResponse<bool>> CreateRoleAsync([FromBody] string roleName)
    {
        return await roleService.CreateRoleAsync(roleName);
    }
}