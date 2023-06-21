using FluentAssertions;
using NUnit.Framework;
using OrderHandler.AddOrder.GetKitVariantPrice;
using OrderHandler.Core.Enums;

namespace OrderHandler.Tests;

public class KitVariantPriceServiceTests
{
    private readonly IKitVariantPriceService _kitVariantPriceService;
    public KitVariantPriceServiceTests()
    {
        _kitVariantPriceService = new KitVariantPriceService();
    }
    
    [Test]
    public void GetPrice_KitVariantDnaKit_ShouldReturnCorrectPrice()
    {
        var kitVariantPriceService = new KitVariantPriceService();

        var price = kitVariantPriceService.GetPrice(KitVariant.DnaKit);

        price.Should().Be(98.99m);
    }

    [Test]
    public void GetPrice_AllKitVariantsShouldBeRegisteredInKitVariantPriceService()
    { 
        var kitVariants = (KitVariant[])Enum.GetValues(typeof(KitVariant));
        
        foreach (var kitVariant in kitVariants)
        {
            var action = () => _kitVariantPriceService.GetPrice(kitVariant);

            action.Should().NotThrow();
        }
    }
}