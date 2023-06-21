using FluentAssertions;
using NUnit.Framework;
using OrderHandler.AddOrder.ValidateOrder;
using OrderHandler.Core.Models;

namespace OrderHandler.Tests;

public class ValidationServiceTests
{
    private readonly IValidationService _validationService;
    
    public ValidationServiceTests()
    {
        _validationService = new ValidationService();
    }
    
    [Test]
    public void IsValidOrder_ValidOrderRequest_ShouldNotThrowException()
    {
        var oneHourInTheFuture = DateTime.Now.AddHours(1);

        var orderRequest = new OrderRequest
        {
            CustomerId = 1,
            Quantity = 1,
            ExpectedDeliveryDate = oneHourInTheFuture
        };

        var action = () => _validationService.IsValidOrder(orderRequest);

        action.Should().NotThrow();
    }

    [Test]
    public void IsValidOrder_ExpectedDeliveryDateNotInFuture_ThrowsArgumentException()
    {
        var orderRequest = new OrderRequest
        {
            CustomerId = 1,
            Quantity = 1,
            ExpectedDeliveryDate = DateTime.Now
        };
        
        var action = () => _validationService.IsValidOrder(orderRequest);

        action.Should().Throw<ArgumentException>()
            .WithMessage("Expected delivery date must be in the future! (Parameter 'ExpectedDeliveryDate')");
    }

    [TestCase(-5)]
    [TestCase(0)]
    [TestCase(1000)]
    public void IsValidOrder_QuantityOutOfRange_ThrowsArgumentOutOfRangeException(int quantity)
    {
        var orderRequest = new OrderRequest
        {
            CustomerId = 1,
            Quantity = quantity,
            ExpectedDeliveryDate = DateTime.Now.AddHours(1)
        };
        
        var action = () => _validationService.IsValidOrder(orderRequest);

        action.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("Kit quantity must be between the ranges of 1 to 999! (Parameter 'Quantity')");
    }

    [Test]
    public void IsValidOrder_OrderRequestIsNull_ThrowArgumentNullException()
    {
        OrderRequest? orderRequest = null;
        
        var action = () => _validationService.IsValidOrder(orderRequest!);

        action.Should().Throw<ArgumentNullException>()
            .WithMessage("Order request can't be null! (Parameter 'orderRequest')");
    }
}