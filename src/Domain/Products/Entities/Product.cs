using Domain.Orders.ValueObjects;

namespace Domain.Products.Entities;

public sealed class Product
{
    private string _name;
    private decimal _price;

    public Product(Guid id, string name, decimal price)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (price <= 0) throw new InvalidOperationException("Price has to be greater then 0.");

        Id = id;
        _name = name;
        _price = price;
    }

    public Guid Id { get; }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        _name = name;
    }

    public void ChangePrice(decimal price)
    {
        if (price <= 0) throw new InvalidOperationException("Price has to be greater then 0.");

        _price = price;
    }
}