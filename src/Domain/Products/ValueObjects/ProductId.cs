namespace Domain.Products.ValueObjects;

public sealed record ProductId
{
    public const string EmptyMessage = "Product id can't be empty.";

    public ProductId(Guid value)
    {
        if (value == Guid.Empty) throw new InvalidOperationException(EmptyMessage);
        Value = value;
    }

    public Guid Value { get; }
}