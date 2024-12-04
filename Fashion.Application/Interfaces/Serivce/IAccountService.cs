using Fashion.Application.Dtos.Account;
using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface IAccountService
{
    Task<BaseResponse<bool>> RegisterAsync(RegisterAccount request);
    Task<BaseResponse<object>> LoginAsync(LoginAccount request);
    Task<BaseResponse<bool>> CreateRoleAsync(string roleName);
    Task<BaseResponse<bool>> CreateAccountAsync(CreateAccount request);
    Task<BaseResponse<bool>> UpdateAsync(UpdateAccount request);
    Task<BaseResponse<bool>> DeleteAsync(string accountId);
    Task<BaseResponse<AccountDto>> GetInfoAsync();
}
