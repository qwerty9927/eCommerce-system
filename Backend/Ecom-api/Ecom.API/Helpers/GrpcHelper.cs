using System.Collections;
using System.Reflection;
using Ecom.API.Protos.Dtos;
using Ecom.Domain.Enums;
using Ecom.Domain.Shared;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Mapster;

namespace Ecom.API.Helpers;

public static class GrpcHelper
{
    private static TDestination ObjectTypeConverting<TSource, TDestination, TObjectDestination>(
        TSource source)
        where TDestination : new()
    {
        TDestination target = new TDestination();
        PropertyInfo[] properties = source.GetType().GetProperties();

        for (var i = 0; i < properties.Length; i++)
        {
            var targetProp = target.GetType().GetProperty(properties[i].Name);
            var sourceValue = properties[i].GetValue(source);

            if (targetProp == null || sourceValue == null) continue;

            if (targetProp.PropertyType == typeof(Any))
            {
                targetProp.SetValue(target,
                    Any.Pack((IMessage)sourceValue.Adapt<TObjectDestination>()!));
                continue;
            }

            targetProp.SetValue(target, sourceValue);
        }

        return target;
    }

    private static TDestination IterableTypeConverting<TSource, TDestination, TIterableDestination>(
        TSource source)
        where TDestination : new()
    {
        TDestination target = new TDestination();
        PropertyInfo[] properties = source.GetType().GetProperties();

        for (var i = 0; i < properties.Length; i++)
        {
            var targetProp = target.GetType().GetProperty(properties[i].Name);
            var sourceValue = properties[i].GetValue(source);

            if (targetProp == null || sourceValue == null) continue;

            if (targetProp.PropertyType == typeof(RepeatedField<Any>) && sourceValue is IList)
            {
                var messages = (RepeatedField<Any>)targetProp.GetValue(target)!;
                var paramSourceData = (IList)sourceValue;
                foreach (var item in paramSourceData)
                {
                    var packedMessage =
                        Any.Pack((IMessage)item.Adapt<TIterableDestination>()!);
                    messages.Add(packedMessage);
                }

                continue;
            }

            targetProp.SetValue(target, sourceValue);
        }

        return target;
    }

    private static TDestination PagingTypeConverting<TSource, TDestination, TIterableDestination>(
        TSource source)
        where TDestination : new()
    {
        TDestination target = new TDestination();
        PropertyInfo[] properties = source.GetType().GetProperties();

        for (var i = 0; i < properties.Length; i++)
        {
            var targetProp = target.GetType().GetProperty(properties[i].Name);
            var sourceValue = properties[i].GetValue(source);

            if (targetProp == null || sourceValue == null) continue;

            if (targetProp.PropertyType == typeof(PagingGrpcResponse) &&
                sourceValue is PagingResponse)
            {
                PagingGrpcResponse paging =
                    IterableTypeConverting<PagingResponse, PagingGrpcResponse,
                        TIterableDestination>((PagingResponse)sourceValue);

                targetProp.SetValue(target, paging);

                continue;
            }

            targetProp.SetValue(target, sourceValue);
        }

        return target;
    }

    public static TDestination ConvertingStrategy<TSource, TDestination, TNestedDestination>(TSource source)
        where TSource : BaseResponse where TDestination : IMessage, new()
    {
        return typeof(TDestination) switch
        {
            { } t when t == typeof(GrpcResponse) =>
                ObjectTypeConverting<TSource, TDestination, TNestedDestination>(source),
            { } t when t == typeof(GrpcIterableResponse) =>
                IterableTypeConverting<TSource, TDestination, TNestedDestination>(source),
            { } t when t == typeof(GrpcPagingResponse) =>
                PagingTypeConverting<TSource, TDestination, TNestedDestination>(source),
            _ => throw new BaseException("Converting type not supported", (int)GrpcStatusCode.Internal)
        };
    }
}
