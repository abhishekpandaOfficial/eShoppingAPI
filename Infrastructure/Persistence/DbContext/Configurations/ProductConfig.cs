using eShopping.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopping.API.Infrastructure.Persistence.DbContext.Configurations;

// Using of Fluent API Configuration
public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Defining the primary key
        builder.HasKey(p => p.Id);

        // Configuring the Name property (required and with a max length of 100)
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Configuring the Description property (optional, with a max length of 500)
        builder.Property(p => p.Description)
            .HasMaxLength(500);
        
        builder.Property(p => p.Price)
            .HasColumnName("Amount").HasColumnType("decimal(18,2)").IsRequired();
    }
}