using Domain.Orders.ValueObjects;

namespace Domain.Orders.Entities;

public sealed class Order
{
    private readonly Guid _id;
    private readonly List<OrderItem> _items;

    public Order(Guid id)
    {
        _id = id;
        _items = new();
    }

    public void AddItem(Guid productId, int amount)
    {
        if (_items.Any(item => item.ProductId == productId)) throw new InvalidOperationException("Product already in order.");

        var item = new OrderItem(productId, amount);
        _items.Add(item);
    }

    public void MutateProductAmount(Guid productId, int amount)
    {
        if (productId == Guid.Empty) throw new ArgumentNullException(nameof(productId));

        var oldItem = _items.FirstOrDefault(item => item.ProductId == productId);
        if (oldItem == null) throw new InvalidOperationException("Product not in order");

        var newItem = oldItem.Mutate(amount);

        _items.Remove(oldItem);
        _items.Add(newItem);
    }
}