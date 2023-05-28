namespace DnaKitOrdering;

public class Order
{
    public int Quantity { get; set; }
    public int CustomerId { get; set; }
    public DateTime ExpectedDeliveryDate { get; set; }
    public decimal TotalPrice { get; set; }
}