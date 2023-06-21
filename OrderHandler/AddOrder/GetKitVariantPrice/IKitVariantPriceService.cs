using OrderHandler.Core.Enums;

namespace OrderHandler.AddOrder.GetKitVariantPrice;

public interface IKitVariantPriceService
{
    decimal GetPrice(KitVariant kitVariant);
}