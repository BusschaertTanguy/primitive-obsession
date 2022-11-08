using Domain.Orders.Entities;
using Domain.Orders.Mementos;
using Domain.Orders.ValueObjects;
using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<OrderMemento>
{
    public void Configure(EntityTypeBuilder<OrderMemento> builder)
    {
        builder.ToTable(nameof(Order));
        builder.HasKey(order => order.Id);

        builder
            .Property(order => order.Id)
            .ValueGeneratedNever();

        builder.OwnsMany(order => order.Items, orderItemBuilder =>
        {
            orderItemBuilder.ToTable(nameof(OrderItem));

            orderItemBuilder
                .Property(item => item.Amount)
                .IsRequired();

            orderItemBuilder
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(item => item.ProductId)
                .IsRequired();
        });
    }
}