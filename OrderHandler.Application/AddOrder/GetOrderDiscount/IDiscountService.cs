namespace OrderHandler.Application.AddOrder.GetOrderDiscount;

public interface IDiscountService
{
    decimal GetOrderDiscount(int quantity);
}