namespace eShopping.API.Domain.Entities;

public class Order
{
    // Primary key for the Order entity
    public Guid Id { get; set; } 
    // The date and time when the order was placed
    public DateTime OrderDate { get; set; } 
    // Foreign key to the Product entity
    public Guid ProductId { get; set; } 
    // Foreign key to the Customer entity (indicating which customer placed the order)
    public Guid CustomerId { get; set; }
    // The quantity of the product being ordered
    public int Quantity { get; set; } 
    // The total price for this order (calculated from Quantity and Price)
    public decimal TotalAmount { get; set; }
    // Navigation property to the Product entity (One-to-Many relationship with Product)
    public Product Product { get; set; }
    
    // Navigation property to the Customer entity (One-to-Many relationship with Customer)
    public Customer Customer { get; set; }
}