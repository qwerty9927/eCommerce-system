using System.Net;
using Fashion.Application.Dtos.DeliveryInformation;
using Fashion.Application.Interfaces.Repository;
using Fashion.Application.Interfaces.Service;
using Fashion.Domain.Constants;
using Fashion.Domain.Entities;
using Fashion.Domain.Shared;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Fashion.Application.Service;

public class DeliveryInformationService(
    IDeliveryInformationRepository deliveryInformationRepository,
    IHttpContextAccessor httpContextAccessor) : IDeliveryInformationService
{
    public async Task<BaseResponse<bool>> CreateAsync(DeliveryInformationDto request)
    {
        try
        {
            string userId = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypesExtension.UserId).Value;

            var isCreated = await deliveryInformationRepository.CreateAsync(request.Adapt<DeliveryInformation>());
            if (!isCreated)
            {
                throw new BaseException();
            }

            return new SuccessResponse<bool>(true);
        }
        catch (BaseException ex)
        {
            return new BadResponse<bool>(false)
            {
                Code = ex.Code ?? (int)HttpStatusCode.BadRequest,
                Message = ex.Message ?? "Create failed"
            };
        }
    }
}
