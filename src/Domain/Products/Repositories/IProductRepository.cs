using Domain.Products.Entities;

namespace Domain.Products.Repositories;

public interface IProductRepository
{
    Task<Product> GetById(Guid id);
    Task Save(Product product);
}