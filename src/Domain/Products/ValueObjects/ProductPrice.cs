namespace Domain.Products.ValueObjects;

public sealed record ProductPrice
{
    public const string GreaterThanZeroMessage = "Product price has to be greater then 0.";

    public ProductPrice(decimal value)
    {
        if (value <= 0) throw new InvalidOperationException(GreaterThanZeroMessage);
        Value = value;
    }

    public decimal Value { get; }
}