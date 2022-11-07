namespace Domain.Orders.ValueObjects;

public record OrderItemAmount
{
    public const string GreaterThanZeroMessage = "Order item amount has to be greater then 0.";

    public OrderItemAmount(int value)
    {
        if (value <= 0) throw new InvalidOperationException(GreaterThanZeroMessage);
        Value = value;
    }

    public int Value { get; }

    public OrderItemAmount Mutate(OrderItemMutationAmount mutationAmount)
    {
        return new(Value + mutationAmount.Value);
    }
}