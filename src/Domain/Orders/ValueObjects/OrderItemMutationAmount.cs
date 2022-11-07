namespace Domain.Orders.ValueObjects;

public sealed class OrderItemMutationAmount
{
    public const string OtherThanZero = "Order item mutation amount has to be other than 0.";

    public OrderItemMutationAmount(int value)
    {
        if (value == 0) throw new InvalidOperationException(OtherThanZero);
        Value = value;
    }

    public int Value { get; }
}