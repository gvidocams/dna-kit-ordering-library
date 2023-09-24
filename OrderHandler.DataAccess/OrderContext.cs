using Microsoft.EntityFrameworkCore;
using OrderHandler.Core.Models;

namespace OrderHandler.DataAccess;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
}