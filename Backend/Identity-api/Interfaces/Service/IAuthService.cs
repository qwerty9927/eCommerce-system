using Identity_api.Common;
using Identity_api.Dtos;

namespace Identity_api.Interfaces.Service;

public interface IAuthService
{
    Task<BaseResponse<bool>> RegisterAsync(RegisterRequest request);
    Task<BaseResponse<bool>> DeleteAsync(string id);
}