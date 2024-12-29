using Ecom.API.Helpers;
using Ecom.API.Protos;
using Ecom.Application.Dtos.Product;
using Ecom.Application.Interfaces.Services;
using Ecom.Domain.Shared;
using Grpc.Core;
using Mapster;
using SearchRequest = Ecom.API.Protos.SearchRequest;

namespace Ecom.API.GrpcServices;

public class ProductGrpcService(IProductService productService) : Product.ProductBase
{
    public override async Task<GrpcResponse> SearchAsync(SearchRequest request, ServerCallContext context)
    {
        BaseResponse<PagingResponse<ProductDto>> result =
            await productService.SearchAsync(request.Adapt<Ecom.Domain.Shared.SearchRequest>());

        return GrpcHelper.TypeConverting<BaseResponse<PagingResponse<ProductDto>>, GrpcResponse>(result);
    }
}
