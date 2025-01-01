using Ecom.API.Helpers;
using Ecom.API.Protos;
using Ecom.API.Protos.Dtos.Product;
using Ecom.API.Protos.Services;
using Ecom.Application.Dtos.Product;
using Ecom.Application.Interfaces.Services;
using Ecom.Domain.Shared;
using Grpc.Core;

namespace Ecom.API.GrpcServices;

public class ProductGrpcService(IProductService _productService) : ProductGrpc.ProductGrpcBase
{
    // public override async Task<GrpcResponse> SearchAsync(SearchRequest request, ServerCallContext context)
    // {
    //     BaseResponse<PagingResponse<ProductDto>> result =
    //         await productService.SearchAsync(request.Adapt<Ecom.Domain.Shared.SearchRequest>());
    //
    //     var encoded = Any.Pack(result.Data.Adapt<PagingResponse>());
    //     var decode = encoded.Unpack<PagingResponse<ProductDto>>();
    //     
    //     return new GrpcResponse
    //     {
    //         Code = result.Code,
    //         Data = Any.Pack(result.Data.Adapt<PagingResponse>())
    //     };
    //     // return GrpcHelper.TypeConverting(result, new GrpcResponse());
    // }

    public override async Task<GrpcResponse> GetByIdAsync(IdRequest request, ServerCallContext context)
    {
        BaseResponse<ProductDto> result = await _productService.GetByIdAsync(request.Id);

        return GrpcHelper.TypeConverting<BaseResponse<ProductDto>, GrpcResponse>(result);
    }
}
