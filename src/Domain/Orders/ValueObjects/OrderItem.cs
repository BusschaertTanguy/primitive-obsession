using Domain.Products.ValueObjects;

namespace Domain.Orders.ValueObjects;

public sealed record OrderItem(ProductId ProductId, OrderItemAmount Amount)
{
    public OrderItem Mutate(OrderItemMutationAmount mutationAmount)
    {
        var newAmount = Amount.Mutate(mutationAmount);
        return this with { Amount = newAmount };
    }
}