using OrderHandler.Core.Enums;

namespace OrderHandler.AddOrder.CalculateOrderPrice;

public interface IOrderPriceService
{
    decimal CalculatePrice(KitVariant kitVariant, int quantity);
}