using Domain.Products.Entities;
using Domain.Products.Mementos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<ProductMemento>
{
    public void Configure(EntityTypeBuilder<ProductMemento> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(product => product.Id);

        builder.Property(product => product.Id)
            .ValueGeneratedNever();

        builder.Property(product => product.Name)
            .IsRequired();

        builder.Property(product => product.Price)
            .IsRequired();
    }
}