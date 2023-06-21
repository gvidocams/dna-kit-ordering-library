using OrderHandler.Core.Models;

namespace OrderHandler.Core.Converters;

public static class OrderRequestExtensions
{
    public static Order ConvertToOrder(this OrderRequest orderRequest) =>
        new()
        {
            CustomerId = orderRequest.CustomerId,
            ExpectedDeliveryDate = orderRequest.ExpectedDeliveryDate,
            Quantity = orderRequest.Quantity,
            KitVariant = orderRequest.KitVariant
        };
}