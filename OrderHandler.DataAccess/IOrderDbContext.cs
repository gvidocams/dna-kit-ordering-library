using OrderHandler.Core.Models;

namespace OrderHandler.DataAccess;

public interface IOrderDbContext
{
    void AddOrder(Order orderResponse);
    IEnumerable<Order> GetCustomerOrders(int customerId);
}