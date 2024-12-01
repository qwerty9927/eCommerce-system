namespace Fashion.Application.Configurations;

public class StripeSettings
{
    public const string Name = "Stripe";
    public string PublicKey { get; set; }
    public string SecretKey { get; set; }
}
