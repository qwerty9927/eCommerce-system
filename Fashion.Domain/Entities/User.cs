using Microsoft.AspNetCore.Identity;
namespace Fashion.Domain.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }

        public Cart Cart { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string URLImage { get; set; } = string.Empty;

        public int? VerifyCode { get; set; }
    }
}
