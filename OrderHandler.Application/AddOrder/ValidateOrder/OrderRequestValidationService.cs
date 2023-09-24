using OrderHandler.Application.AddOrder.ValidateOrder.Results;
using OrderHandler.Core.Models;

namespace OrderHandler.Application.AddOrder.ValidateOrder;

public class OrderRequestValidationService : IOrderRequestValidationService
{
    private const int MaximumQuantity = 999;
    private const int MinimumQuantity = 1;
    
    public IValidationResult Validate(OrderRequest orderRequest)
    {
        if (orderRequest.ExpectedDeliveryDate <= DateTime.Now)
        {
            return new FailedValidationResult
            {
                ErrorMessage = "Expected delivery date must be in the future!"
            };
        }

        if (orderRequest.Quantity is > MaximumQuantity or < MinimumQuantity)
        {
            return new FailedValidationResult
            {
                ErrorMessage = "Kit quantity must be between the ranges of 1 to 999!"
            };
        }

        return new SuccessValidationResult();
    }
}