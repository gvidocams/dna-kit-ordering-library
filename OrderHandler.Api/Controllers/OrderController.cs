using Microsoft.AspNetCore.Mvc;
using OrderHandler.Application;
using OrderHandler.Application.AddOrder.ValidateOrder;
using OrderHandler.Application.AddOrder.ValidateOrder.Results;
using OrderHandler.Core.Models;

namespace OrderHandler.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderHandlerService _orderHandlerService;
    private readonly IOrderRequestValidationService _orderRequestValidationService;

    public OrderController(
        ILogger<OrderController> logger,
        IOrderHandlerService orderHandlerService,
        IOrderRequestValidationService orderRequestValidationService)
    {
        _logger = logger;
        _orderHandlerService = orderHandlerService;
        _orderRequestValidationService = orderRequestValidationService;
    }
    
    [HttpPost]
    public IActionResult PlaceOrder(OrderRequest orderRequest)
    {
        var validationResult = _orderRequestValidationService.Validate(orderRequest);

        if (validationResult is FailedValidationResult failedValidationResult)
        {
            return BadRequest(failedValidationResult);
        }
        
        var order = _orderHandlerService.PlaceAnOrder(orderRequest);
        
        return Ok(order);
    }

    [HttpGet, Route("GetOrdersByCustomerId/{id:int}")]
    public IActionResult GetOrdersByCustomerId(int id)
    {
        var orders = _orderHandlerService.GetOrdersByCustomerId(id);

        if (!orders.Any())
        {
            return NoContent();
        }
        
        return Ok(orders);
    }
}