using FluentAssertions;
using Moq;
using NUnit.Framework;
using OrderHandler.AddOrder.CalculateOrderPrice;
using OrderHandler.AddOrder.GetKitVariantPrice;
using OrderHandler.AddOrder.GetOrderDiscount;
using OrderHandler.Core.Enums;

namespace OrderHandler.Tests;

public class OrderPriceServiceTests
{
    private readonly IOrderPriceService _orderPriceService;
    private readonly Mock<IDiscountService> _discountService = new();
    private readonly Mock<IKitVariantPriceService> _kitVariantPriceService = new();

    public OrderPriceServiceTests()
    {
        _orderPriceService = new OrderPriceService(_discountService.Object, _kitVariantPriceService.Object);
    }

    [TestCase(1, 197.98)]
    [TestCase(0.95, 188.08)]
    [TestCase(0.90, 178.18)]
    public void CalculatePrice_KitVariantDnaKit_ShouldReturnCorrectPrices(decimal discount, decimal expectedPrice)
    {
        _discountService
            .Setup(service => service.GetOrderDiscount(It.IsAny<int>()))
            .Returns(discount);

        _kitVariantPriceService
            .Setup(service => service.GetPrice(It.IsAny<KitVariant>()))
            .Returns(98.99m);

        var price = _orderPriceService.CalculatePrice(KitVariant.DnaKit, 2);

        price.Should().Be(expectedPrice);
    }
}