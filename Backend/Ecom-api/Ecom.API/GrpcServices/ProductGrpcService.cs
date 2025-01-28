using Ecom.API.Helpers;
using Ecom.API.Protos.Dtos;
using Ecom.API.Protos.Dtos.Product;
using Ecom.API.Protos.Services;
using Ecom.Application.Dtos.Product;
using Ecom.Application.Interfaces.Services;
using Ecom.Domain.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mapster;

namespace Ecom.API.GrpcServices;

public class ProductGrpcService(IProductService _productService) : ProductGrpc.ProductGrpcBase
{
    public override async Task<GrpcPagingResponse> SearchAsync(SearchGrpcRequest request,
        ServerCallContext context)
    {
        BaseResponse<PagingResponse<ProductDto>> result =
            await _productService.SearchAsync(request.Adapt<SearchRequest>());

        return GrpcHelper
            .ConvertingStrategy<BaseResponse<PagingResponse<ProductDto>>, GrpcPagingResponse,
                ProductGrpcDto>(result);
    }

    public override async Task<GrpcResponse> GetByIdAsync(IdGrpcRequest request,
        ServerCallContext context)
    {
        BaseResponse<ProductDto> result = await _productService.GetByIdAsync(request.Id);

        return GrpcHelper
            .ConvertingStrategy<BaseResponse<ProductDto>, GrpcResponse, ProductGrpcDto>(result);
    }

    public override async Task<GrpcIterableResponse> GetAllAsync(Empty request,
        ServerCallContext context)
    {
        BaseResponse<List<ProductDto>> result = await _productService.GetAllAsync();

        return GrpcHelper
            .ConvertingStrategy<BaseResponse<List<ProductDto>>, GrpcIterableResponse,
                ProductGrpcDto>(result);
    }
}
