using OrderHandler.Core.Models;

namespace OrderHandler.DataAccess;

public class OrderDbContext : IOrderDbContext
{
    private readonly List<Order> _orders;

    public OrderDbContext(List<Order> orders)
    {
        _orders = orders;
    }

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    public IEnumerable<Order> GetCustomerOrders(int customerId)
    {
        return _orders.FindAll(order => order.CustomerId == customerId).ToList();
    }
}