using OrderHandler.Core.Enums;

namespace OrderHandler.Application.AddOrder.CalculateOrderPrice;

public interface IOrderPriceService
{
    decimal CalculatePrice(KitVariant kitVariant, int quantity);
}