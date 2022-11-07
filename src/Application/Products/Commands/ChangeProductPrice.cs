using Application.Common.Commands;
using Domain.Products.Repositories;

namespace Application.Products.Commands;

public static class ChangeProductPrice
{
    public sealed record Command(Guid ProductId, decimal Price);

    internal sealed class Handler : ICommandHandler<Command>
    {
        private readonly IProductRepository _productRepository;

        public Handler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(Command command)
        {
            var (productId, price) = command;

            var product = await _productRepository.GetById(productId);
            product.ChangePrice(price);

            await _productRepository.Save(product);
        }
    }
}