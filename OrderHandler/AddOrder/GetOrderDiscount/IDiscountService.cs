namespace OrderHandler.AddOrder.GetOrderDiscount;

public interface IDiscountService
{
    decimal GetOrderDiscount(int quantity);
}