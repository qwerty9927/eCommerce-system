using Fashion.Application.Dtos.DeliveryInformation;
using Fashion.Domain.Shared;

namespace Fashion.Application.Interfaces.Service;

public interface IDeliveryInformationService
{
    Task<BaseResponse<bool>> CreateAsync(DeliveryInformationDto request);
}
