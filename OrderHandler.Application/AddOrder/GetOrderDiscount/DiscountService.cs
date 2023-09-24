using OrderHandler.Core.Models;

namespace OrderHandler.Application.AddOrder.GetOrderDiscount;

public class DiscountService : IDiscountService
{
    private const decimal NoDiscountValue = 1;
    
    private readonly List<DiscountRule> _discountRules = new()
    {
        new DiscountRule(50, 0.85m),
        new DiscountRule(10, 0.95m)
    };

    public decimal GetOrderDiscount(int quantity)
    {
        var discountRule = _discountRules
            .OrderByDescending(d => d.Quantity)
            .FirstOrDefault(d => quantity >= d.Quantity);

        return discountRule?.Discount ?? NoDiscountValue;
    }
}