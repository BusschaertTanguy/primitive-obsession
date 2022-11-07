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
}