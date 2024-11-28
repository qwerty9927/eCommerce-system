using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface IAccountService
{
    Task<BaseResponse<bool>> RegisterAsync(string email, string password);
    Task<BaseResponse<object>> LoginAsync(string email, string password);
    Task<BaseResponse<bool>> CreateRoleAsync(string roleName);
}
