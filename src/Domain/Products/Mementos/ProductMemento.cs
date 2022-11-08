namespace Domain.Products.Mementos;

internal sealed class ProductMemento
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}