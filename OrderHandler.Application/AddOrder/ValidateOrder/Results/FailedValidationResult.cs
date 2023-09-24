namespace OrderHandler.Application.AddOrder.ValidateOrder.Results;

public class FailedValidationResult : IValidationResult
{
    public string ErrorMessage { get; set; }
}