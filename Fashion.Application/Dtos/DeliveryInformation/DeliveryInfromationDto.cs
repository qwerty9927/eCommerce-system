using Fashion.Application.Dtos.Product;

namespace Fashion.Application.Dtos.DeliveryInformation;

public class DeliveryInformationDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? AddressDetail { get; set; } = string.Empty;

    public string PhoneNumber { get; set; }
}
