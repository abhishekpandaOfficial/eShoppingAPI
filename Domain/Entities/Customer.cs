namespace eShopping.API.Domain.Entities;

public class Customer
{
    // Primary key for the Customer entity
    public Guid Id { get; set; }

    // Name of the customer
    public string Name { get; set; }

    // Email address of the customer (unique identifier for login, etc.)
    public string Email { get; set; }

    // Phone number of the customer (optional)
    public string PhoneNumber { get; set; }

    // Collection of Orders placed by the customer
    public ICollection<Order> Orders { get; set; } // One-to-many relationship with Order
}