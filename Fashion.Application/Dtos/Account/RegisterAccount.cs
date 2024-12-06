namespace Fashion.Application.Dtos.Account;

public class RegisterAccount
{
    public string Email { get; set; }
    public string FullName { get; set; }
    public string URLImage { get; set; } = string.Empty;
    public string Password { get; set; }
}
