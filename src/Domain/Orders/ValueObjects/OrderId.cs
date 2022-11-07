namespace Domain.Orders.ValueObjects;

public sealed class OrderId
{
    public const string EmptyMessage = "Order id can't be empty.";

    public OrderId(Guid value)
    {
        if (value == Guid.Empty) throw new InvalidOperationException(EmptyMessage);
        Value = value;
    }

    public Guid Value { get; }
}