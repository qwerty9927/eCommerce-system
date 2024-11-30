using System.Net;
using System.Security.Claims;
using Fashion.Application.Configurations;
using Fashion.Application.Dtos.Account;
using Fashion.Application.Helpers;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Constants;
using Fashion.Domain.Entities;
using Fashion.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Fashion.Application.Service;

public class AccountService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    RoleManager<IdentityRole> roleManager,
    IOptions<JwtSettings> options,
    IHttpContextAccessor httpContextAccessor) : IAccountService
{
    public async Task<BaseResponse<bool>> RegisterAsync(RegisterAccount request)
    {
        try
        {
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                UserName = request.Email,
                FullName = request.FullName,
                URLImage = request.URLImage
            };
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new BaseException();
            }

            await userManager.AddToRoleAsync(user, RoleConstant.User);

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Register failed"
            };
        }
    }

    public async Task<BaseResponse<object>> LoginAsync(string email, string password)
    {
        try
        {
            var result = await signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new BaseException();
            }

            var user = await userManager.FindByEmailAsync(email);
            var roles = (await userManager.GetRolesAsync(user)).ToList();

            var token = Security.GenerateJwtToken(user, roles, options.Value.Key);

            return new SuccessResponse<object>(new { token });
        }
        catch (BaseException ex)
        {
            return new BadResponse<object>(default)
            {
                Code = ex.Code ?? (int)HttpStatusCode.Unauthorized,
                Message = ex.Message ?? "Login failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> CreateRoleAsync(string roleName)
    {
        try
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));

                if (!result.Succeeded)
                {
                    throw new BaseException();
                }
            }

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Create role failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> CreateAccountAsync(CreateAccount request)
    {
        try
        {
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                UserName = request.Email,
            };
            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new BaseException();
            }

            await userManager.AddToRoleAsync(user, request.Role);

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Create failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> UpdateAsync(UpdateRequest request)
    {
        try
        {
            string id = httpContextAccessor.HttpContext.User.Claims
                .Any(c => c.Type == ClaimTypes.Role && c.Value != RoleConstant.Admin)
                ? httpContextAccessor.HttpContext.User.Claims
                    .First(c => c.Type == ClaimTypesExtension.UserId).Value
                : request.Id;

            var foundUser = await userManager.FindByIdAsync(id);
            if (foundUser == null)
            {
                throw new BaseException
                {
                    Message = "User not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            if (request.OldPassword != null && request.NewPassword != null)
            {
                var passwordUpdate = await userManager.ChangePasswordAsync(foundUser, request.OldPassword, request.NewPassword);
                if (!passwordUpdate.Succeeded)
                {
                    throw new BaseException { Message = "Password doesn't match" };
                }
            }

            foundUser.FullName = request.FullName ?? foundUser.FullName;
            foundUser.URLImage = request.URLImage ?? foundUser.URLImage;

            var result = await userManager.UpdateAsync(foundUser);

            if (!result.Succeeded)
            {
                throw new BaseException();
            }

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Update failed"
            };
        }
    }
    public async Task<BaseResponse<bool>> DeleteAsync(string id)
    {
        try
        {
            var foundUser = await userManager.FindByIdAsync(id);
            if (foundUser == null)
            {
                throw new BaseException
                {
                    Message = "User not found",
                    Code = (int)HttpStatusCode.NotFound
                };
            }

            var result = await userManager.DeleteAsync(foundUser);
            if (!result.Succeeded)
            {
                throw new BaseException();
            }

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Delete failed"
            };
        }
    }
}
