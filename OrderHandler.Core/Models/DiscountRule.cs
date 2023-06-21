namespace OrderHandler.Core.Models;

public class DiscountRule
{
    public int Quantity { get; set; }
    public decimal Discount { get; set; }

    public DiscountRule(int quantity, decimal discount)
    {
        Quantity = quantity;
        Discount = discount;
    }
}