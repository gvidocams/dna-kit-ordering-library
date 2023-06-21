using OrderHandler.Core.Models;

namespace OrderHandler;

public interface IOrderHandler
{
    Order PlaceAnOrder(OrderRequest orderRequest);
    IEnumerable<Order> GetOrdersByCustomerId(int customerId);
}