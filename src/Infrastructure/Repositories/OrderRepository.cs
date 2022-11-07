using Domain.Orders.Entities;
using Domain.Orders.Mementos;
using Domain.Orders.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly MyDbContext _context;

    public OrderRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Order> GetById(Guid id)
    {
        var memento = await _context
            .Set<OrderMemento>()
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id) ?? throw new InvalidOperationException("Order not found.");

        return Order.FromMemento(memento);
    }

    public async Task Save(Order order)
    {
        var newMemento = order.ToMemento();
        var existingMemento = await _context
            .Set<OrderMemento>()
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == newMemento.Id);

        if (existingMemento == null)
            await _context.AddAsync(newMemento);
        else
            _context.Entry(existingMemento).CurrentValues.SetValues(newMemento);

        await _context.SaveChangesAsync();
    }
}