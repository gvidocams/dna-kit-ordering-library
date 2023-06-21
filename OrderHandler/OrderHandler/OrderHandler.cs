using Autofac;
using OrderHandler.Core.Models;

namespace OrderHandler;

public class OrderHandler : IOrderHandler
{
    private IOrderHandlerService _orderHandlerService;

    public OrderHandler()
    {
        ConfigureDependencyInjection();
    }

    private void ConfigureDependencyInjection()
    {
        var container = AutofacConfig.ConfigureContainer();

        using var scope = container.BeginLifetimeScope();
        
        _orderHandlerService = scope.Resolve<IOrderHandlerService>();
    }
    
    public Order PlaceAnOrder(OrderRequest orderRequest)
    {
        return _orderHandlerService.PlaceAnOrder(orderRequest);
    }

    public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
    {
        return _orderHandlerService.GetOrdersByCustomerId(customerId);
    }
}