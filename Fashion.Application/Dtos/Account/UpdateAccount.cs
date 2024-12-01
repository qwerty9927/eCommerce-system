namespace Fashion.Application.Dtos.Account;

public class UpdateAccount
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string URLImage { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string VerifyCode { get; set; }
}
