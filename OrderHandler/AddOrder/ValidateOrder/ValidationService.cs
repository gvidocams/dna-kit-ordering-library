using OrderHandler.Core.Models;

namespace OrderHandler.AddOrder.ValidateOrder;

public class ValidationService : IValidationService
{
    private const int MaximumQuantity = 999;
    private const int MinimumQuantity = 1;
    
    public void IsValidOrder(OrderRequest orderRequest)
    {
        if (orderRequest is null)
        {
            throw new ArgumentNullException(nameof(orderRequest), "Order request can't be null!");
        }
        
        if (orderRequest.ExpectedDeliveryDate <= DateTime.Now)
        {
            throw new ArgumentOutOfRangeException(nameof(orderRequest.ExpectedDeliveryDate), "Expected delivery date must be in the future!");
        }

        if (orderRequest.Quantity is > MaximumQuantity or < MinimumQuantity)
        {
            throw new ArgumentOutOfRangeException(nameof(orderRequest.Quantity), "Kit quantity must be between the ranges of 1 to 999!");
        }
    }
}