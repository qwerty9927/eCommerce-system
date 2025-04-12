using Microsoft.AspNetCore.Identity;

namespace Identity_api.Models;

public class UserModel : IdentityUser
{
    public string? FullName { get; set; }
    public string? UrlImage { get; set; }
}