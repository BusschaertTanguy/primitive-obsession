using Domain.Common.Guards;

namespace Domain.Products.Entities;

public sealed class Product
{
    private string _name;
    private decimal _price;

    public Product(Guid id, string name, decimal price)
    {
        Guards.NotEmpty(id, nameof(id));
        Guards.NotEmpty(name, nameof(name));
        Guards.GreaterThanZero(price, nameof(price));

        Id = id;
        _name = name;
        _price = price;
    }

    public Guid Id { get; }

    public void ChangeName(string name)
    {
        Guards.NotEmpty(name, nameof(name));

        _name = name;
    }

    public void ChangePrice(decimal price)
    {
        Guards.GreaterThanZero(price, nameof(price));

        _price = price;
    }
}