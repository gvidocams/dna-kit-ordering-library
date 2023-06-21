using OrderHandler.Core.Enums;

namespace OrderHandler.AddOrder.GetKitVariantPrice;

public class KitVariantPriceService : IKitVariantPriceService
{
    private readonly Dictionary<KitVariant, decimal> _kitVariantsWithPrices = new()
    {
        { KitVariant.DnaKit, KitVariantPrices.DnaKit}
    };
    
    public decimal GetPrice(KitVariant kitVariant) => 
        _kitVariantsWithPrices
            .First(kitVariantWithPrice => kitVariantWithPrice.Key == kitVariant).Value;
}