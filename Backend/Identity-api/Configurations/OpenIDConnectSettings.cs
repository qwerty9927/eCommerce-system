namespace Identity_api.Configurations;

public class OpenIDConnectSettings
{
    public string Name { get; set; }
    public string Authority { get; set; }
    public GeneralGrantTypeSetting ClientCredentials { get; set; }
    public GeneralGrantTypeSetting AuthorizationCode { get; set; }
    public GeneralGrantTypeSetting Password { get; set; }
    public PckeGrantType Pcke { get; set; }
}

public class GeneralGrantTypeSetting
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}

public class PckeGrantType : GeneralGrantTypeSetting
{
    public string CodeChallenge { get; set; }
    public string CodeChallengeMethod { get; set; }
    public string CodeVerifier { get; set; }
    public string WebhookExchangeCode { get; set; }
    public string WebhookExchangeToken { get; set; }
}