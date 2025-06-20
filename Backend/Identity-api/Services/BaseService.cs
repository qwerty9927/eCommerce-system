using Identity_api.Common;
using Microsoft.AspNetCore.Identity;

namespace Identity_api.Services;

public class BaseService
{
    protected static async Task EnsureModifyActionSuccess(Func<Task<object>> action, string funcName)
    {
        try
        {
            var result = await action();
            if (result is IdentityResult { Succeeded: false })
            {
                throw new BadRequestException($"{funcName} -- Modify user failed.");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}