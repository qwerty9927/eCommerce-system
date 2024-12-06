namespace Fashion.Domain.Entities
{
    public class DeliveryInformation : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? AddressDetail { get; set; } = string.Empty;

        public string PhoneNumber { get; set; }

        public bool IsDefault { get; set; }

        public string? UserId { get; set; }
    }
}
