using Domain.Orders.Entities;

namespace Domain.Orders.Repositories;

public interface IOrderRepository
{
    Task<Order> GetById(Guid id);
    Task Save(Order order);
}