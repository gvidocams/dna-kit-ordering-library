using OrderHandler.Application.AddOrder.GetKitVariantPrice;
using OrderHandler.Application.AddOrder.GetOrderDiscount;
using OrderHandler.Core.Enums;

namespace OrderHandler.Application.AddOrder.CalculateOrderPrice;

public class OrderPriceService : IOrderPriceService
{
    private readonly IDiscountService _discountService;
    private readonly IKitVariantPriceService _kitVariantPriceService;

    public OrderPriceService(IDiscountService discountService, IKitVariantPriceService kitVariantPriceService)
    {
        _discountService = discountService;
        _kitVariantPriceService = kitVariantPriceService;
    }

    public decimal CalculatePrice(KitVariant kitVariant, int quantity)
    {
        var priceBeforeDiscount = quantity * _kitVariantPriceService.GetPrice(kitVariant);
        
        var discount = _discountService.GetOrderDiscount(quantity);
        
        var finalPrice = priceBeforeDiscount * discount;
        
        return Math.Round(finalPrice, 2, MidpointRounding.AwayFromZero);
    }
}