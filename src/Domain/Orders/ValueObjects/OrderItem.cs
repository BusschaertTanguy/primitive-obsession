using Domain.Common.Guards;

namespace Domain.Orders.ValueObjects;

public sealed record OrderItem
{
    public OrderItem(Guid productId, int amount)
    {
        Guards.NotEmpty(productId, nameof(productId));
        Guards.GreaterThanZero(amount, nameof(amount));

        ProductId = productId;
        Amount = amount;
    }

    public Guid ProductId { get; }
    public int Amount { get; private init; }

    public OrderItem Mutate(int amount)
    {
        Guards.OtherThanZero(amount, nameof(amount));

        var newAmount = Amount + amount;
        Guards.GreaterThanZero(newAmount, nameof(newAmount));

        return this with { Amount = newAmount };
    }
}