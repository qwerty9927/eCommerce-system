using Grpc.Core;
using Identity_api;
using Identity_api.Interfaces.WebApi;
using Identity_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Identity_api.Services;

public class GreeterService(
    ILogger<GreeterService> logger,
    IIdentityProviderApi identityProviderApi,
    UserManager<UserModel> userManager) : Greeter.GreeterBase
{
    // [Authorize]
    public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        // var foundUser = await userManager.FindByEmailAsync(request.Email);
        // if (foundUser != null)
        // {
        //     throw new ErrorResponse("Account was existed");
        // }
        //
        // User user = new User
        // {
        //     Id = Guid.NewGuid().ToString(),
        //     Email = request.Email,
        //     UserName = request.Email,
        //     FullName = request.FullName,
        //     URLImage = request.URLImage
        // };
        // var result = await userManager.CreateAsync(user, request.Password);
        //
        // if (!result.Succeeded)
        // {
        //     throw new ErrorResponse();
        // }
        //
        // await userManager.AddToRoleAsync(user, RoleConstant.User);
        //
        // return new SuccessResponse<bool>(true);

        return new HelloReply
        {
            Message = "Hello " + request.Name
        };
    }
}