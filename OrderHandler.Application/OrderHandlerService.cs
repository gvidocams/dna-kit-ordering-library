using OrderHandler.Application.AddOrder.CalculateOrderPrice;
using OrderHandler.Application.AddOrder.ValidateOrder;
using OrderHandler.Core.Converters;
using OrderHandler.Core.Models;
using OrderHandler.DataAccess;

namespace OrderHandler.Application;

public class OrderHandlerService : IOrderHandlerService
{
    private readonly IOrderDbContext _orderDbContext;
    private readonly IOrderPriceService _orderPriceService;
    private readonly IOrderRequestValidationService _orderRequestValidationService;

    public OrderHandlerService(
        IOrderDbContext orderDbContext,
        IOrderPriceService orderPriceService,
        IOrderRequestValidationService orderRequestValidationService)
    {
        _orderDbContext = orderDbContext;
        _orderPriceService = orderPriceService;
        _orderRequestValidationService = orderRequestValidationService;
    }

    public Order PlaceAnOrder(OrderRequest orderRequest)
    {
        var order = orderRequest.ConvertToOrder();

        order.Price = _orderPriceService.CalculatePrice(order.KitVariant, order.Quantity);

        _orderDbContext.AddOrder(order);

        return order;
    }

    public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
    {
        return _orderDbContext.GetCustomerOrders(customerId);
    }
}