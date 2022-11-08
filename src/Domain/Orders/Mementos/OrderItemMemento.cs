namespace Domain.Orders.Mementos;

internal sealed class OrderItemMemento
{
    public required Guid ProductId { get; init; }
    public required int Amount { get; init; }
}