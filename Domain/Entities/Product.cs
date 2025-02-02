namespace eShopping.API.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    
    public ICollection<Order> Orders { get; set; } // This is for One-to-Many relationship with Orders
}