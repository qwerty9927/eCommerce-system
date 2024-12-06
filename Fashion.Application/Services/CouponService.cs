using Fashion.Application.Interfaces.Repository;
using Fashion.Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;

namespace Fashion.Application.Service;

public class CouponService(
    ICouponRepository couponRepository,
    IHttpContextAccessor httpContextAccessor) : ICouponService
{
}
