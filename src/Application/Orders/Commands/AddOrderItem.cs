using Application.Common.Commands;
using Domain.Orders.Repositories;
using Domain.Products.Repositories;

namespace Application.Orders.Commands;

public static class AddOrderItem
{
    public sealed record Command(Guid OrderId, Guid ProductId, int Amount);

    internal sealed class Handler : ICommandHandler<Command>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public Handler(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task Handle(Command command)
        {
            var (orderId, productId, amount) = command;

            var product = await _productRepository.GetById(productId);
            var order = await _orderRepository.GetById(orderId);

            order.AddItem(
                product.Id,
                new(amount)
            );

            await _orderRepository.Save(order);
        }
    }
}