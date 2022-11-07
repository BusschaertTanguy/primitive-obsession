namespace Domain.Orders.ValueObjects;

public sealed record OrderItem
{
    public OrderItem(Guid productId, int amount)
    {
        if (productId == Guid.Empty) throw new ArgumentNullException(nameof(productId));
        if (amount <= 0) throw new InvalidOperationException("Amount has to be greater then 0.");

        ProductId = productId;
        Amount = amount;
    }

    public Guid ProductId { get; }
    public int Amount { get; private init; }

    public OrderItem Mutate(int amount)
    {
        if (amount == 0) throw new InvalidOperationException("Mutation amount can't be 0.");

        var newAmount = Amount + amount;
        if (newAmount <= 0) throw new InvalidOperationException("Product amount must be greater then 0");

        return this with { Amount = newAmount };
    }
}