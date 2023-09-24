using FluentAssertions;
using NUnit.Framework;
using OrderHandler.Application.AddOrder.ValidateOrder;
using OrderHandler.Application.AddOrder.ValidateOrder.Results;
using OrderHandler.Core.Models;

namespace OrderHandler.Tests;

public class ValidationServiceTests
{
    private readonly IOrderRequestValidationService _orderRequestValidationService;
    
    public ValidationServiceTests()
    {
        _orderRequestValidationService = new OrderRequestValidationService();
    }
    
    [Test]
    public void IsValidOrder_ValidOrderRequest_ShouldReturnSuccessValidationResult()
    {
        var oneHourInTheFuture = DateTime.Now.AddHours(1);

        var orderRequest = new OrderRequest
        {
            CustomerId = 1,
            Quantity = 1,
            ExpectedDeliveryDate = oneHourInTheFuture
        };

        var response = _orderRequestValidationService.Validate(orderRequest);

        response.Should().BeOfType<SuccessValidationResult>();
    }

    [Test]
    public void IsValidOrder_ExpectedDeliveryDateNotInFuture_ShouldReturnFailedValidationResult()
    {
        var orderRequest = new OrderRequest
        {
            CustomerId = 1,
            Quantity = 1,
            ExpectedDeliveryDate = DateTime.Now
        };
        
        var response = _orderRequestValidationService.Validate(orderRequest);

        response.Should().BeEquivalentTo(new FailedValidationResult
        {
            ErrorMessage = "Expected delivery date must be in the future!"
        });
    }

    [TestCase(-5)]
    [TestCase(0)]
    [TestCase(1000)]
    public void IsValidOrder_QuantityOutOfRange_ShouldReturnFailedValidationResult(int quantity)
    {
        var orderRequest = new OrderRequest
        {
            CustomerId = 1,
            Quantity = quantity,
            ExpectedDeliveryDate = DateTime.Now.AddHours(1)
        };
        
        var response = _orderRequestValidationService.Validate(orderRequest);

        response.Should().BeEquivalentTo(new FailedValidationResult
        {
            ErrorMessage = "Kit quantity must be between the ranges of 1 to 999! (Parameter 'Quantity')"
        });
    }
}