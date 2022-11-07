namespace Domain.Orders.Mementos;

internal sealed class OrderItemMemento
{
    public OrderItemMemento(Guid productId, int amount)
    {
        ProductId = productId;
        Amount = amount;
    }

    public Guid ProductId { get; }
    public int Amount { get; }
}