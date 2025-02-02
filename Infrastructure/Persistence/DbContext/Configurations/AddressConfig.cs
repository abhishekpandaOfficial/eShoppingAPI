using eShopping.API.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopping.API.Infrastructure.Persistence.DbContext.Configurations;

public class AddressConfig :IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        // Configure Street property
        builder.Property(a => a.Street)
            .HasColumnName("Street")
            .HasMaxLength(200)  // Adjust length as needed
            .IsRequired(); // Assuming street is a required field

        // Configure City property
        builder.Property(a => a.City)
            .HasColumnName("City")
            .HasMaxLength(100)  // Adjust length as needed
            .IsRequired(); // Assuming city is a required field

        // Configure State property
        builder.Property(a => a.State)
            .HasColumnName("State")
            .HasMaxLength(100)  // Adjust length as needed
            .IsRequired(); // Assuming state is a required field

        // Configure PostalCode property
        builder.Property(a => a.PostalCode)
            .HasColumnName("PostalCode")
            .HasMaxLength(20)  // Adjust length as needed
            .IsRequired(); // Assuming postal code is a required field

        // Configure Country property
        builder.Property(a => a.Country)
            .HasColumnName("Country")
            .HasMaxLength(100)  // Adjust length as needed
            .IsRequired(); // Assuming country is a required field
    }
}