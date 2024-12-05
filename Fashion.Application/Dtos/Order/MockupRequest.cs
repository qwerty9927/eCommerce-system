using Fashion.Application.Dtos.DeliveryInformation;
using Fashion.Application.Dtos.Product;

namespace Fashion.Application.Dtos.Order;

public class MockupRequest
{
    public string SourceId { get; set; }

    public DeliveryInformationDto DeliveryInformation { get; set; }

}
