using Application.Common.Commands;
using Domain.Orders.Repositories;

namespace Application.Orders.Commands;

public static class MutateProductAmount
{
    public sealed record Command(Guid OrderId, Guid ProductId, int Amount);

    internal sealed class Handler : ICommandHandler<Command>
    {
        private readonly IOrderRepository _orderRepository;

        public Handler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(Command command)
        {
            var (orderId, productId, amount) = command;

            var order = await _orderRepository.GetById(orderId);

            order.MutateProductAmount(
                new(productId),
                new(amount)
            );

            await _orderRepository.Save(order);
        }
    }
}