using Autofac;
using OrderHandler.AddOrder.CalculateOrderPrice;
using OrderHandler.AddOrder.GetOrderDiscount;
using OrderHandler.AddOrder.ValidateOrder;
using OrderHandler.Core.Models;
using OrderHandler.DataAccess;

namespace OrderHandler;

public static class AutofacConfig
{
    public static IContainer ConfigureContainer()
    {
        var builder = new ContainerBuilder();
        
        builder.RegisterType<OrderPriceService>().As<IOrderPriceService>();
        builder.RegisterType<DiscountService>().As<IDiscountService>();
        builder.RegisterType<ValidationService>().As<IValidationService>();
        builder.RegisterType<OrderHandlerService>().As<IOrderHandlerService>();

        builder.Register(c =>
        {
            var orders = new List<Order>();
            return new OrderDbContext(orders);
        }).As<IOrderDbContext>();
        
        return builder.Build();
    }
}