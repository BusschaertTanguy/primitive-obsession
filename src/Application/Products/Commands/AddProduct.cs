using Application.Common.Commands;
using Domain.Products.Entities;
using Domain.Products.Repositories;

namespace Application.Products.Commands;

public static class AddProduct
{
    public sealed record Command(Guid Id, string Name, decimal Price);

    internal sealed class Handler : ICommandHandler<Command>
    {
        private readonly IProductRepository _productRepository;

        public Handler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task Handle(Command command)
        {
            var (id, name, price) = command;

            var product = new Product(id, name, price);

            return _productRepository.Save(product);
        }
    }
}