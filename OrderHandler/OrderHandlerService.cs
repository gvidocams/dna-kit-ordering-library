using OrderHandler.AddOrder.CalculateOrderPrice;
using OrderHandler.AddOrder.ValidateOrder;
using OrderHandler.Core.Converters;
using OrderHandler.Core.Models;
using OrderHandler.DataAccess;

namespace OrderHandler;

public class OrderHandlerService : IOrderHandlerService
{
    private readonly IOrderDbContext _orderDbContext;
    private readonly IOrderPriceService _orderPriceService;
    private readonly IValidationService _validationService;

    public OrderHandlerService(
        IOrderDbContext orderDbContext,
        IOrderPriceService orderPriceService, 
        IValidationService validationService)
    {
        _orderDbContext = orderDbContext;
        _orderPriceService = orderPriceService;
        _validationService = validationService;
    }

    public Order PlaceAnOrder(OrderRequest orderRequest)
    {
        _validationService.IsValidOrder(orderRequest);

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