using OrderHandler.Core.Enums;

namespace OrderHandler.Application.AddOrder.GetKitVariantPrice;

public interface IKitVariantPriceService
{
    decimal GetPrice(KitVariant kitVariant);
}