using eShopping.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopping.API.Infrastructure.Persistence.DbContext.Configurations;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Defining the primary key for the Order entity
        builder.HasKey(o => o.Id);

        // Configuring the OrderDate property (required and stored as datetime)
        builder.Property(o => o.OrderDate)
            .IsRequired()
            .HasColumnType("timestamp");

        // Configuring the ProductId property (foreign key to Product)
        builder.Property(o => o.ProductId)
            .IsRequired();

        // Configuring the Quantity property (required)
        builder.Property(o => o.Quantity)
            .IsRequired();

        // Configuring the TotalAmount property (required with precision)
        builder.Property(o => o.TotalAmount)
            .HasPrecision(18, 2)
            .IsRequired();

        // Configuring the relationship between Order and Product (Many-to-One)
        builder.HasOne(o => o.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

        // Configuring the relationship between Order and Customer (Many-to-One)
        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete (optional)
    }
    
}