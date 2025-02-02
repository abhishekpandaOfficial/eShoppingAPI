using eShopping.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopping.API.Infrastructure.Persistence.DbContext.Configurations;

public class CustomerConfig: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Defining the primary key for the Customer entity
        builder.HasKey(c => c.Id);

        // Configuring the Name property (required and with a max length of 100)
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Configuring the Email property (required and with a max length of 200)
        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(200);

        // Configuring the PhoneNumber property (optional)
        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(15);

        // Configuring the relationship between Customer and Orders (One-to-Many)
        builder.HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
    }
}