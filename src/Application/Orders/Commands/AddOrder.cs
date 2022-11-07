using Application.Common.Commands;
using Domain.Orders.Entities;
using Domain.Orders.Repositories;

namespace Application.Orders.Commands;

public static class AddOrder
{
    public sealed record Command(Guid Id);

    internal sealed class Handler : ICommandHandler<Command>
    {
        private readonly IOrderRepository _orderRepository;

        public Handler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Handle(Command command)
        {
            var order = new Order(command.Id);

            return _orderRepository.Save(order);
        }
    }
}