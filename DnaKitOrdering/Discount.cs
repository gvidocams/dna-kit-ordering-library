namespace DnaKitOrdering;

public class Discount
{
    public int QuantityFromWhichDiscountStartsFrom { get; set; }
    public decimal Discountt { get; set; }

    public Discount(int quantityFromWhichDiscountStartsFrom, decimal discountt)
    {
        QuantityFromWhichDiscountStartsFrom = quantityFromWhichDiscountStartsFrom;
        Discountt = discountt;
    }
}