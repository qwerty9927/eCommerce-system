namespace Identity_api.Dtos;

public class UserAuthorizeDto
{
    public string SubjectId { get; set; }
    public string Username { get; set; }
    public bool RememberLogin { get; set; }
    public bool IsValid { get; set; }
}