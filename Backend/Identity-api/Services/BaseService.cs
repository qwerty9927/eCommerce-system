using Microsoft.AspNetCore.Identity;

namespace Identity_api.Services;

public class BaseService
{
    protected static async Task EnsureModifyActionSuccess(Func<Task<IdentityResult>> action, string funcName)
    {
        try
        {
            var result = await action();
            if (result is { Succeeded: false })
            {
                throw new Exception($"{funcName} -- Internal server error");
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}