using OrderHandler.Core.Models;

namespace OrderHandler.AddOrder.ValidateOrder;

public interface IValidationService
{
    void IsValidOrder(OrderRequest orderRequest);
}