using Identity_api.Common;
using Identity_api.Dtos;

namespace Identity_api.Interfaces.Service;

public interface IAuthService
{
    Task<BaseResponse<TokenDto>> LoginAsync(LoginRequest request);
    Task<BaseResponse<bool>> RegisterAsync(RegisterRequest request);
    Task<BaseResponse<bool>> RevokeTokenAsync(string token);
    Task<BaseResponse<TokenDto>> RefreshTokenAsync(string refreshToken);
    Task<BaseResponse<UserInfoDto>> GetUserInfoByEmailAsync(string email);
    Task<BaseResponse<bool>> DeleteAsync(string id);
}