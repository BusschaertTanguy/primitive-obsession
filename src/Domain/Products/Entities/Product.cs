using Domain.Products.Mementos;
using Domain.Products.ValueObjects;

namespace Domain.Products.Entities;

public sealed class Product
{
    private ProductName _name;
    private ProductPrice _price;

    public Product(ProductId id, ProductName name, ProductPrice price)
    {
        Id = id;
        _name = name;
        _price = price;
    }

    public ProductId Id { get; }

    public void ChangeName(ProductName name)
    {
        _name = name;
    }

    public void ChangePrice(ProductPrice price)
    {
        _price = price;
    }

    internal static Product FromMemento(ProductMemento memento)
    {
        var product = new Product(
            new(memento.Id),
            new(memento.Name),
            new(memento.Price)
        );

        return product;
    }

    internal ProductMemento ToMemento()
    {
        var memento = new ProductMemento
        {
            Id = Id.Value,
            Name = _name.Value,
            Price = _price.Value
        };

        return memento;
    }
}