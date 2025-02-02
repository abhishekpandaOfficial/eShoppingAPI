using eShopping.API.Domain.ValueObjects;

namespace eShopping.API.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Money Price { get; set; }
    
    public ICollection<Order> Orders { get; set; } // This is for One-to-Many relationship with Orders
    public Product()
    {
        // Initialize with a default Money object if needed
        Price = new Money(0m, "INR");
    }
}