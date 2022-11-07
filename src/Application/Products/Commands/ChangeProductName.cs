using Application.Common.Commands;
using Domain.Products.Repositories;

namespace Application.Products.Commands;

public static class ChangeProductName
{
    public sealed record Command(Guid ProductId, string Name);

    internal sealed class Handler : ICommandHandler<Command>
    {
        private readonly IProductRepository _productRepository;

        public Handler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(Command command)
        {
            var (productId, name) = command;

            var product = await _productRepository.GetById(productId);

            product.ChangeName(
                new(name)
            );

            await _productRepository.Save(product);
        }
    }
}