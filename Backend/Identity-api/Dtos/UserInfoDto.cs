namespace Identity_api.Dtos;

public class UserInfoDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string? FullName { get; set; }
    public string? UrlImage { get; set; }
}