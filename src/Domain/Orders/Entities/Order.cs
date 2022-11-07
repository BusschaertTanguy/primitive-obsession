using Domain.Orders.ValueObjects;
using Domain.Products.ValueObjects;

namespace Domain.Orders.Entities;

public sealed class Order
{
    private readonly OrderId _id;
    private readonly List<OrderItem> _items;

    public Order(OrderId id)
    {
        _id = id;
        _items = new();
    }

    public void AddItem(ProductId productId, OrderItemAmount amount)
    {
        if (_items.Any(item => item.ProductId == productId)) throw new InvalidOperationException("Product already in order.");

        var item = new OrderItem(productId, amount);
        _items.Add(item);
    }

    public void MutateProductAmount(ProductId productId, OrderItemMutationAmount amount)
    {
        var oldItem = _items.FirstOrDefault(item => item.ProductId == productId);
        if (oldItem == null) throw new InvalidOperationException("Product not in order");

        var newItem = oldItem.Mutate(amount);

        _items.Remove(oldItem);
        _items.Add(newItem);
    }
}