namespace Domain.Products.ValueObjects;

public record ProductName
{
    public const string EmptyMessage = "Product name can't be empty.";

    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidOperationException(EmptyMessage);
        Value = value;
    }

    public string Value { get; }
}