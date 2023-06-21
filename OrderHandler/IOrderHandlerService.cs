using OrderHandler.Core.Models;

namespace OrderHandler;

public interface IOrderHandlerService
{
    Order PlaceAnOrder(OrderRequest orderRequest);
    IEnumerable<Order> GetOrdersByCustomerId(int customerId);
}