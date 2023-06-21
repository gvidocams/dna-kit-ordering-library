using FluentAssertions;
using NUnit.Framework;
using OrderHandler.Core.Converters;
using OrderHandler.Core.Models;

namespace OrderHandler.Tests;

public class OrderRequestExtensionsTests
{
    [Test]
    public void ConvertToOrder_ValidIncomingOrder_ShouldReturnOrder()
    {
        var expectedDeliveryDate = DateTime.Now;
        
        var incomingOrder = new OrderRequest
        {
            Quantity = 1,
            CustomerId = 1,
            ExpectedDeliveryDate = expectedDeliveryDate
        };

        var order = incomingOrder.ConvertToOrder();

        order.Should().BeEquivalentTo(new Order
        {
            Quantity = 1,
            CustomerId = 1,
            ExpectedDeliveryDate = expectedDeliveryDate
        });
    }
}