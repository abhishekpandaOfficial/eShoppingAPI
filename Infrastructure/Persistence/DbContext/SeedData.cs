using eShopping.API.Domain.Entities;
using eShopping.API.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace eShopping.API.Infrastructure.Persistence.DbContext;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Ensure the database is created and apply any migrations
            context.Database.Migrate();

            // Seed data for Products
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Product 1",
                        Description = "Description of Product 1",
                        Price = new Money(99.99m, "INR")
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Product 2",
                        Description = "Description of Product 2",
                        Price = new Money(199.99m, "INR")
                    });

                context.SaveChanges();
            }

            // Seed data for Customers
            if (!context.Customers.Any())
                
            {
                context.Customers.AddRange(
                    new Customer
                    {
                        Id = Guid.NewGuid(),
                        Name = "John Doe",
                        Email = "john.doe@example.com"
                    },
                    new Customer
                    {
                        Id = Guid.NewGuid(),
                        Name = "Jane Smith",
                        Email = "jane.smith@example.com"
                    });

                context.SaveChanges();
            }

            // Seed data for Orders
            if (!context.Orders.Any())
            {
                var productId = context.Products.First().Id;
                var customerId = context.Customers.First().Id;

                context.Orders.AddRange(
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        OrderDate = DateTime.Now,
                        ProductId = productId,
                        CustomerId = customerId,
                        Quantity = 1,
                        TotalAmount = 99.99m
                    });

                context.SaveChanges();
            }
        }
}