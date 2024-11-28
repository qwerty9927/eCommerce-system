namespace Fashion.Domain.Entities
{
    public class DeliveryInformation : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? CompanyName { get; set; } = string.Empty;

        public string StreetAddress { get; set; }

        public string? AddressDetail { get; set; } = string.Empty;

        public string State { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? OrderNote { get; set; } = string.Empty;

        public string UserId { get; set; }
    }
}
