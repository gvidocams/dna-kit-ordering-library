using OrderHandler.Core.Enums;

namespace OrderHandler.Core.Models;

public class Order
{
    public int Quantity { get; set; }
    public int CustomerId { get; set; }
    public DateTime ExpectedDeliveryDate { get; set; }
    public KitVariant KitVariant { get; set; }
    public decimal Price { get; set; }
}