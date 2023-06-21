using FluentAssertions;
using NUnit.Framework;
using OrderHandler.AddOrder.GetOrderDiscount;

namespace OrderHandler.Tests;

public class DiscountServiceTests
{
    private readonly IDiscountService _discountService;

    public DiscountServiceTests()
    {
        _discountService = new DiscountService();
    }
    
    [TestCase(1, 1)]
    [TestCase(9, 1)]
    [TestCase(10, 0.95)]
    [TestCase(49, 0.95)]
    [TestCase(50, 0.85)]
    [TestCase(60, 0.85)]
    public void GetOrderDiscount_TestingDifferentQuantities_ShouldReturnCorrectDiscountPercentage(int quantity, decimal expectedDiscount)
    {
        var discount = _discountService.GetOrderDiscount(quantity);
        
        discount.Should().Be(expectedDiscount);
    }
}