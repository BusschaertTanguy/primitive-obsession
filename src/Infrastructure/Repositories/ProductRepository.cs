using Domain.Products.Entities;
using Domain.Products.Mementos;
using Domain.Products.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly MyDbContext _context;

    public ProductRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetById(Guid id)
    {
        var memento = await _context
            .Set<ProductMemento>()
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id) ?? throw new InvalidOperationException("Product not found.");

        return Product.FromMemento(memento);
    }

    public async Task Save(Product product)
    {
        var newMemento = product.ToMemento();
        var existingMemento = await _context
            .Set<ProductMemento>()
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == newMemento.Id);

        if (existingMemento == null)
            await _context.AddAsync(newMemento);
        else
            _context.Entry(existingMemento).CurrentValues.SetValues(newMemento);

        await _context.SaveChangesAsync();
    }
}