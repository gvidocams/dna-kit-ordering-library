using OrderHandler.Core.Models;

namespace OrderHandler.DataAccess;

public interface IOrderDbContext
{
    void AddOrder(Order order);
    IEnumerable<Order> GetCustomerOrders(int customerId);
}