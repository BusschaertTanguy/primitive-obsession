namespace Domain.Orders.Mementos;

internal sealed class OrderMemento
{
    public OrderMemento(Guid id)
    {
        Id = id;
        Items = new();
    }

    public Guid Id { get; }
    public List<OrderItemMemento> Items { get; }
}