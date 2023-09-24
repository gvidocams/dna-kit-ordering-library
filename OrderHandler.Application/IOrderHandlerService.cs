using OrderHandler.Core.Models;

namespace OrderHandler.Application;

public interface IOrderHandlerService
{
    Order PlaceAnOrder(OrderRequest orderRequest);
    IEnumerable<Order> GetOrdersByCustomerId(int customerId);
}