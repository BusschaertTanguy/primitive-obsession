namespace Domain.Orders.Mementos;

internal sealed class OrderMemento
{
    public required Guid Id { get; init; }
    public required IEnumerable<OrderItemMemento> Items { get; init; }
}