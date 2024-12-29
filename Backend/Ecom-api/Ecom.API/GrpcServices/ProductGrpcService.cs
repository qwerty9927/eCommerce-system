using Ecom.API.Protos;
using Ecom.Application.Interfaces.Services;
using Grpc.Core;
using Mapster;

namespace Ecom.API.GrpcServices;

public class ProductGrpcService(IProductService productService) : Product.ProductBase
{
    public override async Task<BaseResponse> SearchAsync(SearchRequest request, ServerCallContext context)
    {
        return (await productService.SearchAsync(request.Adapt<Ecom.Domain.Shared.SearchRequest>()))
            .Adapt<BaseResponse>();
    }
}
