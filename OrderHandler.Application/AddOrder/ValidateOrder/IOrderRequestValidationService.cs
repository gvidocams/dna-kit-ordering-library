using OrderHandler.Application.AddOrder.ValidateOrder.Results;
using OrderHandler.Core.Models;

namespace OrderHandler.Application.AddOrder.ValidateOrder;

public interface IOrderRequestValidationService
{
    IValidationResult Validate(OrderRequest orderRequest);
}