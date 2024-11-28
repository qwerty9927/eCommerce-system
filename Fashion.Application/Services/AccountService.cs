using System.Net;
using Fashion.Application.Configurations;
using Fashion.Application.Helpers;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Constants;
using Fashion.Domain.Entities;
using Fashion.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Fashion.Application.Service;

public class AccountService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    RoleManager<IdentityRole> roleManager,
    IOptions<JwtSettings> options) : IAccountService
{
    public async Task<BaseResponse<bool>> RegisterAsync(string email, string password)
    {
        try
        {
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                UserName = email,
            };
            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception();
            }

            await userManager.AddToRoleAsync(user, RoleConstant.User);

            return new SuccessResponse<bool>(true);
        }
        catch (Exception ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = (int)HttpStatusCode.BadRequest,
                Message = "Register failed"
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
                throw new Exception();
            }

            var user = await userManager.FindByEmailAsync(email);

            var token = Security.GenerateJwtToken(user, options.Value.Key);

            return new SuccessResponse<object>(new { token });
        }
        catch (Exception ex)
        {
            return new BadResponse<object>(default)
            {
                Code = (int)HttpStatusCode.Unauthorized,
                Message = "Login failed"
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
                    throw new Exception();
                }
            }

            return new SuccessResponse<bool>(true);
        }
        catch (Exception ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = (int)HttpStatusCode.BadRequest,
                Message = "Create role failed"
            };
        }
    }

    public async Task<BaseResponse<bool>> CreateAccountAsync(string email, string password, string role)
    {
        try
        {
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                UserName = email,
                PasswordHash = Security.ComputeMd5Hash(password)
            };
            var result = await userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception();
            }

            var test = await userManager.AddToRoleAsync(user, RoleConstant.User);

            return new SuccessResponse<bool>(true);
        }
        catch (Exception ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = (int)HttpStatusCode.BadRequest,
                Message = "Register failed"
            };
        }
    }
}
