namespace DnaKitOrdering;

public static class DnaKitOrderExtensions
{
    public static Order ConvertToOrder(this DnaKitOrder dnaKitOrder) =>
        new()
        {
            CustomerId = dnaKitOrder.CustomerId,
            ExpectedDeliveryDate = dnaKitOrder.ExpectedDeliveryDate,
            Quantity = dnaKitOrder.Quantity
        };
}