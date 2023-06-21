using OrderHandler.Core.Enums;

namespace OrderHandler.Core.Models;

public class OrderRequest
{
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpectedDeliveryDate { get; set; }
    public KitVariant KitVariant { get; set; }
}