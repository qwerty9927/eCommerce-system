using System.ComponentModel.DataAnnotations;

namespace Identity_api.Dtos;

public class RegisterRequest
{
    [EmailAddress]
    public string Username { get; set; }

    [StringLength(maximumLength: 100, MinimumLength = 8,
        ErrorMessage = "Password must be between 8 and 100 characters.")]
    public string Password { get; set; }
    
    public string? FullName { get; set; }
    
    public string? UrlImage { get; set; }
}